using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
namespace AdventureWorksNS.Api.DataAccess
{
	public partial class ApplicationDbContext: DbContext
	{
		public Guid UserId { get; private set; }

		public int TenantId { get; private set; }

		public ApplicationDbContext(DbContextOptions options)
			: base(options)
		{}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			base.OnConfiguring(options);
		}

		public void SetUserId(Guid userId)
		{
			if(userId == default (Guid))
			{
				throw new ArgumentException("UserId cannot be a default value");
			}
			this.UserId = userId;
		}

		public void SetTenantId(int tenantId)
		{
			if(tenantId <= 0)
			{
				throw new ArgumentException("TenantId must be greater than 0");
			}
			this.TenantId = tenantId;
		}

		public virtual DbSet<EFAWBuildVersion> AWBuildVersions { get; set; }

		public virtual DbSet<EFDatabaseLog> DatabaseLogs { get; set; }

		public virtual DbSet<EFErrorLog> ErrorLogs { get; set; }

		public virtual DbSet<EFDepartment> Departments { get; set; }

		public virtual DbSet<EFEmployee> Employees { get; set; }

		public virtual DbSet<EFEmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }

		public virtual DbSet<EFEmployeePayHistory> EmployeePayHistories { get; set; }

		public virtual DbSet<EFJobCandidate> JobCandidates { get; set; }

		public virtual DbSet<EFShift> Shifts { get; set; }

		public virtual DbSet<EFAddress> Addresses { get; set; }

		public virtual DbSet<EFAddressType> AddressTypes { get; set; }

		public virtual DbSet<EFBusinessEntity> BusinessEntities { get; set; }

		public virtual DbSet<EFBusinessEntityAddress> BusinessEntityAddresses { get; set; }

		public virtual DbSet<EFBusinessEntityContact> BusinessEntityContacts { get; set; }

		public virtual DbSet<EFContactType> ContactTypes { get; set; }

		public virtual DbSet<EFCountryRegion> CountryRegions { get; set; }

		public virtual DbSet<EFEmailAddress> EmailAddresses { get; set; }

		public virtual DbSet<EFPassword> Passwords { get; set; }

		public virtual DbSet<EFPerson> People { get; set; }

		public virtual DbSet<EFPersonPhone> PersonPhones { get; set; }

		public virtual DbSet<EFPhoneNumberType> PhoneNumberTypes { get; set; }

		public virtual DbSet<EFStateProvince> StateProvinces { get; set; }

		public virtual DbSet<EFBillOfMaterials> BillOfMaterials { get; set; }

		public virtual DbSet<EFCulture> Cultures { get; set; }

		public virtual DbSet<EFDocument> Documents { get; set; }

		public virtual DbSet<EFIllustration> Illustrations { get; set; }

		public virtual DbSet<EFLocation> Locations { get; set; }

		public virtual DbSet<EFProduct> Products { get; set; }

		public virtual DbSet<EFProductCategory> ProductCategories { get; set; }

		public virtual DbSet<EFProductCostHistory> ProductCostHistories { get; set; }

		public virtual DbSet<EFProductDescription> ProductDescriptions { get; set; }

		public virtual DbSet<EFProductDocument> ProductDocuments { get; set; }

		public virtual DbSet<EFProductInventory> ProductInventories { get; set; }

		public virtual DbSet<EFProductListPriceHistory> ProductListPriceHistories { get; set; }

		public virtual DbSet<EFProductModel> ProductModels { get; set; }

		public virtual DbSet<EFProductModelIllustration> ProductModelIllustrations { get; set; }

		public virtual DbSet<EFProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; }

		public virtual DbSet<EFProductPhoto> ProductPhotoes { get; set; }

		public virtual DbSet<EFProductProductPhoto> ProductProductPhotoes { get; set; }

		public virtual DbSet<EFProductReview> ProductReviews { get; set; }

		public virtual DbSet<EFProductSubcategory> ProductSubcategories { get; set; }

		public virtual DbSet<EFScrapReason> ScrapReasons { get; set; }

		public virtual DbSet<EFTransactionHistory> TransactionHistories { get; set; }

		public virtual DbSet<EFTransactionHistoryArchive> TransactionHistoryArchives { get; set; }

		public virtual DbSet<EFUnitMeasure> UnitMeasures { get; set; }

		public virtual DbSet<EFWorkOrder> WorkOrders { get; set; }

		public virtual DbSet<EFWorkOrderRouting> WorkOrderRoutings { get; set; }

		public virtual DbSet<EFProductVendor> ProductVendors { get; set; }

		public virtual DbSet<EFPurchaseOrderDetail> PurchaseOrderDetails { get; set; }

		public virtual DbSet<EFPurchaseOrderHeader> PurchaseOrderHeaders { get; set; }

		public virtual DbSet<EFShipMethod> ShipMethods { get; set; }

		public virtual DbSet<EFVendor> Vendors { get; set; }

		public virtual DbSet<EFCountryRegionCurrency> CountryRegionCurrencies { get; set; }

		public virtual DbSet<EFCreditCard> CreditCards { get; set; }

		public virtual DbSet<EFCurrency> Currencies { get; set; }

		public virtual DbSet<EFCurrencyRate> CurrencyRates { get; set; }

		public virtual DbSet<EFCustomer> Customers { get; set; }

		public virtual DbSet<EFPersonCreditCard> PersonCreditCards { get; set; }

		public virtual DbSet<EFSalesOrderDetail> SalesOrderDetails { get; set; }

		public virtual DbSet<EFSalesOrderHeader> SalesOrderHeaders { get; set; }

		public virtual DbSet<EFSalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons { get; set; }

		public virtual DbSet<EFSalesPerson> SalesPersons { get; set; }

		public virtual DbSet<EFSalesPersonQuotaHistory> SalesPersonQuotaHistories { get; set; }

		public virtual DbSet<EFSalesReason> SalesReasons { get; set; }

		public virtual DbSet<EFSalesTaxRate> SalesTaxRates { get; set; }

		public virtual DbSet<EFSalesTerritory> SalesTerritories { get; set; }

		public virtual DbSet<EFSalesTerritoryHistory> SalesTerritoryHistories { get; set; }

		public virtual DbSet<EFShoppingCartItem> ShoppingCartItems { get; set; }

		public virtual DbSet<EFSpecialOffer> SpecialOffers { get; set; }

		public virtual DbSet<EFSpecialOfferProduct> SpecialOfferProducts { get; set; }

		public virtual DbSet<EFStore> Stores { get; set; }
	}

	public class ApplicationDbContextFactory: IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public ApplicationDbContext CreateDbContext(string[] args)
		{
			string settingsDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "AdventureWorks.Api.Service");

			IConfigurationRoot configuration = new ConfigurationBuilder()
			                                   .SetBasePath(settingsDirectory)
			                                   .AddJsonFile("appsettings.json")
			                                   .Build();

			var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

			var connectionString = configuration.GetConnectionString("ApplicationDbContext");

			builder.UseSqlServer(connectionString);

			return new ApplicationDbContext(builder.Options);
		}
	}
}

/*<Codenesium>
    <Hash>393c80c2b1dd66852987bd39ef567460</Hash>
</Codenesium>*/