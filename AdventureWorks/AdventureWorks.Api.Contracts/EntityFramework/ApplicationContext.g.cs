using Microsoft.EntityFrameworkCore;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApplicationContext: DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{}
		public virtual DbSet<EFAWBuildVersion> AWBuildVersion { get; set; }
		public virtual DbSet<EFDatabaseLog> DatabaseLog { get; set; }
		public virtual DbSet<EFErrorLog> ErrorLog { get; set; }
		public virtual DbSet<EFDepartment> Department { get; set; }
		public virtual DbSet<EFEmployee> Employee { get; set; }
		public virtual DbSet<EFEmployeeDepartmentHistory> EmployeeDepartmentHistory { get; set; }
		public virtual DbSet<EFEmployeePayHistory> EmployeePayHistory { get; set; }
		public virtual DbSet<EFJobCandidate> JobCandidate { get; set; }
		public virtual DbSet<EFShift> Shift { get; set; }
		public virtual DbSet<EFAddress> Address { get; set; }
		public virtual DbSet<EFAddressType> AddressType { get; set; }
		public virtual DbSet<EFBusinessEntity> BusinessEntity { get; set; }
		public virtual DbSet<EFBusinessEntityAddress> BusinessEntityAddress { get; set; }
		public virtual DbSet<EFBusinessEntityContact> BusinessEntityContact { get; set; }
		public virtual DbSet<EFContactType> ContactType { get; set; }
		public virtual DbSet<EFCountryRegion> CountryRegion { get; set; }
		public virtual DbSet<EFEmailAddress> EmailAddress { get; set; }
		public virtual DbSet<EFPassword> Password { get; set; }
		public virtual DbSet<EFPerson> Person { get; set; }
		public virtual DbSet<EFPersonPhone> PersonPhone { get; set; }
		public virtual DbSet<EFPhoneNumberType> PhoneNumberType { get; set; }
		public virtual DbSet<EFStateProvince> StateProvince { get; set; }
		public virtual DbSet<EFBillOfMaterials> BillOfMaterials { get; set; }
		public virtual DbSet<EFCulture> Culture { get; set; }
		public virtual DbSet<EFDocument> Document { get; set; }
		public virtual DbSet<EFIllustration> Illustration { get; set; }
		public virtual DbSet<EFLocation> Location { get; set; }
		public virtual DbSet<EFProduct> Product { get; set; }
		public virtual DbSet<EFProductCategory> ProductCategory { get; set; }
		public virtual DbSet<EFProductCostHistory> ProductCostHistory { get; set; }
		public virtual DbSet<EFProductDescription> ProductDescription { get; set; }
		public virtual DbSet<EFProductDocument> ProductDocument { get; set; }
		public virtual DbSet<EFProductInventory> ProductInventory { get; set; }
		public virtual DbSet<EFProductListPriceHistory> ProductListPriceHistory { get; set; }
		public virtual DbSet<EFProductModel> ProductModel { get; set; }
		public virtual DbSet<EFProductModelIllustration> ProductModelIllustration { get; set; }
		public virtual DbSet<EFProductModelProductDescriptionCulture> ProductModelProductDescriptionCulture { get; set; }
		public virtual DbSet<EFProductPhoto> ProductPhoto { get; set; }
		public virtual DbSet<EFProductProductPhoto> ProductProductPhoto { get; set; }
		public virtual DbSet<EFProductReview> ProductReview { get; set; }
		public virtual DbSet<EFProductSubcategory> ProductSubcategory { get; set; }
		public virtual DbSet<EFScrapReason> ScrapReason { get; set; }
		public virtual DbSet<EFTransactionHistory> TransactionHistory { get; set; }
		public virtual DbSet<EFTransactionHistoryArchive> TransactionHistoryArchive { get; set; }
		public virtual DbSet<EFUnitMeasure> UnitMeasure { get; set; }
		public virtual DbSet<EFWorkOrder> WorkOrder { get; set; }
		public virtual DbSet<EFWorkOrderRouting> WorkOrderRouting { get; set; }
		public virtual DbSet<EFProductVendor> ProductVendor { get; set; }
		public virtual DbSet<EFPurchaseOrderDetail> PurchaseOrderDetail { get; set; }
		public virtual DbSet<EFPurchaseOrderHeader> PurchaseOrderHeader { get; set; }
		public virtual DbSet<EFShipMethod> ShipMethod { get; set; }
		public virtual DbSet<EFVendor> Vendor { get; set; }
		public virtual DbSet<EFCountryRegionCurrency> CountryRegionCurrency { get; set; }
		public virtual DbSet<EFCreditCard> CreditCard { get; set; }
		public virtual DbSet<EFCurrency> Currency { get; set; }
		public virtual DbSet<EFCurrencyRate> CurrencyRate { get; set; }
		public virtual DbSet<EFCustomer> Customer { get; set; }
		public virtual DbSet<EFPersonCreditCard> PersonCreditCard { get; set; }
		public virtual DbSet<EFSalesOrderDetail> SalesOrderDetail { get; set; }
		public virtual DbSet<EFSalesOrderHeader> SalesOrderHeader { get; set; }
		public virtual DbSet<EFSalesOrderHeaderSalesReason> SalesOrderHeaderSalesReason { get; set; }
		public virtual DbSet<EFSalesPerson> SalesPerson { get; set; }
		public virtual DbSet<EFSalesPersonQuotaHistory> SalesPersonQuotaHistory { get; set; }
		public virtual DbSet<EFSalesReason> SalesReason { get; set; }
		public virtual DbSet<EFSalesTaxRate> SalesTaxRate { get; set; }
		public virtual DbSet<EFSalesTerritory> SalesTerritory { get; set; }
		public virtual DbSet<EFSalesTerritoryHistory> SalesTerritoryHistory { get; set; }
		public virtual DbSet<EFShoppingCartItem> ShoppingCartItem { get; set; }
		public virtual DbSet<EFSpecialOffer> SpecialOffer { get; set; }
		public virtual DbSet<EFSpecialOfferProduct> SpecialOfferProduct { get; set; }
		public virtual DbSet<EFStore> Store { get; set; }
	}
}

/*<Codenesium>
    <Hash>07d5bfaa795b97fc46f475ee995bfd59</Hash>
</Codenesium>*/