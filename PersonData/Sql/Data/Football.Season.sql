DECLARE @SeasonStaging TABLE
(
   [Year] INT NOT NULL UNIQUE
);

-- Insert data into the staging table
INSERT @SeasonStaging([Year])
VALUES
   (2019),
   (2020),
   (2021),
   (2022),
   (2023),
   (2024);

-- Merge data into the Football.Season table
MERGE Football.Season T
USING @SeasonStaging S ON S.[Year] = T.[Year]
WHEN NOT MATCHED THEN
   INSERT([Year])
   VALUES(S.[Year]);
