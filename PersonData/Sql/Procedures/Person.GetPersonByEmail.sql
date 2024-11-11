CREATE OR ALTER PROCEDURE Person.GetPersonByEmail
   @Email NVARCHAR(128)
AS

SELECT P.PersonId, P.FirstName, P.LastName, P.Email
FROM Person.Person P
WHERE P.Email = @Email;
GO
