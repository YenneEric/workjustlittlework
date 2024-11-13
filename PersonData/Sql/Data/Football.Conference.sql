DECLARE @ConferenceStaging TABLE
(
   ConfName NVARCHAR(255) NOT NULL UNIQUE
);

INSERT @ConferenceStaging(ConfName)
VALUES
   ('SEC'),
   ('Big Ten'),
   ('Big-12'),
   ('ACC');

MERGE Football.Conference T
USING @ConferenceStaging S ON S.ConfName = T.ConfName
WHEN NOT MATCHED THEN
   INSERT(ConfName)
   VALUES(S.ConfName);
