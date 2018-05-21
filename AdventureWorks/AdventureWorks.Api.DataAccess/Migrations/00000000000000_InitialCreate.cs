using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.DataAccess.Migrations
{
	[DbContext(typeof(ApplicationDbContext))]
    [Migration("00000000000000_InitialCreate")]
	public partial class InitialCreate : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"IF NOT EXISTS(SELECT *
FROM sys.schemas
WHERE name = N'dbo')
EXEC('CREATE SCHEMA [dbo] AUTHORIZATION [dbo]');
GO

IF NOT EXISTS(SELECT *
FROM sys.schemas
WHERE name = N'HumanResources')
EXEC('CREATE SCHEMA [HumanResources] AUTHORIZATION [dbo]');
GO

IF NOT EXISTS(SELECT *
FROM sys.schemas
WHERE name = N'Person')
EXEC('CREATE SCHEMA [Person] AUTHORIZATION [dbo]');
GO

IF NOT EXISTS(SELECT *
FROM sys.schemas
WHERE name = N'Production')
EXEC('CREATE SCHEMA [Production] AUTHORIZATION [dbo]');
GO

IF NOT EXISTS(SELECT *
FROM sys.schemas
WHERE name = N'Purchasing')
EXEC('CREATE SCHEMA [Purchasing] AUTHORIZATION [dbo]');
GO

IF NOT EXISTS(SELECT *
FROM sys.schemas
WHERE name = N'Sales')
EXEC('CREATE SCHEMA [Sales] AUTHORIZATION [dbo]');
GO

CREATE TABLE [dbo].[AWBuildVersion](
[SystemInformationID] [tinyint]   IDENTITY(1,1)  NOT NULL,
[Database Version] [nvarchar]  (25)   NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[VersionDate] [datetime]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[DatabaseLog](
[DatabaseLogID] [int]   IDENTITY(1,1)  NOT NULL,
[DatabaseUser] [nvarchar]  (128)   NOT NULL,
[Event] [nvarchar]  (128)   NOT NULL,
[Object] [nvarchar]  (128)   NULL,
[PostTime] [datetime]     NOT NULL,
[Schema] [nvarchar]  (128)   NULL,
[TSQL] [nvarchar]     NOT NULL,
[XmlEvent] [xml]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[ErrorLog](
[ErrorLogID] [int]   IDENTITY(1,1)  NOT NULL,
[ErrorLine] [int]     NULL,
[ErrorMessage] [nvarchar]  (4000)   NOT NULL,
[ErrorNumber] [int]     NOT NULL,
[ErrorProcedure] [nvarchar]  (126)   NULL,
[ErrorSeverity] [int]     NULL,
[ErrorState] [int]     NULL,
[ErrorTime] [datetime]     NOT NULL,
[UserName] [nvarchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [HumanResources].[Department](
[DepartmentID] [smallint]   IDENTITY(1,1)  NOT NULL,
[GroupName] [nvarchar]  (50)   NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Name] [nvarchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [HumanResources].[Employee](
[BusinessEntityID] [int]     NOT NULL,
[BirthDate] [date]     NOT NULL,
[CurrentFlag] [bit]     NOT NULL,
[Gender] [nchar]  (1)   NOT NULL,
[HireDate] [date]     NOT NULL,
[JobTitle] [nvarchar]  (50)   NOT NULL,
[LoginID] [nvarchar]  (256)   NOT NULL,
[MaritalStatus] [nchar]  (1)   NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[NationalIDNumber] [nvarchar]  (15)   NOT NULL,
[OrganizationLevel] [smallint]     NULL,
[OrganizationNode] [hierarchyid]     NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
[SalariedFlag] [bit]     NOT NULL,
[SickLeaveHours] [smallint]     NOT NULL,
[VacationHours] [smallint]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [HumanResources].[EmployeeDepartmentHistory](
[BusinessEntityID] [int]     NOT NULL,
[DepartmentID] [smallint]     NOT NULL,
[EndDate] [date]     NULL,
[ModifiedDate] [datetime]     NOT NULL,
[ShiftID] [tinyint]     NOT NULL,
[StartDate] [date]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [HumanResources].[EmployeePayHistory](
[BusinessEntityID] [int]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[PayFrequency] [tinyint]     NOT NULL,
[Rate] [money]     NOT NULL,
[RateChangeDate] [datetime]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [HumanResources].[JobCandidate](
[JobCandidateID] [int]   IDENTITY(1,1)  NOT NULL,
[BusinessEntityID] [int]     NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Resume] [xml]     NULL,
) ON[PRIMARY]
GO

CREATE TABLE [HumanResources].[Shift](
[ShiftID] [tinyint]   IDENTITY(1,1)  NOT NULL,
[EndTime] [time]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Name] [nvarchar]  (50)   NOT NULL,
[StartTime] [time]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[Address](
[AddressID] [int]   IDENTITY(1,1)  NOT NULL,
[AddressLine1] [nvarchar]  (60)   NOT NULL,
[AddressLine2] [nvarchar]  (60)   NULL,
[City] [nvarchar]  (30)   NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[PostalCode] [nvarchar]  (15)   NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
[SpatialLocation] [geography]     NULL,
[StateProvinceID] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[AddressType](
[AddressTypeID] [int]   IDENTITY(1,1)  NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Name] [nvarchar]  (50)   NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[BusinessEntity](
[BusinessEntityID] [int]   IDENTITY(1,1)  NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[BusinessEntityAddress](
[BusinessEntityID] [int]     NOT NULL,
[AddressID] [int]     NOT NULL,
[AddressTypeID] [int]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[BusinessEntityContact](
[BusinessEntityID] [int]     NOT NULL,
[ContactTypeID] [int]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[PersonID] [int]     NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[ContactType](
[ContactTypeID] [int]   IDENTITY(1,1)  NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Name] [nvarchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[CountryRegion](
[CountryRegionCode] [nvarchar]  (3)   NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Name] [nvarchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[EmailAddress](
[BusinessEntityID] [int]     NOT NULL,
[EmailAddress] [nvarchar]  (50)   NULL,
[EmailAddressID] [int]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[Password](
[BusinessEntityID] [int]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[PasswordHash] [varchar]  (128)   NOT NULL,
[PasswordSalt] [varchar]  (10)   NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[Person](
[BusinessEntityID] [int]     NOT NULL,
[AdditionalContactInfo] [xml]     NULL,
[Demographics] [xml]     NULL,
[EmailPromotion] [int]     NOT NULL,
[FirstName] [nvarchar]  (50)   NOT NULL,
[LastName] [nvarchar]  (50)   NOT NULL,
[MiddleName] [nvarchar]  (50)   NULL,
[ModifiedDate] [datetime]     NOT NULL,
[NameStyle] [bit]     NOT NULL,
[PersonType] [nchar]  (2)   NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
[Suffix] [nvarchar]  (10)   NULL,
[Title] [nvarchar]  (8)   NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[PersonPhone](
[BusinessEntityID] [int]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[PhoneNumber] [nvarchar]  (25)   NOT NULL,
[PhoneNumberTypeID] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[PhoneNumberType](
[PhoneNumberTypeID] [int]   IDENTITY(1,1)  NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Name] [nvarchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[StateProvince](
[StateProvinceID] [int]   IDENTITY(1,1)  NOT NULL,
[CountryRegionCode] [nvarchar]  (3)   NOT NULL,
[IsOnlyStateProvinceFlag] [bit]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Name] [nvarchar]  (50)   NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
[StateProvinceCode] [nchar]  (3)   NOT NULL,
[TerritoryID] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[BillOfMaterials](
[BillOfMaterialsID] [int]   IDENTITY(1,1)  NOT NULL,
[BOMLevel] [smallint]     NOT NULL,
[ComponentID] [int]     NOT NULL,
[EndDate] [datetime]     NULL,
[ModifiedDate] [datetime]     NOT NULL,
[PerAssemblyQty] [decimal]     NOT NULL,
[ProductAssemblyID] [int]     NULL,
[StartDate] [datetime]     NOT NULL,
[UnitMeasureCode] [nchar]  (3)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[Culture](
[CultureID] [nchar]  (6)   NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Name] [nvarchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[Document](
[DocumentNode] [hierarchyid]     NOT NULL,
[ChangeNumber] [int]     NOT NULL,
[Document] [varbinary]     NULL,
[DocumentLevel] [smallint]     NULL,
[DocumentSummary] [nvarchar]     NULL,
[FileExtension] [nvarchar]  (8)   NOT NULL,
[FileName] [nvarchar]  (400)   NOT NULL,
[FolderFlag] [bit]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Owner] [int]     NOT NULL,
[Revision] [nchar]  (5)   NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
[Status] [tinyint]     NOT NULL,
[Title] [nvarchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[Illustration](
[IllustrationID] [int]   IDENTITY(1,1)  NOT NULL,
[Diagram] [xml]     NULL,
[ModifiedDate] [datetime]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[Location](
[LocationID] [smallint]   IDENTITY(1,1)  NOT NULL,
[Availability] [decimal]     NOT NULL,
[CostRate] [smallmoney]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Name] [nvarchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[Product](
[ProductID] [int]   IDENTITY(1,1)  NOT NULL,
[Class] [nchar]  (2)   NULL,
[Color] [nvarchar]  (15)   NULL,
[DaysToManufacture] [int]     NOT NULL,
[DiscontinuedDate] [datetime]     NULL,
[FinishedGoodsFlag] [bit]     NOT NULL,
[ListPrice] [money]     NOT NULL,
[MakeFlag] [bit]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Name] [nvarchar]  (50)   NOT NULL,
[ProductLine] [nchar]  (2)   NULL,
[ProductModelID] [int]     NULL,
[ProductNumber] [nvarchar]  (25)   NOT NULL,
[ProductSubcategoryID] [int]     NULL,
[ReorderPoint] [smallint]     NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
[SafetyStockLevel] [smallint]     NOT NULL,
[SellEndDate] [datetime]     NULL,
[SellStartDate] [datetime]     NOT NULL,
[Size] [nvarchar]  (5)   NULL,
[SizeUnitMeasureCode] [nchar]  (3)   NULL,
[StandardCost] [money]     NOT NULL,
[Style] [nchar]  (2)   NULL,
[Weight] [decimal]     NULL,
[WeightUnitMeasureCode] [nchar]  (3)   NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductCategory](
[ProductCategoryID] [int]   IDENTITY(1,1)  NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Name] [nvarchar]  (50)   NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductCostHistory](
[ProductID] [int]     NOT NULL,
[EndDate] [datetime]     NULL,
[ModifiedDate] [datetime]     NOT NULL,
[StandardCost] [money]     NOT NULL,
[StartDate] [datetime]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductDescription](
[ProductDescriptionID] [int]   IDENTITY(1,1)  NOT NULL,
[Description] [nvarchar]  (400)   NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductDocument](
[ProductID] [int]     NOT NULL,
[DocumentNode] [hierarchyid]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductInventory](
[ProductID] [int]     NOT NULL,
[Bin] [tinyint]     NOT NULL,
[LocationID] [smallint]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Quantity] [smallint]     NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
[Shelf] [nvarchar]  (10)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductListPriceHistory](
[ProductID] [int]     NOT NULL,
[EndDate] [datetime]     NULL,
[ListPrice] [money]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[StartDate] [datetime]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductModel](
[ProductModelID] [int]   IDENTITY(1,1)  NOT NULL,
[CatalogDescription] [xml]     NULL,
[Instructions] [xml]     NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Name] [nvarchar]  (50)   NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductModelIllustration](
[ProductModelID] [int]     NOT NULL,
[IllustrationID] [int]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductModelProductDescriptionCulture](
[ProductModelID] [int]     NOT NULL,
[CultureID] [nchar]  (6)   NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[ProductDescriptionID] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductPhoto](
[ProductPhotoID] [int]   IDENTITY(1,1)  NOT NULL,
[LargePhoto] [varbinary]     NULL,
[LargePhotoFileName] [nvarchar]  (50)   NULL,
[ModifiedDate] [datetime]     NOT NULL,
[ThumbNailPhoto] [varbinary]     NULL,
[ThumbnailPhotoFileName] [nvarchar]  (50)   NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductProductPhoto](
[ProductID] [int]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Primary] [bit]     NOT NULL,
[ProductPhotoID] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductReview](
[ProductReviewID] [int]   IDENTITY(1,1)  NOT NULL,
[Comments] [nvarchar]  (3850)   NULL,
[EmailAddress] [nvarchar]  (50)   NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[ProductID] [int]     NOT NULL,
[Rating] [int]     NOT NULL,
[ReviewDate] [datetime]     NOT NULL,
[ReviewerName] [nvarchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductSubcategory](
[ProductSubcategoryID] [int]   IDENTITY(1,1)  NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Name] [nvarchar]  (50)   NOT NULL,
[ProductCategoryID] [int]     NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ScrapReason](
[ScrapReasonID] [smallint]   IDENTITY(1,1)  NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Name] [nvarchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[TransactionHistory](
[TransactionID] [int]   IDENTITY(1,1)  NOT NULL,
[ActualCost] [money]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[ProductID] [int]     NOT NULL,
[Quantity] [int]     NOT NULL,
[ReferenceOrderID] [int]     NOT NULL,
[ReferenceOrderLineID] [int]     NOT NULL,
[TransactionDate] [datetime]     NOT NULL,
[TransactionType] [nchar]  (1)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[TransactionHistoryArchive](
[TransactionID] [int]     NOT NULL,
[ActualCost] [money]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[ProductID] [int]     NOT NULL,
[Quantity] [int]     NOT NULL,
[ReferenceOrderID] [int]     NOT NULL,
[ReferenceOrderLineID] [int]     NOT NULL,
[TransactionDate] [datetime]     NOT NULL,
[TransactionType] [nchar]  (1)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[UnitMeasure](
[UnitMeasureCode] [nchar]  (3)   NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Name] [nvarchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[WorkOrder](
[WorkOrderID] [int]   IDENTITY(1,1)  NOT NULL,
[DueDate] [datetime]     NOT NULL,
[EndDate] [datetime]     NULL,
[ModifiedDate] [datetime]     NOT NULL,
[OrderQty] [int]     NOT NULL,
[ProductID] [int]     NOT NULL,
[ScrappedQty] [smallint]     NOT NULL,
[ScrapReasonID] [smallint]     NULL,
[StartDate] [datetime]     NOT NULL,
[StockedQty] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[WorkOrderRouting](
[WorkOrderID] [int]     NOT NULL,
[ActualCost] [money]     NULL,
[ActualEndDate] [datetime]     NULL,
[ActualResourceHrs] [decimal]     NULL,
[ActualStartDate] [datetime]     NULL,
[LocationID] [smallint]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[OperationSequence] [smallint]     NOT NULL,
[PlannedCost] [money]     NOT NULL,
[ProductID] [int]     NOT NULL,
[ScheduledEndDate] [datetime]     NOT NULL,
[ScheduledStartDate] [datetime]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Purchasing].[ProductVendor](
[ProductID] [int]     NOT NULL,
[AverageLeadTime] [int]     NOT NULL,
[BusinessEntityID] [int]     NOT NULL,
[LastReceiptCost] [money]     NULL,
[LastReceiptDate] [datetime]     NULL,
[MaxOrderQty] [int]     NOT NULL,
[MinOrderQty] [int]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[OnOrderQty] [int]     NULL,
[StandardPrice] [money]     NOT NULL,
[UnitMeasureCode] [nchar]  (3)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Purchasing].[PurchaseOrderDetail](
[PurchaseOrderID] [int]     NOT NULL,
[DueDate] [datetime]     NOT NULL,
[LineTotal] [money]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[OrderQty] [smallint]     NOT NULL,
[ProductID] [int]     NOT NULL,
[PurchaseOrderDetailID] [int]     NOT NULL,
[ReceivedQty] [decimal]     NOT NULL,
[RejectedQty] [decimal]     NOT NULL,
[StockedQty] [decimal]     NOT NULL,
[UnitPrice] [money]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Purchasing].[PurchaseOrderHeader](
[PurchaseOrderID] [int]   IDENTITY(1,1)  NOT NULL,
[EmployeeID] [int]     NOT NULL,
[Freight] [money]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[OrderDate] [datetime]     NOT NULL,
[RevisionNumber] [tinyint]     NOT NULL,
[ShipDate] [datetime]     NULL,
[ShipMethodID] [int]     NOT NULL,
[Status] [tinyint]     NOT NULL,
[SubTotal] [money]     NOT NULL,
[TaxAmt] [money]     NOT NULL,
[TotalDue] [money]     NOT NULL,
[VendorID] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Purchasing].[ShipMethod](
[ShipMethodID] [int]   IDENTITY(1,1)  NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Name] [nvarchar]  (50)   NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
[ShipBase] [money]     NOT NULL,
[ShipRate] [money]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Purchasing].[Vendor](
[BusinessEntityID] [int]     NOT NULL,
[AccountNumber] [nvarchar]  (15)   NOT NULL,
[ActiveFlag] [bit]     NOT NULL,
[CreditRating] [tinyint]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Name] [nvarchar]  (50)   NOT NULL,
[PreferredVendorStatus] [bit]     NOT NULL,
[PurchasingWebServiceURL] [nvarchar]  (1024)   NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[CountryRegionCurrency](
[CountryRegionCode] [nvarchar]  (3)   NOT NULL,
[CurrencyCode] [nchar]  (3)   NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[CreditCard](
[CreditCardID] [int]   IDENTITY(1,1)  NOT NULL,
[CardNumber] [nvarchar]  (25)   NOT NULL,
[CardType] [nvarchar]  (50)   NOT NULL,
[ExpMonth] [tinyint]     NOT NULL,
[ExpYear] [smallint]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[Currency](
[CurrencyCode] [nchar]  (3)   NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Name] [nvarchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[CurrencyRate](
[CurrencyRateID] [int]   IDENTITY(1,1)  NOT NULL,
[AverageRate] [money]     NOT NULL,
[CurrencyRateDate] [datetime]     NOT NULL,
[EndOfDayRate] [money]     NOT NULL,
[FromCurrencyCode] [nchar]  (3)   NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[ToCurrencyCode] [nchar]  (3)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[Customer](
[CustomerID] [int]   IDENTITY(1,1)  NOT NULL,
[AccountNumber] [varchar]  (10)   NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[PersonID] [int]     NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
[StoreID] [int]     NULL,
[TerritoryID] [int]     NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[PersonCreditCard](
[BusinessEntityID] [int]     NOT NULL,
[CreditCardID] [int]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[SalesOrderDetail](
[SalesOrderID] [int]     NOT NULL,
[CarrierTrackingNumber] [nvarchar]  (25)   NULL,
[LineTotal] [decimal]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[OrderQty] [smallint]     NOT NULL,
[ProductID] [int]     NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
[SalesOrderDetailID] [int]     NOT NULL,
[SpecialOfferID] [int]     NOT NULL,
[UnitPrice] [money]     NOT NULL,
[UnitPriceDiscount] [money]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[SalesOrderHeader](
[SalesOrderID] [int]   IDENTITY(1,1)  NOT NULL,
[AccountNumber] [nvarchar]  (15)   NULL,
[BillToAddressID] [int]     NOT NULL,
[Comment] [nvarchar]  (128)   NULL,
[CreditCardApprovalCode] [varchar]  (15)   NULL,
[CreditCardID] [int]     NULL,
[CurrencyRateID] [int]     NULL,
[CustomerID] [int]     NOT NULL,
[DueDate] [datetime]     NOT NULL,
[Freight] [money]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[OnlineOrderFlag] [bit]     NOT NULL,
[OrderDate] [datetime]     NOT NULL,
[PurchaseOrderNumber] [nvarchar]  (25)   NULL,
[RevisionNumber] [tinyint]     NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
[SalesOrderNumber] [nvarchar]  (25)   NOT NULL,
[SalesPersonID] [int]     NULL,
[ShipDate] [datetime]     NULL,
[ShipMethodID] [int]     NOT NULL,
[ShipToAddressID] [int]     NOT NULL,
[Status] [tinyint]     NOT NULL,
[SubTotal] [money]     NOT NULL,
[TaxAmt] [money]     NOT NULL,
[TerritoryID] [int]     NULL,
[TotalDue] [money]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[SalesOrderHeaderSalesReason](
[SalesOrderID] [int]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[SalesReasonID] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[SalesPerson](
[BusinessEntityID] [int]     NOT NULL,
[Bonus] [money]     NOT NULL,
[CommissionPct] [smallmoney]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
[SalesLastYear] [money]     NOT NULL,
[SalesQuota] [money]     NULL,
[SalesYTD] [money]     NOT NULL,
[TerritoryID] [int]     NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[SalesPersonQuotaHistory](
[BusinessEntityID] [int]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[QuotaDate] [datetime]     NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
[SalesQuota] [money]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[SalesReason](
[SalesReasonID] [int]   IDENTITY(1,1)  NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Name] [nvarchar]  (50)   NOT NULL,
[ReasonType] [nvarchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[SalesTaxRate](
[SalesTaxRateID] [int]   IDENTITY(1,1)  NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Name] [nvarchar]  (50)   NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
[StateProvinceID] [int]     NOT NULL,
[TaxRate] [smallmoney]     NOT NULL,
[TaxType] [tinyint]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[SalesTerritory](
[TerritoryID] [int]   IDENTITY(1,1)  NOT NULL,
[CostLastYear] [money]     NOT NULL,
[CostYTD] [money]     NOT NULL,
[CountryRegionCode] [nvarchar]  (3)   NOT NULL,
[Group] [nvarchar]  (50)   NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Name] [nvarchar]  (50)   NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
[SalesLastYear] [money]     NOT NULL,
[SalesYTD] [money]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[SalesTerritoryHistory](
[BusinessEntityID] [int]     NOT NULL,
[EndDate] [datetime]     NULL,
[ModifiedDate] [datetime]     NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
[StartDate] [datetime]     NOT NULL,
[TerritoryID] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[ShoppingCartItem](
[ShoppingCartItemID] [int]   IDENTITY(1,1)  NOT NULL,
[DateCreated] [datetime]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[ProductID] [int]     NOT NULL,
[Quantity] [int]     NOT NULL,
[ShoppingCartID] [nvarchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[SpecialOffer](
[SpecialOfferID] [int]   IDENTITY(1,1)  NOT NULL,
[Category] [nvarchar]  (50)   NOT NULL,
[Description] [nvarchar]  (255)   NOT NULL,
[DiscountPct] [smallmoney]     NOT NULL,
[EndDate] [datetime]     NOT NULL,
[MaxQty] [int]     NULL,
[MinQty] [int]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
[StartDate] [datetime]     NOT NULL,
[Type] [nvarchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[SpecialOfferProduct](
[SpecialOfferID] [int]     NOT NULL,
[ModifiedDate] [datetime]     NOT NULL,
[ProductID] [int]     NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[Store](
[BusinessEntityID] [int]     NOT NULL,
[Demographics] [xml]     NULL,
[ModifiedDate] [datetime]     NOT NULL,
[Name] [nvarchar]  (50)   NOT NULL,
[rowguid] [uniqueidentifier]     NOT NULL,
[SalesPersonID] [int]     NULL,
) ON[PRIMARY]
GO

ALTER TABLE[dbo].[AWBuildVersion]
ADD CONSTRAINT[PK_AWBuildVersion_SystemInformationID] PRIMARY KEY CLUSTERED
(
SystemInformationID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[DatabaseLog]
ADD CONSTRAINT[PK_DatabaseLog_DatabaseLogID] PRIMARY KEY NONCLUSTERED
(
DatabaseLogID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[ErrorLog]
ADD CONSTRAINT[PK_ErrorLog_ErrorLogID] PRIMARY KEY CLUSTERED
(
ErrorLogID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[HumanResources].[Department]
ADD CONSTRAINT[PK_Department_DepartmentID] PRIMARY KEY CLUSTERED
(
DepartmentID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_Department_Name] ON[HumanResources].[Department]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[HumanResources].[Employee]
ADD CONSTRAINT[PK_Employee_BusinessEntityID] PRIMARY KEY CLUSTERED
(
BusinessEntityID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_Employee_LoginID] ON[HumanResources].[Employee]
(
[LoginID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_Employee_NationalIDNumber] ON[HumanResources].[Employee]
(
[NationalIDNumber] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_Employee_rowguid] ON[HumanResources].[Employee]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Employee_OrganizationLevel_OrganizationNode] ON[HumanResources].[Employee]
(
[OrganizationLevel] ASC
,[OrganizationNode] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Employee_OrganizationNode] ON[HumanResources].[Employee]
(
[OrganizationNode] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[HumanResources].[EmployeeDepartmentHistory]
ADD CONSTRAINT[PK_EmployeeDepartmentHistory_BusinessEntityID_StartDate_DepartmentID] PRIMARY KEY CLUSTERED
(
BusinessEntityID ASC
,StartDate ASC
,DepartmentID ASC
,ShiftID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_EmployeeDepartmentHistory_DepartmentID] ON[HumanResources].[EmployeeDepartmentHistory]
(
[DepartmentID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_EmployeeDepartmentHistory_ShiftID] ON[HumanResources].[EmployeeDepartmentHistory]
(
[ShiftID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[HumanResources].[EmployeePayHistory]
ADD CONSTRAINT[PK_EmployeePayHistory_BusinessEntityID_RateChangeDate] PRIMARY KEY CLUSTERED
(
BusinessEntityID ASC
,RateChangeDate ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[HumanResources].[JobCandidate]
ADD CONSTRAINT[PK_JobCandidate_JobCandidateID] PRIMARY KEY CLUSTERED
(
JobCandidateID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_JobCandidate_BusinessEntityID] ON[HumanResources].[JobCandidate]
(
[BusinessEntityID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[HumanResources].[Shift]
ADD CONSTRAINT[PK_Shift_ShiftID] PRIMARY KEY CLUSTERED
(
ShiftID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_Shift_Name] ON[HumanResources].[Shift]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_Shift_StartTime_EndTime] ON[HumanResources].[Shift]
(
[StartTime] ASC
,[EndTime] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Person].[Address]
ADD CONSTRAINT[PK_Address_AddressID] PRIMARY KEY CLUSTERED
(
AddressID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_Address_rowguid] ON[Person].[Address]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[IX_Address_AddressLine1_AddressLine2_City_StateProvinceID_PostalCode] ON[Person].[Address]
(
[AddressLine1] ASC
,[AddressLine2] ASC
,[City] ASC
,[StateProvinceID] ASC
,[PostalCode] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Address_StateProvinceID] ON[Person].[Address]
(
[StateProvinceID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Person].[AddressType]
ADD CONSTRAINT[PK_AddressType_AddressTypeID] PRIMARY KEY CLUSTERED
(
AddressTypeID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_AddressType_Name] ON[Person].[AddressType]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_AddressType_rowguid] ON[Person].[AddressType]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Person].[BusinessEntity]
ADD CONSTRAINT[PK_BusinessEntity_BusinessEntityID] PRIMARY KEY CLUSTERED
(
BusinessEntityID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_BusinessEntity_rowguid] ON[Person].[BusinessEntity]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Person].[BusinessEntityAddress]
ADD CONSTRAINT[PK_BusinessEntityAddress_BusinessEntityID_AddressID_AddressTypeID] PRIMARY KEY CLUSTERED
(
BusinessEntityID ASC
,AddressID ASC
,AddressTypeID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_BusinessEntityAddress_rowguid] ON[Person].[BusinessEntityAddress]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_BusinessEntityAddress_AddressID] ON[Person].[BusinessEntityAddress]
(
[AddressID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_BusinessEntityAddress_AddressTypeID] ON[Person].[BusinessEntityAddress]
(
[AddressTypeID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Person].[BusinessEntityContact]
ADD CONSTRAINT[PK_BusinessEntityContact_BusinessEntityID_PersonID_ContactTypeID] PRIMARY KEY CLUSTERED
(
BusinessEntityID ASC
,PersonID ASC
,ContactTypeID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_BusinessEntityContact_rowguid] ON[Person].[BusinessEntityContact]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_BusinessEntityContact_ContactTypeID] ON[Person].[BusinessEntityContact]
(
[ContactTypeID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_BusinessEntityContact_PersonID] ON[Person].[BusinessEntityContact]
(
[PersonID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Person].[ContactType]
ADD CONSTRAINT[PK_ContactType_ContactTypeID] PRIMARY KEY CLUSTERED
(
ContactTypeID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_ContactType_Name] ON[Person].[ContactType]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Person].[CountryRegion]
ADD CONSTRAINT[PK_CountryRegion_CountryRegionCode] PRIMARY KEY CLUSTERED
(
CountryRegionCode ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_CountryRegion_Name] ON[Person].[CountryRegion]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Person].[EmailAddress]
ADD CONSTRAINT[PK_EmailAddress_BusinessEntityID_EmailAddressID] PRIMARY KEY CLUSTERED
(
BusinessEntityID ASC
,EmailAddressID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_EmailAddress_EmailAddress] ON[Person].[EmailAddress]
(
[EmailAddress] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Person].[Password]
ADD CONSTRAINT[PK_Password_BusinessEntityID] PRIMARY KEY CLUSTERED
(
BusinessEntityID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Person].[Person]
ADD CONSTRAINT[PK_Person_BusinessEntityID] PRIMARY KEY CLUSTERED
(
BusinessEntityID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_Person_rowguid] ON[Person].[Person]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Person_LastName_FirstName_MiddleName] ON[Person].[Person]
(
[LastName] ASC
,[FirstName] ASC
,[MiddleName] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Person].[PersonPhone]
ADD CONSTRAINT[PK_PersonPhone_BusinessEntityID_PhoneNumber_PhoneNumberTypeID] PRIMARY KEY CLUSTERED
(
BusinessEntityID ASC
,PhoneNumber ASC
,PhoneNumberTypeID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_PersonPhone_PhoneNumber] ON[Person].[PersonPhone]
(
[PhoneNumber] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Person].[PhoneNumberType]
ADD CONSTRAINT[PK_PhoneNumberType_PhoneNumberTypeID] PRIMARY KEY CLUSTERED
(
PhoneNumberTypeID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Person].[StateProvince]
ADD CONSTRAINT[PK_StateProvince_StateProvinceID] PRIMARY KEY CLUSTERED
(
StateProvinceID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_StateProvince_Name] ON[Person].[StateProvince]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_StateProvince_rowguid] ON[Person].[StateProvince]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_StateProvince_StateProvinceCode_CountryRegionCode] ON[Person].[StateProvince]
(
[StateProvinceCode] ASC
,[CountryRegionCode] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Production].[BillOfMaterials]
ADD CONSTRAINT[PK_BillOfMaterials_BillOfMaterialsID] PRIMARY KEY NONCLUSTERED
(
BillOfMaterialsID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE CLUSTERED INDEX[AK_BillOfMaterials_ProductAssemblyID_ComponentID_StartDate] ON[Production].[BillOfMaterials]
(
[ProductAssemblyID] ASC
,[ComponentID] ASC
,[StartDate] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_BillOfMaterials_UnitMeasureCode] ON[Production].[BillOfMaterials]
(
[UnitMeasureCode] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Production].[Culture]
ADD CONSTRAINT[PK_Culture_CultureID] PRIMARY KEY CLUSTERED
(
CultureID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_Culture_Name] ON[Production].[Culture]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Production].[Document]
ADD CONSTRAINT[PK_Document_DocumentNode] PRIMARY KEY CLUSTERED
(
DocumentNode ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_Document_DocumentLevel_DocumentNode] ON[Production].[Document]
(
[DocumentLevel] ASC
,[DocumentNode] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_Document_rowguid] ON[Production].[Document]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ__Document__F73921F793071A63] ON[Production].[Document]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Document_FileName_Revision] ON[Production].[Document]
(
[FileName] ASC
,[Revision] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Production].[Illustration]
ADD CONSTRAINT[PK_Illustration_IllustrationID] PRIMARY KEY CLUSTERED
(
IllustrationID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Production].[Location]
ADD CONSTRAINT[PK_Location_LocationID] PRIMARY KEY CLUSTERED
(
LocationID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_Location_Name] ON[Production].[Location]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Production].[Product]
ADD CONSTRAINT[PK_Product_ProductID] PRIMARY KEY CLUSTERED
(
ProductID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_Product_Name] ON[Production].[Product]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_Product_ProductNumber] ON[Production].[Product]
(
[ProductNumber] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_Product_rowguid] ON[Production].[Product]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Production].[ProductCategory]
ADD CONSTRAINT[PK_ProductCategory_ProductCategoryID] PRIMARY KEY CLUSTERED
(
ProductCategoryID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_ProductCategory_Name] ON[Production].[ProductCategory]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_ProductCategory_rowguid] ON[Production].[ProductCategory]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Production].[ProductCostHistory]
ADD CONSTRAINT[PK_ProductCostHistory_ProductID_StartDate] PRIMARY KEY CLUSTERED
(
ProductID ASC
,StartDate ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Production].[ProductDescription]
ADD CONSTRAINT[PK_ProductDescription_ProductDescriptionID] PRIMARY KEY CLUSTERED
(
ProductDescriptionID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_ProductDescription_rowguid] ON[Production].[ProductDescription]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Production].[ProductDocument]
ADD CONSTRAINT[PK_ProductDocument_ProductID_DocumentNode] PRIMARY KEY CLUSTERED
(
ProductID ASC
,DocumentNode ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Production].[ProductInventory]
ADD CONSTRAINT[PK_ProductInventory_ProductID_LocationID] PRIMARY KEY CLUSTERED
(
ProductID ASC
,LocationID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Production].[ProductListPriceHistory]
ADD CONSTRAINT[PK_ProductListPriceHistory_ProductID_StartDate] PRIMARY KEY CLUSTERED
(
ProductID ASC
,StartDate ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Production].[ProductModel]
ADD CONSTRAINT[PK_ProductModel_ProductModelID] PRIMARY KEY CLUSTERED
(
ProductModelID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_ProductModel_Name] ON[Production].[ProductModel]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_ProductModel_rowguid] ON[Production].[ProductModel]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Production].[ProductModelIllustration]
ADD CONSTRAINT[PK_ProductModelIllustration_ProductModelID_IllustrationID] PRIMARY KEY CLUSTERED
(
ProductModelID ASC
,IllustrationID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Production].[ProductModelProductDescriptionCulture]
ADD CONSTRAINT[PK_ProductModelProductDescriptionCulture_ProductModelID_ProductDescriptionID_CultureID] PRIMARY KEY CLUSTERED
(
ProductModelID ASC
,ProductDescriptionID ASC
,CultureID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Production].[ProductPhoto]
ADD CONSTRAINT[PK_ProductPhoto_ProductPhotoID] PRIMARY KEY CLUSTERED
(
ProductPhotoID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Production].[ProductProductPhoto]
ADD CONSTRAINT[PK_ProductProductPhoto_ProductID_ProductPhotoID] PRIMARY KEY NONCLUSTERED
(
ProductID ASC
,ProductPhotoID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Production].[ProductReview]
ADD CONSTRAINT[PK_ProductReview_ProductReviewID] PRIMARY KEY CLUSTERED
(
ProductReviewID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_ProductReview_ProductID_Name] ON[Production].[ProductReview]
(
[Comments] ASC
,[ProductID] ASC
,[ReviewerName] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Production].[ProductSubcategory]
ADD CONSTRAINT[PK_ProductSubcategory_ProductSubcategoryID] PRIMARY KEY CLUSTERED
(
ProductSubcategoryID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_ProductSubcategory_Name] ON[Production].[ProductSubcategory]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_ProductSubcategory_rowguid] ON[Production].[ProductSubcategory]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Production].[ScrapReason]
ADD CONSTRAINT[PK_ScrapReason_ScrapReasonID] PRIMARY KEY CLUSTERED
(
ScrapReasonID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_ScrapReason_Name] ON[Production].[ScrapReason]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Production].[TransactionHistory]
ADD CONSTRAINT[PK_TransactionHistory_TransactionID] PRIMARY KEY CLUSTERED
(
TransactionID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_TransactionHistory_ProductID] ON[Production].[TransactionHistory]
(
[ProductID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_TransactionHistory_ReferenceOrderID_ReferenceOrderLineID] ON[Production].[TransactionHistory]
(
[ReferenceOrderID] ASC
,[ReferenceOrderLineID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Production].[TransactionHistoryArchive]
ADD CONSTRAINT[PK_TransactionHistoryArchive_TransactionID] PRIMARY KEY CLUSTERED
(
TransactionID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_TransactionHistoryArchive_ProductID] ON[Production].[TransactionHistoryArchive]
(
[ProductID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_TransactionHistoryArchive_ReferenceOrderID_ReferenceOrderLineID] ON[Production].[TransactionHistoryArchive]
(
[ReferenceOrderID] ASC
,[ReferenceOrderLineID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Production].[UnitMeasure]
ADD CONSTRAINT[PK_UnitMeasure_UnitMeasureCode] PRIMARY KEY CLUSTERED
(
UnitMeasureCode ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_UnitMeasure_Name] ON[Production].[UnitMeasure]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Production].[WorkOrder]
ADD CONSTRAINT[PK_WorkOrder_WorkOrderID] PRIMARY KEY CLUSTERED
(
WorkOrderID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_WorkOrder_ProductID] ON[Production].[WorkOrder]
(
[ProductID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_WorkOrder_ScrapReasonID] ON[Production].[WorkOrder]
(
[ScrapReasonID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Production].[WorkOrderRouting]
ADD CONSTRAINT[PK_WorkOrderRouting_WorkOrderID_ProductID_OperationSequence] PRIMARY KEY CLUSTERED
(
WorkOrderID ASC
,ProductID ASC
,OperationSequence ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_WorkOrderRouting_ProductID] ON[Production].[WorkOrderRouting]
(
[ProductID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Purchasing].[ProductVendor]
ADD CONSTRAINT[PK_ProductVendor_ProductID_BusinessEntityID] PRIMARY KEY CLUSTERED
(
ProductID ASC
,BusinessEntityID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_ProductVendor_BusinessEntityID] ON[Purchasing].[ProductVendor]
(
[BusinessEntityID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_ProductVendor_UnitMeasureCode] ON[Purchasing].[ProductVendor]
(
[UnitMeasureCode] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Purchasing].[PurchaseOrderDetail]
ADD CONSTRAINT[PK_PurchaseOrderDetail_PurchaseOrderID_PurchaseOrderDetailID] PRIMARY KEY CLUSTERED
(
PurchaseOrderID ASC
,PurchaseOrderDetailID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_PurchaseOrderDetail_ProductID] ON[Purchasing].[PurchaseOrderDetail]
(
[ProductID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Purchasing].[PurchaseOrderHeader]
ADD CONSTRAINT[PK_PurchaseOrderHeader_PurchaseOrderID] PRIMARY KEY CLUSTERED
(
PurchaseOrderID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_PurchaseOrderHeader_EmployeeID] ON[Purchasing].[PurchaseOrderHeader]
(
[EmployeeID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_PurchaseOrderHeader_VendorID] ON[Purchasing].[PurchaseOrderHeader]
(
[VendorID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Purchasing].[ShipMethod]
ADD CONSTRAINT[PK_ShipMethod_ShipMethodID] PRIMARY KEY CLUSTERED
(
ShipMethodID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_ShipMethod_Name] ON[Purchasing].[ShipMethod]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_ShipMethod_rowguid] ON[Purchasing].[ShipMethod]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Purchasing].[Vendor]
ADD CONSTRAINT[PK_Vendor_BusinessEntityID] PRIMARY KEY CLUSTERED
(
BusinessEntityID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_Vendor_AccountNumber] ON[Purchasing].[Vendor]
(
[AccountNumber] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Sales].[CountryRegionCurrency]
ADD CONSTRAINT[PK_CountryRegionCurrency_CountryRegionCode_CurrencyCode] PRIMARY KEY CLUSTERED
(
CountryRegionCode ASC
,CurrencyCode ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_CountryRegionCurrency_CurrencyCode] ON[Sales].[CountryRegionCurrency]
(
[CurrencyCode] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Sales].[CreditCard]
ADD CONSTRAINT[PK_CreditCard_CreditCardID] PRIMARY KEY CLUSTERED
(
CreditCardID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_CreditCard_CardNumber] ON[Sales].[CreditCard]
(
[CardNumber] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Sales].[Currency]
ADD CONSTRAINT[PK_Currency_CurrencyCode] PRIMARY KEY CLUSTERED
(
CurrencyCode ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_Currency_Name] ON[Sales].[Currency]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Sales].[CurrencyRate]
ADD CONSTRAINT[PK_CurrencyRate_CurrencyRateID] PRIMARY KEY CLUSTERED
(
CurrencyRateID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_CurrencyRate_CurrencyRateDate_FromCurrencyCode_ToCurrencyCode] ON[Sales].[CurrencyRate]
(
[CurrencyRateDate] ASC
,[FromCurrencyCode] ASC
,[ToCurrencyCode] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Sales].[Customer]
ADD CONSTRAINT[PK_Customer_CustomerID] PRIMARY KEY CLUSTERED
(
CustomerID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_Customer_AccountNumber] ON[Sales].[Customer]
(
[AccountNumber] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_Customer_rowguid] ON[Sales].[Customer]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Customer_TerritoryID] ON[Sales].[Customer]
(
[TerritoryID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Sales].[PersonCreditCard]
ADD CONSTRAINT[PK_PersonCreditCard_BusinessEntityID_CreditCardID] PRIMARY KEY CLUSTERED
(
BusinessEntityID ASC
,CreditCardID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Sales].[SalesOrderDetail]
ADD CONSTRAINT[PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID] PRIMARY KEY CLUSTERED
(
SalesOrderID ASC
,SalesOrderDetailID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_SalesOrderDetail_rowguid] ON[Sales].[SalesOrderDetail]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_SalesOrderDetail_ProductID] ON[Sales].[SalesOrderDetail]
(
[ProductID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Sales].[SalesOrderHeader]
ADD CONSTRAINT[PK_SalesOrderHeader_SalesOrderID] PRIMARY KEY CLUSTERED
(
SalesOrderID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_SalesOrderHeader_rowguid] ON[Sales].[SalesOrderHeader]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_SalesOrderHeader_SalesOrderNumber] ON[Sales].[SalesOrderHeader]
(
[SalesOrderNumber] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_SalesOrderHeader_CustomerID] ON[Sales].[SalesOrderHeader]
(
[CustomerID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_SalesOrderHeader_SalesPersonID] ON[Sales].[SalesOrderHeader]
(
[SalesPersonID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Sales].[SalesOrderHeaderSalesReason]
ADD CONSTRAINT[PK_SalesOrderHeaderSalesReason_SalesOrderID_SalesReasonID] PRIMARY KEY CLUSTERED
(
SalesOrderID ASC
,SalesReasonID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Sales].[SalesPerson]
ADD CONSTRAINT[PK_SalesPerson_BusinessEntityID] PRIMARY KEY CLUSTERED
(
BusinessEntityID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_SalesPerson_rowguid] ON[Sales].[SalesPerson]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Sales].[SalesPersonQuotaHistory]
ADD CONSTRAINT[PK_SalesPersonQuotaHistory_BusinessEntityID_QuotaDate] PRIMARY KEY CLUSTERED
(
BusinessEntityID ASC
,QuotaDate ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_SalesPersonQuotaHistory_rowguid] ON[Sales].[SalesPersonQuotaHistory]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Sales].[SalesReason]
ADD CONSTRAINT[PK_SalesReason_SalesReasonID] PRIMARY KEY CLUSTERED
(
SalesReasonID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Sales].[SalesTaxRate]
ADD CONSTRAINT[PK_SalesTaxRate_SalesTaxRateID] PRIMARY KEY CLUSTERED
(
SalesTaxRateID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_SalesTaxRate_rowguid] ON[Sales].[SalesTaxRate]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_SalesTaxRate_StateProvinceID_TaxType] ON[Sales].[SalesTaxRate]
(
[StateProvinceID] ASC
,[TaxType] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Sales].[SalesTerritory]
ADD CONSTRAINT[PK_SalesTerritory_TerritoryID] PRIMARY KEY CLUSTERED
(
TerritoryID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_SalesTerritory_Name] ON[Sales].[SalesTerritory]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_SalesTerritory_rowguid] ON[Sales].[SalesTerritory]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Sales].[SalesTerritoryHistory]
ADD CONSTRAINT[PK_SalesTerritoryHistory_BusinessEntityID_StartDate_TerritoryID] PRIMARY KEY CLUSTERED
(
BusinessEntityID ASC
,StartDate ASC
,TerritoryID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_SalesTerritoryHistory_rowguid] ON[Sales].[SalesTerritoryHistory]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Sales].[ShoppingCartItem]
ADD CONSTRAINT[PK_ShoppingCartItem_ShoppingCartItemID] PRIMARY KEY CLUSTERED
(
ShoppingCartItemID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_ShoppingCartItem_ShoppingCartID_ProductID] ON[Sales].[ShoppingCartItem]
(
[ShoppingCartID] ASC
,[ProductID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Sales].[SpecialOffer]
ADD CONSTRAINT[PK_SpecialOffer_SpecialOfferID] PRIMARY KEY CLUSTERED
(
SpecialOfferID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_SpecialOffer_rowguid] ON[Sales].[SpecialOffer]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Sales].[SpecialOfferProduct]
ADD CONSTRAINT[PK_SpecialOfferProduct_SpecialOfferID_ProductID] PRIMARY KEY CLUSTERED
(
SpecialOfferID ASC
,ProductID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_SpecialOfferProduct_rowguid] ON[Sales].[SpecialOfferProduct]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_SpecialOfferProduct_ProductID] ON[Sales].[SpecialOfferProduct]
(
[ProductID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[Sales].[Store]
ADD CONSTRAINT[PK_Store_BusinessEntityID] PRIMARY KEY CLUSTERED
(
BusinessEntityID ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AK_Store_rowguid] ON[Sales].[Store]
(
[rowguid] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Store_SalesPersonID] ON[Sales].[Store]
(
[SalesPersonID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO



ALTER TABLE[HumanResources].[Employee]  WITH CHECK ADD  CONSTRAINT[FK_Employee_Person_BusinessEntityID] FOREIGN KEY([BusinessEntityID])
REFERENCES[Person].[Person]([BusinessEntityID])
GO
ALTER TABLE[HumanResources].[Employee] CHECK CONSTRAINT[FK_Employee_Person_BusinessEntityID]
GO
ALTER TABLE[HumanResources].[EmployeeDepartmentHistory]  WITH CHECK ADD  CONSTRAINT[FK_EmployeeDepartmentHistory_Department_DepartmentID] FOREIGN KEY([DepartmentID])
REFERENCES[HumanResources].[Department]([DepartmentID])
GO
ALTER TABLE[HumanResources].[EmployeeDepartmentHistory] CHECK CONSTRAINT[FK_EmployeeDepartmentHistory_Department_DepartmentID]
GO
ALTER TABLE[HumanResources].[EmployeeDepartmentHistory]  WITH CHECK ADD  CONSTRAINT[FK_EmployeeDepartmentHistory_Employee_BusinessEntityID] FOREIGN KEY([BusinessEntityID])
REFERENCES[HumanResources].[Employee]([BusinessEntityID])
GO
ALTER TABLE[HumanResources].[EmployeeDepartmentHistory] CHECK CONSTRAINT[FK_EmployeeDepartmentHistory_Employee_BusinessEntityID]
GO
ALTER TABLE[HumanResources].[EmployeeDepartmentHistory]  WITH CHECK ADD  CONSTRAINT[FK_EmployeeDepartmentHistory_Shift_ShiftID] FOREIGN KEY([ShiftID])
REFERENCES[HumanResources].[Shift]([ShiftID])
GO
ALTER TABLE[HumanResources].[EmployeeDepartmentHistory] CHECK CONSTRAINT[FK_EmployeeDepartmentHistory_Shift_ShiftID]
GO
ALTER TABLE[HumanResources].[EmployeePayHistory]  WITH CHECK ADD  CONSTRAINT[FK_EmployeePayHistory_Employee_BusinessEntityID] FOREIGN KEY([BusinessEntityID])
REFERENCES[HumanResources].[Employee]([BusinessEntityID])
GO
ALTER TABLE[HumanResources].[EmployeePayHistory] CHECK CONSTRAINT[FK_EmployeePayHistory_Employee_BusinessEntityID]
GO
ALTER TABLE[HumanResources].[JobCandidate]  WITH CHECK ADD  CONSTRAINT[FK_JobCandidate_Employee_BusinessEntityID] FOREIGN KEY([BusinessEntityID])
REFERENCES[HumanResources].[Employee]([BusinessEntityID])
GO
ALTER TABLE[HumanResources].[JobCandidate] CHECK CONSTRAINT[FK_JobCandidate_Employee_BusinessEntityID]
GO

ALTER TABLE[Person].[Address]  WITH CHECK ADD  CONSTRAINT[FK_Address_StateProvince_StateProvinceID] FOREIGN KEY([StateProvinceID])
REFERENCES[Person].[StateProvince]([StateProvinceID])
GO
ALTER TABLE[Person].[Address] CHECK CONSTRAINT[FK_Address_StateProvince_StateProvinceID]
GO
ALTER TABLE[Person].[BusinessEntityAddress]  WITH CHECK ADD  CONSTRAINT[FK_BusinessEntityAddress_Address_AddressID] FOREIGN KEY([AddressID])
REFERENCES[Person].[Address]([AddressID])
GO
ALTER TABLE[Person].[BusinessEntityAddress] CHECK CONSTRAINT[FK_BusinessEntityAddress_Address_AddressID]
GO
ALTER TABLE[Person].[BusinessEntityAddress]  WITH CHECK ADD  CONSTRAINT[FK_BusinessEntityAddress_AddressType_AddressTypeID] FOREIGN KEY([AddressTypeID])
REFERENCES[Person].[AddressType]([AddressTypeID])
GO
ALTER TABLE[Person].[BusinessEntityAddress] CHECK CONSTRAINT[FK_BusinessEntityAddress_AddressType_AddressTypeID]
GO
ALTER TABLE[Person].[BusinessEntityAddress]  WITH CHECK ADD  CONSTRAINT[FK_BusinessEntityAddress_BusinessEntity_BusinessEntityID] FOREIGN KEY([BusinessEntityID])
REFERENCES[Person].[BusinessEntity]([BusinessEntityID])
GO
ALTER TABLE[Person].[BusinessEntityAddress] CHECK CONSTRAINT[FK_BusinessEntityAddress_BusinessEntity_BusinessEntityID]
GO
ALTER TABLE[Person].[BusinessEntityContact]  WITH CHECK ADD  CONSTRAINT[FK_BusinessEntityContact_BusinessEntity_BusinessEntityID] FOREIGN KEY([BusinessEntityID])
REFERENCES[Person].[BusinessEntity]([BusinessEntityID])
GO
ALTER TABLE[Person].[BusinessEntityContact] CHECK CONSTRAINT[FK_BusinessEntityContact_BusinessEntity_BusinessEntityID]
GO
ALTER TABLE[Person].[BusinessEntityContact]  WITH CHECK ADD  CONSTRAINT[FK_BusinessEntityContact_ContactType_ContactTypeID] FOREIGN KEY([ContactTypeID])
REFERENCES[Person].[ContactType]([ContactTypeID])
GO
ALTER TABLE[Person].[BusinessEntityContact] CHECK CONSTRAINT[FK_BusinessEntityContact_ContactType_ContactTypeID]
GO
ALTER TABLE[Person].[BusinessEntityContact]  WITH CHECK ADD  CONSTRAINT[FK_BusinessEntityContact_Person_PersonID] FOREIGN KEY([PersonID])
REFERENCES[Person].[Person]([BusinessEntityID])
GO
ALTER TABLE[Person].[BusinessEntityContact] CHECK CONSTRAINT[FK_BusinessEntityContact_Person_PersonID]
GO
ALTER TABLE[Person].[EmailAddress]  WITH CHECK ADD  CONSTRAINT[FK_EmailAddress_Person_BusinessEntityID] FOREIGN KEY([BusinessEntityID])
REFERENCES[Person].[Person]([BusinessEntityID])
GO
ALTER TABLE[Person].[EmailAddress] CHECK CONSTRAINT[FK_EmailAddress_Person_BusinessEntityID]
GO
ALTER TABLE[Person].[Password]  WITH CHECK ADD  CONSTRAINT[FK_Password_Person_BusinessEntityID] FOREIGN KEY([BusinessEntityID])
REFERENCES[Person].[Person]([BusinessEntityID])
GO
ALTER TABLE[Person].[Password] CHECK CONSTRAINT[FK_Password_Person_BusinessEntityID]
GO
ALTER TABLE[Person].[Person]  WITH CHECK ADD  CONSTRAINT[FK_Person_BusinessEntity_BusinessEntityID] FOREIGN KEY([BusinessEntityID])
REFERENCES[Person].[BusinessEntity]([BusinessEntityID])
GO
ALTER TABLE[Person].[Person] CHECK CONSTRAINT[FK_Person_BusinessEntity_BusinessEntityID]
GO
ALTER TABLE[Person].[PersonPhone]  WITH CHECK ADD  CONSTRAINT[FK_PersonPhone_Person_BusinessEntityID] FOREIGN KEY([BusinessEntityID])
REFERENCES[Person].[Person]([BusinessEntityID])
GO
ALTER TABLE[Person].[PersonPhone] CHECK CONSTRAINT[FK_PersonPhone_Person_BusinessEntityID]
GO
ALTER TABLE[Person].[PersonPhone]  WITH CHECK ADD  CONSTRAINT[FK_PersonPhone_PhoneNumberType_PhoneNumberTypeID] FOREIGN KEY([PhoneNumberTypeID])
REFERENCES[Person].[PhoneNumberType]([PhoneNumberTypeID])
GO
ALTER TABLE[Person].[PersonPhone] CHECK CONSTRAINT[FK_PersonPhone_PhoneNumberType_PhoneNumberTypeID]
GO
ALTER TABLE[Person].[StateProvince]  WITH CHECK ADD  CONSTRAINT[FK_StateProvince_CountryRegion_CountryRegionCode] FOREIGN KEY([CountryRegionCode])
REFERENCES[Person].[CountryRegion]([CountryRegionCode])
GO
ALTER TABLE[Person].[StateProvince] CHECK CONSTRAINT[FK_StateProvince_CountryRegion_CountryRegionCode]
GO
ALTER TABLE[Person].[StateProvince]  WITH CHECK ADD  CONSTRAINT[FK_StateProvince_SalesTerritory_TerritoryID] FOREIGN KEY([TerritoryID])
REFERENCES[Sales].[SalesTerritory]([TerritoryID])
GO
ALTER TABLE[Person].[StateProvince] CHECK CONSTRAINT[FK_StateProvince_SalesTerritory_TerritoryID]
GO

ALTER TABLE[Production].[BillOfMaterials]  WITH CHECK ADD  CONSTRAINT[FK_BillOfMaterials_Product_ComponentID] FOREIGN KEY([ComponentID])
REFERENCES[Production].[Product]([ProductID])
GO
ALTER TABLE[Production].[BillOfMaterials] CHECK CONSTRAINT[FK_BillOfMaterials_Product_ComponentID]
GO
ALTER TABLE[Production].[BillOfMaterials]  WITH CHECK ADD  CONSTRAINT[FK_BillOfMaterials_Product_ProductAssemblyID] FOREIGN KEY([ProductAssemblyID])
REFERENCES[Production].[Product]([ProductID])
GO
ALTER TABLE[Production].[BillOfMaterials] CHECK CONSTRAINT[FK_BillOfMaterials_Product_ProductAssemblyID]
GO
ALTER TABLE[Production].[BillOfMaterials]  WITH CHECK ADD  CONSTRAINT[FK_BillOfMaterials_UnitMeasure_UnitMeasureCode] FOREIGN KEY([UnitMeasureCode])
REFERENCES[Production].[UnitMeasure]([UnitMeasureCode])
GO
ALTER TABLE[Production].[BillOfMaterials] CHECK CONSTRAINT[FK_BillOfMaterials_UnitMeasure_UnitMeasureCode]
GO
ALTER TABLE[Production].[Document]  WITH CHECK ADD  CONSTRAINT[FK_Document_Employee_Owner] FOREIGN KEY([Owner])
REFERENCES[HumanResources].[Employee]([BusinessEntityID])
GO
ALTER TABLE[Production].[Document] CHECK CONSTRAINT[FK_Document_Employee_Owner]
GO
ALTER TABLE[Production].[Product]  WITH CHECK ADD  CONSTRAINT[FK_Product_ProductModel_ProductModelID] FOREIGN KEY([ProductModelID])
REFERENCES[Production].[ProductModel]([ProductModelID])
GO
ALTER TABLE[Production].[Product] CHECK CONSTRAINT[FK_Product_ProductModel_ProductModelID]
GO
ALTER TABLE[Production].[Product]  WITH CHECK ADD  CONSTRAINT[FK_Product_ProductSubcategory_ProductSubcategoryID] FOREIGN KEY([ProductSubcategoryID])
REFERENCES[Production].[ProductSubcategory]([ProductSubcategoryID])
GO
ALTER TABLE[Production].[Product] CHECK CONSTRAINT[FK_Product_ProductSubcategory_ProductSubcategoryID]
GO
ALTER TABLE[Production].[Product]  WITH CHECK ADD  CONSTRAINT[FK_Product_UnitMeasure_SizeUnitMeasureCode] FOREIGN KEY([SizeUnitMeasureCode])
REFERENCES[Production].[UnitMeasure]([UnitMeasureCode])
GO
ALTER TABLE[Production].[Product] CHECK CONSTRAINT[FK_Product_UnitMeasure_SizeUnitMeasureCode]
GO
ALTER TABLE[Production].[Product]  WITH CHECK ADD  CONSTRAINT[FK_Product_UnitMeasure_WeightUnitMeasureCode] FOREIGN KEY([WeightUnitMeasureCode])
REFERENCES[Production].[UnitMeasure]([UnitMeasureCode])
GO
ALTER TABLE[Production].[Product] CHECK CONSTRAINT[FK_Product_UnitMeasure_WeightUnitMeasureCode]
GO
ALTER TABLE[Production].[ProductCostHistory]  WITH CHECK ADD  CONSTRAINT[FK_ProductCostHistory_Product_ProductID] FOREIGN KEY([ProductID])
REFERENCES[Production].[Product]([ProductID])
GO
ALTER TABLE[Production].[ProductCostHistory] CHECK CONSTRAINT[FK_ProductCostHistory_Product_ProductID]
GO
ALTER TABLE[Production].[ProductDocument]  WITH CHECK ADD  CONSTRAINT[FK_ProductDocument_Document_DocumentNode] FOREIGN KEY([DocumentNode])
REFERENCES[Production].[Document]([DocumentNode])
GO
ALTER TABLE[Production].[ProductDocument] CHECK CONSTRAINT[FK_ProductDocument_Document_DocumentNode]
GO
ALTER TABLE[Production].[ProductDocument]  WITH CHECK ADD  CONSTRAINT[FK_ProductDocument_Product_ProductID] FOREIGN KEY([ProductID])
REFERENCES[Production].[Product]([ProductID])
GO
ALTER TABLE[Production].[ProductDocument] CHECK CONSTRAINT[FK_ProductDocument_Product_ProductID]
GO
ALTER TABLE[Production].[ProductInventory]  WITH CHECK ADD  CONSTRAINT[FK_ProductInventory_Location_LocationID] FOREIGN KEY([LocationID])
REFERENCES[Production].[Location]([LocationID])
GO
ALTER TABLE[Production].[ProductInventory] CHECK CONSTRAINT[FK_ProductInventory_Location_LocationID]
GO
ALTER TABLE[Production].[ProductInventory]  WITH CHECK ADD  CONSTRAINT[FK_ProductInventory_Product_ProductID] FOREIGN KEY([ProductID])
REFERENCES[Production].[Product]([ProductID])
GO
ALTER TABLE[Production].[ProductInventory] CHECK CONSTRAINT[FK_ProductInventory_Product_ProductID]
GO
ALTER TABLE[Production].[ProductListPriceHistory]  WITH CHECK ADD  CONSTRAINT[FK_ProductListPriceHistory_Product_ProductID] FOREIGN KEY([ProductID])
REFERENCES[Production].[Product]([ProductID])
GO
ALTER TABLE[Production].[ProductListPriceHistory] CHECK CONSTRAINT[FK_ProductListPriceHistory_Product_ProductID]
GO
ALTER TABLE[Production].[ProductModelIllustration]  WITH CHECK ADD  CONSTRAINT[FK_ProductModelIllustration_Illustration_IllustrationID] FOREIGN KEY([IllustrationID])
REFERENCES[Production].[Illustration]([IllustrationID])
GO
ALTER TABLE[Production].[ProductModelIllustration] CHECK CONSTRAINT[FK_ProductModelIllustration_Illustration_IllustrationID]
GO
ALTER TABLE[Production].[ProductModelIllustration]  WITH CHECK ADD  CONSTRAINT[FK_ProductModelIllustration_ProductModel_ProductModelID] FOREIGN KEY([ProductModelID])
REFERENCES[Production].[ProductModel]([ProductModelID])
GO
ALTER TABLE[Production].[ProductModelIllustration] CHECK CONSTRAINT[FK_ProductModelIllustration_ProductModel_ProductModelID]
GO
ALTER TABLE[Production].[ProductModelProductDescriptionCulture]  WITH CHECK ADD  CONSTRAINT[FK_ProductModelProductDescriptionCulture_Culture_CultureID] FOREIGN KEY([CultureID])
REFERENCES[Production].[Culture]([CultureID])
GO
ALTER TABLE[Production].[ProductModelProductDescriptionCulture] CHECK CONSTRAINT[FK_ProductModelProductDescriptionCulture_Culture_CultureID]
GO
ALTER TABLE[Production].[ProductModelProductDescriptionCulture]  WITH CHECK ADD  CONSTRAINT[FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID] FOREIGN KEY([ProductDescriptionID])
REFERENCES[Production].[ProductDescription]([ProductDescriptionID])
GO
ALTER TABLE[Production].[ProductModelProductDescriptionCulture] CHECK CONSTRAINT[FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID]
GO
ALTER TABLE[Production].[ProductModelProductDescriptionCulture]  WITH CHECK ADD  CONSTRAINT[FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID] FOREIGN KEY([ProductModelID])
REFERENCES[Production].[ProductModel]([ProductModelID])
GO
ALTER TABLE[Production].[ProductModelProductDescriptionCulture] CHECK CONSTRAINT[FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID]
GO
ALTER TABLE[Production].[ProductProductPhoto]  WITH CHECK ADD  CONSTRAINT[FK_ProductProductPhoto_Product_ProductID] FOREIGN KEY([ProductID])
REFERENCES[Production].[Product]([ProductID])
GO
ALTER TABLE[Production].[ProductProductPhoto] CHECK CONSTRAINT[FK_ProductProductPhoto_Product_ProductID]
GO
ALTER TABLE[Production].[ProductProductPhoto]  WITH CHECK ADD  CONSTRAINT[FK_ProductProductPhoto_ProductPhoto_ProductPhotoID] FOREIGN KEY([ProductPhotoID])
REFERENCES[Production].[ProductPhoto]([ProductPhotoID])
GO
ALTER TABLE[Production].[ProductProductPhoto] CHECK CONSTRAINT[FK_ProductProductPhoto_ProductPhoto_ProductPhotoID]
GO
ALTER TABLE[Production].[ProductReview]  WITH CHECK ADD  CONSTRAINT[FK_ProductReview_Product_ProductID] FOREIGN KEY([ProductID])
REFERENCES[Production].[Product]([ProductID])
GO
ALTER TABLE[Production].[ProductReview] CHECK CONSTRAINT[FK_ProductReview_Product_ProductID]
GO
ALTER TABLE[Production].[ProductSubcategory]  WITH CHECK ADD  CONSTRAINT[FK_ProductSubcategory_ProductCategory_ProductCategoryID] FOREIGN KEY([ProductCategoryID])
REFERENCES[Production].[ProductCategory]([ProductCategoryID])
GO
ALTER TABLE[Production].[ProductSubcategory] CHECK CONSTRAINT[FK_ProductSubcategory_ProductCategory_ProductCategoryID]
GO
ALTER TABLE[Production].[TransactionHistory]  WITH CHECK ADD  CONSTRAINT[FK_TransactionHistory_Product_ProductID] FOREIGN KEY([ProductID])
REFERENCES[Production].[Product]([ProductID])
GO
ALTER TABLE[Production].[TransactionHistory] CHECK CONSTRAINT[FK_TransactionHistory_Product_ProductID]
GO
ALTER TABLE[Production].[WorkOrder]  WITH CHECK ADD  CONSTRAINT[FK_WorkOrder_Product_ProductID] FOREIGN KEY([ProductID])
REFERENCES[Production].[Product]([ProductID])
GO
ALTER TABLE[Production].[WorkOrder] CHECK CONSTRAINT[FK_WorkOrder_Product_ProductID]
GO
ALTER TABLE[Production].[WorkOrder]  WITH CHECK ADD  CONSTRAINT[FK_WorkOrder_ScrapReason_ScrapReasonID] FOREIGN KEY([ScrapReasonID])
REFERENCES[Production].[ScrapReason]([ScrapReasonID])
GO
ALTER TABLE[Production].[WorkOrder] CHECK CONSTRAINT[FK_WorkOrder_ScrapReason_ScrapReasonID]
GO
ALTER TABLE[Production].[WorkOrderRouting]  WITH CHECK ADD  CONSTRAINT[FK_WorkOrderRouting_Location_LocationID] FOREIGN KEY([LocationID])
REFERENCES[Production].[Location]([LocationID])
GO
ALTER TABLE[Production].[WorkOrderRouting] CHECK CONSTRAINT[FK_WorkOrderRouting_Location_LocationID]
GO
ALTER TABLE[Production].[WorkOrderRouting]  WITH CHECK ADD  CONSTRAINT[FK_WorkOrderRouting_WorkOrder_WorkOrderID] FOREIGN KEY([WorkOrderID])
REFERENCES[Production].[WorkOrder]([WorkOrderID])
GO
ALTER TABLE[Production].[WorkOrderRouting] CHECK CONSTRAINT[FK_WorkOrderRouting_WorkOrder_WorkOrderID]
GO

ALTER TABLE[Purchasing].[ProductVendor]  WITH CHECK ADD  CONSTRAINT[FK_ProductVendor_Product_ProductID] FOREIGN KEY([ProductID])
REFERENCES[Production].[Product]([ProductID])
GO
ALTER TABLE[Purchasing].[ProductVendor] CHECK CONSTRAINT[FK_ProductVendor_Product_ProductID]
GO
ALTER TABLE[Purchasing].[ProductVendor]  WITH CHECK ADD  CONSTRAINT[FK_ProductVendor_UnitMeasure_UnitMeasureCode] FOREIGN KEY([UnitMeasureCode])
REFERENCES[Production].[UnitMeasure]([UnitMeasureCode])
GO
ALTER TABLE[Purchasing].[ProductVendor] CHECK CONSTRAINT[FK_ProductVendor_UnitMeasure_UnitMeasureCode]
GO
ALTER TABLE[Purchasing].[ProductVendor]  WITH CHECK ADD  CONSTRAINT[FK_ProductVendor_Vendor_BusinessEntityID] FOREIGN KEY([BusinessEntityID])
REFERENCES[Purchasing].[Vendor]([BusinessEntityID])
GO
ALTER TABLE[Purchasing].[ProductVendor] CHECK CONSTRAINT[FK_ProductVendor_Vendor_BusinessEntityID]
GO
ALTER TABLE[Purchasing].[PurchaseOrderDetail]  WITH CHECK ADD  CONSTRAINT[FK_PurchaseOrderDetail_Product_ProductID] FOREIGN KEY([ProductID])
REFERENCES[Production].[Product]([ProductID])
GO
ALTER TABLE[Purchasing].[PurchaseOrderDetail] CHECK CONSTRAINT[FK_PurchaseOrderDetail_Product_ProductID]
GO
ALTER TABLE[Purchasing].[PurchaseOrderDetail]  WITH CHECK ADD  CONSTRAINT[FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID] FOREIGN KEY([PurchaseOrderID])
REFERENCES[Purchasing].[PurchaseOrderHeader]([PurchaseOrderID])
GO
ALTER TABLE[Purchasing].[PurchaseOrderDetail] CHECK CONSTRAINT[FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID]
GO
ALTER TABLE[Purchasing].[PurchaseOrderHeader]  WITH CHECK ADD  CONSTRAINT[FK_PurchaseOrderHeader_Employee_EmployeeID] FOREIGN KEY([EmployeeID])
REFERENCES[HumanResources].[Employee]([BusinessEntityID])
GO
ALTER TABLE[Purchasing].[PurchaseOrderHeader] CHECK CONSTRAINT[FK_PurchaseOrderHeader_Employee_EmployeeID]
GO
ALTER TABLE[Purchasing].[PurchaseOrderHeader]  WITH CHECK ADD  CONSTRAINT[FK_PurchaseOrderHeader_ShipMethod_ShipMethodID] FOREIGN KEY([ShipMethodID])
REFERENCES[Purchasing].[ShipMethod]([ShipMethodID])
GO
ALTER TABLE[Purchasing].[PurchaseOrderHeader] CHECK CONSTRAINT[FK_PurchaseOrderHeader_ShipMethod_ShipMethodID]
GO
ALTER TABLE[Purchasing].[PurchaseOrderHeader]  WITH CHECK ADD  CONSTRAINT[FK_PurchaseOrderHeader_Vendor_VendorID] FOREIGN KEY([VendorID])
REFERENCES[Purchasing].[Vendor]([BusinessEntityID])
GO
ALTER TABLE[Purchasing].[PurchaseOrderHeader] CHECK CONSTRAINT[FK_PurchaseOrderHeader_Vendor_VendorID]
GO
ALTER TABLE[Purchasing].[Vendor]  WITH CHECK ADD  CONSTRAINT[FK_Vendor_BusinessEntity_BusinessEntityID] FOREIGN KEY([BusinessEntityID])
REFERENCES[Person].[BusinessEntity]([BusinessEntityID])
GO
ALTER TABLE[Purchasing].[Vendor] CHECK CONSTRAINT[FK_Vendor_BusinessEntity_BusinessEntityID]
GO

ALTER TABLE[Sales].[CountryRegionCurrency]  WITH CHECK ADD  CONSTRAINT[FK_CountryRegionCurrency_CountryRegion_CountryRegionCode] FOREIGN KEY([CountryRegionCode])
REFERENCES[Person].[CountryRegion]([CountryRegionCode])
GO
ALTER TABLE[Sales].[CountryRegionCurrency] CHECK CONSTRAINT[FK_CountryRegionCurrency_CountryRegion_CountryRegionCode]
GO
ALTER TABLE[Sales].[CountryRegionCurrency]  WITH CHECK ADD  CONSTRAINT[FK_CountryRegionCurrency_Currency_CurrencyCode] FOREIGN KEY([CurrencyCode])
REFERENCES[Sales].[Currency]([CurrencyCode])
GO
ALTER TABLE[Sales].[CountryRegionCurrency] CHECK CONSTRAINT[FK_CountryRegionCurrency_Currency_CurrencyCode]
GO
ALTER TABLE[Sales].[CurrencyRate]  WITH CHECK ADD  CONSTRAINT[FK_CurrencyRate_Currency_FromCurrencyCode] FOREIGN KEY([FromCurrencyCode])
REFERENCES[Sales].[Currency]([CurrencyCode])
GO
ALTER TABLE[Sales].[CurrencyRate] CHECK CONSTRAINT[FK_CurrencyRate_Currency_FromCurrencyCode]
GO
ALTER TABLE[Sales].[CurrencyRate]  WITH CHECK ADD  CONSTRAINT[FK_CurrencyRate_Currency_ToCurrencyCode] FOREIGN KEY([ToCurrencyCode])
REFERENCES[Sales].[Currency]([CurrencyCode])
GO
ALTER TABLE[Sales].[CurrencyRate] CHECK CONSTRAINT[FK_CurrencyRate_Currency_ToCurrencyCode]
GO
ALTER TABLE[Sales].[Customer]  WITH CHECK ADD  CONSTRAINT[FK_Customer_Person_PersonID] FOREIGN KEY([PersonID])
REFERENCES[Person].[Person]([BusinessEntityID])
GO
ALTER TABLE[Sales].[Customer] CHECK CONSTRAINT[FK_Customer_Person_PersonID]
GO
ALTER TABLE[Sales].[Customer]  WITH CHECK ADD  CONSTRAINT[FK_Customer_SalesTerritory_TerritoryID] FOREIGN KEY([TerritoryID])
REFERENCES[Sales].[SalesTerritory]([TerritoryID])
GO
ALTER TABLE[Sales].[Customer] CHECK CONSTRAINT[FK_Customer_SalesTerritory_TerritoryID]
GO
ALTER TABLE[Sales].[Customer]  WITH CHECK ADD  CONSTRAINT[FK_Customer_Store_StoreID] FOREIGN KEY([StoreID])
REFERENCES[Sales].[Store]([BusinessEntityID])
GO
ALTER TABLE[Sales].[Customer] CHECK CONSTRAINT[FK_Customer_Store_StoreID]
GO
ALTER TABLE[Sales].[PersonCreditCard]  WITH CHECK ADD  CONSTRAINT[FK_PersonCreditCard_CreditCard_CreditCardID] FOREIGN KEY([CreditCardID])
REFERENCES[Sales].[CreditCard]([CreditCardID])
GO
ALTER TABLE[Sales].[PersonCreditCard] CHECK CONSTRAINT[FK_PersonCreditCard_CreditCard_CreditCardID]
GO
ALTER TABLE[Sales].[PersonCreditCard]  WITH CHECK ADD  CONSTRAINT[FK_PersonCreditCard_Person_BusinessEntityID] FOREIGN KEY([BusinessEntityID])
REFERENCES[Person].[Person]([BusinessEntityID])
GO
ALTER TABLE[Sales].[PersonCreditCard] CHECK CONSTRAINT[FK_PersonCreditCard_Person_BusinessEntityID]
GO
ALTER TABLE[Sales].[SalesOrderDetail]  WITH CHECK ADD  CONSTRAINT[FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID] FOREIGN KEY([SalesOrderID])
REFERENCES[Sales].[SalesOrderHeader]([SalesOrderID])
GO
ALTER TABLE[Sales].[SalesOrderDetail] CHECK CONSTRAINT[FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID]
GO
ALTER TABLE[Sales].[SalesOrderDetail]  WITH CHECK ADD  CONSTRAINT[FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID] FOREIGN KEY([SpecialOfferID],[ProductID])
REFERENCES[Sales].[SpecialOfferProduct]([SpecialOfferID],[ProductID])
GO
ALTER TABLE[Sales].[SalesOrderDetail] CHECK CONSTRAINT[FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID]
GO
ALTER TABLE[Sales].[SalesOrderHeader]  WITH CHECK ADD  CONSTRAINT[FK_SalesOrderHeader_Address_BillToAddressID] FOREIGN KEY([BillToAddressID])
REFERENCES[Person].[Address]([AddressID])
GO
ALTER TABLE[Sales].[SalesOrderHeader] CHECK CONSTRAINT[FK_SalesOrderHeader_Address_BillToAddressID]
GO
ALTER TABLE[Sales].[SalesOrderHeader]  WITH CHECK ADD  CONSTRAINT[FK_SalesOrderHeader_Address_ShipToAddressID] FOREIGN KEY([ShipToAddressID])
REFERENCES[Person].[Address]([AddressID])
GO
ALTER TABLE[Sales].[SalesOrderHeader] CHECK CONSTRAINT[FK_SalesOrderHeader_Address_ShipToAddressID]
GO
ALTER TABLE[Sales].[SalesOrderHeader]  WITH CHECK ADD  CONSTRAINT[FK_SalesOrderHeader_CreditCard_CreditCardID] FOREIGN KEY([CreditCardID])
REFERENCES[Sales].[CreditCard]([CreditCardID])
GO
ALTER TABLE[Sales].[SalesOrderHeader] CHECK CONSTRAINT[FK_SalesOrderHeader_CreditCard_CreditCardID]
GO
ALTER TABLE[Sales].[SalesOrderHeader]  WITH CHECK ADD  CONSTRAINT[FK_SalesOrderHeader_CurrencyRate_CurrencyRateID] FOREIGN KEY([CurrencyRateID])
REFERENCES[Sales].[CurrencyRate]([CurrencyRateID])
GO
ALTER TABLE[Sales].[SalesOrderHeader] CHECK CONSTRAINT[FK_SalesOrderHeader_CurrencyRate_CurrencyRateID]
GO
ALTER TABLE[Sales].[SalesOrderHeader]  WITH CHECK ADD  CONSTRAINT[FK_SalesOrderHeader_Customer_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES[Sales].[Customer]([CustomerID])
GO
ALTER TABLE[Sales].[SalesOrderHeader] CHECK CONSTRAINT[FK_SalesOrderHeader_Customer_CustomerID]
GO
ALTER TABLE[Sales].[SalesOrderHeader]  WITH CHECK ADD  CONSTRAINT[FK_SalesOrderHeader_SalesPerson_SalesPersonID] FOREIGN KEY([SalesPersonID])
REFERENCES[Sales].[SalesPerson]([BusinessEntityID])
GO
ALTER TABLE[Sales].[SalesOrderHeader] CHECK CONSTRAINT[FK_SalesOrderHeader_SalesPerson_SalesPersonID]
GO
ALTER TABLE[Sales].[SalesOrderHeader]  WITH CHECK ADD  CONSTRAINT[FK_SalesOrderHeader_SalesTerritory_TerritoryID] FOREIGN KEY([TerritoryID])
REFERENCES[Sales].[SalesTerritory]([TerritoryID])
GO
ALTER TABLE[Sales].[SalesOrderHeader] CHECK CONSTRAINT[FK_SalesOrderHeader_SalesTerritory_TerritoryID]
GO
ALTER TABLE[Sales].[SalesOrderHeader]  WITH CHECK ADD  CONSTRAINT[FK_SalesOrderHeader_ShipMethod_ShipMethodID] FOREIGN KEY([ShipMethodID])
REFERENCES[Purchasing].[ShipMethod]([ShipMethodID])
GO
ALTER TABLE[Sales].[SalesOrderHeader] CHECK CONSTRAINT[FK_SalesOrderHeader_ShipMethod_ShipMethodID]
GO
ALTER TABLE[Sales].[SalesOrderHeaderSalesReason]  WITH CHECK ADD  CONSTRAINT[FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID] FOREIGN KEY([SalesOrderID])
REFERENCES[Sales].[SalesOrderHeader]([SalesOrderID])
GO
ALTER TABLE[Sales].[SalesOrderHeaderSalesReason] CHECK CONSTRAINT[FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID]
GO
ALTER TABLE[Sales].[SalesOrderHeaderSalesReason]  WITH CHECK ADD  CONSTRAINT[FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID] FOREIGN KEY([SalesReasonID])
REFERENCES[Sales].[SalesReason]([SalesReasonID])
GO
ALTER TABLE[Sales].[SalesOrderHeaderSalesReason] CHECK CONSTRAINT[FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID]
GO
ALTER TABLE[Sales].[SalesPerson]  WITH CHECK ADD  CONSTRAINT[FK_SalesPerson_Employee_BusinessEntityID] FOREIGN KEY([BusinessEntityID])
REFERENCES[HumanResources].[Employee]([BusinessEntityID])
GO
ALTER TABLE[Sales].[SalesPerson] CHECK CONSTRAINT[FK_SalesPerson_Employee_BusinessEntityID]
GO
ALTER TABLE[Sales].[SalesPerson]  WITH CHECK ADD  CONSTRAINT[FK_SalesPerson_SalesTerritory_TerritoryID] FOREIGN KEY([TerritoryID])
REFERENCES[Sales].[SalesTerritory]([TerritoryID])
GO
ALTER TABLE[Sales].[SalesPerson] CHECK CONSTRAINT[FK_SalesPerson_SalesTerritory_TerritoryID]
GO
ALTER TABLE[Sales].[SalesPersonQuotaHistory]  WITH CHECK ADD  CONSTRAINT[FK_SalesPersonQuotaHistory_SalesPerson_BusinessEntityID] FOREIGN KEY([BusinessEntityID])
REFERENCES[Sales].[SalesPerson]([BusinessEntityID])
GO
ALTER TABLE[Sales].[SalesPersonQuotaHistory] CHECK CONSTRAINT[FK_SalesPersonQuotaHistory_SalesPerson_BusinessEntityID]
GO
ALTER TABLE[Sales].[SalesTaxRate]  WITH CHECK ADD  CONSTRAINT[FK_SalesTaxRate_StateProvince_StateProvinceID] FOREIGN KEY([StateProvinceID])
REFERENCES[Person].[StateProvince]([StateProvinceID])
GO
ALTER TABLE[Sales].[SalesTaxRate] CHECK CONSTRAINT[FK_SalesTaxRate_StateProvince_StateProvinceID]
GO
ALTER TABLE[Sales].[SalesTerritory]  WITH CHECK ADD  CONSTRAINT[FK_SalesTerritory_CountryRegion_CountryRegionCode] FOREIGN KEY([CountryRegionCode])
REFERENCES[Person].[CountryRegion]([CountryRegionCode])
GO
ALTER TABLE[Sales].[SalesTerritory] CHECK CONSTRAINT[FK_SalesTerritory_CountryRegion_CountryRegionCode]
GO
ALTER TABLE[Sales].[SalesTerritoryHistory]  WITH CHECK ADD  CONSTRAINT[FK_SalesTerritoryHistory_SalesPerson_BusinessEntityID] FOREIGN KEY([BusinessEntityID])
REFERENCES[Sales].[SalesPerson]([BusinessEntityID])
GO
ALTER TABLE[Sales].[SalesTerritoryHistory] CHECK CONSTRAINT[FK_SalesTerritoryHistory_SalesPerson_BusinessEntityID]
GO
ALTER TABLE[Sales].[SalesTerritoryHistory]  WITH CHECK ADD  CONSTRAINT[FK_SalesTerritoryHistory_SalesTerritory_TerritoryID] FOREIGN KEY([TerritoryID])
REFERENCES[Sales].[SalesTerritory]([TerritoryID])
GO
ALTER TABLE[Sales].[SalesTerritoryHistory] CHECK CONSTRAINT[FK_SalesTerritoryHistory_SalesTerritory_TerritoryID]
GO
ALTER TABLE[Sales].[ShoppingCartItem]  WITH CHECK ADD  CONSTRAINT[FK_ShoppingCartItem_Product_ProductID] FOREIGN KEY([ProductID])
REFERENCES[Production].[Product]([ProductID])
GO
ALTER TABLE[Sales].[ShoppingCartItem] CHECK CONSTRAINT[FK_ShoppingCartItem_Product_ProductID]
GO
ALTER TABLE[Sales].[SpecialOfferProduct]  WITH CHECK ADD  CONSTRAINT[FK_SpecialOfferProduct_Product_ProductID] FOREIGN KEY([ProductID])
REFERENCES[Production].[Product]([ProductID])
GO
ALTER TABLE[Sales].[SpecialOfferProduct] CHECK CONSTRAINT[FK_SpecialOfferProduct_Product_ProductID]
GO
ALTER TABLE[Sales].[SpecialOfferProduct]  WITH CHECK ADD  CONSTRAINT[FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID] FOREIGN KEY([SpecialOfferID])
REFERENCES[Sales].[SpecialOffer]([SpecialOfferID])
GO
ALTER TABLE[Sales].[SpecialOfferProduct] CHECK CONSTRAINT[FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID]
GO
ALTER TABLE[Sales].[Store]  WITH CHECK ADD  CONSTRAINT[FK_Store_BusinessEntity_BusinessEntityID] FOREIGN KEY([BusinessEntityID])
REFERENCES[Person].[BusinessEntity]([BusinessEntityID])
GO
ALTER TABLE[Sales].[Store] CHECK CONSTRAINT[FK_Store_BusinessEntity_BusinessEntityID]
GO
ALTER TABLE[Sales].[Store]  WITH CHECK ADD  CONSTRAINT[FK_Store_SalesPerson_SalesPersonID] FOREIGN KEY([SalesPersonID])
REFERENCES[Sales].[SalesPerson]([BusinessEntityID])
GO
ALTER TABLE[Sales].[Store] CHECK CONSTRAINT[FK_Store_SalesPerson_SalesPersonID]
GO

");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
          
		}
	}
};