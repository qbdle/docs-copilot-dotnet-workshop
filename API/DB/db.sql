-- SQL file for a demo use case

-- Create a database
CREATE DATABASE DemoDB;

-- Use the created database
USE DemoDB;

-- Create a table for users
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    UserName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Create a table for tasks
CREATE TABLE Tasks (
    TaskID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    TaskName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    IsCompleted BIT DEFAULT 0,
    DueDate DATETIME,
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Insert demo data into Users table
INSERT INTO Users (UserName, Email) VALUES
('John Doe', 'john.doe@example.com'),
('Jane Smith', 'jane.smith@example.com');

-- Insert demo data into Tasks table
INSERT INTO Tasks (UserID, TaskName, Description, IsCompleted, DueDate) VALUES
(1, 'Task 1', 'Description for Task 1', 0, '2023-12-31'),
(1, 'Task 2', 'Description for Task 2', 1, '2023-11-30'),
(2, 'Task 3', 'Description for Task 3', 0, '2023-10-15');
