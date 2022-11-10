# DROP DATABASE Inventory;

# CREATE DATABASE Inventory DEFAULT CHARSET utf8;
# USE Inventory;

CREATE TABLE `Role`(
    `IdRole` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Name` NVARCHAR(50) NOT NULL UNIQUE CHECK (`Name` REGEXP '^[a-zA-Z а-яА-ЯёЁ]+$')
);

CREATE TABLE `DocumentPosition`(
    `IdDocumentPosition` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Name` NVARCHAR(250) NOT NULL CHECK (`Name` REGEXP '^[а-яА-Я ёЁ]+$')
);

CREATE TABLE `Employee`(
    `IdEmployee` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `LastName` NVARCHAR(100) NOT NULL CHECK (`LastName` REGEXP '^[а-яА-Я ёЁ]+$'),
    `FirstName` NVARCHAR(100) NOT NULL CHECK (`FirstName` REGEXP '^[а-яА-Я ёЁ]+$'),
    `Patronymic` NVARCHAR(100) NOT NULL CHECK (`Patronymic` REGEXP '^[а-яА-Я ёЁ]+$'),
    `DocumentPositionId` INT NOT NULL,

    FOREIGN KEY (`DocumentPositionId`) REFERENCES `DocumentPosition` (`IdDocumentPosition`)
);

CREATE TABLE `User`(
    `IdUser` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Login` NVARCHAR(100) NOT NULL UNIQUE,
    `Password` VARCHAR(100) NOT NULL, # PROGRAM CHECKERS
    `RoleId` INT NOT NULL,
    `EmployeeId` INT NOT NULL,

    CONSTRAINT UQ_USER_LOGIN UNIQUE (`Login`),

    FOREIGN KEY (`RoleId`) REFERENCES `Role` (`IdRole`),
    FOREIGN KEY (`EmployeeId`) REFERENCES `Employee` (`IdEmployee`)
);

CREATE TABLE `Commission`(
    `IdCommission` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `FormationDate` DATE NOT NULL,
    `DissolutionDate` DATE NOT NULL,
    `ChairmanId` INT NOT NULL,

    FOREIGN KEY (`ChairmanId`) REFERENCES `Employee` (`IdEmployee`)
);

CREATE TABLE `CommissionMember`(
    `IdCommissionMember` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `CommissionId` INT NOT NULL,
    `EmployeeId` INT NOT NULL,

    FOREIGN KEY (`CommissionId`) REFERENCES `Commission` (`IdCommission`),
    FOREIGN KEY (`EmployeeId`) REFERENCES `Employee` (`IdEmployee`)
);

CREATE TABLE `TrainingCenter`(
    `IdTrainingCenter` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Address` NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE `Location`(
    `IdLocation` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Number` NVARCHAR(10) NOT NULL,
    `Description` NVARCHAR(250) NULL,
    `TrainingCenterId` INT NOT NULL,

    FOREIGN KEY (`TrainingCenterId`) REFERENCES `TrainingCenter` (`IdTrainingCenter`)
);

CREATE TABLE `Availability`(
    `IdAvailability` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Name` NVARCHAR(30) NOT NULL UNIQUE CHECK (`Name` REGEXP '^[a-zA-Z а-яА-ЯёЁ]+$')
);

CREATE TABLE `State`(
    `IdState` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Name` NVARCHAR(30) NOT NULL UNIQUE CHECK (`Name` REGEXP '^[a-zA-Z а-яА-ЯёЁ]+$')
);

CREATE TABLE `EquipmentType`(
    `IdEquipmentType` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Name` NVARCHAR(100) NOT NULL UNIQUE CHECK (`Name` REGEXP '^[a-zA-Z а-яА-ЯёЁ]+$')
);

CREATE TABLE `Unit`(
    `IdUnit` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `OKEICode` INT NOT NULL UNIQUE CHECK (`OKEICode` REGEXP '^[0-9]+$'),
    `Name` NVARCHAR(250) NOT NULL UNIQUE
);

CREATE TABLE `Equipment`(
    `IdEquipment` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Model` NVARCHAR(250) NOT NULL UNIQUE,
    `EquipmentTypeId` INT NOT NULL,
    `UnitId` INT NOT NULL,
    `Specifications` LONGBLOB NULL,

    FOREIGN KEY (`EquipmentTypeId`) REFERENCES `EquipmentType` (`IdEquipmentType`),
    FOREIGN KEY (`UnitId`) REFERENCES `Unit` (`IdUnit`)
);

CREATE TABLE `EquipmentUnit`(
    `IdEquipmentUnit` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `InventoryNumber` NVARCHAR(22) NOT NULL UNIQUE,
    `LocationId` INT NOT NULL,
    `StateId` INT NOT NULL,
    `AvailabilityId` INT NOT NULL,
    `Price` DECIMAL(38,2) NULL DEFAULT (0.0) CHECK (`Price` >= 0.0),
    `InstallationDate` DATE NOT NULL,
    `DecommissioningDate` DATE NULL,
    `ReasonsForDecommissioning` VARCHAR(250) NULL,
    `EquipmentId` INT NOT NULL,
    `SerialNumber` NVARCHAR(22) NOT NULL UNIQUE,
    `ResponsiblePersonId` INT NOT NULL,

    FOREIGN KEY (`LocationId`) REFERENCES `Location` (`IdLocation`),
    FOREIGN KEY (`StateId`) REFERENCES `State` (`IdState`),
    FOREIGN KEY (`AvailabilityId`) REFERENCES `Availability` (`IdAvailability`),
    FOREIGN KEY (`EquipmentId`) REFERENCES `Equipment` (`IdEquipment`),
    FOREIGN KEY (`ResponsiblePersonId`) REFERENCES `Employee` (`IdEmployee`)
);

CREATE TABLE `Inventory`(
    `IdInventory` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `EventDate` DATE NOT NULL,
    `EndingDate` DATE NOT NULL,
    `CommissionId` INT NOT NULL,
    `ExecutiveDecision` NVARCHAR(250) NULL,

    FOREIGN KEY (`CommissionId`) REFERENCES `Commission` (`IdCommission`)
);

CREATE TABLE `InspectedUnit`(
    `IdInspectedUnit` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `InventoryId` INT NOT NULL,
    `EquipmentUnitId` INT NOT NULL,

    FOREIGN KEY (`EquipmentUnitId`) REFERENCES `EquipmentUnit` (`IdEquipmentUnit`)
);
