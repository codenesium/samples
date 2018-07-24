using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        public class IntegrationTestMigration
        {
                private ApplicationDbContext context;

                public IntegrationTestMigration(ApplicationDbContext context)
                {
                        this.context = context;
                }

                public void Migrate()
                {
                        var aWBuildVersionItem1 = new AWBuildVersion();
                        aWBuildVersionItem1.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        this.context.AWBuildVersions.Add(aWBuildVersionItem1);

                        var databaseLogItem1 = new DatabaseLog();
                        databaseLogItem1.SetProperties(1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A");
                        this.context.DatabaseLogs.Add(databaseLogItem1);

                        var errorLogItem1 = new ErrorLog();
                        errorLogItem1.SetProperties(1, 1, "A", 1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        this.context.ErrorLogs.Add(errorLogItem1);

                        this.context.SaveChanges();
                        var departmentItem1 = new Department();
                        departmentItem1.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        this.context.Departments.Add(departmentItem1);

                        var employeeItem1 = new Employee();
                        employeeItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, true, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), true, 1, 1);
                        this.context.Employees.Add(employeeItem1);

                        var employeeDepartmentHistoryItem1 = new EmployeeDepartmentHistory();
                        employeeDepartmentHistoryItem1.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        this.context.EmployeeDepartmentHistories.Add(employeeDepartmentHistoryItem1);

                        var employeePayHistoryItem1 = new EmployeePayHistory();
                        employeePayHistoryItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        this.context.EmployeePayHistories.Add(employeePayHistoryItem1);

                        var jobCandidateItem1 = new JobCandidate();
                        jobCandidateItem1.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        this.context.JobCandidates.Add(jobCandidateItem1);

                        var shiftItem1 = new Shift();
                        shiftItem1.SetProperties(TimeSpan.Parse("0"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, TimeSpan.Parse("0"));
                        this.context.Shifts.Add(shiftItem1);

                        this.context.SaveChanges();
                        var addressItem1 = new Address();
                        addressItem1.SetProperties(1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);
                        this.context.Addresses.Add(addressItem1);

                        var addressTypeItem1 = new AddressType();
                        addressTypeItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        this.context.AddressTypes.Add(addressTypeItem1);

                        var businessEntityItem1 = new BusinessEntity();
                        businessEntityItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        this.context.BusinessEntities.Add(businessEntityItem1);

                        var businessEntityAddressItem1 = new BusinessEntityAddress();
                        businessEntityAddressItem1.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        this.context.BusinessEntityAddresses.Add(businessEntityAddressItem1);

                        var businessEntityContactItem1 = new BusinessEntityContact();
                        businessEntityContactItem1.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        this.context.BusinessEntityContacts.Add(businessEntityContactItem1);

                        var contactTypeItem1 = new ContactType();
                        contactTypeItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        this.context.ContactTypes.Add(contactTypeItem1);

                        var countryRegionItem1 = new CountryRegion();
                        countryRegionItem1.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        this.context.CountryRegions.Add(countryRegionItem1);

                        var emailAddressItem1 = new EmailAddress();
                        emailAddressItem1.SetProperties(1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        this.context.EmailAddresses.Add(emailAddressItem1);

                        var passwordItem1 = new Password();
                        passwordItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        this.context.Passwords.Add(passwordItem1);

                        var personItem1 = new Person();
                        personItem1.SetProperties("A", 1, "A", 1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A");
                        this.context.People.Add(personItem1);

                        var personPhoneItem1 = new PersonPhone();
                        personPhoneItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
                        this.context.PersonPhones.Add(personPhoneItem1);

                        var phoneNumberTypeItem1 = new PhoneNumberType();
                        phoneNumberTypeItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
                        this.context.PhoneNumberTypes.Add(phoneNumberTypeItem1);

                        var stateProvinceItem1 = new StateProvince();
                        stateProvinceItem1.SetProperties("A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1, 1);
                        this.context.StateProvinces.Add(stateProvinceItem1);

                        this.context.SaveChanges();
                        var billOfMaterialItem1 = new BillOfMaterial();
                        billOfMaterialItem1.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        this.context.BillOfMaterials.Add(billOfMaterialItem1);

                        var cultureItem1 = new Culture();
                        cultureItem1.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        this.context.Cultures.Add(cultureItem1);

                        var documentItem1 = new Document();
                        documentItem1.SetProperties(1, BitConverter.GetBytes(1), 1, "A", "A", "A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A");
                        this.context.Documents.Add(documentItem1);

                        var illustrationItem1 = new Illustration();
                        illustrationItem1.SetProperties("A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        this.context.Illustrations.Add(illustrationItem1);

                        var locationItem1 = new Location();
                        locationItem1.SetProperties(1, 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        this.context.Locations.Add(locationItem1);

                        var productItem1 = new Product();
                        productItem1.SetProperties("A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1m, true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A", 1, "A", 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1m, "A", 1, "A");
                        this.context.Products.Add(productItem1);

                        var productCategoryItem1 = new ProductCategory();
                        productCategoryItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        this.context.ProductCategories.Add(productCategoryItem1);

                        var productCostHistoryItem1 = new ProductCostHistory();
                        productCostHistoryItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        this.context.ProductCostHistories.Add(productCostHistoryItem1);

                        var productDescriptionItem1 = new ProductDescription();
                        productDescriptionItem1.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        this.context.ProductDescriptions.Add(productDescriptionItem1);

                        var productInventoryItem1 = new ProductInventory();
                        productInventoryItem1.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
                        this.context.ProductInventories.Add(productInventoryItem1);

                        var productListPriceHistoryItem1 = new ProductListPriceHistory();
                        productListPriceHistoryItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        this.context.ProductListPriceHistories.Add(productListPriceHistoryItem1);

                        var productModelItem1 = new ProductModel();
                        productModelItem1.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        this.context.ProductModels.Add(productModelItem1);

                        var productModelIllustrationItem1 = new ProductModelIllustration();
                        productModelIllustrationItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
                        this.context.ProductModelIllustrations.Add(productModelIllustrationItem1);

                        var productModelProductDescriptionCultureItem1 = new ProductModelProductDescriptionCulture();
                        productModelProductDescriptionCultureItem1.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1);
                        this.context.ProductModelProductDescriptionCultures.Add(productModelProductDescriptionCultureItem1);

                        var productPhotoItem1 = new ProductPhoto();
                        productPhotoItem1.SetProperties(BitConverter.GetBytes(1), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, BitConverter.GetBytes(1), "A");
                        this.context.ProductPhotoes.Add(productPhotoItem1);

                        var productProductPhotoItem1 = new ProductProductPhoto();
                        productProductPhotoItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1, 1);
                        this.context.ProductProductPhotoes.Add(productProductPhotoItem1);

                        var productReviewItem1 = new ProductReview();
                        productReviewItem1.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        this.context.ProductReviews.Add(productReviewItem1);

                        var productSubcategoryItem1 = new ProductSubcategory();
                        productSubcategoryItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        this.context.ProductSubcategories.Add(productSubcategoryItem1);

                        var scrapReasonItem1 = new ScrapReason();
                        scrapReasonItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
                        this.context.ScrapReasons.Add(scrapReasonItem1);

                        var transactionHistoryItem1 = new TransactionHistory();
                        transactionHistoryItem1.SetProperties(1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
                        this.context.TransactionHistories.Add(transactionHistoryItem1);

                        var transactionHistoryArchiveItem1 = new TransactionHistoryArchive();
                        transactionHistoryArchiveItem1.SetProperties(1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
                        this.context.TransactionHistoryArchives.Add(transactionHistoryArchiveItem1);

                        var unitMeasureItem1 = new UnitMeasure();
                        unitMeasureItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");
                        this.context.UnitMeasures.Add(unitMeasureItem1);

                        var workOrderItem1 = new WorkOrder();
                        workOrderItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1);
                        this.context.WorkOrders.Add(workOrderItem1);

                        var workOrderRoutingItem1 = new WorkOrderRouting();
                        workOrderRoutingItem1.SetProperties(1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
                        this.context.WorkOrderRoutings.Add(workOrderRoutingItem1);

                        this.context.SaveChanges();
                        var productVendorItem1 = new ProductVendor();
                        productVendorItem1.SetProperties(1, 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1m, "A");
                        this.context.ProductVendors.Add(productVendorItem1);

                        var purchaseOrderDetailItem1 = new PurchaseOrderDetail();
                        purchaseOrderDetailItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, 1, 1, 1, 1m);
                        this.context.PurchaseOrderDetails.Add(purchaseOrderDetailItem1);

                        var purchaseOrderHeaderItem1 = new PurchaseOrderHeader();
                        purchaseOrderHeaderItem1.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1m, 1m, 1m, 1);
                        this.context.PurchaseOrderHeaders.Add(purchaseOrderHeaderItem1);

                        var shipMethodItem1 = new ShipMethod();
                        shipMethodItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1, 1m);
                        this.context.ShipMethods.Add(shipMethodItem1);

                        var vendorItem1 = new Vendor();
                        vendorItem1.SetProperties("A", true, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, "A");
                        this.context.Vendors.Add(vendorItem1);

                        this.context.SaveChanges();
                        var countryRegionCurrencyItem1 = new CountryRegionCurrency();
                        countryRegionCurrencyItem1.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"));
                        this.context.CountryRegionCurrencies.Add(countryRegionCurrencyItem1);

                        var creditCardItem1 = new CreditCard();
                        creditCardItem1.SetProperties("A", "A", 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        this.context.CreditCards.Add(creditCardItem1);

                        var currencyItem1 = new Currency();
                        currencyItem1.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        this.context.Currencies.Add(currencyItem1);

                        var currencyRateItem1 = new CurrencyRate();
                        currencyRateItem1.SetProperties(1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        this.context.CurrencyRates.Add(currencyRateItem1);

                        var customerItem1 = new Customer();
                        customerItem1.SetProperties("A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1);
                        this.context.Customers.Add(customerItem1);

                        var personCreditCardItem1 = new PersonCreditCard();
                        personCreditCardItem1.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        this.context.PersonCreditCards.Add(personCreditCardItem1);

                        var salesOrderDetailItem1 = new SalesOrderDetail();
                        salesOrderDetailItem1.SetProperties("A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1, 1m, 1m);
                        this.context.SalesOrderDetails.Add(salesOrderDetailItem1);

                        var salesOrderHeaderItem1 = new SalesOrderHeader();
                        salesOrderHeaderItem1.SetProperties("A", 1, "A", "A", 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1m, 1m, 1, 1m);
                        this.context.SalesOrderHeaders.Add(salesOrderHeaderItem1);

                        var salesOrderHeaderSalesReasonItem1 = new SalesOrderHeaderSalesReason();
                        salesOrderHeaderSalesReasonItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1);
                        this.context.SalesOrderHeaderSalesReasons.Add(salesOrderHeaderSalesReasonItem1);

                        var salesPersonItem1 = new SalesPerson();
                        salesPersonItem1.SetProperties(1m, 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m, 1m, 1);
                        this.context.SalesPersons.Add(salesPersonItem1);

                        var salesPersonQuotaHistoryItem1 = new SalesPersonQuotaHistory();
                        salesPersonQuotaHistoryItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m);
                        this.context.SalesPersonQuotaHistories.Add(salesPersonQuotaHistoryItem1);

                        var salesReasonItem1 = new SalesReason();
                        salesReasonItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1);
                        this.context.SalesReasons.Add(salesReasonItem1);

                        var salesTaxRateItem1 = new SalesTaxRate();
                        salesTaxRateItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1m, 1);
                        this.context.SalesTaxRates.Add(salesTaxRateItem1);

                        var salesTerritoryItem1 = new SalesTerritory();
                        salesTerritoryItem1.SetProperties(1m, 1m, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m, 1);
                        this.context.SalesTerritories.Add(salesTerritoryItem1);

                        var salesTerritoryHistoryItem1 = new SalesTerritoryHistory();
                        salesTerritoryHistoryItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
                        this.context.SalesTerritoryHistories.Add(salesTerritoryHistoryItem1);

                        var shoppingCartItemItem1 = new ShoppingCartItem();
                        shoppingCartItemItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1);
                        this.context.ShoppingCartItems.Add(shoppingCartItemItem1);

                        var specialOfferItem1 = new SpecialOffer();
                        specialOfferItem1.SetProperties("A", "A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        this.context.SpecialOffers.Add(specialOfferItem1);

                        var specialOfferProductItem1 = new SpecialOfferProduct();
                        specialOfferProductItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);
                        this.context.SpecialOfferProducts.Add(specialOfferProductItem1);

                        var storeItem1 = new Store();
                        storeItem1.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);
                        this.context.Stores.Add(storeItem1);

                        this.context.SaveChanges();
                }
        }
}

/*<Codenesium>
    <Hash>d72f7c35393b1ba8c36621af0e7e1a08</Hash>
</Codenesium>*/