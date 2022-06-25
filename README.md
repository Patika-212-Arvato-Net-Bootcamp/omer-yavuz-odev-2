# Basic Bootcamp WebApi Project
---
## Admin

- GET api/admin          : Shows the list of candidates applying to registered bootcamps.

- POST api/admin         : Creates a new bootcamp.

- GET api/admin/{id}     : Shows the available bootcamps by bootcamp id number.

- PATCH api/admin/{id}   : Approves the candidates who have applied for bootcamp by setting the status to 'true' by participant id number.

- PUT api/admin/{id}     : Modifies existing bootcamp information by bootcamp id number.

- DELETE api/admin/{id}  : Deletes an existing bootcamp by bootcamp id number.
---
## Bootcamp

- GET api/bootcamp          : Shows the list of available bootcamps.

- POST api/bootcamp         : Creates a new bootcamp application.

- GET api/bootcamp/{id}     : Shows an existing application with the participant id number.

- PUT api/bootcamp/{id}     : Modifies existing participant information by participant id number.

- DELETE api/bootcamp/{id}  : Deletes an existing participant by participant id number.
