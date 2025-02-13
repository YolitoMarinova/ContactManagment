import { Component } from '@angular/core';
import { Contact } from './models/contact.model';
import { Observable } from 'rxjs/internal/Observable';
import { AppState } from './store/app.state';
import { Store } from '@ngrx/store';
import * as ContactActions from './store/contact/contact.actions';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ContactManagment.UI';

  contacts$: Observable<Contact[]>;

  constructor(private store: Store<AppState>) {
    this.contacts$ = store.select(state => state.contacts.contacts);
  }

  loadContacts() {
    this.store.dispatch(ContactActions.loadContacts());
  }

  addContact() {
    const newContact: Contact = {
      id: crypto.randomUUID(), // Generate a random ID for testing
      firstName: 'John',
      surName: 'Doe',
      dateOfBirth: '1990-01-01',
      address: '123 Street',
      phoneNumber: '1234567890',
      iban: 'IBAN12345'
    };
    this.store.dispatch(ContactActions.addContact({ contact: newContact }));
  }

  deleteContact(id: string) {
    this.store.dispatch(ContactActions.deleteContact({ id }));
  }
}
