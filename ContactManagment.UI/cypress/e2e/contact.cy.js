describe('Contact Management E2E Test', () => {
  beforeEach(() => {
    cy.intercept('POST', '/api/Contact', {
      statusCode: 201,
      body: {
        id: 1,
        firstName: 'John',
        surName: 'Doe',
        dateOfBirth: '1990-01-01',
        address: '123 Main St',
        phoneNumber: '1234567890',
        iban: 'DE89370400440532013000'
      }
    }).as('saveContact');

    cy.visit('http://localhost:52128/');
  });

  it('should add a new contact and display it in the table', () => {
    cy.get('[data-testid="add-contact-button"]').click();

    cy.get('#firstName').type('John');
    cy.get('#surName').type('Doe');
    cy.get('#dateOfBirth').type('1990-01-01');
    cy.get('#address').type('123 Main St');
    cy.get('#phoneNumber').type('1234567890');
    cy.get('#iban').type('DE89370400440532013000');

    cy.get('[data-testid="save-contact-button"]').click();

    cy.get('p-table').should('contain', 'John');
    cy.get('p-table').should('contain', 'Doe');
    cy.get('p-table').should('contain', '1990-01-01');
    cy.get('p-table').should('contain', '123 Main St');
    cy.get('p-table').should('contain', '1234567890');
    cy.get('p-table').should('contain', 'DE89370400440532013000');
  });
});
