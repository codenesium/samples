using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractIntegrationTestMigration
	{
		protected ApplicationDbContext Context { get; private set; }

		public AbstractIntegrationTestMigration(ApplicationDbContext context)
		{
			this.Context = context;
		}

		public virtual async Task Migrate()
		{
			var aWBuildVersionItem1 = new AWBuildVersion();
			aWBuildVersionItem1.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
			this.Context.AWBuildVersions.Add(aWBuildVersionItem1);

			var databaseLogItem1 = new DatabaseLog();
			databaseLogItem1.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A");
			this.Context.DatabaseLogs.Add(databaseLogItem1);

			var errorLogItem1 = new ErrorLog();
			errorLogItem1.SetProperties(1, 1, "A", 1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			this.Context.ErrorLogs.Add(errorLogItem1);

			await this.Context.SaveChangesAsync();

			var departmentItem1 = new Department();
			departmentItem1.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			this.Context.Departments.Add(departmentItem1);

			var employeeItem1 = new Employee();
			employeeItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), true, 1, 1);
			this.Context.Employees.Add(employeeItem1);

			var jobCandidateItem1 = new JobCandidate();
			jobCandidateItem1.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			this.Context.JobCandidates.Add(jobCandidateItem1);

			var shiftItem1 = new Shift();
			shiftItem1.SetProperties(1, TimeSpan.Parse("01:00:00"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", TimeSpan.Parse("01:00:00"));
			this.Context.Shifts.Add(shiftItem1);

			await this.Context.SaveChangesAsync();

			var addressItem1 = new Address();
			addressItem1.SetProperties(1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);
			this.Context.Addresses.Add(addressItem1);

			var addressTypeItem1 = new AddressType();
			addressTypeItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			this.Context.AddressTypes.Add(addressTypeItem1);

			var businessEntityItem1 = new BusinessEntity();
			businessEntityItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			this.Context.BusinessEntities.Add(businessEntityItem1);

			var contactTypeItem1 = new ContactType();
			contactTypeItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			this.Context.ContactTypes.Add(contactTypeItem1);

			var countryRegionItem1 = new CountryRegion();
			countryRegionItem1.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			this.Context.CountryRegions.Add(countryRegionItem1);

			var passwordItem1 = new Password();
			passwordItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			this.Context.Passwords.Add(passwordItem1);

			var personItem1 = new Person();
			personItem1.SetProperties(1, "A", "A", 1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A");
			this.Context.People.Add(personItem1);

			var phoneNumberTypeItem1 = new PhoneNumberType();
			phoneNumberTypeItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			this.Context.PhoneNumberTypes.Add(phoneNumberTypeItem1);

			var stateProvinceItem1 = new StateProvince();
			stateProvinceItem1.SetProperties(1, "A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);
			this.Context.StateProvinces.Add(stateProvinceItem1);

			await this.Context.SaveChangesAsync();

			var billOfMaterialItem1 = new BillOfMaterial();
			billOfMaterialItem1.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			this.Context.BillOfMaterials.Add(billOfMaterialItem1);

			var cultureItem1 = new Culture();
			cultureItem1.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			this.Context.Cultures.Add(cultureItem1);

			var documentItem1 = new Document();
			documentItem1.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, BitConverter.GetBytes(1), 1, "A", "A", "A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, "A");
			this.Context.Documents.Add(documentItem1);

			var illustrationItem1 = new Illustration();
			illustrationItem1.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"));
			this.Context.Illustrations.Add(illustrationItem1);

			var locationItem1 = new Location();
			locationItem1.SetProperties(1, 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			this.Context.Locations.Add(locationItem1);

			var productItem1 = new Product();
			productItem1.SetProperties(1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1m, true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1m, "A", 1, "A");
			this.Context.Products.Add(productItem1);

			var productCategoryItem1 = new ProductCategory();
			productCategoryItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			this.Context.ProductCategories.Add(productCategoryItem1);

			var productDescriptionItem1 = new ProductDescription();
			productDescriptionItem1.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			this.Context.ProductDescriptions.Add(productDescriptionItem1);

			var productModelItem1 = new ProductModel();
			productModelItem1.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			this.Context.ProductModels.Add(productModelItem1);

			var productPhotoItem1 = new ProductPhoto();
			productPhotoItem1.SetProperties(1, BitConverter.GetBytes(1), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), BitConverter.GetBytes(1), "A");
			this.Context.ProductPhotoes.Add(productPhotoItem1);

			var productReviewItem1 = new ProductReview();
			productReviewItem1.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			this.Context.ProductReviews.Add(productReviewItem1);

			var productSubcategoryItem1 = new ProductSubcategory();
			productSubcategoryItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			this.Context.ProductSubcategories.Add(productSubcategoryItem1);

			var scrapReasonItem1 = new ScrapReason();
			scrapReasonItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			this.Context.ScrapReasons.Add(scrapReasonItem1);

			var transactionHistoryItem1 = new TransactionHistory();
			transactionHistoryItem1.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			this.Context.TransactionHistories.Add(transactionHistoryItem1);

			var transactionHistoryArchiveItem1 = new TransactionHistoryArchive();
			transactionHistoryArchiveItem1.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			this.Context.TransactionHistoryArchives.Add(transactionHistoryArchiveItem1);

			var unitMeasureItem1 = new UnitMeasure();
			unitMeasureItem1.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			this.Context.UnitMeasures.Add(unitMeasureItem1);

			var workOrderItem1 = new WorkOrder();
			workOrderItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			this.Context.WorkOrders.Add(workOrderItem1);

			await this.Context.SaveChangesAsync();

			var purchaseOrderHeaderItem1 = new PurchaseOrderHeader();
			purchaseOrderHeaderItem1.SetProperties(1, 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1m, 1m, 1m, 1);
			this.Context.PurchaseOrderHeaders.Add(purchaseOrderHeaderItem1);

			var shipMethodItem1 = new ShipMethod();
			shipMethodItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);
			this.Context.ShipMethods.Add(shipMethodItem1);

			var vendorItem1 = new Vendor();
			vendorItem1.SetProperties(1, "A", true, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, "A");
			this.Context.Vendors.Add(vendorItem1);

			await this.Context.SaveChangesAsync();

			var creditCardItem1 = new CreditCard();
			creditCardItem1.SetProperties(1, "A", "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			this.Context.CreditCards.Add(creditCardItem1);

			var currencyItem1 = new Currency();
			currencyItem1.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			this.Context.Currencies.Add(currencyItem1);

			var currencyRateItem1 = new CurrencyRate();
			currencyRateItem1.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			this.Context.CurrencyRates.Add(currencyRateItem1);

			var customerItem1 = new Customer();
			customerItem1.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1);
			this.Context.Customers.Add(customerItem1);

			var salesOrderHeaderItem1 = new SalesOrderHeader();
			salesOrderHeaderItem1.SetProperties(1, "A", 1, "A", "A", 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1m, 1m, 1, 1m);
			this.Context.SalesOrderHeaders.Add(salesOrderHeaderItem1);

			var salesPersonItem1 = new SalesPerson();
			salesPersonItem1.SetProperties(1, 1m, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m, 1m, 1);
			this.Context.SalesPersons.Add(salesPersonItem1);

			var salesReasonItem1 = new SalesReason();
			salesReasonItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");
			this.Context.SalesReasons.Add(salesReasonItem1);

			var salesTaxRateItem1 = new SalesTaxRate();
			salesTaxRateItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1m, 1);
			this.Context.SalesTaxRates.Add(salesTaxRateItem1);

			var salesTerritoryItem1 = new SalesTerritory();
			salesTerritoryItem1.SetProperties(1, 1m, 1m, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);
			this.Context.SalesTerritories.Add(salesTerritoryItem1);

			var shoppingCartItemItem1 = new ShoppingCartItem();
			shoppingCartItemItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");
			this.Context.ShoppingCartItems.Add(shoppingCartItemItem1);

			var specialOfferItem1 = new SpecialOffer();
			specialOfferItem1.SetProperties(1, "A", "A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), DateTime.Parse("1/1/1987 12:00:00 AM"));
			this.Context.SpecialOffers.Add(specialOfferItem1);

			var storeItem1 = new Store();
			storeItem1.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);
			this.Context.Stores.Add(storeItem1);

			await this.Context.SaveChangesAsync();
		}
	}
}

/*<Codenesium>
    <Hash>f01e074ea82d2d146c5cd1bce1825518</Hash>
</Codenesium>*/