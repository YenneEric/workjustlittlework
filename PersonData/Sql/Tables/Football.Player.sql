IF OBJECT_ID(N'Football.Player') IS NULL
BEGIN
   CREATE TABLE Football.Player
   (
      PlayerId INT NOT NULL IDENTITY(1, 1),
      PlayerName NVARCHAR(255) NOT NULL,
      Position NVARCHAR(50) NOT NULL,

      CONSTRAINT [PK_Football_Player_PlayerId] PRIMARY KEY CLUSTERED
      (
         PlayerId ASC
      )
   );
END;
