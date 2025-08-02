CREATE DATABASE eShiftDB;

USE eShiftDB;

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100),
    Address NVARCHAR(255),
    Phone NVARCHAR(20),
    Email NVARCHAR(100),
    Password NVARCHAR(100)
);

CREATE TABLE Admins (
    AdminID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50),
    Password NVARCHAR(100)
);

CREATE TABLE TransportUnits (
    TransportID INT PRIMARY KEY IDENTITY(1,1),
    LorryID NVARCHAR(50),
    DriverName NVARCHAR(100),
    AssistantName NVARCHAR(100),
    ContainerID NVARCHAR(50)
);

CREATE TABLE Jobs (
    JobID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT,
    StartLocation NVARCHAR(255),
    EndLocation NVARCHAR(255),
    JobDate DATE,
    Status NVARCHAR(50),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE Loads (
    LoadID INT PRIMARY KEY IDENTITY(1,1),
    JobID INT,
    Description NVARCHAR(255),
    Weight FLOAT,
    TransportID INT,
    FOREIGN KEY (JobID) REFERENCES Jobs(JobID),
   FOREIGN KEY (TransportID) REFERENCES TransportUnits(TransportID)
);

INSERT INTO Admins (Username, Password) VALUES ('admin', 'admin123');
INSERT INTO Customers (FullName, Address, Phone, Email, Password)
VALUES ('Test User', '123 Street', '0771234567', 'user@example.com', 'user123');

Use eShiftDB
ALTER TABLE Jobs
ADD Description NVARCHAR(500)

Use eShiftDB
DROP TABLE IF EXISTS Admins;

CREATE TABLE Admins (
    AdminID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(15) NOT NULL,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL
);

Use eShiftDB
CREATE TABLE AdminCodes (
    Code NVARCHAR(50) PRIMARY KEY,
    IsUsed BIT DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETDATE()
);

INSERT INTO AdminCodes (Code, IsUsed) VALUES
('ESHIFT-ADM-X93L7PZ', 0),
('ESHIFT-ADM-PLD7XQ9', 0),
('ESHIFT-ADM-R7ZKQ38', 0),
('ESHIFT-ADM-WQ92LXT', 0),
('ESHIFT-ADM-D93Z7LM', 0),
('ESHIFT-ADM-MPQ7WXD', 0),
('ESHIFT-ADM-ZX3PLDT', 0),
('ESHIFT-ADM-Y9TQWML', 0),
('ESHIFT-ADM-N7LQ3XP', 0),
('ESHIFT-ADM-XP3WQL7', 0),
('ESHIFT-ADM-K72PXLW', 0),
('ESHIFT-ADM-LMXQ94Z', 0),
('ESHIFT-ADM-TX93WDL', 0),
('ESHIFT-ADM-93PXWTL', 0),
('ESHIFT-ADM-WTX3PL9', 0),
('ESHIFT-ADM-BQ7D9LM', 0),
('ESHIFT-ADM-JTQXW79', 0),
('ESHIFT-ADM-VXWPT93', 0),
('ESHIFT-ADM-FZ93TQL', 0),
('ESHIFT-ADM-LWTQX93', 0),
('ESHIFT-ADM-GPDXQ79', 0),
('ESHIFT-ADM-MT7PQWX', 0),
('ESHIFT-ADM-ZPLTW93', 0),
('ESHIFT-ADM-Y9PWTXL', 0),
('ESHIFT-ADM-TQXWL97', 0),
('ESHIFT-ADM-KPQZ93T', 0),
('ESHIFT-ADM-LX93PWT', 0),
('ESHIFT-ADM-XD7WPTQ', 0),
('ESHIFT-ADM-RQTLX93', 0),
('ESHIFT-ADM-NWX9QPL', 0),
('ESHIFT-ADM-TQWDX93', 0),
('ESHIFT-ADM-WPXQLT9', 0),
('ESHIFT-ADM-A7PXLDQ', 0),
('ESHIFT-ADM-QWTPL93', 0),
('ESHIFT-ADM-PQ9TLXW', 0),
('ESHIFT-ADM-PLWXTQ9', 0),
('ESHIFT-ADM-XWLQT93', 0),
('ESHIFT-ADM-JQTXW93', 0),
('ESHIFT-ADM-BQ7PLMX', 0),
('ESHIFT-ADM-ZXTW93L', 0),
('ESHIFT-ADM-MXLPQ97', 0),
('ESHIFT-ADM-GWLX93T', 0),
('ESHIFT-ADM-T9PWLXQ', 0),
('ESHIFT-ADM-F93PLTX', 0),
('ESHIFT-ADM-VTLXP93', 0),
('ESHIFT-ADM-XWTQLP9', 0),
('ESHIFT-ADM-KWTX93L', 0),
('ESHIFT-ADM-W9PQXLT', 0),
('ESHIFT-ADM-TX93PLD', 0),
('ESHIFT-ADM-QPLXW93', 0),
('ESHIFT-ADM-ZTQWXP9', 0),
('ESHIFT-ADM-MLWTX93', 0),
('ESHIFT-ADM-YTXPL93', 0),
('ESHIFT-ADM-WPLQT93', 0),
('ESHIFT-ADM-RW9XQTL', 0),
('ESHIFT-ADM-LXQTW93', 0),
('ESHIFT-ADM-DXWQTL9', 0),
('ESHIFT-ADM-TQ93WPL', 0),
('ESHIFT-ADM-NXLPQ93', 0),
('ESHIFT-ADM-JXPLQ93', 0),
('ESHIFT-ADM-BPLXWT9', 0),
('ESHIFT-ADM-MTX9PQL', 0),
('ESHIFT-ADM-PWQT93L', 0),
('ESHIFT-ADM-ZQXP93L', 0),
('ESHIFT-ADM-WPXLTQ9', 0),
('ESHIFT-ADM-KWQT93L', 0),
('ESHIFT-ADM-YT93PXW', 0),
('ESHIFT-ADM-VPLXQ93', 0),
('ESHIFT-ADM-WPLT93X', 0),
('ESHIFT-ADM-FWQT93P', 0),
('ESHIFT-ADM-XTQ93PL', 0),
('ESHIFT-ADM-TPLXW93', 0),
('ESHIFT-ADM-QL93PTX', 0),
('ESHIFT-ADM-GPXWT93', 0),
('ESHIFT-ADM-WPXT93L', 0),
('ESHIFT-ADM-MLPQ93T', 0),
('ESHIFT-ADM-ZT93WPL', 0),
('ESHIFT-ADM-TXP93WL', 0),
('ESHIFT-ADM-RPQXW93', 0),
('ESHIFT-ADM-9TXPLWQ', 0),
('ESHIFT-ADM-XPLWT93', 0),
('ESHIFT-ADM-93QWPLX', 0),
('ESHIFT-ADM-PLXQT93', 0),
('ESHIFT-ADM-XPW93TL', 0),
('ESHIFT-ADM-K93PLWT', 0),
('ESHIFT-ADM-TPWLX93', 0),
('ESHIFT-ADM-WQXPLT9', 0),
('ESHIFT-ADM-YPLXQT9', 0),
('ESHIFT-ADM-ZTQ93XW', 0),
('ESHIFT-ADM-LPXQW93', 0),
('ESHIFT-ADM-MXPLW93', 0),
('ESHIFT-ADM-FPQ93TL', 0),
('ESHIFT-ADM-TWX93PL', 0),
('ESHIFT-ADM-Q93PLWX', 0),
('ESHIFT-ADM-NQXTLW9', 0),
('ESHIFT-ADM-KWXP93L', 0),
('ESHIFT-ADM-WLPQT93', 0),
('ESHIFT-ADM-XPWTL93', 0),
('ESHIFT-ADM-93WPLTX', 0),
('ESHIFT-ADM-TLXP93W', 0),
('ESHIFT-ADM-PWTQ93L', 0),
('ESHIFT-ADM-YQ93PLX', 0);

use eShiftDB
CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(100) NOT NULL,
    Description VARCHAR(255),
    Price DECIMAL(10, 2) NOT NULL,
    Category VARCHAR(100),
    Quantity INT NOT NULL
);
INSERT INTO Products (ProductName, Description, Price, Category, Quantity) VALUES 
('Wireless Mouse', 'Ergonomic design with 2.4GHz connection', 12.99, 'Electronics', 150),
('Bluetooth Headphones', 'Over-ear noise cancelling headphones', 45.50, 'Electronics', 100),
('Laptop Stand', 'Adjustable aluminum stand for laptops', 22.00, 'Accessories', 75),
('LED Monitor 24"', 'Full HD display with HDMI and VGA support', 129.99, 'Electronics', 60),
('USB-C Hub', '6-in-1 hub with HDMI, USB 3.0, SD Card Reader', 18.75, 'Electronics', 120),
('Gaming Keyboard', 'Mechanical RGB backlit keyboard', 55.00, 'Gaming', 50),
('Webcam 1080p', 'Full HD webcam with microphone', 34.95, 'Electronics', 85),
('Portable SSD 1TB', 'High-speed external solid state drive', 89.90, 'Storage', 40),
('Wireless Charger', 'Fast charging pad for smartphones', 15.00, 'Accessories', 140),
('Smartwatch', 'Fitness tracker with heart rate monitor', 69.99, 'Wearables', 70),
('Coffee Maker', '12-cup programmable drip coffee machine', 49.99, 'Home Appliances', 45),
('Electric Kettle', '1.7L stainless steel fast-boil kettle', 24.99, 'Home Appliances', 110),
('Air Fryer', 'Oil-less fryer with 6 cooking presets', 59.95, 'Home Appliances', 35),
('Blender', 'Smoothie blender with 3 speed settings', 34.00, 'Kitchen Appliances', 90),
('Yoga Mat', 'Non-slip, eco-friendly 6mm thick mat', 17.50, 'Fitness', 200),
('Adjustable Dumbbells', '2.5 to 24 lbs weight set', 95.00, 'Fitness', 25),
('Resistance Bands Set', 'Set of 5 bands with varying resistance', 12.25, 'Fitness', 180),
('Treadmill', 'Foldable electric treadmill with LCD display', 499.99, 'Fitness', 12),
('Running Shoes', 'Lightweight breathable running shoes', 39.99, 'Footwear', 100),
('Men’s Jacket', 'Waterproof winter jacket', 59.00, 'Clothing', 70),
('Women’s Handbag', 'Leather handbag with zipper closure', 45.50, 'Fashion', 65),
('Sunglasses', 'UV400 protection polarized sunglasses', 19.99, 'Accessories', 160),
('Backpack', 'Anti-theft travel laptop backpack', 29.99, 'Bags', 90),
('Desk Lamp', 'LED lamp with touch control and USB port', 14.75, 'Home Decor', 130),
('Wall Clock', 'Modern silent non-ticking clock', 12.50, 'Home Decor', 95),
('Curtains Set', '2 blackout panels, 52x84 inches', 35.00, 'Home Decor', 55),
('Cotton Bed Sheets', '4-piece queen-size soft cotton sheets', 42.00, 'Bedding', 60),
('Memory Foam Pillow', 'Ergonomic pillow for neck support', 25.99, 'Bedding', 90),
('Bookshelf', '5-tier wooden shelf for books & decor', 69.99, 'Furniture', 25),
('Office Chair', 'Ergonomic mesh back chair with lumbar support', 89.00, 'Furniture', 35),
('Gaming Chair', 'Reclining chair with footrest and headrest', 129.99, 'Furniture', 30),
('Frying Pan Set', 'Non-stick cookware set of 3 pans', 39.95, 'Kitchen Appliances', 80),
('Knife Set', '15-piece stainless steel kitchen knife block', 49.90, 'Kitchen', 70),
('Cutting Board Set', '3 BPA-free plastic boards with juice grooves', 14.99, 'Kitchen', 95),
('Microwave Oven', '700W compact digital microwave', 89.99, 'Home Appliances', 20),
('Vacuum Cleaner', 'Cordless stick vacuum with HEPA filter', 149.99, 'Home Appliances', 15),
('Pet Bed', 'Soft washable round pet bed', 21.99, 'Pet Supplies', 75),
('Dog Leash', 'Heavy-duty reflective leash for large dogs', 9.99, 'Pet Supplies', 200),
('Cat Tree Tower', 'Multi-level activity center for cats', 64.00, 'Pet Supplies', 22),
('Hair Dryer', 'Ionic blow dryer with diffuser', 29.95, 'Beauty', 100),
('Electric Toothbrush', 'Rechargeable toothbrush with timer', 34.50, 'Personal Care', 85),
('Shaving Kit', 'Razor, brush, cream and stand set', 22.99, 'Personal Care', 65),
('Water Bottle', 'Insulated stainless steel bottle - 750ml', 16.00, 'Accessories', 180),
('Camping Tent', '4-person waterproof pop-up tent', 89.00, 'Outdoors', 20),
('Flashlight', 'Rechargeable LED tactical flashlight', 14.50, 'Outdoors', 100),
('Tool Kit', 'Home tool set with 100+ pieces', 59.99, 'Hardware', 45),
('Screwdriver Set', 'Precision magnetic screwdriver kit', 18.25, 'Hardware', 70),
('Painting Set', '24 acrylic paint tubes with brushes & canvas', 27.99, 'Art Supplies', 55),
('Guitar', 'Acoustic guitar with bag and tuner', 99.00, 'Music', 25),
('Keyboard Piano', '61-key electronic keyboard with stand', 139.95, 'Music', 18);

CREATE TABLE JobProducts (
    JobProductID INT PRIMARY KEY IDENTITY(1,1),
    JobID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL DEFAULT 1,
    FOREIGN KEY (JobID) REFERENCES Jobs(JobID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
