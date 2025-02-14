import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Contact } from '../../models/contact.model';
import * as ContactActions from '../../store/contact/contact.actions';

@Component({
  standalone: false,
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
  contacts$: Observable<Contact[]> = this.store.select(state => state.contacts.contacts);  // No selector
  loading$: Observable<boolean> = this.store.select(state => state.contacts.loading);  // No selector

  contactDialog = false;
  newContact: Partial<Contact> = {};
  isEdit = false;

  constructor(private store: Store<any>) { }  // Use `any` temporarily

  ngOnInit() {
    this.store.dispatch(ContactActions.loadContacts());
  }

  openNew() {
    this.newContact = {};
    this.contactDialog = true;
    this.isEdit = false;
  }

  editContact(contact: Contact) {
    this.newContact = { ...contact };
    this.contactDialog = true;
    this.isEdit = true;
  }

  saveContact() {
    if (this.isEdit) {
      this.store.dispatch(ContactActions.updateContact({ contact: this.newContact }));
    } else {
      this.store.dispatch(ContactActions.addContact({ contact: this.newContact as Contact }));
    }
    this.contactDialog = false;
  }

  deleteContact(id: string) {
    this.store.dispatch(ContactActions.deleteContact({ id }));
  }
}
