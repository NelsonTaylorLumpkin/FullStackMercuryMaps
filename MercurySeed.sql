CREATE TABLE [users] (
  [id] INT PRIMARY KEY,
  [firebaseId] NVARCHAR(MAX),
  [isStaff] BIT,
  [email] NVARCHAR(255)
)
GO

CREATE TABLE [services] (
  [id] INT PRIMARY KEY,
  [name] NVARCHAR(255)
)
GO

CREATE TABLE [employee] (
  [id] INT PRIMARY KEY,
  [userId] INT FOREIGN KEY REFERENCES [users]([id])
)
GO

CREATE TABLE [clients] (
  [id] INT PRIMARY KEY,
  [userId] INT FOREIGN KEY REFERENCES [users]([id]),
  [name] NVARCHAR(255),
  [phone] INT,
  [hasBC] BIT,
  [newClient] BIT,
  [birthday] DATE
)
GO

CREATE TABLE [appointment] (
  [id] INT PRIMARY KEY,
  [clientId] INT FOREIGN KEY REFERENCES [clients]([id]),
  [formsId] INT,
  [serviceId] INT FOREIGN KEY REFERENCES [services]([id]),
  [preferences] NVARCHAR(MAX),
  [questions] NVARCHAR(MAX),
  [familiarity] NVARCHAR(MAX),
  [time] INT,
  [isCompleted] BIT
)
GO
