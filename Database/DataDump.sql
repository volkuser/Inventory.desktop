-- STATIC

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

-- DYNAMIC

INSERT INTO Inventory.DocumentPosition (IdDocumentPosition, Name) VALUES
                                                                      (1, 'Заместитель директора'),
                                                                      (2, 'Заместитель главного бухгалтера'),
                                                                      (3, 'Главный бухгалтер'),
                                                                      (4, 'Преподаватель'),
                                                                      (5, 'Директор'),
                                                                      (6, 'Заведущий отедлением');

INSERT INTO Inventory.Employee (IdEmployee, LastName, FirstName, Patronymic, DocumentPositionId) VALUES
                                                                (1, 'Иванов', 'Иванов', 'Иванович', 1),
                                                                (2, 'Петров', 'Петр', 'Петрович', 4),
                                                                (3, 'Данилов', 'Данил', 'Данилович', 4),
                                                                (4, 'Артемов', 'Артем', 'Артемович', 5),
                                                                (5, 'Викторов', 'Виктор', 'Викторович', 6);

INSERT INTO Inventory.User (IdUser, Login, Password, RoleId, EmployeeId) VALUES
                                                                     (1, 'iivanov', '1123', 1, 1),
                                                                     (2, 'ppetrov', '2123', 2, 2),
                                                                     (3, 'ddanilov', '3123', 3, 3),
                                                                     (4, 'aartemov', '3123', 3, 4),
                                                                     (5, 'vviktorov', '3123', 3, 5);

INSERT INTO Inventory.Commission (IdCommission, FormationDate, DissolutionDate, ChairmanId) VALUES
                                                                             (1, '2021-10-01', '2021-10-01', 2),
                                                                             (2, '2022-01-23', '2021-10-01', 2),
                                                                             (3, '2020-03-03', '2021-10-01', 2);

INSERT INTO Inventory.TrainingCenter (IdTrainingCenter, Address) VALUES
                                      (1, 'ленина, 7'),
                                      (2, 'центраьная, 9'),
                                      (3, 'зеленая, 39');

INSERT INTO Inventory.Location (IdLocation, Number, Description, TrainingCenterId) VALUES
                                                                                       (1, '123H', 'нет', 1),
                                                                                       (2, '124', 'нет', 1),
                                                                                       (3, '355J', 'нет', 1),
                                                                                       (4, '244', 'нет', 2);

INSERT INTO Inventory.CommissionMember (IdCommissionMember, CommissionId, EmployeeId) VALUES
                                                                                          (1, 1, 3),
                                                                                          (2, 1, 4),
                                                                                          (3, 2, 4),
                                                                                          (4, 2, 5);

INSERT INTO Inventory.EquipmentType (IdEquipmentType, Name) VALUES
                                                              (1, 'ПК'),
                                                              (2, 'Принтер'),
                                                              (3, 'Проектор');

INSERT INTO Inventory.Unit (IdUnit, OKEICode, Name) VALUES
                                                        (1, 704, 'набор'),
                                                        (2, 657, 'изд'),
                                                        (3, 715, 'пар'),
                                                        (4, 796, 'шт');

INSERT INTO Inventory.Equipment (IdEquipment, Model, EquipmentTypeId, UnitId, Specifications) VALUES
                                                                   (1, 'ПК DEXP Atlas H341', 1, 4, 'большой'),
                                                                   (2, 'Epson EB-X500', 2, 4, 'нет'),
                                                                   (3, 'Rombica Ray Box W1', 2, 4, 'нет'),
                                                                   (4, 'Мини ПК MSI Cubi N JSL-041RU', 1, 4, 'нет');

INSERT INTO Inventory.EquipmentUnit (IdEquipmentUnit, InventoryNumber, LocationId, StateId, AvailabilityId, Price, InstallationDate, DecommissioningDate, ReasonsForDecommissioning, EquipmentId, SerialNumber, ResponsiblePersonId) VALUES
                                                                                 (1, 'P-112-1', 1, 2, 1, 29000.40, '2020-01-01', '2022-01-01', NULL, 2, '231218232', 1),
                                                                                 (2, 'P-234-1', 2, 1, 3, 67000.40, '2020-01-01', '2022-01-01', NULL, 2, '230000002', 2),
                                                                                 (3, 'P-302-1', 3, 2, 2, 33000.60, '2020-01-01', '2022-01-01', NULL, 2, '2312189992', 2),
                                                                                 (4, 'PK-222-1', 4, 3, 2, 48000.50, '2020-01-01', '2022-01-01', NULL, 1, '23188882', 1),
                                                                                 (5, 'P-303-1', 1, 1, 3, 29900.40, '2020-01-01', '2022-01-01', NULL, 2, '2312183442', 2),
                                                                                 (6, 'PK-248-24', 1, 2, 1, 39000.80, '2020-01-01', '2022-01-01', NULL, 1, '231215332', 1);

INSERT INTO Inventory.Inventory (IdInventory, EventDate, EndingDate, CommissionId, ExecutiveDecision) VALUES
                                                                           (1, '2020-01-01', '2020-01-02', 1, NULL),
                                                                           (2, '2021-01-01', '2020-01-02', 2, NULL);

INSERT INTO Inventory.InspectedUnit (IdInspectedUnit, InventoryId, EquipmentUnitId) VALUES
                                                                                        (1, 1, 1),
                                                                                        (2, 1, 2),
                                                                                        (3, 1, 3),
                                                                                        (4, 1, 4),
                                                                                        (5, 2, 4),
                                                                                        (6, 2, 5),
                                                                                        (7, 2, 6);
