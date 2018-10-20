using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractApplicationDbContext : DbContext
	{
		public Guid UserId { get; private set; }

		public int TenantId { get; private set; } = 1;

		public AbstractApplicationDbContext(DbContextOptions options)
			: base(options)
		{
		}

		public virtual void SetUserId(Guid userId)
		{
			if (userId == default(Guid))
			{
				throw new ArgumentException("UserId cannot be a default value");
			}

			this.UserId = userId;
		}

		public virtual void SetTenantId(int tenantId)
		{
			if (tenantId <= 0)
			{
				throw new ArgumentException("TenantId must be greater than 0");
			}

			this.TenantId = tenantId;
		}

		public virtual DbSet<AWBuildVersion> AWBuildVersions { get; set; }

		public virtual DbSet<DatabaseLog> DatabaseLogs { get; set; }

		public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

		public virtual DbSet<Department> Departments { get; set; }

		public virtual DbSet<Employee> Employees { get; set; }

		public virtual DbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }

		public virtual DbSet<EmployeePayHistory> EmployeePayHistories { get; set; }

		public virtual DbSet<JobCandidate> JobCandidates { get; set; }

		public virtual DbSet<Shift> Shifts { get; set; }

		public virtual DbSet<Address> Addresses { get; set; }

		public virtual DbSet<AddressType> AddressTypes { get; set; }

		public virtual DbSet<BusinessEntity> BusinessEntities { get; set; }

		public virtual DbSet<BusinessEntityAddress> BusinessEntityAddresses { get; set; }

		public virtual DbSet<BusinessEntityContact> BusinessEntityContacts { get; set; }

		public virtual DbSet<ContactType> ContactTypes { get; set; }

		public virtual DbSet<CountryRegion> CountryRegions { get; set; }

		public virtual DbSet<EmailAddress> EmailAddresses { get; set; }

		public virtual DbSet<Password> Passwords { get; set; }

		public virtual DbSet<Person> People { get; set; }

		public virtual DbSet<PersonPhone> PersonPhones { get; set; }

		public virtual DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }

		public virtual DbSet<StateProvince> StateProvinces { get; set; }

		public virtual DbSet<VStateProvinceCountryRegion> VStateProvinceCountryRegions { get; set; }

		public virtual DbSet<BillOfMaterial> BillOfMaterials { get; set; }

		public virtual DbSet<Culture> Cultures { get; set; }

		public virtual DbSet<Document> Documents { get; set; }

		public virtual DbSet<Illustration> Illustrations { get; set; }

		public virtual DbSet<Location> Locations { get; set; }

		public virtual DbSet<Product> Products { get; set; }

		public virtual DbSet<ProductCategory> ProductCategories { get; set; }

		public virtual DbSet<ProductCostHistory> ProductCostHistories { get; set; }

		public virtual DbSet<ProductDescription> ProductDescriptions { get; set; }

		public virtual DbSet<ProductDocument> ProductDocuments { get; set; }

		public virtual DbSet<ProductInventory> ProductInventories { get; set; }

		public virtual DbSet<ProductListPriceHistory> ProductListPriceHistories { get; set; }

		public virtual DbSet<ProductModel> ProductModels { get; set; }

		public virtual DbSet<ProductModelIllustration> ProductModelIllustrations { get; set; }

		public virtual DbSet<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; }

		public virtual DbSet<ProductPhoto> ProductPhotoes { get; set; }

		public virtual DbSet<ProductProductPhoto> ProductProductPhotoes { get; set; }

		public virtual DbSet<ProductReview> ProductReviews { get; set; }

		public virtual DbSet<ProductSubcategory> ProductSubcategories { get; set; }

		public virtual DbSet<ScrapReason> ScrapReasons { get; set; }

		public virtual DbSet<TransactionHistory> TransactionHistories { get; set; }

		public virtual DbSet<TransactionHistoryArchive> TransactionHistoryArchives { get; set; }

		public virtual DbSet<UnitMeasure> UnitMeasures { get; set; }

		public virtual DbSet<VProductAndDescription> VProductAndDescriptions { get; set; }

		public virtual DbSet<WorkOrder> WorkOrders { get; set; }

		public virtual DbSet<WorkOrderRouting> WorkOrderRoutings { get; set; }

		public virtual DbSet<ProductVendor> ProductVendors { get; set; }

		public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

		public virtual DbSet<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; }

		public virtual DbSet<ShipMethod> ShipMethods { get; set; }

		public virtual DbSet<Vendor> Vendors { get; set; }

		public virtual DbSet<CountryRegionCurrency> CountryRegionCurrencies { get; set; }

		public virtual DbSet<CreditCard> CreditCards { get; set; }

		public virtual DbSet<Currency> Currencies { get; set; }

		public virtual DbSet<CurrencyRate> CurrencyRates { get; set; }

		public virtual DbSet<Customer> Customers { get; set; }

		public virtual DbSet<PersonCreditCard> PersonCreditCards { get; set; }

		public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }

		public virtual DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }

		public virtual DbSet<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons { get; set; }

		public virtual DbSet<SalesPerson> SalesPersons { get; set; }

		public virtual DbSet<SalesPersonQuotaHistory> SalesPersonQuotaHistories { get; set; }

		public virtual DbSet<SalesReason> SalesReasons { get; set; }

		public virtual DbSet<SalesTaxRate> SalesTaxRates { get; set; }

		public virtual DbSet<SalesTerritory> SalesTerritories { get; set; }

		public virtual DbSet<SalesTerritoryHistory> SalesTerritoryHistories { get; set; }

		public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

		public virtual DbSet<SpecialOffer> SpecialOffers { get; set; }

		public virtual DbSet<SpecialOfferProduct> SpecialOfferProducts { get; set; }

		public virtual DbSet<Store> Stores { get; set; }

		/// <summary>
		/// We're overriding SaveChanges because SQLite does not support database computed columns.
		/// ROWGUID is a very common type of column and it does not work with SQLite.
		/// To work around this limitation we detect ROWGUID columns here and set the value.
		/// On SQL Server the database would set the value.
		/// </summary>
		/// <param name="acceptAllChangesOnSuccess">Commit all changes on success</param>
		/// <param name="cancellationToken">Token that can be passed to hault execution</param>
		/// <returns>int</returns>
		public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
		{
			var entries = this.ChangeTracker.Entries().Where(e => EntityState.Added.HasFlag(e.State));
			if (entries.Any())
			{
				foreach (var createdEntry in entries)
				{
					var entity = createdEntry.Properties.FirstOrDefault(x => x.Metadata.Name.ToUpper() == "ROWGUID");
					if (entity != null && entity.Metadata.ClrType == typeof(Guid) && (Guid)entity.CurrentValue != default(Guid))
					{
						entity.CurrentValue = Guid.NewGuid();
					}

					var tenantEntity = createdEntry.Properties.FirstOrDefault(x => x.Metadata.Name.ToUpper() == "TENANTID");
					if (tenantEntity != null)
					{
						tenantEntity.CurrentValue = this.TenantId;
					}
				}
			}

			return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			base.OnConfiguring(options);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AWBuildVersion>()
			.HasKey(c => new
			{
				c.SystemInformationID,
			});

			modelBuilder.Entity<AWBuildVersion>()
			.Property("SystemInformationID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<DatabaseLog>()
			.HasKey(c => new
			{
				c.DatabaseLogID,
			});

			modelBuilder.Entity<DatabaseLog>()
			.Property("DatabaseLogID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<ErrorLog>()
			.HasKey(c => new
			{
				c.ErrorLogID,
			});

			modelBuilder.Entity<ErrorLog>()
			.Property("ErrorLogID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Department>()
			.HasKey(c => new
			{
				c.DepartmentID,
			});

			modelBuilder.Entity<Department>()
			.Property("DepartmentID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Employee>()
			.HasKey(c => new
			{
				c.BusinessEntityID,
			});

			modelBuilder.Entity<EmployeeDepartmentHistory>()
			.HasKey(c => new
			{
				c.BusinessEntityID,
				c.StartDate,
				c.DepartmentID,
				c.ShiftID,
			});

			modelBuilder.Entity<EmployeePayHistory>()
			.HasKey(c => new
			{
				c.BusinessEntityID,
				c.RateChangeDate,
			});

			modelBuilder.Entity<JobCandidate>()
			.HasKey(c => new
			{
				c.JobCandidateID,
			});

			modelBuilder.Entity<JobCandidate>()
			.Property("JobCandidateID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Shift>()
			.HasKey(c => new
			{
				c.ShiftID,
			});

			modelBuilder.Entity<Shift>()
			.Property("ShiftID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Address>()
			.HasKey(c => new
			{
				c.AddressID,
			});

			modelBuilder.Entity<Address>()
			.Property("AddressID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<AddressType>()
			.HasKey(c => new
			{
				c.AddressTypeID,
			});

			modelBuilder.Entity<AddressType>()
			.Property("AddressTypeID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<BusinessEntity>()
			.HasKey(c => new
			{
				c.BusinessEntityID,
			});

			modelBuilder.Entity<BusinessEntity>()
			.Property("BusinessEntityID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<BusinessEntityAddress>()
			.HasKey(c => new
			{
				c.BusinessEntityID,
				c.AddressID,
				c.AddressTypeID,
			});

			modelBuilder.Entity<BusinessEntityContact>()
			.HasKey(c => new
			{
				c.BusinessEntityID,
				c.PersonID,
				c.ContactTypeID,
			});

			modelBuilder.Entity<ContactType>()
			.HasKey(c => new
			{
				c.ContactTypeID,
			});

			modelBuilder.Entity<ContactType>()
			.Property("ContactTypeID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<CountryRegion>()
			.HasKey(c => new
			{
				c.CountryRegionCode,
			});

			modelBuilder.Entity<EmailAddress>()
			.HasKey(c => new
			{
				c.BusinessEntityID,
				c.EmailAddressID,
			});

			modelBuilder.Entity<EmailAddress>()
			.Property("EmailAddressID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Password>()
			.HasKey(c => new
			{
				c.BusinessEntityID,
			});

			modelBuilder.Entity<Person>()
			.HasKey(c => new
			{
				c.BusinessEntityID,
			});

			modelBuilder.Entity<PersonPhone>()
			.HasKey(c => new
			{
				c.BusinessEntityID,
				c.PhoneNumber,
				c.PhoneNumberTypeID,
			});

			modelBuilder.Entity<PhoneNumberType>()
			.HasKey(c => new
			{
				c.PhoneNumberTypeID,
			});

			modelBuilder.Entity<PhoneNumberType>()
			.Property("PhoneNumberTypeID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<StateProvince>()
			.HasKey(c => new
			{
				c.StateProvinceID,
			});

			modelBuilder.Entity<StateProvince>()
			.Property("StateProvinceID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<VStateProvinceCountryRegion>()
			.HasKey(c => new
			{
				c.StateProvinceID,
				c.CountryRegionCode,
			});

			modelBuilder.Entity<BillOfMaterial>()
			.HasKey(c => new
			{
				c.BillOfMaterialsID,
			});

			modelBuilder.Entity<BillOfMaterial>()
			.Property("BillOfMaterialsID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Culture>()
			.HasKey(c => new
			{
				c.CultureID,
			});

			modelBuilder.Entity<Document>()
			.HasKey(c => new
			{
				c.Rowguid,
			});

			modelBuilder.Entity<Document>()
			.Property("Rowguid")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Illustration>()
			.HasKey(c => new
			{
				c.IllustrationID,
			});

			modelBuilder.Entity<Illustration>()
			.Property("IllustrationID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Location>()
			.HasKey(c => new
			{
				c.LocationID,
			});

			modelBuilder.Entity<Location>()
			.Property("LocationID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Product>()
			.HasKey(c => new
			{
				c.ProductID,
			});

			modelBuilder.Entity<Product>()
			.Property("ProductID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<ProductCategory>()
			.HasKey(c => new
			{
				c.ProductCategoryID,
			});

			modelBuilder.Entity<ProductCategory>()
			.Property("ProductCategoryID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<ProductCostHistory>()
			.HasKey(c => new
			{
				c.ProductID,
				c.StartDate,
			});

			modelBuilder.Entity<ProductDescription>()
			.HasKey(c => new
			{
				c.ProductDescriptionID,
			});

			modelBuilder.Entity<ProductDescription>()
			.Property("ProductDescriptionID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<ProductInventory>()
			.HasKey(c => new
			{
				c.ProductID,
				c.LocationID,
			});

			modelBuilder.Entity<ProductListPriceHistory>()
			.HasKey(c => new
			{
				c.ProductID,
				c.StartDate,
			});

			modelBuilder.Entity<ProductModel>()
			.HasKey(c => new
			{
				c.ProductModelID,
			});

			modelBuilder.Entity<ProductModel>()
			.Property("ProductModelID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<ProductModelIllustration>()
			.HasKey(c => new
			{
				c.ProductModelID,
				c.IllustrationID,
			});

			modelBuilder.Entity<ProductModelProductDescriptionCulture>()
			.HasKey(c => new
			{
				c.ProductModelID,
				c.ProductDescriptionID,
				c.CultureID,
			});

			modelBuilder.Entity<ProductPhoto>()
			.HasKey(c => new
			{
				c.ProductPhotoID,
			});

			modelBuilder.Entity<ProductPhoto>()
			.Property("ProductPhotoID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<ProductProductPhoto>()
			.HasKey(c => new
			{
				c.ProductID,
				c.ProductPhotoID,
			});

			modelBuilder.Entity<ProductReview>()
			.HasKey(c => new
			{
				c.ProductReviewID,
			});

			modelBuilder.Entity<ProductReview>()
			.Property("ProductReviewID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<ProductSubcategory>()
			.HasKey(c => new
			{
				c.ProductSubcategoryID,
			});

			modelBuilder.Entity<ProductSubcategory>()
			.Property("ProductSubcategoryID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<ScrapReason>()
			.HasKey(c => new
			{
				c.ScrapReasonID,
			});

			modelBuilder.Entity<ScrapReason>()
			.Property("ScrapReasonID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<TransactionHistory>()
			.HasKey(c => new
			{
				c.TransactionID,
			});

			modelBuilder.Entity<TransactionHistory>()
			.Property("TransactionID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<TransactionHistoryArchive>()
			.HasKey(c => new
			{
				c.TransactionID,
			});

			modelBuilder.Entity<UnitMeasure>()
			.HasKey(c => new
			{
				c.UnitMeasureCode,
			});

			modelBuilder.Entity<VProductAndDescription>()
			.HasKey(c => new
			{
				c.CultureID,
				c.ProductID,
			});

			modelBuilder.Entity<WorkOrder>()
			.HasKey(c => new
			{
				c.WorkOrderID,
			});

			modelBuilder.Entity<WorkOrder>()
			.Property("WorkOrderID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<WorkOrderRouting>()
			.HasKey(c => new
			{
				c.WorkOrderID,
				c.ProductID,
				c.OperationSequence,
			});

			modelBuilder.Entity<ProductVendor>()
			.HasKey(c => new
			{
				c.ProductID,
				c.BusinessEntityID,
			});

			modelBuilder.Entity<PurchaseOrderDetail>()
			.HasKey(c => new
			{
				c.PurchaseOrderID,
				c.PurchaseOrderDetailID,
			});

			modelBuilder.Entity<PurchaseOrderDetail>()
			.Property("PurchaseOrderDetailID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<PurchaseOrderHeader>()
			.HasKey(c => new
			{
				c.PurchaseOrderID,
			});

			modelBuilder.Entity<PurchaseOrderHeader>()
			.Property("PurchaseOrderID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<ShipMethod>()
			.HasKey(c => new
			{
				c.ShipMethodID,
			});

			modelBuilder.Entity<ShipMethod>()
			.Property("ShipMethodID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Vendor>()
			.HasKey(c => new
			{
				c.BusinessEntityID,
			});

			modelBuilder.Entity<CountryRegionCurrency>()
			.HasKey(c => new
			{
				c.CountryRegionCode,
				c.CurrencyCode,
			});

			modelBuilder.Entity<CreditCard>()
			.HasKey(c => new
			{
				c.CreditCardID,
			});

			modelBuilder.Entity<CreditCard>()
			.Property("CreditCardID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Currency>()
			.HasKey(c => new
			{
				c.CurrencyCode,
			});

			modelBuilder.Entity<CurrencyRate>()
			.HasKey(c => new
			{
				c.CurrencyRateID,
			});

			modelBuilder.Entity<CurrencyRate>()
			.Property("CurrencyRateID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Customer>()
			.HasKey(c => new
			{
				c.CustomerID,
			});

			modelBuilder.Entity<Customer>()
			.Property("CustomerID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<PersonCreditCard>()
			.HasKey(c => new
			{
				c.BusinessEntityID,
				c.CreditCardID,
			});

			modelBuilder.Entity<SalesOrderDetail>()
			.HasKey(c => new
			{
				c.SalesOrderID,
				c.SalesOrderDetailID,
			});

			modelBuilder.Entity<SalesOrderDetail>()
			.Property("SalesOrderDetailID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<SalesOrderHeader>()
			.HasKey(c => new
			{
				c.SalesOrderID,
			});

			modelBuilder.Entity<SalesOrderHeader>()
			.Property("SalesOrderID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<SalesOrderHeaderSalesReason>()
			.HasKey(c => new
			{
				c.SalesOrderID,
				c.SalesReasonID,
			});

			modelBuilder.Entity<SalesPerson>()
			.HasKey(c => new
			{
				c.BusinessEntityID,
			});

			modelBuilder.Entity<SalesPersonQuotaHistory>()
			.HasKey(c => new
			{
				c.BusinessEntityID,
				c.QuotaDate,
			});

			modelBuilder.Entity<SalesReason>()
			.HasKey(c => new
			{
				c.SalesReasonID,
			});

			modelBuilder.Entity<SalesReason>()
			.Property("SalesReasonID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<SalesTaxRate>()
			.HasKey(c => new
			{
				c.SalesTaxRateID,
			});

			modelBuilder.Entity<SalesTaxRate>()
			.Property("SalesTaxRateID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<SalesTerritory>()
			.HasKey(c => new
			{
				c.TerritoryID,
			});

			modelBuilder.Entity<SalesTerritory>()
			.Property("TerritoryID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<SalesTerritoryHistory>()
			.HasKey(c => new
			{
				c.BusinessEntityID,
				c.StartDate,
				c.TerritoryID,
			});

			modelBuilder.Entity<ShoppingCartItem>()
			.HasKey(c => new
			{
				c.ShoppingCartItemID,
			});

			modelBuilder.Entity<ShoppingCartItem>()
			.Property("ShoppingCartItemID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<SpecialOffer>()
			.HasKey(c => new
			{
				c.SpecialOfferID,
			});

			modelBuilder.Entity<SpecialOffer>()
			.Property("SpecialOfferID")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<SpecialOfferProduct>()
			.HasKey(c => new
			{
				c.SpecialOfferID,
				c.ProductID,
			});

			modelBuilder.Entity<Store>()
			.HasKey(c => new
			{
				c.BusinessEntityID,
			});

			var booleanStringConverter = new BoolToStringConverter("N", "Y");
		}
	}

	public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public virtual ApplicationDbContext CreateDbContext(string[] args)
		{
			string settingsDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "AdventureWorks.Api.Web");

			string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

			IConfigurationRoot configuration = new ConfigurationBuilder()
			                                   .SetBasePath(settingsDirectory)
			                                   .AddJsonFile($"appSettings.{environment}.json")
			                                   .AddEnvironmentVariables()
			                                   .Build();

			var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

			var connectionString = configuration.GetConnectionString("ApplicationDbContext");

			builder.UseSqlServer(connectionString);

			return new ApplicationDbContext(builder.Options);
		}
	}
}

/*<Codenesium>
    <Hash>74bd96761cbb2699e75bed9897a64b68</Hash>
</Codenesium>*/