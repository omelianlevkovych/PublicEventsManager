USE PublicEventsManager
GO

DROP TABLE Ticket
GO
DROP TABLE PublicEvent
GO
DROP TABLE EventDate
GO
DROP TABLE EventType
GO
DROP TABLE Manager
GO
DROP PROCEDURE spGetManagerByLogin
GO
DROP PROCEDURE spGetAllPublicEvents
GO
DROP PROCEDURE spGetAllPublicEventsByTypeName
GO
DROP PROCEDURE spGetPublicEventById
GO
DROP PROCEDURE spInsertPublicEvent
GO
DROP PROCEDURE spUpdatePublicEvent
GO
DROP PROCEDURE spReserveTicketById
GO
DROP PROCEDURE spGetTicketsByOwnerName
GO
DROP PROCEDURE spCreateTicketForPublicEvent
GO
DROP PROCEDURE spChangePriceForTickets
GO
DROP PROCEDURE spUpdateEventType
GO
DROP PROCEDURE spCreateEventDate
GO
DROP PROCEDURE spUpdateEventDate

