import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Contact } from '../../models/contact.model';
import * as ContactActions from '../../store/contact/contact.actions';
import { AppState } from '../../store/app.state';

interface Column {
  field: string;
  header: string;
}

@Component({
  standalone: false,
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
  contacts$: Observable<Contact[]> = this.store.select(state => state.contacts.contacts);
  loading$: Observable<boolean> = this.store.select(state => state.contacts.loading);

  contactsLength: number = 0;
  columns!: Column[];

  contactDialog = false;
  newContact: Partial<Contact> = {};
  isEdit = false;
  isSubmitted = false;

  constructor(private store: Store<AppState>) { }

  ngOnInit() {
    this.store.dispatch(ContactActions.loadContacts());
    this.columns = [
      { field: 'firstName', header: 'First Name' },
      { field: 'surName', header: 'Sur Name' },
      { field: 'dateOfBirth', header: 'Date of Birth' },
      { field: 'address', header: 'Address' },
      { field: 'phoneNumber', header: 'Phone Number' },
      { field: 'iban', header: 'IBAN' }
    ];
    this.contacts$.subscribe(contacts => {
      this.contactsLength = contacts.length;
    });
  }

  openNew() {
    this.newContact = {};
    this.contactDialog = true;
    this.isEdit = false;
    this.isSubmitted = false;
  }

  editContact(contact: Contact) {
    this.newContact = { ...contact };
    this.contactDialog = true;
    this.isEdit = true;
    this.isSubmitted = false;
  }

  saveContact() {
    const contactToSave = { ...this.newContact };
    if (contactToSave.dateOfBirth) {
      const date = new Date(contactToSave.dateOfBirth);
      contactToSave.dateOfBirth = `${date.getFullYear()}-${(date.getMonth() + 1).toString().padStart(2, '0')}-${date.getDate().toString().padStart(2, '0')}`;
    }
    if (this.isEdit) {
      this.store.dispatch(ContactActions.updateContact({ contact: contactToSave }));
    } else {
      this.store.dispatch(ContactActions.addContact({ contact: contactToSave as Contact }));
    }
    this.contactDialog = false;
    this.isSubmitted = true;
  }

  deleteContact(contact: Contact) {
    this.store.dispatch(ContactActions.deleteContact({ id: contact.id }));
  }

  hideDialog() {
    this.contactDialog = false;
    this.isSubmitted = false;
  }
}
