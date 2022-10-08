DELIMITER //
CREATE PROCEDURE User_Insert (p_Login NVARCHAR(100), p_Password VARCHAR(100), p_RoleId INT, p_EmployeeId INT)
BEGIN
    DECLARE HAVE_RECORD INT;
    SELECT COUNT(*) INTO HAVE_RECORD FROM Inventory.User
        WHERE Login = p_Login AND Password = p_Password AND RoleId = p_RoleId AND EmployeeId = p_EmployeeId;
    IF (HAVE_RECORD > 0) THEN
        SELECT 'There is already user with specified data.' AS 'Error';
    ELSE
        INSERT INTO Inventory.User (Login, Password, RoleId, EmployeeId)
            VALUES (p_Login, p_Password, p_RoleId, p_EmployeeId);
    END IF;
END;

DELIMITER //
CREATE PROCEDURE User_Update (p_IdUser INT, p_Login NVARCHAR(100), p_Password VARCHAR(100), p_RoleId INT,
                              p_EmployeeId INT)
BEGIN
    DECLARE HAVE_RECORD INT;
    SELECT COUNT(*) INTO HAVE_RECORD FROM Inventory.User
        WHERE Login = p_Login AND Password = p_Password AND RoleId = p_RoleId AND EmployeeId = p_EmployeeId;
    IF (HAVE_RECORD > 0) THEN
        SELECT 'Such data is already specified for the user.' AS 'Error';
    ELSE
        UPDATE Inventory.User SET
                                  Login = p_Login,
                                  Password = p_Password,
                                  RoleId = p_RoleId,
                                  EmployeeId = p_EmployeeId
        WHERE IdUser = p_IdUser;
    END IF;
END;

DELIMITER //
CREATE PROCEDURE User_Delete (p_IdUser INT)
BEGIN
    DELETE FROM Inventory.User
        WHERE IdUser = p_IdUser;
END;

