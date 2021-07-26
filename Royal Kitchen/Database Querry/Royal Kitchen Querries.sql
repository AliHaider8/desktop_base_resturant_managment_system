CREATE TABLE Login
(
     LoginID  INT IDENTITY(1,1) PRIMARY KEY(LoginID),
     Username VARCHAR(30) UNIQUE NOT NULL,
	 Password VARCHAR(30) UNIQUE NOT NULL,
	 Email    VARCHAR(50) NOT NULL,
	 EntryDate DATETIME   NOT NULL
);

CREATE TABLE LoginDetail
(
     LoginDetailID INT IDENTITY(1,1) PRIMARY KEY(LoginDetailID),
	 LoginID  INT Foreign key(LoginID) REFERENCES Login(LoginID) NOT NULL,
	 Username VARCHAR(30) NOT NULL,
	 Email    VARCHAR(50) NOT NULL,
	 LoginTime DATETIME   NOT NULL
);

CREATE TABLE DistributerPersonalDetail
(
     DistributerPID INT IDENTITY(1,1) PRIMARY KEY( DistributerPID),
	 FirstName VARCHAR(30) NOT NULL,
	 LastName  VARCHAR(30) NOT NULL,
	 FatherName VARCHAR(30) NOT NULL,
	 CNIC CHAR(13) UNIQUE NULL,
	 Age INT NOT NULL,
	 Gender CHAR(8) NOT NULL,
	 MaritalStatus CHAR(10) NOT NULL,
	 EntryDate DATETIME NOT NULL
)

CREATE TABLE DistributerContactDetail
(
    DistributerCID INT IDENTITY(1,1) PRIMARY KEY(DistributerCID),
    DistributerPID INT FOREIGN KEY(DistributerPID) REFERENCES DistributerPersonalDetail(DistributerPID),
    Address VARCHAR(100) NOT NULL,
    City VARCHAR(100) NOT NULL,
    Country VARCHAR(100) NOT NULL,
    PhoneNo CHAR(13) NOT NULL,
    LandLineNo CHAR(15) NULL,
    Email VARCHAR(50)   NULL,
    Others VARCHAR(100) NULL,
    EntryDate DATETIME NOT NULL
)

CREATE TABLE DistributerBrandDetail
(
   BrandID INT identity(1,1) PRIMARY KEY(BrandID),
   DistributerPID INT FOREIGN KEY(DistributerPID) REFERENCES DistributerPersonalDetail(DistributerPID),
   BrandName VARCHAR(30) UNIQUE NOT NULL,
   Address VARCHAR(100)  NOT NULL,
   Email VARCHAR(50)  UNIQUE NULL,
   PhoneNo CHAR(13)   UNIQUE NOT NULL,
   EntryDate DATETIME  NOT NULL
)

CREATE TABLE Ingredient
(
   IngredientID INT IDENTITY(1,1) PRIMARY KEY(IngredientID),
   IngredientName VARCHAR(30) UNIQUE NOT NULL,
   IngredientPrice DECIMAL(8,2) NOT NULL,
   Size CHAR(10) NULL,
   Description VARCHAR(100) NULL,
   EntryDate DATETIME NOT NULL
)

CREATE TABLE ProductPurchase
(
   PurchaseID INT IDENTITY(1,1) PRIMARY KEY(PurchaseID),
   BrandID INT FOREIGN KEY(BrandID) REFERENCES DistributerBrandDetail(BrandID),
   IngredientID INT REFERENCES Ingredient(IngredientID),
   PurchasePrice DECIMAL(8,2) NOT NULL,
   Quantity INT CHECK(Quantity>=0) NOT NULL,
   Size CHAR(10) NULL,
   PurchaseDate DATETIME NOT NULL
)

CREATE TABLE DistributerPayment
(
   DistributerPaymentID INT IDENTITY(1,1) PRIMARY KEY(DistributerPaymentID),
   DistributerPID INT FOREIGN KEY(DistributerPID) REFERENCES DistributerPersonalDetail(DistributerPID),
   PurchaseID INT FOREIGN KEY(PurchaseID) REFERENCES ProductPurchase(PurchaseID),
   PaidAmount VARCHAR(30),
   RemaningAmount VARCHAR(100),
   PaymentMethod VARCHAR(50),
   PaymentType CHAR(13),
   EntryDate DATETIME
);
CREATE TABLE CurrentStock
(
   CurrentStockID INT IDENTITY(1,1) PRIMARY KEY(CurrentStockID),
   IngredientID INT REFERENCES Ingredient(IngredientID),
   Quantity INT CHECK(Quantity>=0) NOT NULL,
   EntryDate DATETIME NOT NULL
)

CREATE TABLE Food
(
   FoodID INT IDENTITY(1,1) PRIMARY KEY(FoodID),
   FoodName VARCHAR(30) UNIQUE NOT NULL,
   FoodType VARCHAR(50) NOT NULL,
   FoodDescription VARCHAR(100) NULL,
   EntryDate DATETIME 
)
CREATE TABLE FoodSize
(
   FoodSizeID INT IDENTITY(1,1) PRIMARY KEY(FoodSizeID),
   FoodID INT FOREIGN KEY(FoodID) REFERENCES Food(FoodID),
   FoodSize CHAR(10) NOT NULL,
   FoodPrice DECIMAL(8,2) NOT NULL,
   EntryDate DATETIME   NULL
)
CREATE TABLE FoodIngredient
(
  FoodIngredientID INT IDENTITY(1,1) PRIMARY KEY(FoodIngredientID),
  FoodID INT FOREIGN KEY(FoodID) REFERENCES Food(FoodID),
  FoodSizeID INT FOREIGN KEY(FoodSizeID) REFERENCES FoodSize(FoodSizeID),
  IngredientID INT REFERENCES Ingredient(IngredientID),
  Quantity Float Not NULL,
  Size CHAR(10) NOT NULL,
  EntryDate DATETIME   NULL
)



CREATE TABLE Offers
(
  OfferID INT IDENTITY(1,1) PRIMARY KEY(OfferID),
  OfferName VARCHAR(30) UNIQUE NOT NULL,
  OfferPrice DECIMAL(8,2) NOT NULL,
  Availability CHAR(10) NULL,
  CreateTime DATETIME   NOT NULL
)

CREATE TABLE OffersFood
(
  OffersFoodID INT IDENTITY(1,1) PRIMARY KEY(OffersFoodID),
  OfferID INT FOREIGN KEY(OfferID) REFERENCES Offers(OfferID),
  FoodID INT FOREIGN KEY(FoodID) REFERENCES Food(FoodID),
  FoodSizeID INT FOREIGN KEY(FoodSizeID) REFERENCES FoodSize(FoodSizeID),
  Quantity INT NOT NULL,
  EntryDate DATETIME   NULL
)

CREATE TABLE EmployeePesonalDetail
(
   EmployeePID INT IDENTITY(1,1) PRIMARY KEY(EmployeePID),
   FirstName VARCHAR(30) NOT NULL,
   LastName VARCHAR(30) NULL,
   CNIC CHAR(13) UNIQUE NULL,
   FatherName VARCHAR(30) NOT NULL,
   Age INT NOT NULL,
   Gender CHAR(8) NOT NULL,
   MaritalStatus CHAR(10) NOT NULL,
   EntryDate DATETIME   NULL
)
CREATE TABLE Employee
(
   EmployeeID INT IDENTITY(1,1) PRIMARY KEY(EmployeeID),
   EmployeePID INT FOREIGN KEY(EmployeePID) REFERENCES EmployeePesonalDetail(EmployeePID),
   JobName VARCHAR(30) NOT NULL,
   EmployeementYears INT NOT NULL,
   Salary DECIMAL(8,2) CHECK(Salary>=0) NOT NULL,
   Bonus DECIMAL(8,2) CHECK(Bonus>=0) NULL,
   DutyStartTime TIME NULL,
   DutyEndTime TIME  NULL,
   JobDescription VARCHAR(100) NULL,
   EntryDate DATETIME   NULL
)












CREATE TABLE Customer
(
  CustomerID INT IDENTITY(1,1) PRIMARY KEY(CustomerID),
  FirstName VARCHAR(30) NOT NULL,
  LastName VARCHAR(30) NULL,
  CNIC CHAR(13) NULL,
  PhoneNo1 CHAR(13) NOT NULL,
  PhoneNo2 CHAR(13) NULL,
  Email VARCHAR(50) NULL,
  Address VARCHAR(100) NOT NULL,
  EntryDate DATETIME NOT NULL
)
CREATE TABLE CustomerOrderBooking
(
   CustomerOrderID INT IDENTITY(1,1) PRIMARY KEY(CustomerOrderID),
   CustomerID INT FOREIGN KEY(CustomerID) REFERENCES Customer(CustomerID),
   EmployeePID INT FOREIGN KEY(EmployeePID) REFERENCES EmployeePesonalDetail(EmployeePID),
   TotalBill Decimal(18,2) ,
   EntryDate DATETIME NOT NULL
)
CREATE TABLE CustomerOrderDetail
(
    CustomerDetailID INT IDENTITY(1,1) PRIMARY KEY(CustomerDetailID),
	CustomerOrderID INT FOREIGN KEY(CustomerOrderID) REFERENCES CustomerOrderBooking(CustomerOrderID),
    ProductName VARCHAR(30) NOT NULL,
	ProductSize Char(10) Not Null,
    ProductQuantity INT NOT NULL,
    SalePrice DECIMAL(8,2) NOT NULL,
    EntryDate DATETIME    NOT NULL
)



CREATE TABLE EmployeeContactDetail
(
  EmployeeCID INT IDENTITY(1,1) PRIMARY KEY(EmployeeCID),
  EmployeePID INT FOREIGN KEY(EmployeePID) REFERENCES EmployeePesonalDetail(EmployeePID),
  Address1 VARCHAR(100) NOT NULL,
  Address2 VARCHAR(100) NULL,
  City VARCHAR(100) NOT NULL,
  Country VARCHAR(100) NOT NULL,
  PhoneNo1 CHAR(13) UNIQUE NOT NULL,
  PhoneNo2 CHAR(13) NULL,
  LandLineNo CHAR(15) NULL,
  Email VARCHAR(50) NULL,
  Others VARCHAR(100) NULL,
  EntryDate DATETIME NOT NULL
)

CREATE TABLE Qualification
(
   QualificationID INT IDENTITY(1,1) PRIMARY KEY(QualificationID),
   EmployeePID INT FOREIGN KEY(EmployeePID) REFERENCES EmployeePesonalDetail(EmployeePID),
   DegreeName VARCHAR(50) NOT NULL,
   InstituteName VARCHAR(50) NOT NULL,
   PassingYear CHAR(10) NULL,
   ObtainedMarks INT NOT NULL,
   TotalMarks INT NOT NULL,
   Grade CHAR(2) NULL,
   Other VARCHAR(100) NULL,
   EntryDate DATETIME   NULL
)

CREATE TABLE EmployeeSkill
(
   EmployeeSkillID INT IDENTITY(1,1) PRIMARY KEY(EmployeeSkillID),
   EmployeePID INT FOREIGN KEY(EmployeePID) REFERENCES EmployeePesonalDetail(EmployeePID),
   SkillName VARCHAR(50) NOT NULL,
   OrganizationName VARCHAR(50) NOT NULL,
   CertificationNumber VARCHAR(50) NULL,
   LearnStartDate DATE NOT NULL,
   LearnEndDate DATE   NOT NULL,
   Others VARCHAR(100) NULL,
   EntryDate DATETIME   NULL
)

CREATE TABLE EmployeePrevoiusExperiance
(
   EmployeePEID INT IDENTITY(1,1) PRIMARY KEY(EmployeePEID),
   EmployeePID INT FOREIGN KEY(EmployeePID) REFERENCES EmployeePesonalDetail(EmployeePID),
   OrganizationName VARCHAR(50) NOT NULL,
   JobName VARCHAR(50) NOT NULL,
   JobDescription VARCHAR(100) NULL,
   StartDate DATE NOT NULL,
   EndDate DATE   NOT NULL,
   Others VARCHAR(100) NULL,
   EntryDate DATETIME   NULL
)


CREATE TABLE CustomerOrderPayment
(
   CustOdrPayID INT IDENTITY(1,1) PRIMARY KEY(CustOdrPayID),
   CustomerOrderID INT FOREIGN KEY(CustomerOrderID) REFERENCES CustomerOrderBooking(CustomerOrderID),
   PaymentMedium VARCHAR(50) NOT NULL,
   PaymentAmount DECIMAL(8,2) NOT NULL,
   EntryDate DATETIME NOT NULL
)
CREATE TABLE Delivery
(
   DeliveryID INT IDENTITY(1,1) PRIMARY KEY(DeliveryID),
   EmployeePID INT FOREIGN KEY(EmployeePID) REFERENCES EmployeePesonalDetail(EmployeePID),
   CustomerOrderID INT FOREIGN KEY(CustomerOrderID) REFERENCES CustomerOrderBooking(CustomerOrderID),
   DeliveryAddress VARCHAR(100) NOT NULL,
   ExpectedTime char(10)  NOT NULL,
   EntryDate DATETIME   NULL
)

CREATE TABLE Extras
(
   ExtrasID INT IDENTITY(1,1) PRIMARY KEY(ExtrasID),
   EmployeePID INT FOREIGN KEY(EmployeePID) REFERENCES EmployeePesonalDetail(EmployeePID),
   ExtrasName VARCHAR(30) NOT NULL,
   ExtrasType CHAR(10) NOT NULL,
   ExtrasQuantity INT  NULL,
   Amount DECIMAL(8,2) NOT NULL,
   Description VARCHAR(250) NULL,
   EntryDate DATETIME NOT NULL
)



