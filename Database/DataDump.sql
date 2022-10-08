# STATIC

INSERT INTO Inventory.Role (IdRole, Name) VALUES
                                      (1, 'Администратор'),
                                      (2, 'Составитель инвентаризационных комиссий'),
                                      (3, 'Член временных инвентаризационных комиссий');

INSERT INTO Inventory.Status (IdStatus, Name) VALUES
                                                  (1, 'Числится'),
                                                  (2, 'Эксплуатируется'),
                                                  (3, 'Утеряно');

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
                                                                     (1, 'st. Lenina, 5'),
                                                                     (2, 'st. Chehova, 67');

INSERT INTO Inventory.Audience (IdAudience, Number, TrainingCenterId) VALUES
                                                                          (1, '134A', 1),
                                                                          (2, '134', 1),
                                                                          (3, '101', 1),
                                                                          (4, '101B', 1),
                                                                          (5, '094', 2),
                                                                          (6, '020', 2),
                                                                          (7, '020C', 2);

INSERT INTO Inventory.EquipmentType (IdEquipmentType, Name) VALUES
                                                                (1, 'ПК'),
                                                                (2, 'ручки');

INSERT INTO Inventory.Equipment (IdEquipment, Name, EquipmentTypeId) VALUES
                                                                   (1, 'Asus k8630', 1),
                                                                   (2, 'шариковая синяя', 2),
                                                                   (3, 'черная гелевая', 2),
                                                                   (4, 'Acer cm 30', 1);

INSERT INTO Inventory.EquipmentUnit (IdEquipmentUnit, Series, Number, StatusId, AudienceId,
                                     IntroductionDate, StateId, EquipmentId) VALUES
                                                                                 (1, 3245, '234H', 1, 2,
                                                                                  '2018-09-09', 1, 2),
                                                                                 (2, 2222, 'G12', 1, 2,
                                                                                  '2018-06-09', 1, 2),
                                                                                 (3, 2333, 'FS', 1, 2,
                                                                                  '2018-03-03', 2, 2),
                                                                                 (4, 1244, '333', 1, 2,
                                                                                  '2018-09-09', 2, 1),
                                                                                 (5, 3245, '2', 1, 2,
                                                                                  '2018-09-10', 1, 2),
                                                                                 (6, 2332, '123', 1, 2,
                                                                                  '2018-01-09', 1, 1);

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
