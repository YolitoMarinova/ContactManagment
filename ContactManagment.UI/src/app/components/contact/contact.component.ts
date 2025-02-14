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
  selectedContacts: Contact[] = [];

  contactDialog = false;
  newContact: Partial<Contact> = {};
  isEdit = false;
  isSubmitted = false;

  constructor(private store: Store<AppState>) { }

  ngOnInit() {
    console.log("HEREEEEEEEEEE0");
    this.store.dispatch(ContactActions.loadContacts());
    this.columns = [
      { field: 'firstName', header: 'First Name' },
      { field: 'surName', header: 'Sur Name' },
      { field: 'dateOfBirth', header: 'Date of Birth' },
      { field: 'address', header: 'Address' },
      { field: 'phoneNumber', header: 'Phone Number' },
      { field: 'iban', header: 'IBAN' }
    ];
    //this.contacts$.subscribe(contacts => {
    //  this.contactsLength = contacts.length;
    //});
    console.log(this.contacts$);
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
    if (this.isEdit) {
      this.store.dispatch(ContactActions.updateContact({ contact: this.newContact }));
    } else {
      this.store.dispatch(ContactActions.addContact({ contact: this.newContact as Contact }));
    }
    this.contactDialog = false;
    this.isSubmitted = true;
  }

  deleteContact(id: string) {
    this.store.dispatch(ContactActions.deleteContact({ id }));
  }

  deleteContacts() {
    this.selectedContacts.forEach(contact => {
      this.store.dispatch(ContactActions.deleteContact({ id: contact.id }));
    });
    this.selectedContacts = [];
  }

  hideDialog() {
    this.contactDialog = false;
    this.isSubmitted = false;
  }
}
