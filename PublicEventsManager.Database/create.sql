CREATE DATABASE PublicEventsManager
GO

USE PublicEventsManager
GO

CREATE TABLE Manager
(
	Id INT NOT NULL IDENTITY(1, 1),
	FirstName NVARCHAR(32) NOT NULL,
	LastName NVARCHAR(32) NOT NULL,
	[Login] VARCHAR(32) NOT NULL,
	[Password] VARCHAR(32) NOT NULL,
	IsDisabled BIT NOT NULL,
	CONSTRAINT PK_Manager_Id PRIMARY KEY (Id),
	CONSTRAINT UQ_Manager_Login UNIQUE ([Login])
)
GO

CREATE TABLE EventType
(
	Id INT NOT NULL IDENTITY(1, 1),
	Name NVARCHAR(64) NOT NULL,
	CONSTRAINT PK_EventType_Id PRIMARY KEY (Id)
)


CREATE TABLE EventDate
(
	Id INT NOT NULL IDENTITY(1, 1),
	EventStart DATETIME NOT NULL,
	EventEnd DATETIME NOT NULL,
	SaleStart DATETIME NOT NULL,
	SaleEnd DATETIME NOT NULL,
	CONSTRAINT PK_EventDate_Id PRIMARY KEY (Id),
	CONSTRAINT CK_EventDate_EventStartLessThanEventEnd CHECK (EventStart < EventEnd),
	CONSTRAINT CK_EventDate_SaleStartLessThanSaleEnd CHECK (SaleStart < SaleEnd),
	CONSTRAINT CK_EventDate_SaleEndLessThanEventStart CHECK (SaleEnd < EventStart)
)
GO

CREATE TABLE PublicEvent
(
	Id INT NOT NULL IDENTITY(1, 1),
	ManagerId INT,
	EventTypeId INT,
	EventDateId INT,
	Name NVARCHAR(32) NOT NULL,
	Location NVARCHAR(64) NOT NULL,
	Description NTEXT NOT NULL,
	TicketsAmount INT NOT NULL,
	AvailableTicketsAmount INT NOT NULL,
	CONSTRAINT PK_PublicEvent_Id PRIMARY KEY (Id),
	CONSTRAINT FK_PublicEvent_ManagerId_Manager_Id FOREIGN KEY(ManagerId) REFERENCES Manager(Id),
	CONSTRAINT FK_PublicEvent_EventTypeId_EventType_Id FOREIGN KEY(EventTypeId) REFERENCES EventType(Id),
	CONSTRAINT FK_PublicEvent_EventDateId_EventDate_Id FOREIGN KEY(EventDateId) REFERENCES EventDate(Id),
	CONSTRAINT CK_PublicEvent_AvailableTicketsAmountLessThanTicketsAmount CHECK (AvailableTicketsAmount <= TicketsAmount)
)
GO

CREATE TABLE Ticket
(
	Id INT NOT NULL IDENTITY(1, 1),
	PublicEventId INT NOT NULL,
	OwnerName NVARCHAR(64),
	Price DECIMAL(19, 4) NOT NULL,
	CONSTRAINT PK_Ticket_Id PRIMARY KEY (Id),
	CONSTRAINT FK_Ticket_PublicEventId_PublicEvent_Id FOREIGN KEY(PublicEventId) REFERENCES PublicEvent(Id)
)
