using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiResponse
	{
		public ApiResponse()
		{
		}

		public void Merge(ApiResponse from)
		{
			from.AWBuildVersions.ForEach(x => this.AddAWBuildVersion(x));
			from.DatabaseLogs.ForEach(x => this.AddDatabaseLog(x));
			from.ErrorLogs.ForEach(x => this.AddErrorLog(x));
			from.Departments.ForEach(x => this.AddDepartment(x));
			from.Employees.ForEach(x => this.AddEmployee(x));
			from.JobCandidates.ForEach(x => this.AddJobCandidate(x));
			from.Shifts.ForEach(x => this.AddShift(x));
			from.Addresses.ForEach(x => this.AddAddress(x));
			from.AddressTypes.ForEach(x => this.AddAddressType(x));
			from.BusinessEntities.ForEach(x => this.AddBusinessEntity(x));
			from.ContactTypes.ForEach(x => this.AddContactType(x));
			from.CountryRegions.ForEach(x => this.AddCountryRegion(x));
			from.Passwords.ForEach(x => this.AddPassword(x));
			from.People.ForEach(x => this.AddPerson(x));
			from.PhoneNumberTypes.ForEach(x => this.AddPhoneNumberType(x));
			from.StateProvinces.ForEach(x => this.AddStateProvince(x));
			from.BillOfMaterials.ForEach(x => this.AddBillOfMaterial(x));
			from.Cultures.ForEach(x => this.AddCulture(x));
			from.Documents.ForEach(x => this.AddDocument(x));
			from.Illustrations.ForEach(x => this.AddIllustration(x));
			from.Locations.ForEach(x => this.AddLocation(x));
			from.Products.ForEach(x => this.AddProduct(x));
			from.ProductCategories.ForEach(x => this.AddProductCategory(x));
			from.ProductDescriptions.ForEach(x => this.AddProductDescription(x));
			from.ProductModels.ForEach(x => this.AddProductModel(x));
			from.ProductPhotoes.ForEach(x => this.AddProductPhoto(x));
			from.ProductReviews.ForEach(x => this.AddProductReview(x));
			from.ProductSubcategories.ForEach(x => this.AddProductSubcategory(x));
			from.ScrapReasons.ForEach(x => this.AddScrapReason(x));
			from.TransactionHistories.ForEach(x => this.AddTransactionHistory(x));
			from.TransactionHistoryArchives.ForEach(x => this.AddTransactionHistoryArchive(x));
			from.UnitMeasures.ForEach(x => this.AddUnitMeasure(x));
			from.WorkOrders.ForEach(x => this.AddWorkOrder(x));
			from.PurchaseOrderHeaders.ForEach(x => this.AddPurchaseOrderHeader(x));
			from.ShipMethods.ForEach(x => this.AddShipMethod(x));
			from.Vendors.ForEach(x => this.AddVendor(x));
			from.CreditCards.ForEach(x => this.AddCreditCard(x));
			from.Currencies.ForEach(x => this.AddCurrency(x));
			from.CurrencyRates.ForEach(x => this.AddCurrencyRate(x));
			from.Customers.ForEach(x => this.AddCustomer(x));
			from.SalesOrderHeaders.ForEach(x => this.AddSalesOrderHeader(x));
			from.SalesPersons.ForEach(x => this.AddSalesPerson(x));
			from.SalesReasons.ForEach(x => this.AddSalesReason(x));
			from.SalesTaxRates.ForEach(x => this.AddSalesTaxRate(x));
			from.SalesTerritories.ForEach(x => this.AddSalesTerritory(x));
			from.ShoppingCartItems.ForEach(x => this.AddShoppingCartItem(x));
			from.SpecialOffers.ForEach(x => this.AddSpecialOffer(x));
			from.Stores.ForEach(x => this.AddStore(x));
		}

		public List<ApiAWBuildVersionClientResponseModel> AWBuildVersions { get; private set; } = new List<ApiAWBuildVersionClientResponseModel>();

		public List<ApiDatabaseLogClientResponseModel> DatabaseLogs { get; private set; } = new List<ApiDatabaseLogClientResponseModel>();

		public List<ApiErrorLogClientResponseModel> ErrorLogs { get; private set; } = new List<ApiErrorLogClientResponseModel>();

		public List<ApiDepartmentClientResponseModel> Departments { get; private set; } = new List<ApiDepartmentClientResponseModel>();

		public List<ApiEmployeeClientResponseModel> Employees { get; private set; } = new List<ApiEmployeeClientResponseModel>();

		public List<ApiJobCandidateClientResponseModel> JobCandidates { get; private set; } = new List<ApiJobCandidateClientResponseModel>();

		public List<ApiShiftClientResponseModel> Shifts { get; private set; } = new List<ApiShiftClientResponseModel>();

		public List<ApiAddressClientResponseModel> Addresses { get; private set; } = new List<ApiAddressClientResponseModel>();

		public List<ApiAddressTypeClientResponseModel> AddressTypes { get; private set; } = new List<ApiAddressTypeClientResponseModel>();

		public List<ApiBusinessEntityClientResponseModel> BusinessEntities { get; private set; } = new List<ApiBusinessEntityClientResponseModel>();

		public List<ApiContactTypeClientResponseModel> ContactTypes { get; private set; } = new List<ApiContactTypeClientResponseModel>();

		public List<ApiCountryRegionClientResponseModel> CountryRegions { get; private set; } = new List<ApiCountryRegionClientResponseModel>();

		public List<ApiPasswordClientResponseModel> Passwords { get; private set; } = new List<ApiPasswordClientResponseModel>();

		public List<ApiPersonClientResponseModel> People { get; private set; } = new List<ApiPersonClientResponseModel>();

		public List<ApiPhoneNumberTypeClientResponseModel> PhoneNumberTypes { get; private set; } = new List<ApiPhoneNumberTypeClientResponseModel>();

		public List<ApiStateProvinceClientResponseModel> StateProvinces { get; private set; } = new List<ApiStateProvinceClientResponseModel>();

		public List<ApiBillOfMaterialClientResponseModel> BillOfMaterials { get; private set; } = new List<ApiBillOfMaterialClientResponseModel>();

		public List<ApiCultureClientResponseModel> Cultures { get; private set; } = new List<ApiCultureClientResponseModel>();

		public List<ApiDocumentClientResponseModel> Documents { get; private set; } = new List<ApiDocumentClientResponseModel>();

		public List<ApiIllustrationClientResponseModel> Illustrations { get; private set; } = new List<ApiIllustrationClientResponseModel>();

		public List<ApiLocationClientResponseModel> Locations { get; private set; } = new List<ApiLocationClientResponseModel>();

		public List<ApiProductClientResponseModel> Products { get; private set; } = new List<ApiProductClientResponseModel>();

		public List<ApiProductCategoryClientResponseModel> ProductCategories { get; private set; } = new List<ApiProductCategoryClientResponseModel>();

		public List<ApiProductDescriptionClientResponseModel> ProductDescriptions { get; private set; } = new List<ApiProductDescriptionClientResponseModel>();

		public List<ApiProductModelClientResponseModel> ProductModels { get; private set; } = new List<ApiProductModelClientResponseModel>();

		public List<ApiProductPhotoClientResponseModel> ProductPhotoes { get; private set; } = new List<ApiProductPhotoClientResponseModel>();

		public List<ApiProductReviewClientResponseModel> ProductReviews { get; private set; } = new List<ApiProductReviewClientResponseModel>();

		public List<ApiProductSubcategoryClientResponseModel> ProductSubcategories { get; private set; } = new List<ApiProductSubcategoryClientResponseModel>();

		public List<ApiScrapReasonClientResponseModel> ScrapReasons { get; private set; } = new List<ApiScrapReasonClientResponseModel>();

		public List<ApiTransactionHistoryClientResponseModel> TransactionHistories { get; private set; } = new List<ApiTransactionHistoryClientResponseModel>();

		public List<ApiTransactionHistoryArchiveClientResponseModel> TransactionHistoryArchives { get; private set; } = new List<ApiTransactionHistoryArchiveClientResponseModel>();

		public List<ApiUnitMeasureClientResponseModel> UnitMeasures { get; private set; } = new List<ApiUnitMeasureClientResponseModel>();

		public List<ApiWorkOrderClientResponseModel> WorkOrders { get; private set; } = new List<ApiWorkOrderClientResponseModel>();

		public List<ApiPurchaseOrderHeaderClientResponseModel> PurchaseOrderHeaders { get; private set; } = new List<ApiPurchaseOrderHeaderClientResponseModel>();

		public List<ApiShipMethodClientResponseModel> ShipMethods { get; private set; } = new List<ApiShipMethodClientResponseModel>();

		public List<ApiVendorClientResponseModel> Vendors { get; private set; } = new List<ApiVendorClientResponseModel>();

		public List<ApiCreditCardClientResponseModel> CreditCards { get; private set; } = new List<ApiCreditCardClientResponseModel>();

		public List<ApiCurrencyClientResponseModel> Currencies { get; private set; } = new List<ApiCurrencyClientResponseModel>();

		public List<ApiCurrencyRateClientResponseModel> CurrencyRates { get; private set; } = new List<ApiCurrencyRateClientResponseModel>();

		public List<ApiCustomerClientResponseModel> Customers { get; private set; } = new List<ApiCustomerClientResponseModel>();

		public List<ApiSalesOrderHeaderClientResponseModel> SalesOrderHeaders { get; private set; } = new List<ApiSalesOrderHeaderClientResponseModel>();

		public List<ApiSalesPersonClientResponseModel> SalesPersons { get; private set; } = new List<ApiSalesPersonClientResponseModel>();

		public List<ApiSalesReasonClientResponseModel> SalesReasons { get; private set; } = new List<ApiSalesReasonClientResponseModel>();

		public List<ApiSalesTaxRateClientResponseModel> SalesTaxRates { get; private set; } = new List<ApiSalesTaxRateClientResponseModel>();

		public List<ApiSalesTerritoryClientResponseModel> SalesTerritories { get; private set; } = new List<ApiSalesTerritoryClientResponseModel>();

		public List<ApiShoppingCartItemClientResponseModel> ShoppingCartItems { get; private set; } = new List<ApiShoppingCartItemClientResponseModel>();

		public List<ApiSpecialOfferClientResponseModel> SpecialOffers { get; private set; } = new List<ApiSpecialOfferClientResponseModel>();

		public List<ApiStoreClientResponseModel> Stores { get; private set; } = new List<ApiStoreClientResponseModel>();

		public void AddAWBuildVersion(ApiAWBuildVersionClientResponseModel item)
		{
			if (!this.AWBuildVersions.Any(x => x.SystemInformationID == item.SystemInformationID))
			{
				this.AWBuildVersions.Add(item);
			}
		}

		public void AddDatabaseLog(ApiDatabaseLogClientResponseModel item)
		{
			if (!this.DatabaseLogs.Any(x => x.DatabaseLogID == item.DatabaseLogID))
			{
				this.DatabaseLogs.Add(item);
			}
		}

		public void AddErrorLog(ApiErrorLogClientResponseModel item)
		{
			if (!this.ErrorLogs.Any(x => x.ErrorLogID == item.ErrorLogID))
			{
				this.ErrorLogs.Add(item);
			}
		}

		public void AddDepartment(ApiDepartmentClientResponseModel item)
		{
			if (!this.Departments.Any(x => x.DepartmentID == item.DepartmentID))
			{
				this.Departments.Add(item);
			}
		}

		public void AddEmployee(ApiEmployeeClientResponseModel item)
		{
			if (!this.Employees.Any(x => x.BusinessEntityID == item.BusinessEntityID))
			{
				this.Employees.Add(item);
			}
		}

		public void AddJobCandidate(ApiJobCandidateClientResponseModel item)
		{
			if (!this.JobCandidates.Any(x => x.JobCandidateID == item.JobCandidateID))
			{
				this.JobCandidates.Add(item);
			}
		}

		public void AddShift(ApiShiftClientResponseModel item)
		{
			if (!this.Shifts.Any(x => x.ShiftID == item.ShiftID))
			{
				this.Shifts.Add(item);
			}
		}

		public void AddAddress(ApiAddressClientResponseModel item)
		{
			if (!this.Addresses.Any(x => x.AddressID == item.AddressID))
			{
				this.Addresses.Add(item);
			}
		}

		public void AddAddressType(ApiAddressTypeClientResponseModel item)
		{
			if (!this.AddressTypes.Any(x => x.AddressTypeID == item.AddressTypeID))
			{
				this.AddressTypes.Add(item);
			}
		}

		public void AddBusinessEntity(ApiBusinessEntityClientResponseModel item)
		{
			if (!this.BusinessEntities.Any(x => x.BusinessEntityID == item.BusinessEntityID))
			{
				this.BusinessEntities.Add(item);
			}
		}

		public void AddContactType(ApiContactTypeClientResponseModel item)
		{
			if (!this.ContactTypes.Any(x => x.ContactTypeID == item.ContactTypeID))
			{
				this.ContactTypes.Add(item);
			}
		}

		public void AddCountryRegion(ApiCountryRegionClientResponseModel item)
		{
			if (!this.CountryRegions.Any(x => x.CountryRegionCode == item.CountryRegionCode))
			{
				this.CountryRegions.Add(item);
			}
		}

		public void AddPassword(ApiPasswordClientResponseModel item)
		{
			if (!this.Passwords.Any(x => x.BusinessEntityID == item.BusinessEntityID))
			{
				this.Passwords.Add(item);
			}
		}

		public void AddPerson(ApiPersonClientResponseModel item)
		{
			if (!this.People.Any(x => x.BusinessEntityID == item.BusinessEntityID))
			{
				this.People.Add(item);
			}
		}

		public void AddPhoneNumberType(ApiPhoneNumberTypeClientResponseModel item)
		{
			if (!this.PhoneNumberTypes.Any(x => x.PhoneNumberTypeID == item.PhoneNumberTypeID))
			{
				this.PhoneNumberTypes.Add(item);
			}
		}

		public void AddStateProvince(ApiStateProvinceClientResponseModel item)
		{
			if (!this.StateProvinces.Any(x => x.StateProvinceID == item.StateProvinceID))
			{
				this.StateProvinces.Add(item);
			}
		}

		public void AddBillOfMaterial(ApiBillOfMaterialClientResponseModel item)
		{
			if (!this.BillOfMaterials.Any(x => x.BillOfMaterialsID == item.BillOfMaterialsID))
			{
				this.BillOfMaterials.Add(item);
			}
		}

		public void AddCulture(ApiCultureClientResponseModel item)
		{
			if (!this.Cultures.Any(x => x.CultureID == item.CultureID))
			{
				this.Cultures.Add(item);
			}
		}

		public void AddDocument(ApiDocumentClientResponseModel item)
		{
			if (!this.Documents.Any(x => x.Rowguid == item.Rowguid))
			{
				this.Documents.Add(item);
			}
		}

		public void AddIllustration(ApiIllustrationClientResponseModel item)
		{
			if (!this.Illustrations.Any(x => x.IllustrationID == item.IllustrationID))
			{
				this.Illustrations.Add(item);
			}
		}

		public void AddLocation(ApiLocationClientResponseModel item)
		{
			if (!this.Locations.Any(x => x.LocationID == item.LocationID))
			{
				this.Locations.Add(item);
			}
		}

		public void AddProduct(ApiProductClientResponseModel item)
		{
			if (!this.Products.Any(x => x.ProductID == item.ProductID))
			{
				this.Products.Add(item);
			}
		}

		public void AddProductCategory(ApiProductCategoryClientResponseModel item)
		{
			if (!this.ProductCategories.Any(x => x.ProductCategoryID == item.ProductCategoryID))
			{
				this.ProductCategories.Add(item);
			}
		}

		public void AddProductDescription(ApiProductDescriptionClientResponseModel item)
		{
			if (!this.ProductDescriptions.Any(x => x.ProductDescriptionID == item.ProductDescriptionID))
			{
				this.ProductDescriptions.Add(item);
			}
		}

		public void AddProductModel(ApiProductModelClientResponseModel item)
		{
			if (!this.ProductModels.Any(x => x.ProductModelID == item.ProductModelID))
			{
				this.ProductModels.Add(item);
			}
		}

		public void AddProductPhoto(ApiProductPhotoClientResponseModel item)
		{
			if (!this.ProductPhotoes.Any(x => x.ProductPhotoID == item.ProductPhotoID))
			{
				this.ProductPhotoes.Add(item);
			}
		}

		public void AddProductReview(ApiProductReviewClientResponseModel item)
		{
			if (!this.ProductReviews.Any(x => x.ProductReviewID == item.ProductReviewID))
			{
				this.ProductReviews.Add(item);
			}
		}

		public void AddProductSubcategory(ApiProductSubcategoryClientResponseModel item)
		{
			if (!this.ProductSubcategories.Any(x => x.ProductSubcategoryID == item.ProductSubcategoryID))
			{
				this.ProductSubcategories.Add(item);
			}
		}

		public void AddScrapReason(ApiScrapReasonClientResponseModel item)
		{
			if (!this.ScrapReasons.Any(x => x.ScrapReasonID == item.ScrapReasonID))
			{
				this.ScrapReasons.Add(item);
			}
		}

		public void AddTransactionHistory(ApiTransactionHistoryClientResponseModel item)
		{
			if (!this.TransactionHistories.Any(x => x.TransactionID == item.TransactionID))
			{
				this.TransactionHistories.Add(item);
			}
		}

		public void AddTransactionHistoryArchive(ApiTransactionHistoryArchiveClientResponseModel item)
		{
			if (!this.TransactionHistoryArchives.Any(x => x.TransactionID == item.TransactionID))
			{
				this.TransactionHistoryArchives.Add(item);
			}
		}

		public void AddUnitMeasure(ApiUnitMeasureClientResponseModel item)
		{
			if (!this.UnitMeasures.Any(x => x.UnitMeasureCode == item.UnitMeasureCode))
			{
				this.UnitMeasures.Add(item);
			}
		}

		public void AddWorkOrder(ApiWorkOrderClientResponseModel item)
		{
			if (!this.WorkOrders.Any(x => x.WorkOrderID == item.WorkOrderID))
			{
				this.WorkOrders.Add(item);
			}
		}

		public void AddPurchaseOrderHeader(ApiPurchaseOrderHeaderClientResponseModel item)
		{
			if (!this.PurchaseOrderHeaders.Any(x => x.PurchaseOrderID == item.PurchaseOrderID))
			{
				this.PurchaseOrderHeaders.Add(item);
			}
		}

		public void AddShipMethod(ApiShipMethodClientResponseModel item)
		{
			if (!this.ShipMethods.Any(x => x.ShipMethodID == item.ShipMethodID))
			{
				this.ShipMethods.Add(item);
			}
		}

		public void AddVendor(ApiVendorClientResponseModel item)
		{
			if (!this.Vendors.Any(x => x.BusinessEntityID == item.BusinessEntityID))
			{
				this.Vendors.Add(item);
			}
		}

		public void AddCreditCard(ApiCreditCardClientResponseModel item)
		{
			if (!this.CreditCards.Any(x => x.CreditCardID == item.CreditCardID))
			{
				this.CreditCards.Add(item);
			}
		}

		public void AddCurrency(ApiCurrencyClientResponseModel item)
		{
			if (!this.Currencies.Any(x => x.CurrencyCode == item.CurrencyCode))
			{
				this.Currencies.Add(item);
			}
		}

		public void AddCurrencyRate(ApiCurrencyRateClientResponseModel item)
		{
			if (!this.CurrencyRates.Any(x => x.CurrencyRateID == item.CurrencyRateID))
			{
				this.CurrencyRates.Add(item);
			}
		}

		public void AddCustomer(ApiCustomerClientResponseModel item)
		{
			if (!this.Customers.Any(x => x.CustomerID == item.CustomerID))
			{
				this.Customers.Add(item);
			}
		}

		public void AddSalesOrderHeader(ApiSalesOrderHeaderClientResponseModel item)
		{
			if (!this.SalesOrderHeaders.Any(x => x.SalesOrderID == item.SalesOrderID))
			{
				this.SalesOrderHeaders.Add(item);
			}
		}

		public void AddSalesPerson(ApiSalesPersonClientResponseModel item)
		{
			if (!this.SalesPersons.Any(x => x.BusinessEntityID == item.BusinessEntityID))
			{
				this.SalesPersons.Add(item);
			}
		}

		public void AddSalesReason(ApiSalesReasonClientResponseModel item)
		{
			if (!this.SalesReasons.Any(x => x.SalesReasonID == item.SalesReasonID))
			{
				this.SalesReasons.Add(item);
			}
		}

		public void AddSalesTaxRate(ApiSalesTaxRateClientResponseModel item)
		{
			if (!this.SalesTaxRates.Any(x => x.SalesTaxRateID == item.SalesTaxRateID))
			{
				this.SalesTaxRates.Add(item);
			}
		}

		public void AddSalesTerritory(ApiSalesTerritoryClientResponseModel item)
		{
			if (!this.SalesTerritories.Any(x => x.TerritoryID == item.TerritoryID))
			{
				this.SalesTerritories.Add(item);
			}
		}

		public void AddShoppingCartItem(ApiShoppingCartItemClientResponseModel item)
		{
			if (!this.ShoppingCartItems.Any(x => x.ShoppingCartItemID == item.ShoppingCartItemID))
			{
				this.ShoppingCartItems.Add(item);
			}
		}

		public void AddSpecialOffer(ApiSpecialOfferClientResponseModel item)
		{
			if (!this.SpecialOffers.Any(x => x.SpecialOfferID == item.SpecialOfferID))
			{
				this.SpecialOffers.Add(item);
			}
		}

		public void AddStore(ApiStoreClientResponseModel item)
		{
			if (!this.Stores.Any(x => x.BusinessEntityID == item.BusinessEntityID))
			{
				this.Stores.Add(item);
			}
		}
	}
}

/*<Codenesium>
    <Hash>19becb3bc6792b085ae7073697547314</Hash>
</Codenesium>*/