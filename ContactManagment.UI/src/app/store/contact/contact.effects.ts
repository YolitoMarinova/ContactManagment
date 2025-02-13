import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { ContactService } from '../../services/contact.service';
import * as ContactActions from './contact.actions';
import { catchError, map, mergeMap, of, switchMap } from 'rxjs';

@Injectable()
export class ContactEffects {
  constructor(private actions$: Actions, private contactService: ContactService) { }

  // Load Contacts Effect
  loadContacts$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ContactActions.loadContacts),
      mergeMap(() =>
        this.contactService.getAll().pipe(
          map(contacts => ContactActions.loadContactsSuccess({ contacts })),
          catchError(error => of(ContactActions.loadContactsFailure({ error: error.message })))
        )
      )
    )
  );

  // Load Single Contact Effect
  loadSingleContact$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ContactActions.loadSingleContact),
      mergeMap(action =>
        this.contactService.getById(action.id).pipe(
          map(contact => ContactActions.loadSingleContactSuccess({ contact })),
          catchError(error => of(ContactActions.loadSingleContactFailure({ error: error.message })))
        )
      )
    )
  );

  // Add Contact Effect
  addContact$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ContactActions.addContact),
      switchMap(action =>
        this.contactService.create(action.contact).pipe(
          map(contact => ContactActions.addContactSuccess({ contact })),
          catchError(error => of(ContactActions.addContactFailure({ error: error.message })))
        )
      )
    )
  );

  // Update Contact Effect
  updateContact$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ContactActions.updateContact),
      switchMap(action =>
        this.contactService.update(action.contact).pipe(
          map(() => ContactActions.updateContactSuccess({ contact: action.contact })),
          catchError(error => of(ContactActions.updateContactFailure({ error: error.message })))
        )
      )
    )
  );

  // Delete Contact Effect
  deleteContact$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ContactActions.deleteContact),
      switchMap(action =>
        this.contactService.delete(action.id).pipe(
          map(() => ContactActions.deleteContactSuccess({ id: action.id })),
          catchError(error => of(ContactActions.deleteContactFailure({ error: error.message })))
        )
      )
    )
  );
}
