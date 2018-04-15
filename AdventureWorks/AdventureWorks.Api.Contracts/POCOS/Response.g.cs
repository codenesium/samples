using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace AdventureWorksNS.Api.Contracts
{
	public class ReferenceEntity<T>
	{
		[JsonProperty(PropertyName = "V")]
		public T Value { get; set; }

		[JsonProperty(PropertyName = "O")]
		public string ReferenceObjectName { get; set; }

		public ReferenceEntity(T value, string referenceObjectName)
		{
			this.Value = value;
			this.ReferenceObjectName = referenceObjectName;
		}
	}

	public partial class ApiResponse
	{
		public ApiResponse()
		{}
		public List<POCOAWBuildVersion> AWBuildVersions { get; private set; } = new List<POCOAWBuildVersion>();

		public List<POCODatabaseLog> DatabaseLogs { get; private set; } = new List<POCODatabaseLog>();

		public List<POCOErrorLog> ErrorLogs { get; private set; } = new List<POCOErrorLog>();

		public List<POCODepartment> Departments { get; private set; } = new List<POCODepartment>();

		public List<POCOEmployee> Employees { get; private set; } = new List<POCOEmployee>();

		public List<POCOEmployeeDepartmentHistory> EmployeeDepartmentHistories { get; private set; } = new List<POCOEmployeeDepartmentHistory>();

		public List<POCOEmployeePayHistory> EmployeePayHistories { get; private set; } = new List<POCOEmployeePayHistory>();

		public List<POCOJobCandidate> JobCandidates { get; private set; } = new List<POCOJobCandidate>();

		public List<POCOShift> Shifts { get; private set; } = new List<POCOShift>();

		public List<POCOAddress> Addresses { get; private set; } = new List<POCOAddress>();

		public List<POCOAddressType> AddressTypes { get; private set; } = new List<POCOAddressType>();

		public List<POCOBusinessEntity> BusinessEntities { get; private set; } = new List<POCOBusinessEntity>();

		public List<POCOBusinessEntityAddress> BusinessEntityAddresses { get; private set; } = new List<POCOBusinessEntityAddress>();

		public List<POCOBusinessEntityContact> BusinessEntityContacts { get; private set; } = new List<POCOBusinessEntityContact>();

		public List<POCOContactType> ContactTypes { get; private set; } = new List<POCOContactType>();

		public List<POCOCountryRegion> CountryRegions { get; private set; } = new List<POCOCountryRegion>();

		public List<POCOEmailAddress> EmailAddresses { get; private set; } = new List<POCOEmailAddress>();

		public List<POCOPassword> Passwords { get; private set; } = new List<POCOPassword>();

		public List<POCOPerson> People { get; private set; } = new List<POCOPerson>();

		public List<POCOPersonPhone> PersonPhones { get; private set; } = new List<POCOPersonPhone>();

		public List<POCOPhoneNumberType> PhoneNumberTypes { get; private set; } = new List<POCOPhoneNumberType>();

		public List<POCOStateProvince> StateProvinces { get; private set; } = new List<POCOStateProvince>();

		public List<POCOBillOfMaterials> BillOfMaterials { get; private set; } = new List<POCOBillOfMaterials>();

		public List<POCOCulture> Cultures { get; private set; } = new List<POCOCulture>();

		public List<POCODocument> Documents { get; private set; } = new List<POCODocument>();

		public List<POCOIllustration> Illustrations { get; private set; } = new List<POCOIllustration>();

		public List<POCOLocation> Locations { get; private set; } = new List<POCOLocation>();

		public List<POCOProduct> Products { get; private set; } = new List<POCOProduct>();

		public List<POCOProductCategory> ProductCategories { get; private set; } = new List<POCOProductCategory>();

		public List<POCOProductCostHistory> ProductCostHistories { get; private set; } = new List<POCOProductCostHistory>();

		public List<POCOProductDescription> ProductDescriptions { get; private set; } = new List<POCOProductDescription>();

		public List<POCOProductDocument> ProductDocuments { get; private set; } = new List<POCOProductDocument>();

		public List<POCOProductInventory> ProductInventories { get; private set; } = new List<POCOProductInventory>();

		public List<POCOProductListPriceHistory> ProductListPriceHistories { get; private set; } = new List<POCOProductListPriceHistory>();

		public List<POCOProductModel> ProductModels { get; private set; } = new List<POCOProductModel>();

		public List<POCOProductModelIllustration> ProductModelIllustrations { get; private set; } = new List<POCOProductModelIllustration>();

		public List<POCOProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; private set; } = new List<POCOProductModelProductDescriptionCulture>();

		public List<POCOProductPhoto> ProductPhotoes { get; private set; } = new List<POCOProductPhoto>();

		public List<POCOProductProductPhoto> ProductProductPhotoes { get; private set; } = new List<POCOProductProductPhoto>();

		public List<POCOProductReview> ProductReviews { get; private set; } = new List<POCOProductReview>();

		public List<POCOProductSubcategory> ProductSubcategories { get; private set; } = new List<POCOProductSubcategory>();

		public List<POCOScrapReason> ScrapReasons { get; private set; } = new List<POCOScrapReason>();

		public List<POCOTransactionHistory> TransactionHistories { get; private set; } = new List<POCOTransactionHistory>();

		public List<POCOTransactionHistoryArchive> TransactionHistoryArchives { get; private set; } = new List<POCOTransactionHistoryArchive>();

		public List<POCOUnitMeasure> UnitMeasures { get; private set; } = new List<POCOUnitMeasure>();

		public List<POCOWorkOrder> WorkOrders { get; private set; } = new List<POCOWorkOrder>();

		public List<POCOWorkOrderRouting> WorkOrderRoutings { get; private set; } = new List<POCOWorkOrderRouting>();

		public List<POCOProductVendor> ProductVendors { get; private set; } = new List<POCOProductVendor>();

		public List<POCOPurchaseOrderDetail> PurchaseOrderDetails { get; private set; } = new List<POCOPurchaseOrderDetail>();

		public List<POCOPurchaseOrderHeader> PurchaseOrderHeaders { get; private set; } = new List<POCOPurchaseOrderHeader>();

		public List<POCOShipMethod> ShipMethods { get; private set; } = new List<POCOShipMethod>();

		public List<POCOVendor> Vendors { get; private set; } = new List<POCOVendor>();

		public List<POCOCountryRegionCurrency> CountryRegionCurrencies { get; private set; } = new List<POCOCountryRegionCurrency>();

		public List<POCOCreditCard> CreditCards { get; private set; } = new List<POCOCreditCard>();

		public List<POCOCurrency> Currencies { get; private set; } = new List<POCOCurrency>();

		public List<POCOCurrencyRate> CurrencyRates { get; private set; } = new List<POCOCurrencyRate>();

		public List<POCOCustomer> Customers { get; private set; } = new List<POCOCustomer>();

		public List<POCOPersonCreditCard> PersonCreditCards { get; private set; } = new List<POCOPersonCreditCard>();

		public List<POCOSalesOrderDetail> SalesOrderDetails { get; private set; } = new List<POCOSalesOrderDetail>();

		public List<POCOSalesOrderHeader> SalesOrderHeaders { get; private set; } = new List<POCOSalesOrderHeader>();

		public List<POCOSalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons { get; private set; } = new List<POCOSalesOrderHeaderSalesReason>();

		public List<POCOSalesPerson> SalesPersons { get; private set; } = new List<POCOSalesPerson>();

		public List<POCOSalesPersonQuotaHistory> SalesPersonQuotaHistories { get; private set; } = new List<POCOSalesPersonQuotaHistory>();

		public List<POCOSalesReason> SalesReasons { get; private set; } = new List<POCOSalesReason>();

		public List<POCOSalesTaxRate> SalesTaxRates { get; private set; } = new List<POCOSalesTaxRate>();

		public List<POCOSalesTerritory> SalesTerritories { get; private set; } = new List<POCOSalesTerritory>();

		public List<POCOSalesTerritoryHistory> SalesTerritoryHistories { get; private set; } = new List<POCOSalesTerritoryHistory>();

		public List<POCOShoppingCartItem> ShoppingCartItems { get; private set; } = new List<POCOShoppingCartItem>();

		public List<POCOSpecialOffer> SpecialOffers { get; private set; } = new List<POCOSpecialOffer>();

		public List<POCOSpecialOfferProduct> SpecialOfferProducts { get; private set; } = new List<POCOSpecialOfferProduct>();

		public List<POCOStore> Stores { get; private set; } = new List<POCOStore>();

		[JsonIgnore]
		public bool ShouldSerializeAWBuildVersionsValue { get; set; } = true;

		public bool ShouldSerializeAWBuildVersions()
		{
			return this.ShouldSerializeAWBuildVersionsValue;
		}

		public void AddAWBuildVersion(POCOAWBuildVersion item)
		{
			if (!this.AWBuildVersions.Any(x => x.SystemInformationID == item.SystemInformationID))
			{
				this.AWBuildVersions.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeDatabaseLogsValue { get; set; } = true;

		public bool ShouldSerializeDatabaseLogs()
		{
			return this.ShouldSerializeDatabaseLogsValue;
		}

		public void AddDatabaseLog(POCODatabaseLog item)
		{
			if (!this.DatabaseLogs.Any(x => x.DatabaseLogID == item.DatabaseLogID))
			{
				this.DatabaseLogs.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeErrorLogsValue { get; set; } = true;

		public bool ShouldSerializeErrorLogs()
		{
			return this.ShouldSerializeErrorLogsValue;
		}

		public void AddErrorLog(POCOErrorLog item)
		{
			if (!this.ErrorLogs.Any(x => x.ErrorLogID == item.ErrorLogID))
			{
				this.ErrorLogs.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeDepartmentsValue { get; set; } = true;

		public bool ShouldSerializeDepartments()
		{
			return this.ShouldSerializeDepartmentsValue;
		}

		public void AddDepartment(POCODepartment item)
		{
			if (!this.Departments.Any(x => x.DepartmentID == item.DepartmentID))
			{
				this.Departments.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeEmployeesValue { get; set; } = true;

		public bool ShouldSerializeEmployees()
		{
			return this.ShouldSerializeEmployeesValue;
		}

		public void AddEmployee(POCOEmployee item)
		{
			if (!this.Employees.Any(x => x.BusinessEntityID == item.BusinessEntityID))
			{
				this.Employees.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeEmployeeDepartmentHistoriesValue { get; set; } = true;

		public bool ShouldSerializeEmployeeDepartmentHistories()
		{
			return this.ShouldSerializeEmployeeDepartmentHistoriesValue;
		}

		public void AddEmployeeDepartmentHistory(POCOEmployeeDepartmentHistory item)
		{
			if (!this.EmployeeDepartmentHistories.Any(x => x.BusinessEntityID == item.BusinessEntityID))
			{
				this.EmployeeDepartmentHistories.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeEmployeePayHistoriesValue { get; set; } = true;

		public bool ShouldSerializeEmployeePayHistories()
		{
			return this.ShouldSerializeEmployeePayHistoriesValue;
		}

		public void AddEmployeePayHistory(POCOEmployeePayHistory item)
		{
			if (!this.EmployeePayHistories.Any(x => x.BusinessEntityID == item.BusinessEntityID))
			{
				this.EmployeePayHistories.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeJobCandidatesValue { get; set; } = true;

		public bool ShouldSerializeJobCandidates()
		{
			return this.ShouldSerializeJobCandidatesValue;
		}

		public void AddJobCandidate(POCOJobCandidate item)
		{
			if (!this.JobCandidates.Any(x => x.JobCandidateID == item.JobCandidateID))
			{
				this.JobCandidates.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeShiftsValue { get; set; } = true;

		public bool ShouldSerializeShifts()
		{
			return this.ShouldSerializeShiftsValue;
		}

		public void AddShift(POCOShift item)
		{
			if (!this.Shifts.Any(x => x.ShiftID == item.ShiftID))
			{
				this.Shifts.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeAddressesValue { get; set; } = true;

		public bool ShouldSerializeAddresses()
		{
			return this.ShouldSerializeAddressesValue;
		}

		public void AddAddress(POCOAddress item)
		{
			if (!this.Addresses.Any(x => x.AddressID == item.AddressID))
			{
				this.Addresses.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeAddressTypesValue { get; set; } = true;

		public bool ShouldSerializeAddressTypes()
		{
			return this.ShouldSerializeAddressTypesValue;
		}

		public void AddAddressType(POCOAddressType item)
		{
			if (!this.AddressTypes.Any(x => x.AddressTypeID == item.AddressTypeID))
			{
				this.AddressTypes.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntitiesValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntities()
		{
			return this.ShouldSerializeBusinessEntitiesValue;
		}

		public void AddBusinessEntity(POCOBusinessEntity item)
		{
			if (!this.BusinessEntities.Any(x => x.BusinessEntityID == item.BusinessEntityID))
			{
				this.BusinessEntities.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityAddressesValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityAddresses()
		{
			return this.ShouldSerializeBusinessEntityAddressesValue;
		}

		public void AddBusinessEntityAddress(POCOBusinessEntityAddress item)
		{
			if (!this.BusinessEntityAddresses.Any(x => x.BusinessEntityID == item.BusinessEntityID))
			{
				this.BusinessEntityAddresses.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityContactsValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityContacts()
		{
			return this.ShouldSerializeBusinessEntityContactsValue;
		}

		public void AddBusinessEntityContact(POCOBusinessEntityContact item)
		{
			if (!this.BusinessEntityContacts.Any(x => x.BusinessEntityID == item.BusinessEntityID))
			{
				this.BusinessEntityContacts.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeContactTypesValue { get; set; } = true;

		public bool ShouldSerializeContactTypes()
		{
			return this.ShouldSerializeContactTypesValue;
		}

		public void AddContactType(POCOContactType item)
		{
			if (!this.ContactTypes.Any(x => x.ContactTypeID == item.ContactTypeID))
			{
				this.ContactTypes.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeCountryRegionsValue { get; set; } = true;

		public bool ShouldSerializeCountryRegions()
		{
			return this.ShouldSerializeCountryRegionsValue;
		}

		public void AddCountryRegion(POCOCountryRegion item)
		{
			if (!this.CountryRegions.Any(x => x.CountryRegionCode == item.CountryRegionCode))
			{
				this.CountryRegions.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeEmailAddressesValue { get; set; } = true;

		public bool ShouldSerializeEmailAddresses()
		{
			return this.ShouldSerializeEmailAddressesValue;
		}

		public void AddEmailAddress(POCOEmailAddress item)
		{
			if (!this.EmailAddresses.Any(x => x.BusinessEntityID == item.BusinessEntityID))
			{
				this.EmailAddresses.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePasswordsValue { get; set; } = true;

		public bool ShouldSerializePasswords()
		{
			return this.ShouldSerializePasswordsValue;
		}

		public void AddPassword(POCOPassword item)
		{
			if (!this.Passwords.Any(x => x.BusinessEntityID == item.BusinessEntityID))
			{
				this.Passwords.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePeopleValue { get; set; } = true;

		public bool ShouldSerializePeople()
		{
			return this.ShouldSerializePeopleValue;
		}

		public void AddPerson(POCOPerson item)
		{
			if (!this.People.Any(x => x.BusinessEntityID == item.BusinessEntityID))
			{
				this.People.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePersonPhonesValue { get; set; } = true;

		public bool ShouldSerializePersonPhones()
		{
			return this.ShouldSerializePersonPhonesValue;
		}

		public void AddPersonPhone(POCOPersonPhone item)
		{
			if (!this.PersonPhones.Any(x => x.BusinessEntityID == item.BusinessEntityID))
			{
				this.PersonPhones.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePhoneNumberTypesValue { get; set; } = true;

		public bool ShouldSerializePhoneNumberTypes()
		{
			return this.ShouldSerializePhoneNumberTypesValue;
		}

		public void AddPhoneNumberType(POCOPhoneNumberType item)
		{
			if (!this.PhoneNumberTypes.Any(x => x.PhoneNumberTypeID == item.PhoneNumberTypeID))
			{
				this.PhoneNumberTypes.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeStateProvincesValue { get; set; } = true;

		public bool ShouldSerializeStateProvinces()
		{
			return this.ShouldSerializeStateProvincesValue;
		}

		public void AddStateProvince(POCOStateProvince item)
		{
			if (!this.StateProvinces.Any(x => x.StateProvinceID == item.StateProvinceID))
			{
				this.StateProvinces.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeBillOfMaterialsValue { get; set; } = true;

		public bool ShouldSerializeBillOfMaterials()
		{
			return this.ShouldSerializeBillOfMaterialsValue;
		}

		public void AddBillOfMaterials(POCOBillOfMaterials item)
		{
			if (!this.BillOfMaterials.Any(x => x.BillOfMaterialsID == item.BillOfMaterialsID))
			{
				this.BillOfMaterials.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeCulturesValue { get; set; } = true;

		public bool ShouldSerializeCultures()
		{
			return this.ShouldSerializeCulturesValue;
		}

		public void AddCulture(POCOCulture item)
		{
			if (!this.Cultures.Any(x => x.CultureID == item.CultureID))
			{
				this.Cultures.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeDocumentsValue { get; set; } = true;

		public bool ShouldSerializeDocuments()
		{
			return this.ShouldSerializeDocumentsValue;
		}

		public void AddDocument(POCODocument item)
		{
			if (!this.Documents.Any(x => x.DocumentNode == item.DocumentNode))
			{
				this.Documents.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeIllustrationsValue { get; set; } = true;

		public bool ShouldSerializeIllustrations()
		{
			return this.ShouldSerializeIllustrationsValue;
		}

		public void AddIllustration(POCOIllustration item)
		{
			if (!this.Illustrations.Any(x => x.IllustrationID == item.IllustrationID))
			{
				this.Illustrations.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeLocationsValue { get; set; } = true;

		public bool ShouldSerializeLocations()
		{
			return this.ShouldSerializeLocationsValue;
		}

		public void AddLocation(POCOLocation item)
		{
			if (!this.Locations.Any(x => x.LocationID == item.LocationID))
			{
				this.Locations.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeProductsValue { get; set; } = true;

		public bool ShouldSerializeProducts()
		{
			return this.ShouldSerializeProductsValue;
		}

		public void AddProduct(POCOProduct item)
		{
			if (!this.Products.Any(x => x.ProductID == item.ProductID))
			{
				this.Products.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeProductCategoriesValue { get; set; } = true;

		public bool ShouldSerializeProductCategories()
		{
			return this.ShouldSerializeProductCategoriesValue;
		}

		public void AddProductCategory(POCOProductCategory item)
		{
			if (!this.ProductCategories.Any(x => x.ProductCategoryID == item.ProductCategoryID))
			{
				this.ProductCategories.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeProductCostHistoriesValue { get; set; } = true;

		public bool ShouldSerializeProductCostHistories()
		{
			return this.ShouldSerializeProductCostHistoriesValue;
		}

		public void AddProductCostHistory(POCOProductCostHistory item)
		{
			if (!this.ProductCostHistories.Any(x => x.ProductID == item.ProductID))
			{
				this.ProductCostHistories.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeProductDescriptionsValue { get; set; } = true;

		public bool ShouldSerializeProductDescriptions()
		{
			return this.ShouldSerializeProductDescriptionsValue;
		}

		public void AddProductDescription(POCOProductDescription item)
		{
			if (!this.ProductDescriptions.Any(x => x.ProductDescriptionID == item.ProductDescriptionID))
			{
				this.ProductDescriptions.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeProductDocumentsValue { get; set; } = true;

		public bool ShouldSerializeProductDocuments()
		{
			return this.ShouldSerializeProductDocumentsValue;
		}

		public void AddProductDocument(POCOProductDocument item)
		{
			if (!this.ProductDocuments.Any(x => x.ProductID == item.ProductID))
			{
				this.ProductDocuments.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeProductInventoriesValue { get; set; } = true;

		public bool ShouldSerializeProductInventories()
		{
			return this.ShouldSerializeProductInventoriesValue;
		}

		public void AddProductInventory(POCOProductInventory item)
		{
			if (!this.ProductInventories.Any(x => x.ProductID == item.ProductID))
			{
				this.ProductInventories.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeProductListPriceHistoriesValue { get; set; } = true;

		public bool ShouldSerializeProductListPriceHistories()
		{
			return this.ShouldSerializeProductListPriceHistoriesValue;
		}

		public void AddProductListPriceHistory(POCOProductListPriceHistory item)
		{
			if (!this.ProductListPriceHistories.Any(x => x.ProductID == item.ProductID))
			{
				this.ProductListPriceHistories.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeProductModelsValue { get; set; } = true;

		public bool ShouldSerializeProductModels()
		{
			return this.ShouldSerializeProductModelsValue;
		}

		public void AddProductModel(POCOProductModel item)
		{
			if (!this.ProductModels.Any(x => x.ProductModelID == item.ProductModelID))
			{
				this.ProductModels.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeProductModelIllustrationsValue { get; set; } = true;

		public bool ShouldSerializeProductModelIllustrations()
		{
			return this.ShouldSerializeProductModelIllustrationsValue;
		}

		public void AddProductModelIllustration(POCOProductModelIllustration item)
		{
			if (!this.ProductModelIllustrations.Any(x => x.ProductModelID == item.ProductModelID))
			{
				this.ProductModelIllustrations.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeProductModelProductDescriptionCulturesValue { get; set; } = true;

		public bool ShouldSerializeProductModelProductDescriptionCultures()
		{
			return this.ShouldSerializeProductModelProductDescriptionCulturesValue;
		}

		public void AddProductModelProductDescriptionCulture(POCOProductModelProductDescriptionCulture item)
		{
			if (!this.ProductModelProductDescriptionCultures.Any(x => x.ProductModelID == item.ProductModelID))
			{
				this.ProductModelProductDescriptionCultures.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeProductPhotoesValue { get; set; } = true;

		public bool ShouldSerializeProductPhotoes()
		{
			return this.ShouldSerializeProductPhotoesValue;
		}

		public void AddProductPhoto(POCOProductPhoto item)
		{
			if (!this.ProductPhotoes.Any(x => x.ProductPhotoID == item.ProductPhotoID))
			{
				this.ProductPhotoes.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeProductProductPhotoesValue { get; set; } = true;

		public bool ShouldSerializeProductProductPhotoes()
		{
			return this.ShouldSerializeProductProductPhotoesValue;
		}

		public void AddProductProductPhoto(POCOProductProductPhoto item)
		{
			if (!this.ProductProductPhotoes.Any(x => x.ProductID == item.ProductID))
			{
				this.ProductProductPhotoes.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeProductReviewsValue { get; set; } = true;

		public bool ShouldSerializeProductReviews()
		{
			return this.ShouldSerializeProductReviewsValue;
		}

		public void AddProductReview(POCOProductReview item)
		{
			if (!this.ProductReviews.Any(x => x.ProductReviewID == item.ProductReviewID))
			{
				this.ProductReviews.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeProductSubcategoriesValue { get; set; } = true;

		public bool ShouldSerializeProductSubcategories()
		{
			return this.ShouldSerializeProductSubcategoriesValue;
		}

		public void AddProductSubcategory(POCOProductSubcategory item)
		{
			if (!this.ProductSubcategories.Any(x => x.ProductSubcategoryID == item.ProductSubcategoryID))
			{
				this.ProductSubcategories.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeScrapReasonsValue { get; set; } = true;

		public bool ShouldSerializeScrapReasons()
		{
			return this.ShouldSerializeScrapReasonsValue;
		}

		public void AddScrapReason(POCOScrapReason item)
		{
			if (!this.ScrapReasons.Any(x => x.ScrapReasonID == item.ScrapReasonID))
			{
				this.ScrapReasons.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeTransactionHistoriesValue { get; set; } = true;

		public bool ShouldSerializeTransactionHistories()
		{
			return this.ShouldSerializeTransactionHistoriesValue;
		}

		public void AddTransactionHistory(POCOTransactionHistory item)
		{
			if (!this.TransactionHistories.Any(x => x.TransactionID == item.TransactionID))
			{
				this.TransactionHistories.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeTransactionHistoryArchivesValue { get; set; } = true;

		public bool ShouldSerializeTransactionHistoryArchives()
		{
			return this.ShouldSerializeTransactionHistoryArchivesValue;
		}

		public void AddTransactionHistoryArchive(POCOTransactionHistoryArchive item)
		{
			if (!this.TransactionHistoryArchives.Any(x => x.TransactionID == item.TransactionID))
			{
				this.TransactionHistoryArchives.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeUnitMeasuresValue { get; set; } = true;

		public bool ShouldSerializeUnitMeasures()
		{
			return this.ShouldSerializeUnitMeasuresValue;
		}

		public void AddUnitMeasure(POCOUnitMeasure item)
		{
			if (!this.UnitMeasures.Any(x => x.UnitMeasureCode == item.UnitMeasureCode))
			{
				this.UnitMeasures.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeWorkOrdersValue { get; set; } = true;

		public bool ShouldSerializeWorkOrders()
		{
			return this.ShouldSerializeWorkOrdersValue;
		}

		public void AddWorkOrder(POCOWorkOrder item)
		{
			if (!this.WorkOrders.Any(x => x.WorkOrderID == item.WorkOrderID))
			{
				this.WorkOrders.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeWorkOrderRoutingsValue { get; set; } = true;

		public bool ShouldSerializeWorkOrderRoutings()
		{
			return this.ShouldSerializeWorkOrderRoutingsValue;
		}

		public void AddWorkOrderRouting(POCOWorkOrderRouting item)
		{
			if (!this.WorkOrderRoutings.Any(x => x.WorkOrderID == item.WorkOrderID))
			{
				this.WorkOrderRoutings.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeProductVendorsValue { get; set; } = true;

		public bool ShouldSerializeProductVendors()
		{
			return this.ShouldSerializeProductVendorsValue;
		}

		public void AddProductVendor(POCOProductVendor item)
		{
			if (!this.ProductVendors.Any(x => x.ProductID == item.ProductID))
			{
				this.ProductVendors.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePurchaseOrderDetailsValue { get; set; } = true;

		public bool ShouldSerializePurchaseOrderDetails()
		{
			return this.ShouldSerializePurchaseOrderDetailsValue;
		}

		public void AddPurchaseOrderDetail(POCOPurchaseOrderDetail item)
		{
			if (!this.PurchaseOrderDetails.Any(x => x.PurchaseOrderID == item.PurchaseOrderID))
			{
				this.PurchaseOrderDetails.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePurchaseOrderHeadersValue { get; set; } = true;

		public bool ShouldSerializePurchaseOrderHeaders()
		{
			return this.ShouldSerializePurchaseOrderHeadersValue;
		}

		public void AddPurchaseOrderHeader(POCOPurchaseOrderHeader item)
		{
			if (!this.PurchaseOrderHeaders.Any(x => x.PurchaseOrderID == item.PurchaseOrderID))
			{
				this.PurchaseOrderHeaders.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeShipMethodsValue { get; set; } = true;

		public bool ShouldSerializeShipMethods()
		{
			return this.ShouldSerializeShipMethodsValue;
		}

		public void AddShipMethod(POCOShipMethod item)
		{
			if (!this.ShipMethods.Any(x => x.ShipMethodID == item.ShipMethodID))
			{
				this.ShipMethods.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeVendorsValue { get; set; } = true;

		public bool ShouldSerializeVendors()
		{
			return this.ShouldSerializeVendorsValue;
		}

		public void AddVendor(POCOVendor item)
		{
			if (!this.Vendors.Any(x => x.BusinessEntityID == item.BusinessEntityID))
			{
				this.Vendors.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeCountryRegionCurrenciesValue { get; set; } = true;

		public bool ShouldSerializeCountryRegionCurrencies()
		{
			return this.ShouldSerializeCountryRegionCurrenciesValue;
		}

		public void AddCountryRegionCurrency(POCOCountryRegionCurrency item)
		{
			if (!this.CountryRegionCurrencies.Any(x => x.CountryRegionCode == item.CountryRegionCode))
			{
				this.CountryRegionCurrencies.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeCreditCardsValue { get; set; } = true;

		public bool ShouldSerializeCreditCards()
		{
			return this.ShouldSerializeCreditCardsValue;
		}

		public void AddCreditCard(POCOCreditCard item)
		{
			if (!this.CreditCards.Any(x => x.CreditCardID == item.CreditCardID))
			{
				this.CreditCards.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeCurrenciesValue { get; set; } = true;

		public bool ShouldSerializeCurrencies()
		{
			return this.ShouldSerializeCurrenciesValue;
		}

		public void AddCurrency(POCOCurrency item)
		{
			if (!this.Currencies.Any(x => x.CurrencyCode == item.CurrencyCode))
			{
				this.Currencies.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeCurrencyRatesValue { get; set; } = true;

		public bool ShouldSerializeCurrencyRates()
		{
			return this.ShouldSerializeCurrencyRatesValue;
		}

		public void AddCurrencyRate(POCOCurrencyRate item)
		{
			if (!this.CurrencyRates.Any(x => x.CurrencyRateID == item.CurrencyRateID))
			{
				this.CurrencyRates.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeCustomersValue { get; set; } = true;

		public bool ShouldSerializeCustomers()
		{
			return this.ShouldSerializeCustomersValue;
		}

		public void AddCustomer(POCOCustomer item)
		{
			if (!this.Customers.Any(x => x.CustomerID == item.CustomerID))
			{
				this.Customers.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePersonCreditCardsValue { get; set; } = true;

		public bool ShouldSerializePersonCreditCards()
		{
			return this.ShouldSerializePersonCreditCardsValue;
		}

		public void AddPersonCreditCard(POCOPersonCreditCard item)
		{
			if (!this.PersonCreditCards.Any(x => x.BusinessEntityID == item.BusinessEntityID))
			{
				this.PersonCreditCards.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesOrderDetailsValue { get; set; } = true;

		public bool ShouldSerializeSalesOrderDetails()
		{
			return this.ShouldSerializeSalesOrderDetailsValue;
		}

		public void AddSalesOrderDetail(POCOSalesOrderDetail item)
		{
			if (!this.SalesOrderDetails.Any(x => x.SalesOrderID == item.SalesOrderID))
			{
				this.SalesOrderDetails.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesOrderHeadersValue { get; set; } = true;

		public bool ShouldSerializeSalesOrderHeaders()
		{
			return this.ShouldSerializeSalesOrderHeadersValue;
		}

		public void AddSalesOrderHeader(POCOSalesOrderHeader item)
		{
			if (!this.SalesOrderHeaders.Any(x => x.SalesOrderID == item.SalesOrderID))
			{
				this.SalesOrderHeaders.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesOrderHeaderSalesReasonsValue { get; set; } = true;

		public bool ShouldSerializeSalesOrderHeaderSalesReasons()
		{
			return this.ShouldSerializeSalesOrderHeaderSalesReasonsValue;
		}

		public void AddSalesOrderHeaderSalesReason(POCOSalesOrderHeaderSalesReason item)
		{
			if (!this.SalesOrderHeaderSalesReasons.Any(x => x.SalesOrderID == item.SalesOrderID))
			{
				this.SalesOrderHeaderSalesReasons.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesPersonsValue { get; set; } = true;

		public bool ShouldSerializeSalesPersons()
		{
			return this.ShouldSerializeSalesPersonsValue;
		}

		public void AddSalesPerson(POCOSalesPerson item)
		{
			if (!this.SalesPersons.Any(x => x.BusinessEntityID == item.BusinessEntityID))
			{
				this.SalesPersons.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesPersonQuotaHistoriesValue { get; set; } = true;

		public bool ShouldSerializeSalesPersonQuotaHistories()
		{
			return this.ShouldSerializeSalesPersonQuotaHistoriesValue;
		}

		public void AddSalesPersonQuotaHistory(POCOSalesPersonQuotaHistory item)
		{
			if (!this.SalesPersonQuotaHistories.Any(x => x.BusinessEntityID == item.BusinessEntityID))
			{
				this.SalesPersonQuotaHistories.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesReasonsValue { get; set; } = true;

		public bool ShouldSerializeSalesReasons()
		{
			return this.ShouldSerializeSalesReasonsValue;
		}

		public void AddSalesReason(POCOSalesReason item)
		{
			if (!this.SalesReasons.Any(x => x.SalesReasonID == item.SalesReasonID))
			{
				this.SalesReasons.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesTaxRatesValue { get; set; } = true;

		public bool ShouldSerializeSalesTaxRates()
		{
			return this.ShouldSerializeSalesTaxRatesValue;
		}

		public void AddSalesTaxRate(POCOSalesTaxRate item)
		{
			if (!this.SalesTaxRates.Any(x => x.SalesTaxRateID == item.SalesTaxRateID))
			{
				this.SalesTaxRates.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesTerritoriesValue { get; set; } = true;

		public bool ShouldSerializeSalesTerritories()
		{
			return this.ShouldSerializeSalesTerritoriesValue;
		}

		public void AddSalesTerritory(POCOSalesTerritory item)
		{
			if (!this.SalesTerritories.Any(x => x.TerritoryID == item.TerritoryID))
			{
				this.SalesTerritories.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesTerritoryHistoriesValue { get; set; } = true;

		public bool ShouldSerializeSalesTerritoryHistories()
		{
			return this.ShouldSerializeSalesTerritoryHistoriesValue;
		}

		public void AddSalesTerritoryHistory(POCOSalesTerritoryHistory item)
		{
			if (!this.SalesTerritoryHistories.Any(x => x.BusinessEntityID == item.BusinessEntityID))
			{
				this.SalesTerritoryHistories.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeShoppingCartItemsValue { get; set; } = true;

		public bool ShouldSerializeShoppingCartItems()
		{
			return this.ShouldSerializeShoppingCartItemsValue;
		}

		public void AddShoppingCartItem(POCOShoppingCartItem item)
		{
			if (!this.ShoppingCartItems.Any(x => x.ShoppingCartItemID == item.ShoppingCartItemID))
			{
				this.ShoppingCartItems.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSpecialOffersValue { get; set; } = true;

		public bool ShouldSerializeSpecialOffers()
		{
			return this.ShouldSerializeSpecialOffersValue;
		}

		public void AddSpecialOffer(POCOSpecialOffer item)
		{
			if (!this.SpecialOffers.Any(x => x.SpecialOfferID == item.SpecialOfferID))
			{
				this.SpecialOffers.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSpecialOfferProductsValue { get; set; } = true;

		public bool ShouldSerializeSpecialOfferProducts()
		{
			return this.ShouldSerializeSpecialOfferProductsValue;
		}

		public void AddSpecialOfferProduct(POCOSpecialOfferProduct item)
		{
			if (!this.SpecialOfferProducts.Any(x => x.SpecialOfferID == item.SpecialOfferID))
			{
				this.SpecialOfferProducts.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeStoresValue { get; set; } = true;

		public bool ShouldSerializeStores()
		{
			return this.ShouldSerializeStoresValue;
		}

		public void AddStore(POCOStore item)
		{
			if (!this.Stores.Any(x => x.BusinessEntityID == item.BusinessEntityID))
			{
				this.Stores.Add(item);
			}
		}

		public void DisableSerializationOfEmptyFields()
		{
			if (this.AWBuildVersions.Count == 0)
			{
				this.ShouldSerializeAWBuildVersionsValue = false;
			}

			if (this.DatabaseLogs.Count == 0)
			{
				this.ShouldSerializeDatabaseLogsValue = false;
			}

			if (this.ErrorLogs.Count == 0)
			{
				this.ShouldSerializeErrorLogsValue = false;
			}

			if (this.Departments.Count == 0)
			{
				this.ShouldSerializeDepartmentsValue = false;
			}

			if (this.Employees.Count == 0)
			{
				this.ShouldSerializeEmployeesValue = false;
			}

			if (this.EmployeeDepartmentHistories.Count == 0)
			{
				this.ShouldSerializeEmployeeDepartmentHistoriesValue = false;
			}

			if (this.EmployeePayHistories.Count == 0)
			{
				this.ShouldSerializeEmployeePayHistoriesValue = false;
			}

			if (this.JobCandidates.Count == 0)
			{
				this.ShouldSerializeJobCandidatesValue = false;
			}

			if (this.Shifts.Count == 0)
			{
				this.ShouldSerializeShiftsValue = false;
			}

			if (this.Addresses.Count == 0)
			{
				this.ShouldSerializeAddressesValue = false;
			}

			if (this.AddressTypes.Count == 0)
			{
				this.ShouldSerializeAddressTypesValue = false;
			}

			if (this.BusinessEntities.Count == 0)
			{
				this.ShouldSerializeBusinessEntitiesValue = false;
			}

			if (this.BusinessEntityAddresses.Count == 0)
			{
				this.ShouldSerializeBusinessEntityAddressesValue = false;
			}

			if (this.BusinessEntityContacts.Count == 0)
			{
				this.ShouldSerializeBusinessEntityContactsValue = false;
			}

			if (this.ContactTypes.Count == 0)
			{
				this.ShouldSerializeContactTypesValue = false;
			}

			if (this.CountryRegions.Count == 0)
			{
				this.ShouldSerializeCountryRegionsValue = false;
			}

			if (this.EmailAddresses.Count == 0)
			{
				this.ShouldSerializeEmailAddressesValue = false;
			}

			if (this.Passwords.Count == 0)
			{
				this.ShouldSerializePasswordsValue = false;
			}

			if (this.People.Count == 0)
			{
				this.ShouldSerializePeopleValue = false;
			}

			if (this.PersonPhones.Count == 0)
			{
				this.ShouldSerializePersonPhonesValue = false;
			}

			if (this.PhoneNumberTypes.Count == 0)
			{
				this.ShouldSerializePhoneNumberTypesValue = false;
			}

			if (this.StateProvinces.Count == 0)
			{
				this.ShouldSerializeStateProvincesValue = false;
			}

			if (this.BillOfMaterials.Count == 0)
			{
				this.ShouldSerializeBillOfMaterialsValue = false;
			}

			if (this.Cultures.Count == 0)
			{
				this.ShouldSerializeCulturesValue = false;
			}

			if (this.Documents.Count == 0)
			{
				this.ShouldSerializeDocumentsValue = false;
			}

			if (this.Illustrations.Count == 0)
			{
				this.ShouldSerializeIllustrationsValue = false;
			}

			if (this.Locations.Count == 0)
			{
				this.ShouldSerializeLocationsValue = false;
			}

			if (this.Products.Count == 0)
			{
				this.ShouldSerializeProductsValue = false;
			}

			if (this.ProductCategories.Count == 0)
			{
				this.ShouldSerializeProductCategoriesValue = false;
			}

			if (this.ProductCostHistories.Count == 0)
			{
				this.ShouldSerializeProductCostHistoriesValue = false;
			}

			if (this.ProductDescriptions.Count == 0)
			{
				this.ShouldSerializeProductDescriptionsValue = false;
			}

			if (this.ProductDocuments.Count == 0)
			{
				this.ShouldSerializeProductDocumentsValue = false;
			}

			if (this.ProductInventories.Count == 0)
			{
				this.ShouldSerializeProductInventoriesValue = false;
			}

			if (this.ProductListPriceHistories.Count == 0)
			{
				this.ShouldSerializeProductListPriceHistoriesValue = false;
			}

			if (this.ProductModels.Count == 0)
			{
				this.ShouldSerializeProductModelsValue = false;
			}

			if (this.ProductModelIllustrations.Count == 0)
			{
				this.ShouldSerializeProductModelIllustrationsValue = false;
			}

			if (this.ProductModelProductDescriptionCultures.Count == 0)
			{
				this.ShouldSerializeProductModelProductDescriptionCulturesValue = false;
			}

			if (this.ProductPhotoes.Count == 0)
			{
				this.ShouldSerializeProductPhotoesValue = false;
			}

			if (this.ProductProductPhotoes.Count == 0)
			{
				this.ShouldSerializeProductProductPhotoesValue = false;
			}

			if (this.ProductReviews.Count == 0)
			{
				this.ShouldSerializeProductReviewsValue = false;
			}

			if (this.ProductSubcategories.Count == 0)
			{
				this.ShouldSerializeProductSubcategoriesValue = false;
			}

			if (this.ScrapReasons.Count == 0)
			{
				this.ShouldSerializeScrapReasonsValue = false;
			}

			if (this.TransactionHistories.Count == 0)
			{
				this.ShouldSerializeTransactionHistoriesValue = false;
			}

			if (this.TransactionHistoryArchives.Count == 0)
			{
				this.ShouldSerializeTransactionHistoryArchivesValue = false;
			}

			if (this.UnitMeasures.Count == 0)
			{
				this.ShouldSerializeUnitMeasuresValue = false;
			}

			if (this.WorkOrders.Count == 0)
			{
				this.ShouldSerializeWorkOrdersValue = false;
			}

			if (this.WorkOrderRoutings.Count == 0)
			{
				this.ShouldSerializeWorkOrderRoutingsValue = false;
			}

			if (this.ProductVendors.Count == 0)
			{
				this.ShouldSerializeProductVendorsValue = false;
			}

			if (this.PurchaseOrderDetails.Count == 0)
			{
				this.ShouldSerializePurchaseOrderDetailsValue = false;
			}

			if (this.PurchaseOrderHeaders.Count == 0)
			{
				this.ShouldSerializePurchaseOrderHeadersValue = false;
			}

			if (this.ShipMethods.Count == 0)
			{
				this.ShouldSerializeShipMethodsValue = false;
			}

			if (this.Vendors.Count == 0)
			{
				this.ShouldSerializeVendorsValue = false;
			}

			if (this.CountryRegionCurrencies.Count == 0)
			{
				this.ShouldSerializeCountryRegionCurrenciesValue = false;
			}

			if (this.CreditCards.Count == 0)
			{
				this.ShouldSerializeCreditCardsValue = false;
			}

			if (this.Currencies.Count == 0)
			{
				this.ShouldSerializeCurrenciesValue = false;
			}

			if (this.CurrencyRates.Count == 0)
			{
				this.ShouldSerializeCurrencyRatesValue = false;
			}

			if (this.Customers.Count == 0)
			{
				this.ShouldSerializeCustomersValue = false;
			}

			if (this.PersonCreditCards.Count == 0)
			{
				this.ShouldSerializePersonCreditCardsValue = false;
			}

			if (this.SalesOrderDetails.Count == 0)
			{
				this.ShouldSerializeSalesOrderDetailsValue = false;
			}

			if (this.SalesOrderHeaders.Count == 0)
			{
				this.ShouldSerializeSalesOrderHeadersValue = false;
			}

			if (this.SalesOrderHeaderSalesReasons.Count == 0)
			{
				this.ShouldSerializeSalesOrderHeaderSalesReasonsValue = false;
			}

			if (this.SalesPersons.Count == 0)
			{
				this.ShouldSerializeSalesPersonsValue = false;
			}

			if (this.SalesPersonQuotaHistories.Count == 0)
			{
				this.ShouldSerializeSalesPersonQuotaHistoriesValue = false;
			}

			if (this.SalesReasons.Count == 0)
			{
				this.ShouldSerializeSalesReasonsValue = false;
			}

			if (this.SalesTaxRates.Count == 0)
			{
				this.ShouldSerializeSalesTaxRatesValue = false;
			}

			if (this.SalesTerritories.Count == 0)
			{
				this.ShouldSerializeSalesTerritoriesValue = false;
			}

			if (this.SalesTerritoryHistories.Count == 0)
			{
				this.ShouldSerializeSalesTerritoryHistoriesValue = false;
			}

			if (this.ShoppingCartItems.Count == 0)
			{
				this.ShouldSerializeShoppingCartItemsValue = false;
			}

			if (this.SpecialOffers.Count == 0)
			{
				this.ShouldSerializeSpecialOffersValue = false;
			}

			if (this.SpecialOfferProducts.Count == 0)
			{
				this.ShouldSerializeSpecialOfferProductsValue = false;
			}

			if (this.Stores.Count == 0)
			{
				this.ShouldSerializeStoresValue = false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>7b345cbf5dc1deaebe07af86d2c263b7</Hash>
</Codenesium>*/