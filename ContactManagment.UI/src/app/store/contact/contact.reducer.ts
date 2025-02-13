import { createReducer, on } from '@ngrx/store';
import * as ContactActions from './contact.actions';
import { Contact } from '../../models/contact.model';

export interface ContactState {
  contacts: Contact[];
  selectedContact: Contact | null;
  loading: boolean;
  error: string | null;
}

const initialState: ContactState = {
  contacts: [],
  selectedContact: null,
  loading: false,
  error: null
};

export const contactReducer = createReducer(
  initialState,

  // Load Contacts
  on(ContactActions.loadContacts, state => ({
    ...state,
    loading: true,
    error: null
  })),
  on(ContactActions.loadContactsSuccess, (state, { contacts }) => ({
    ...state,
    contacts,
    loading: false
  })),
  on(ContactActions.loadContactsFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error
  })),

  // Load Single Contact
  on(ContactActions.loadSingleContact, state => ({
    ...state,
    loading: true,
    error: null
  })),
  on(ContactActions.loadSingleContactSuccess, (state, { contact }) => ({
    ...state,
    selectedContact: contact,
    loading: false
  })),
  on(ContactActions.loadSingleContactFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error
  })),

  // Add Contact
  on(ContactActions.addContact, state => ({
    ...state,
    loading: true,
    error: null
  })),
  on(ContactActions.addContactSuccess, (state, { contact }) => ({
    ...state,
    contacts: [...state.contacts, contact],
    loading: false
  })),
  on(ContactActions.addContactFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error
  })),

  // Update Contact
  on(ContactActions.updateContact, state => ({
    ...state,
    loading: true,
    error: null
  })),
  on(ContactActions.updateContactSuccess, (state, { contact }) => ({
    ...state,
    contacts: state.contacts.map(c => c.id === contact.id ? {...c, ...contact } : c ),
    loading: false
  })),
  on(ContactActions.updateContactFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error
  })),

  // Delete Contact
  on(ContactActions.deleteContact, state => ({
    ...state,
    loading: true,
    error: null
  })),
  on(ContactActions.deleteContactSuccess, (state, { id }) => ({
    ...state,
    contacts: state.contacts.filter(c => c.id !== id),
    loading: false
  })),
  on(ContactActions.deleteContactFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error
  }))
);
