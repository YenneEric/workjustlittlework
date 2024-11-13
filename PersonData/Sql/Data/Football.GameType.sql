DECLARE @TeamTypeStaging TABLE
(
   [Name] NVARCHAR(50) NOT NULL UNIQUE
);

INSERT INTO @TeamTypeStaging ([Name])
VALUES
   ('Home'),
   ('Away');

MERGE Football.TeamType T
USING @TeamTypeStaging S
ON T.[Name] = S.[Name]
WHEN NOT MATCHED THEN
   INSERT ([Name])
   VALUES (S.[Name]);
