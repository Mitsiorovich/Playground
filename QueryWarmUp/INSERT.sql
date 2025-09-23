-- Insert data into Customers
INSERT INTO Customers (customer_id, name, country, signup_date) VALUES
(1, 'Alice Johnson', 'USA', '2023-01-15'),
(2, 'Bob Smith', 'Canada', '2023-02-20'),
(3, 'Carla Gomez', 'Mexico', '2023-03-05'),
(4, 'David Lee', 'USA', '2023-04-12'),
(5, 'Eva Brown', 'UK', '2023-05-22'),
(6, 'Frank White', 'Germany', '2023-06-18'),
(7, 'Grace Kim', 'South Korea', '2023-07-09'),
(8, 'Hiro Tanaka', 'Japan', '2023-08-14'),
(9, 'Irene Davis', 'Australia', '2023-09-01'),
(10, 'Jack Wilson', 'USA', '2023-10-11'),
(11, 'Karen Miller', 'Canada', '2023-11-03'),
(12, 'Liam Scott', 'UK', '2023-12-07');

-- Insert data into Products
INSERT INTO Products (product_id, product_name, category, price, stock) VALUES
(1, 'Laptop', 'Electronics', 1200.00, 50),
(2, 'Smartphone', 'Electronics', 800.00, 100),
(3, 'Headphones', 'Accessories', 150.00, 200),
(4, 'Office Chair', 'Furniture', 250.00, 30),
(5, 'Coffee Maker', 'Appliances', 120.00, 40),
(6, 'Desk Lamp', 'Lighting', 45.00, 80),
(7, 'Backpack', 'Accessories', 60.00, 150),
(8, 'Monitor', 'Electronics', 300.00, 60),
(9, 'Keyboard', 'Electronics', 80.00, 90),
(10, 'Mouse', 'Electronics', 40.00, 120),
(11, 'Tablet', 'Electronics', 500.00, 70),
(12, 'Smartwatch', 'Electronics', 200.00, 90);

-- Insert data into Orders
INSERT INTO Orders (order_id, customer_id, product_id, quantity, order_date) VALUES
(1, 1, 1, 1, '2023-01-20'),
(2, 2, 2, 2, '2023-02-25'),
(3, 3, 3, 1, '2023-03-10'),
(4, 4, 4, 1, '2023-04-15'),
(5, 5, 5, 1, '2023-05-25'),
(6, 6, 6, 2, '2023-06-20'),
(7, 7, 7, 1, '2023-07-12'),
(8, 8, 8, 1, '2023-08-18'),
(9, 9, 9, 2, '2023-09-05'),
(10, 10, 10, 1, '2023-10-15'),
(11, 11, 11, 1, '2023-11-07'),
(12, 12, 12, 2, '2023-12-12'),
(13, 1, 3, 1, '2023-01-28'),
(14, 2, 5, 1, '2023-02-28'),
(15, 3, 7, 3, '2023-03-18');

-- Insert data into Payments
INSERT INTO Payments (payment_id, order_id, payment_date, amount, payment_method) VALUES
(1, 1, '2023-01-21', 1200.00, 'Credit Card'),
(2, 2, '2023-02-26', 1600.00, 'PayPal'),
(3, 3, '2023-03-11', 150.00, 'Credit Card'),
(4, 4, '2023-04-16', 250.00, 'Debit Card'),
(5, 5, '2023-05-26', 120.00, 'PayPal'),
(6, 6, '2023-06-21', 90.00, 'Credit Card'),
(7, 7, '2023-07-13', 60.00, 'Debit Card'),
(8, 8, '2023-08-19', 300.00, 'Credit Card'),
(9, 9, '2023-09-06', 160.00, 'PayPal'),
(10, 10, '2023-10-16', 40.00, 'Credit Card'),
(11, 11, '2023-11-08', 500.00, 'Credit Card'),
(12, 12, '2023-12-13', 400.00, 'Debit Card'),
(13, 13, '2023-01-29', 150.00, 'PayPal'),
(14, 14, '2023-03-01', 120.00, 'Credit Card'),
(15, 15, '2023-03-19', 180.00, 'Debit Card');
