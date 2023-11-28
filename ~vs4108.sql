CREATE TABLE Events (
    eventID INT PRIMARY KEY IDENTITY(1,1),
    eventName VARCHAR(255) NOT NULL,
    date DATE,
    location VARCHAR(100),
    theme VARCHAR(50)
);

CREATE TABLE Sessions (
    sessionID INT PRIMARY KEY IDENTITY(1,1),
    sessionName VARCHAR(255) NOT NULL,
    time DATETIME,
    speaker VARCHAR(100),
    description TEXT,
    eventID INT,
    FOREIGN KEY (eventID) REFERENCES Events(eventID)
);

CREATE TABLE Attendees (
    attendeeID INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(100) NOT NULL,
    contactInfo VARCHAR(255),
    groupDetails TEXT,
    eventID INT,
    FOREIGN KEY (eventID) REFERENCES Events(eventID)
);

CREATE TABLE DiscountCodes (
    code VARCHAR(50) PRIMARY KEY,
    discountPercentage DECIMAL(5, 2) NOT NULL,
    expirationDate DATE,
    eventID INT,
    FOREIGN KEY (eventID) REFERENCES Events(eventID)
);

CREATE TABLE Reviews (
    reviewID INT PRIMARY KEY IDENTITY(1,1),
    eventID INT,
    sessionID INT,
    productID INT,
    reviewerName VARCHAR(100) NOT NULL,
    rating INT NOT NULL,
    reviewText TEXT,
    reviewDate DATE,
    FOREIGN KEY (eventID) REFERENCES Events(eventID),
    FOREIGN KEY (sessionID) REFERENCES Sessions(sessionID),
);

CREATE TABLE Users (
    userID INT PRIMARY KEY IDENTITY(1,1),
    username VARCHAR(50) NOT NULL,
    passwordHash VARCHAR(255) NOT NULL,
    email VARCHAR(100) NOT NULL,
    fullName VARCHAR(100),
    registrationDate DATETIME DEFAULT GETDATE()
);

