CREATE OR ALTER PROCEDURE Person.GetAddressName
AS
BEGIN
    SELECT ADT.[Name]
    FROM Person.AddressType ADT;
END;
