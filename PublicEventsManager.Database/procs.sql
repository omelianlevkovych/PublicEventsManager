USE PublicEventsManager
GO

--this procedure gets manager based on the login and password values that is passed
CREATE PROCEDURE spGetManagerByLogin
@Login VARCHAR(32),
@Password VARCHAR(32)
AS 
BEGIN
	SELECT
		Id,
		FirstName,
		LastName,
		[Login],
		[Password],
		[IsDisabled]
	FROM Manager
	WHERE [Login] = @Login and [Password] = @Password and [IsDisabled] != 1;
END;
GO

--this procedure gets all public events
CREATE PROCEDURE spGetAllPublicEvents
AS
BEGIN
	SELECT
		PEvent.Id,
		PEvent.Name, 
		PEvent.Location, 
		PEvent.Description, 
		PEvent.TicketsAmount,
		PEvent.AvailableTicketsAmount,
		ETicket.Price,
		EDate.Id AS DateId,
		EType.Id AS TypeId,
		EManager.id AS ManagerId 	
	FROM PublicEvent AS PEvent
	JOIN EventType AS EType
	ON PEvent.EventTypeId = EType.Id
	JOIN EventDate AS EDate
	ON PEvent.EventDateId = EDate.Id
	JOIN Ticket AS ETicket
	ON ETicket.PublicEventId = PEvent.Id
	JOIN Manager AS EManager
	ON PEvent.ManagerId = EManager.Id
	ORDER BY EDate.EventStart;
END;
GO

/*
this procedure gets all public events based on public event type name that is passed
also this procedure returns its values ordered by type name value
*/
CREATE PROCEDURE spGetAllPublicEventsByTypeName
@TypeName VARCHAR(64)
AS
BEGIN
	SELECT 
		PEvent.Id,
		PEvent.Name, 
		PEvent.Location, 
		PEvent.Description, 
		PEvent.TicketsAmount,
		PEvent.AvailableTicketsAmount,
		EType.Name,
		EDate.EventStart,
		EDate.EventEnd,
		EDate.SaleStart,
		EDate.SaleEnd 	
	FROM PublicEvent AS PEvent
	JOIN EventType AS EType
	ON PEvent.EventTypeId = EType.Id
	JOIN EventDate AS EDate
	ON PEvent.EventDateId = EDate.Id
	WHERE EType.Name = @TypeName
	ORDER BY EType.Name;
END;
GO

--this procedure gets information about public event based on its id value
CREATE PROCEDURE spGetPublicEventById
@Id INT
AS 
BEGIN
	SELECT
		PEvent.Id,
		PEvent.Name, 
		PEvent.Location, 
		PEvent.Description, 
		PEvent.TicketsAmount,
		PEvent.AvailableTicketsAmount,
		EType.Name,
		EDate.EventStart,
		EDate.EventEnd,
		EDate.SaleStart,
		EDate.SaleEnd 	
	FROM PublicEvent AS PEvent
	JOIN EventType AS EType
	ON PEvent.EventTypeId = EType.Id
	JOIN EventDate AS EDate
	ON PEvent.EventDateId = EDate.Id
	WHERE PEvent.Id = @Id;
END;
GO

--this procedure creates new public event
CREATE PROCEDURE spInsertPublicEvent
@Id INT,
@ManagerId INT,
@EventTypeId INT,
@EventDateId INT,
@Name NVARCHAR(32),
@Location NVARCHAR(64),
@Description NTEXT,
@TicketsAmount INT,
@AvailableTicketsAmount INT
AS
BEGIN TRAN
	BEGIN TRY
	INSERT INTO PublicEvent
	(
	 Id,
	 ManagerId,
	 EventTypeId,
	 EventDateId,
	 Name,
	 Location,
	 Description,
	 TicketsAmount,
	 AvailableTicketsAmount
	 )
	 VALUES
	 (
	  @Id,
	  @ManagerId,
	  @EventTypeId,
	  @EventDateId,
	  @Name,
	  @Location,
	  @Description,
	  @TicketsAmount,
	  @AvailableTicketsAmount
	 )
	 COMMIT TRAN
	 END TRY
	 BEGIN CATCH
		ROLLBACK TRAN
	END CATCH
GO

--this procedure updates public event state as transaction
CREATE PROCEDURE spUpdatePublicEvent
@Id INT,
@ManagerId INT,
@EventTypeId INT,
@EventDateId INT,
@Name NVARCHAR(32),
@Location NVARCHAR(64),
@Description NTEXT,
@TicketsAmount INT,
@AvailableTicketsAmount INT
AS
BEGIN TRAN
	BEGIN TRY
		UPDATE PublicEvent
		SET
		ManagerId = @ManagerId,
		EventTypeId = @EventTypeId,
		EventDateId = @EventDateId,
		Name = @Name,
		Location = @Location,
		Description = @Description,
		TicketsAmount = @TicketsAmount,
		AvailableTicketsAmount = @AvailableTicketsAmount
		WHERE Id = @Id;
	COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN 
	END CATCH
GO

--this procedure reserves ticket based on id value that is passed
CREATE PROCEDURE spReserveTicketById
@Id INT,
@OwnerName NVARCHAR(64)
AS
BEGIN TRAN
	BEGIN TRY
		UPDATE Ticket
		SET
		OwnerName = @OwnerName
		WHERE
		Id = @Id

		UPDATE PublicEvent
		SET
		AvailableTicketsAmount = AvailableTicketsAmount - 1
		FROM PublicEvent
		JOIN Ticket 
		ON PublicEvent.Id = Ticket.PublicEventId
		WHERE Ticket.Id = @Id
	COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH
GO

--this procedure gets tickets based on owner name value that is passed
CREATE PROCEDURE spGetTicketsByOwnerName
@OwnerName NVARCHAR(64)
AS
BEGIN TRAN
	BEGIN TRY
		SELECT
			Ticket.Id,
			Ticket.OwnerName,
			Ticket.Price,
			Ticket.PublicEventId
		FROM Ticket
		WHERE Ticket.OwnerName = @OwnerName
	COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH
GO

--this procedure adds new ticket for existing public event
CREATE PROCEDURE spCreateTicketForPublicEvent
@PublicEventId INT,
@OwnerName NVARCHAR(64),
@Price DECIMAL(19, 4)
AS
BEGIN TRAN
	BEGIN TRY
		DECLARE @IsAvailableAmount INT;
		SELECT @IsAvailableAmount = (PublicEvent.TicketsAmount - PublicEvent.AvailableTicketsAmount) 
		FROM PublicEvent
		WHERE PublicEvent.Id = @PublicEventId
		IF @IsAvailableAmount > 0
		BEGIN
			INSERT INTO Ticket(OwnerName, Price ,PublicEventId)
			VALUES
			(
			@OwnerName,
			@Price,
			@PublicEventId
			)
		END
	COMMIT TRAN
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH

GO

--this procedure changes price for all tickets based on public event id that is passed
CREATE PROCEDURE spChangePriceForTickets
@PublicEventId INT,
@Price DECIMAL(19, 4)
AS
BEGIN TRAN
	BEGIN TRY
		UPDATE Ticket
		SET
		Price = @Price
		WHERE Ticket.PublicEventId = @PublicEventId
	COMMIT TRAN
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH
GO

--this procedure creates new public event type
CREATE PROCEDURE spCreateEventType
@Name NVARCHAR(64)
AS
BEGIN TRAN
	BEGIN TRY
		INSERT INTO EventType(Name)
		VALUES (@Name)
		COMMIT TRAN
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH
GO

--this procedure updates public event type
CREATE PROCEDURE spUpdateEventType
@EventTypeId INT,
@Name NVARCHAR(64)
AS
BEGIN TRAN
	BEGIN TRY
		UPDATE EventType
		SET
		Name = @EventTypeId
		WHERE Id = @EventTypeId;
		COMMIT TRAN
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH
GO

--this procedure creates new public event date
CREATE PROCEDURE spCreateEventDate
@EventStart DATETIME,
@EventEnd DATETIME,
@SaleStart DATETIME,
@SaleEnd DATETIME
AS
BEGIN TRAN
	BEGIN TRY
		INSERT INTO EventDate(EventStart, EventEnd, SaleStart, SaleEnd)
		VALUES
		(
		@EventStart,
		@EventEnd,
		@SaleStart,
		@SaleEnd
		)
		COMMIT TRAN
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH
GO

--this procedure updates public event date
CREATE PROCEDURE spUpdateEventDate
@EventDateId INT,
@EventStart DATETIME,
@EventEnd DATETIME,
@SaleStart DATETIME,
@SaleEnd DATETIME
AS
BEGIN TRAN
	BEGIN TRY
		UPDATE EventDate
		SET
		EventStart = @EventStart,
		EventEnd = @EventEnd,
		SaleStart = @SaleStart,
		SaleEnd = @SaleEnd
		WHERE Id = @EventDateId;
		COMMIT TRAN
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH
GO

