# STATIC

INSERT INTO Inventory.Role (IdRole, Name) VALUES
                                      (1, 'Администратор'),
                                      (2, 'Составитель комиссии'),
                                      (3, 'Член комиссии');

INSERT INTO Inventory.Availability (IdAvailability, Name) VALUES
                                                              (1, 'Есть на месте'),
                                                              (2, 'Должно быть в другом месте'),
                                                              (3, 'Не найдено');

INSERT INTO Inventory.State (IdState, Name) VALUES
                                                (1, 'Отлично'),
                                                (2, 'Приемлемо'),
                                                (3, 'Требутся замена'),
                                                (4, 'Эксплуатации не подлежит');

# DYNAMIC

INSERT INTO Inventory.Employee (IdEmployee, LastName, FirstName, Email) VALUES
                                                                (1, 'Иванов', 'Иван', 'iwanoff@gmail.com'),
                                                                (2, 'Петров', 'Петр', 'petrchetvertiy@yandex.ru'),
                                                                (3, 'Данилов', 'Данил', 'ddanilllll@mail.ru'),
                                                                (4, 'Артемов', 'Артем', 'artartem@yahooo.com'),
                                                                (5, 'Викторов', 'Виктор', 'viviviviiv@outlook.com');

# CHANGE ONLY IN DATABASE
INSERT INTO Inventory.User (IdUser, Login, Password, RoleId, EmployeeId) VALUES
                                                                     (1, 'iivanov', '1123', 1, 1),
                                                                     (2, 'ppetrov', '2123', 2, 2),
                                                                     (3, 'ddanilov', '3123', 3, 3),
                                                                     (4, 'aartemov', '3123', 3, 4),
                                                                     (5, 'vviktorov', '3123', 3, 5);

INSERT INTO Inventory.Commission (IdCommission, CommissionFormationDate) VALUES
                                                                             (1, '2021-10-01'),
                                                                             (2, '2022-01-23'),
                                                                             (3, '2020-03-03');

INSERT INTO Inventory.CommissionMember (IdCommissionMember, CommissionId, EmployeeId) VALUES
                                                                                          (1, 1, 3),
                                                                                          (2, 1, 4),
                                                                                          (3, 2, 4),
                                                                                          (4, 2, 5);

INSERT INTO Inventory.TrainingCenter (IdTrainingCenter, Address) VALUES
                                                                     (1, 'ул. Ленина, 5'),
                                                                     (2, 'ул. Чехова, 67');

INSERT INTO Inventory.EquipmentType (IdEquipmentType, Name) VALUES
                                                                (1, 'персональные компьютеры'),
                                                                (2, 'проекторы');

INSERT INTO Inventory.Equipment (IdEquipment, Model, EquipmentTypeId) VALUES
                                                                   (1, 'ПК DEXP Atlas H341', 1),
                                                                   (2, 'Epson EB-X500', 2),
                                                                   (3, 'Rombica Ray Box W1', 2),
                                                                   (4, 'Мини ПК MSI Cubi N JSL-041RU', 1);

INSERT INTO Inventory.EquipmentUnit (IdEquipmentUnit, SerialNumber, InventoryNumber,
                                     AvailabilityId, TrainingCenterId, StateId, EquipmentId) VALUES
                                                                                 (1, '323425', 'P-112-1', 1, 2, 1, 2),
                                                                                 (2, '232222', 'P-234-1', 1, 2, 1, 2),
                                                                                 (3, '232333', 'P-302-1', 1, 2, 2, 2),
                                                                                 (4, '124432', 'PK-222-1', 1, 2, 2, 1),
                                                                                 (5, '324325', 'P-303-1', 1, 2, 1, 2),
                                                                                 (6, '233222', 'PK-248-24', 1, 2, 1, 1);

INSERT INTO Inventory.Inventory (IdInventory, EventDate, CommissionId) VALUES
                                                                           (1, '2020-01-01', 1),
                                                                           (2, '2021-01-01', 2);

INSERT INTO Inventory.InspectedUnit (IdInspectedUnit, InventoryId, EquipmentUnitId) VALUES
                                                                                        (1, 1, 1),
                                                                                        (2, 1, 2),
                                                                                        (3, 1, 3),
                                                                                        (4, 1, 4),
                                                                                        (5, 2, 4),
                                                                                        (6, 2, 5),
                                                                                        (7, 2, 6);
