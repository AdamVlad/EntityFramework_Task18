CREATE TABLE Orders
(
	ID INT IDENTITY(1, 1) NOT NULL,
	ProductCode INT NOT NULL,
	ProductName NVARCHAR(20) NOT NULL,
	Email NVARCHAR(30) NOT NULL	
)

SELECT * FROM Orders

DELETE FROM Buyings WHERE ID = 2

INSERT INTO Orders (ProductCode, ProductName, Email)
VALUES (1, N'Телевизор', 'Nika@mail.ru');

INSERT INTO Orders (ProductCode, ProductName, Email)
VALUES (2, N'Компьютер', 'Maksim@mail.ru');

INSERT INTO Orders (ProductCode, ProductName, Email)
VALUES (3, N'Клавиатура', 'Olga@mail.ru');

