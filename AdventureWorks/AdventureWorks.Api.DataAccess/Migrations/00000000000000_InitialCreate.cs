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
[Database Version] [nvarchar]  (25)  NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[SystemInformationID] [tinyint]    NOT NULL,
[VersionDate] [datetime]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[DatabaseLog](
[DatabaseLogID] [int]    NOT NULL,
[DatabaseUser] [nvarchar]  (128)  NOT NULL,
[Event] [nvarchar]  (128)  NOT NULL,
[Object] [nvarchar]  (128)  NULL,
[PostTime] [datetime]    NOT NULL,
[Schema] [nvarchar]  (128)  NULL,
[TSQL] [nvarchar]    NOT NULL,
[XmlEvent] [xml]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[ErrorLog](
[ErrorLine] [int]    NULL,
[ErrorLogID] [int]    NOT NULL,
[ErrorMessage] [nvarchar]  (4000)  NOT NULL,
[ErrorNumber] [int]    NOT NULL,
[ErrorProcedure] [nvarchar]  (126)  NULL,
[ErrorSeverity] [int]    NULL,
[ErrorState] [int]    NULL,
[ErrorTime] [datetime]    NOT NULL,
[UserName] [nvarchar]  (128)  NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [HumanResources].[Department](
[DepartmentID] [smallint]    NOT NULL,
[GroupName] [nvarchar]  (50)  NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[Name] [nvarchar]  (50)  NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [HumanResources].[Employee](
[BirthDate] [date]    NOT NULL,
[BusinessEntityID] [int]    NOT NULL,
[CurrentFlag] [bit]    NOT NULL,
[Gender] [nchar]  (1)  NOT NULL,
[HireDate] [date]    NOT NULL,
[JobTitle] [nvarchar]  (50)  NOT NULL,
[LoginID] [nvarchar]  (256)  NOT NULL,
[MaritalStatus] [nchar]  (1)  NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[NationalIDNumber] [nvarchar]  (15)  NOT NULL,
[OrganizationLevel] [smallint]    NULL,
[OrganizationNode] [hierarchyid]    NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
[SalariedFlag] [bit]    NOT NULL,
[SickLeaveHours] [smallint]    NOT NULL,
[VacationHours] [smallint]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [HumanResources].[EmployeeDepartmentHistory](
[BusinessEntityID] [int]    NOT NULL,
[DepartmentID] [smallint]    NOT NULL,
[EndDate] [date]    NULL,
[ModifiedDate] [datetime]    NOT NULL,
[ShiftID] [tinyint]    NOT NULL,
[StartDate] [date]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [HumanResources].[EmployeePayHistory](
[BusinessEntityID] [int]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[PayFrequency] [tinyint]    NOT NULL,
[Rate] [money]    NOT NULL,
[RateChangeDate] [datetime]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [HumanResources].[JobCandidate](
[BusinessEntityID] [int]    NULL,
[JobCandidateID] [int]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[Resume] [xml]    NULL,
) ON[PRIMARY]
GO

CREATE TABLE [HumanResources].[Shift](
[EndTime] [time]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[Name] [nvarchar]  (50)  NOT NULL,
[ShiftID] [tinyint]    NOT NULL,
[StartTime] [time]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[Address](
[AddressID] [int]    NOT NULL,
[AddressLine1] [nvarchar]  (60)  NOT NULL,
[AddressLine2] [nvarchar]  (60)  NULL,
[City] [nvarchar]  (30)  NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[PostalCode] [nvarchar]  (15)  NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
[SpatialLocation] [geography]    NULL,
[StateProvinceID] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[AddressType](
[AddressTypeID] [int]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[Name] [nvarchar]  (50)  NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[BusinessEntity](
[BusinessEntityID] [int]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[BusinessEntityAddress](
[AddressID] [int]    NOT NULL,
[AddressTypeID] [int]    NOT NULL,
[BusinessEntityID] [int]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[BusinessEntityContact](
[BusinessEntityID] [int]    NOT NULL,
[ContactTypeID] [int]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[PersonID] [int]    NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[ContactType](
[ContactTypeID] [int]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[Name] [nvarchar]  (50)  NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[CountryRegion](
[CountryRegionCode] [nvarchar]  (3)  NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[Name] [nvarchar]  (50)  NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[EmailAddress](
[BusinessEntityID] [int]    NOT NULL,
[EmailAddress] [nvarchar]  (50)  NULL,
[EmailAddressID] [int]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[Password](
[BusinessEntityID] [int]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[PasswordHash] [varchar]  (128)  NOT NULL,
[PasswordSalt] [varchar]  (10)  NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[Person](
[AdditionalContactInfo] [xml]    NULL,
[BusinessEntityID] [int]    NOT NULL,
[Demographics] [xml]    NULL,
[EmailPromotion] [int]    NOT NULL,
[FirstName] [nvarchar]  (50)  NOT NULL,
[LastName] [nvarchar]  (50)  NOT NULL,
[MiddleName] [nvarchar]  (50)  NULL,
[ModifiedDate] [datetime]    NOT NULL,
[NameStyle] [bit]    NOT NULL,
[PersonType] [nchar]  (2)  NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
[Suffix] [nvarchar]  (10)  NULL,
[Title] [nvarchar]  (8)  NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[PersonPhone](
[BusinessEntityID] [int]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[PhoneNumber] [nvarchar]  (25)  NOT NULL,
[PhoneNumberTypeID] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[PhoneNumberType](
[ModifiedDate] [datetime]    NOT NULL,
[Name] [nvarchar]  (50)  NOT NULL,
[PhoneNumberTypeID] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Person].[StateProvince](
[CountryRegionCode] [nvarchar]  (3)  NOT NULL,
[IsOnlyStateProvinceFlag] [bit]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[Name] [nvarchar]  (50)  NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
[StateProvinceCode] [nchar]  (3)  NOT NULL,
[StateProvinceID] [int]    NOT NULL,
[TerritoryID] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[BillOfMaterials](
[BillOfMaterialsID] [int]    NOT NULL,
[BOMLevel] [smallint]    NOT NULL,
[ComponentID] [int]    NOT NULL,
[EndDate] [datetime]    NULL,
[ModifiedDate] [datetime]    NOT NULL,
[PerAssemblyQty] [decimal]    NOT NULL,
[ProductAssemblyID] [int]    NULL,
[StartDate] [datetime]    NOT NULL,
[UnitMeasureCode] [nchar]  (3)  NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[Culture](
[CultureID] [nchar]  (6)  NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[Name] [nvarchar]  (50)  NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[Document](
[ChangeNumber] [int]    NOT NULL,
[Document] [varbinary]    NULL,
[DocumentLevel] [smallint]    NULL,
[DocumentNode] [hierarchyid]    NOT NULL,
[DocumentSummary] [nvarchar]    NULL,
[FileExtension] [nvarchar]  (8)  NOT NULL,
[FileName] [nvarchar]  (400)  NOT NULL,
[FolderFlag] [bit]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[Owner] [int]    NOT NULL,
[Revision] [nchar]  (5)  NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
[Status] [tinyint]    NOT NULL,
[Title] [nvarchar]  (50)  NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[Illustration](
[Diagram] [xml]    NULL,
[IllustrationID] [int]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[Location](
[Availability] [decimal]    NOT NULL,
[CostRate] [smallmoney]    NOT NULL,
[LocationID] [smallint]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[Name] [nvarchar]  (50)  NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[Product](
[Class] [nchar]  (2)  NULL,
[Color] [nvarchar]  (15)  NULL,
[DaysToManufacture] [int]    NOT NULL,
[DiscontinuedDate] [datetime]    NULL,
[FinishedGoodsFlag] [bit]    NOT NULL,
[ListPrice] [money]    NOT NULL,
[MakeFlag] [bit]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[Name] [nvarchar]  (50)  NOT NULL,
[ProductID] [int]    NOT NULL,
[ProductLine] [nchar]  (2)  NULL,
[ProductModelID] [int]    NULL,
[ProductNumber] [nvarchar]  (25)  NOT NULL,
[ProductSubcategoryID] [int]    NULL,
[ReorderPoint] [smallint]    NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
[SafetyStockLevel] [smallint]    NOT NULL,
[SellEndDate] [datetime]    NULL,
[SellStartDate] [datetime]    NOT NULL,
[Size] [nvarchar]  (5)  NULL,
[SizeUnitMeasureCode] [nchar]  (3)  NULL,
[StandardCost] [money]    NOT NULL,
[Style] [nchar]  (2)  NULL,
[Weight] [decimal]    NULL,
[WeightUnitMeasureCode] [nchar]  (3)  NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductCategory](
[ModifiedDate] [datetime]    NOT NULL,
[Name] [nvarchar]  (50)  NOT NULL,
[ProductCategoryID] [int]    NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductCostHistory](
[EndDate] [datetime]    NULL,
[ModifiedDate] [datetime]    NOT NULL,
[ProductID] [int]    NOT NULL,
[StandardCost] [money]    NOT NULL,
[StartDate] [datetime]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductDescription](
[Description] [nvarchar]  (400)  NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[ProductDescriptionID] [int]    NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductDocument](
[DocumentNode] [hierarchyid]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[ProductID] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductInventory](
[Bin] [tinyint]    NOT NULL,
[LocationID] [smallint]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[ProductID] [int]    NOT NULL,
[Quantity] [smallint]    NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
[Shelf] [nvarchar]  (10)  NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductListPriceHistory](
[EndDate] [datetime]    NULL,
[ListPrice] [money]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[ProductID] [int]    NOT NULL,
[StartDate] [datetime]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductModel](
[CatalogDescription] [xml]    NULL,
[Instructions] [xml]    NULL,
[ModifiedDate] [datetime]    NOT NULL,
[Name] [nvarchar]  (50)  NOT NULL,
[ProductModelID] [int]    NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductModelIllustration](
[IllustrationID] [int]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[ProductModelID] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductModelProductDescriptionCulture](
[CultureID] [nchar]  (6)  NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[ProductDescriptionID] [int]    NOT NULL,
[ProductModelID] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductPhoto](
[LargePhoto] [varbinary]    NULL,
[LargePhotoFileName] [nvarchar]  (50)  NULL,
[ModifiedDate] [datetime]    NOT NULL,
[ProductPhotoID] [int]    NOT NULL,
[ThumbNailPhoto] [varbinary]    NULL,
[ThumbnailPhotoFileName] [nvarchar]  (50)  NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductProductPhoto](
[ModifiedDate] [datetime]    NOT NULL,
[Primary] [bit]    NOT NULL,
[ProductID] [int]    NOT NULL,
[ProductPhotoID] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductReview](
[Comments] [nvarchar]  (3850)  NULL,
[EmailAddress] [nvarchar]  (50)  NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[ProductID] [int]    NOT NULL,
[ProductReviewID] [int]    NOT NULL,
[Rating] [int]    NOT NULL,
[ReviewDate] [datetime]    NOT NULL,
[ReviewerName] [nvarchar]  (50)  NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ProductSubcategory](
[ModifiedDate] [datetime]    NOT NULL,
[Name] [nvarchar]  (50)  NOT NULL,
[ProductCategoryID] [int]    NOT NULL,
[ProductSubcategoryID] [int]    NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[ScrapReason](
[ModifiedDate] [datetime]    NOT NULL,
[Name] [nvarchar]  (50)  NOT NULL,
[ScrapReasonID] [smallint]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[TransactionHistory](
[ActualCost] [money]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[ProductID] [int]    NOT NULL,
[Quantity] [int]    NOT NULL,
[ReferenceOrderID] [int]    NOT NULL,
[ReferenceOrderLineID] [int]    NOT NULL,
[TransactionDate] [datetime]    NOT NULL,
[TransactionID] [int]    NOT NULL,
[TransactionType] [nchar]  (1)  NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[TransactionHistoryArchive](
[ActualCost] [money]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[ProductID] [int]    NOT NULL,
[Quantity] [int]    NOT NULL,
[ReferenceOrderID] [int]    NOT NULL,
[ReferenceOrderLineID] [int]    NOT NULL,
[TransactionDate] [datetime]    NOT NULL,
[TransactionID] [int]    NOT NULL,
[TransactionType] [nchar]  (1)  NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[UnitMeasure](
[ModifiedDate] [datetime]    NOT NULL,
[Name] [nvarchar]  (50)  NOT NULL,
[UnitMeasureCode] [nchar]  (3)  NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[WorkOrder](
[DueDate] [datetime]    NOT NULL,
[EndDate] [datetime]    NULL,
[ModifiedDate] [datetime]    NOT NULL,
[OrderQty] [int]    NOT NULL,
[ProductID] [int]    NOT NULL,
[ScrappedQty] [smallint]    NOT NULL,
[ScrapReasonID] [smallint]    NULL,
[StartDate] [datetime]    NOT NULL,
[StockedQty] [int]    NOT NULL,
[WorkOrderID] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Production].[WorkOrderRouting](
[ActualCost] [money]    NULL,
[ActualEndDate] [datetime]    NULL,
[ActualResourceHrs] [decimal]    NULL,
[ActualStartDate] [datetime]    NULL,
[LocationID] [smallint]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[OperationSequence] [smallint]    NOT NULL,
[PlannedCost] [money]    NOT NULL,
[ProductID] [int]    NOT NULL,
[ScheduledEndDate] [datetime]    NOT NULL,
[ScheduledStartDate] [datetime]    NOT NULL,
[WorkOrderID] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Purchasing].[ProductVendor](
[AverageLeadTime] [int]    NOT NULL,
[BusinessEntityID] [int]    NOT NULL,
[LastReceiptCost] [money]    NULL,
[LastReceiptDate] [datetime]    NULL,
[MaxOrderQty] [int]    NOT NULL,
[MinOrderQty] [int]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[OnOrderQty] [int]    NULL,
[ProductID] [int]    NOT NULL,
[StandardPrice] [money]    NOT NULL,
[UnitMeasureCode] [nchar]  (3)  NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Purchasing].[PurchaseOrderDetail](
[DueDate] [datetime]    NOT NULL,
[LineTotal] [money]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[OrderQty] [smallint]    NOT NULL,
[ProductID] [int]    NOT NULL,
[PurchaseOrderDetailID] [int]    NOT NULL,
[PurchaseOrderID] [int]    NOT NULL,
[ReceivedQty] [decimal]    NOT NULL,
[RejectedQty] [decimal]    NOT NULL,
[StockedQty] [decimal]    NOT NULL,
[UnitPrice] [money]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Purchasing].[PurchaseOrderHeader](
[EmployeeID] [int]    NOT NULL,
[Freight] [money]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[OrderDate] [datetime]    NOT NULL,
[PurchaseOrderID] [int]    NOT NULL,
[RevisionNumber] [tinyint]    NOT NULL,
[ShipDate] [datetime]    NULL,
[ShipMethodID] [int]    NOT NULL,
[Status] [tinyint]    NOT NULL,
[SubTotal] [money]    NOT NULL,
[TaxAmt] [money]    NOT NULL,
[TotalDue] [money]    NOT NULL,
[VendorID] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Purchasing].[ShipMethod](
[ModifiedDate] [datetime]    NOT NULL,
[Name] [nvarchar]  (50)  NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
[ShipBase] [money]    NOT NULL,
[ShipMethodID] [int]    NOT NULL,
[ShipRate] [money]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Purchasing].[Vendor](
[AccountNumber] [nvarchar]  (15)  NOT NULL,
[ActiveFlag] [bit]    NOT NULL,
[BusinessEntityID] [int]    NOT NULL,
[CreditRating] [tinyint]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[Name] [nvarchar]  (50)  NOT NULL,
[PreferredVendorStatus] [bit]    NOT NULL,
[PurchasingWebServiceURL] [nvarchar]  (1024)  NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[CountryRegionCurrency](
[CountryRegionCode] [nvarchar]  (3)  NOT NULL,
[CurrencyCode] [nchar]  (3)  NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[CreditCard](
[CardNumber] [nvarchar]  (25)  NOT NULL,
[CardType] [nvarchar]  (50)  NOT NULL,
[CreditCardID] [int]    NOT NULL,
[ExpMonth] [tinyint]    NOT NULL,
[ExpYear] [smallint]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[Currency](
[CurrencyCode] [nchar]  (3)  NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[Name] [nvarchar]  (50)  NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[CurrencyRate](
[AverageRate] [money]    NOT NULL,
[CurrencyRateDate] [datetime]    NOT NULL,
[CurrencyRateID] [int]    NOT NULL,
[EndOfDayRate] [money]    NOT NULL,
[FromCurrencyCode] [nchar]  (3)  NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[ToCurrencyCode] [nchar]  (3)  NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[Customer](
[AccountNumber] [varchar]  (10)  NOT NULL,
[CustomerID] [int]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[PersonID] [int]    NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
[StoreID] [int]    NULL,
[TerritoryID] [int]    NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[PersonCreditCard](
[BusinessEntityID] [int]    NOT NULL,
[CreditCardID] [int]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[SalesOrderDetail](
[CarrierTrackingNumber] [nvarchar]  (25)  NULL,
[LineTotal] [decimal]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[OrderQty] [smallint]    NOT NULL,
[ProductID] [int]    NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
[SalesOrderDetailID] [int]    NOT NULL,
[SalesOrderID] [int]    NOT NULL,
[SpecialOfferID] [int]    NOT NULL,
[UnitPrice] [money]    NOT NULL,
[UnitPriceDiscount] [money]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[SalesOrderHeader](
[AccountNumber] [nvarchar]  (15)  NULL,
[BillToAddressID] [int]    NOT NULL,
[Comment] [nvarchar]  (128)  NULL,
[CreditCardApprovalCode] [varchar]  (15)  NULL,
[CreditCardID] [int]    NULL,
[CurrencyRateID] [int]    NULL,
[CustomerID] [int]    NOT NULL,
[DueDate] [datetime]    NOT NULL,
[Freight] [money]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[OnlineOrderFlag] [bit]    NOT NULL,
[OrderDate] [datetime]    NOT NULL,
[PurchaseOrderNumber] [nvarchar]  (25)  NULL,
[RevisionNumber] [tinyint]    NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
[SalesOrderID] [int]    NOT NULL,
[SalesOrderNumber] [nvarchar]  (25)  NOT NULL,
[SalesPersonID] [int]    NULL,
[ShipDate] [datetime]    NULL,
[ShipMethodID] [int]    NOT NULL,
[ShipToAddressID] [int]    NOT NULL,
[Status] [tinyint]    NOT NULL,
[SubTotal] [money]    NOT NULL,
[TaxAmt] [money]    NOT NULL,
[TerritoryID] [int]    NULL,
[TotalDue] [money]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[SalesOrderHeaderSalesReason](
[ModifiedDate] [datetime]    NOT NULL,
[SalesOrderID] [int]    NOT NULL,
[SalesReasonID] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[SalesPerson](
[Bonus] [money]    NOT NULL,
[BusinessEntityID] [int]    NOT NULL,
[CommissionPct] [smallmoney]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
[SalesLastYear] [money]    NOT NULL,
[SalesQuota] [money]    NULL,
[SalesYTD] [money]    NOT NULL,
[TerritoryID] [int]    NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[SalesPersonQuotaHistory](
[BusinessEntityID] [int]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[QuotaDate] [datetime]    NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
[SalesQuota] [money]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[SalesReason](
[ModifiedDate] [datetime]    NOT NULL,
[Name] [nvarchar]  (50)  NOT NULL,
[ReasonType] [nvarchar]  (50)  NOT NULL,
[SalesReasonID] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[SalesTaxRate](
[ModifiedDate] [datetime]    NOT NULL,
[Name] [nvarchar]  (50)  NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
[SalesTaxRateID] [int]    NOT NULL,
[StateProvinceID] [int]    NOT NULL,
[TaxRate] [smallmoney]    NOT NULL,
[TaxType] [tinyint]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[SalesTerritory](
[CostLastYear] [money]    NOT NULL,
[CostYTD] [money]    NOT NULL,
[CountryRegionCode] [nvarchar]  (3)  NOT NULL,
[Group] [nvarchar]  (50)  NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[Name] [nvarchar]  (50)  NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
[SalesLastYear] [money]    NOT NULL,
[SalesYTD] [money]    NOT NULL,
[TerritoryID] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[SalesTerritoryHistory](
[BusinessEntityID] [int]    NOT NULL,
[EndDate] [datetime]    NULL,
[ModifiedDate] [datetime]    NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
[StartDate] [datetime]    NOT NULL,
[TerritoryID] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[ShoppingCartItem](
[DateCreated] [datetime]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[ProductID] [int]    NOT NULL,
[Quantity] [int]    NOT NULL,
[ShoppingCartID] [nvarchar]  (50)  NOT NULL,
[ShoppingCartItemID] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[SpecialOffer](
[Category] [nvarchar]  (50)  NOT NULL,
[Description] [nvarchar]  (255)  NOT NULL,
[DiscountPct] [smallmoney]    NOT NULL,
[EndDate] [datetime]    NOT NULL,
[MaxQty] [int]    NULL,
[MinQty] [int]    NOT NULL,
[ModifiedDate] [datetime]    NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
[SpecialOfferID] [int]    NOT NULL,
[StartDate] [datetime]    NOT NULL,
[Type] [nvarchar]  (50)  NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[SpecialOfferProduct](
[ModifiedDate] [datetime]    NOT NULL,
[ProductID] [int]    NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
[SpecialOfferID] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [Sales].[Store](
[BusinessEntityID] [int]    NOT NULL,
[Demographics] [xml]    NULL,
[ModifiedDate] [datetime]    NOT NULL,
[Name] [nvarchar]  (50)  NOT NULL,
[rowguid] [uniqueidentifier]    NOT NULL,
[SalesPersonID] [int]    NULL,
) ON[PRIMARY]
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