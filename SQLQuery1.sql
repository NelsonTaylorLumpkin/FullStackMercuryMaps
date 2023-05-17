-- Inserting data into [users] table
INSERT INTO [users] ([id], [firebaseId], [isStaff], [email]) 
VALUES 
(1, 'HAThqBNaPPXYsmwMqRPBHhmLxPz2', 1, 'ossocasa@gmail.com'),
(2, 'firebaseId2', 1, 'staff2@company.com'),
(3, 'kSBSRpE2HFdvVYPgZIRxBhaYixR2', 0, 'gmail@gmail.com'),
(4, 'firebaseId4', 0, 'client2@company.com');

-- Inserting data into [services] table
INSERT INTO [services] ([id], [name]) 
VALUES 
(1, 'Service1'),
(2, 'Service2');

-- Inserting data into [employee] table
INSERT INTO [employee] ([id], [userId])
VALUES 
(1, 1),
(2, 2);

-- Inserting data into [clients] table
INSERT INTO [clients] ([id], [userId], [name], [phone], [hasBC], [newClient], [birthday])
VALUES 
(1, 3, 'John Doe', 1234567890, 1, 0, '1985-06-15'),
(2, 4, 'Jane Doe', 9876543210, 0, 1, '1990-07-20');

-- Inserting data into [appointment] table
INSERT INTO [appointment] ([id], [clientId], [formsId], [serviceId], [preferences], [questions], [familiarity], [time], [isCompleted])
VALUES 
(1, 1, 1, 1, 'Preference1', 'Question1', 'Familiarity1', 1000, 1),
(2, 2, 2, 2, 'Preference2', 'Question2', 'Familiarity2', 2000, 0);
