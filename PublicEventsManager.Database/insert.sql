USE PublicEventsManager
GO

SET IDENTITY_INSERT Manager ON
INSERT INTO Manager(Id, FirstName, LastName, [Login], [Password], IsDisabled)
	VALUES
	(1, 'Omelian', 'Levkovych', 'Omelian', '5D41402ABC4B2A76B9719D911017C592', 0)
SET IDENTITY_INSERT Manager OFF
GO

SET IDENTITY_INSERT EventDate ON
INSERT INTO EventDate(Id, EventStart, EventEnd, SaleStart, SaleEnd)
	VALUES
	(1, '2016-10-10 00:00:00.000', '2016-10-20 00:00:00.000', '2016-09-10 12:00:00.000', '2016-09-15 00:00:00.000'),
	(2, '2016-10-16 00:00:00:000', '2016-11-01 00:00:00.000', '2016-10-15 00:00:00.000', '2016-10-15 23:00:00.000')
SET IDENTITY_INSERT EventDate OFF
GO

SET IDENTITY_INSERT EventType ON
INSERT INTO EventType(Id, Name)
	VALUES
	(1, 'Conference'),
	(2, 'Seminar'),
	(3, 'Meeting'),
	(4, 'Team Building Event'),
	(5, 'Trade Show'),
	(6, 'Business Dinner'),
	(7, 'Golf Event'),
	(8, 'Networking Event'),
	(9, 'Incentive Travel'),
	(10, 'Opening Ceremony'),
	(11, 'VIP Event'),
	(12, 'Trade Fair'),
	(13, 'Award Ceremony')
SET IDENTITY_INSERT EventType OFF
GO

SET IDENTITY_INSERT PublicEvent ON
INSERT INTO PublicEvent(Id, ManagerId, EventTypeId, EventDateId, Name, Location, Description, TicketsAmount, AvailableTicketsAmount)
	VALUES
	(1, 1, 4, 1, 'Epam It Lab Free Day', 'Ukraine, Lviv', 'Description for this event will come soon', 4, 4),
	(2, 1, 13, 2, 'Epam It lab Cleanest Code', 'USA, New York', 'Folk just wanna rest for a while', 1, 1) 
SET IDENTITY_INSERT PublicEvent OFF
GO

SET IDENTITY_INSERT Ticket ON
INSERT INTO Ticket(Id, PublicEventId, OwnerName, Price)
	VALUES
	(1, 1, 'Omelian Levkovych', 200.00),
	(2, 1, NULL, 200.00),
	(3, 1, NULL, 200.00),
	(4, 1, NULL, 200.00),
	(5, 2, NULL, 0.00)
SET IDENTITY_INSERT Ticket OFF