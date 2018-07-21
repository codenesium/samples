using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksNS.Api.Contracts
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
                        from.EmployeeDepartmentHistories.ForEach(x => this.AddEmployeeDepartmentHistory(x));
                        from.EmployeePayHistories.ForEach(x => this.AddEmployeePayHistory(x));
                        from.JobCandidates.ForEach(x => this.AddJobCandidate(x));
                        from.Shifts.ForEach(x => this.AddShift(x));
                        from.Addresses.ForEach(x => this.AddAddress(x));
                        from.AddressTypes.ForEach(x => this.AddAddressType(x));
                        from.BusinessEntities.ForEach(x => this.AddBusinessEntity(x));
                        from.BusinessEntityAddresses.ForEach(x => this.AddBusinessEntityAddress(x));
                        from.BusinessEntityContacts.ForEach(x => this.AddBusinessEntityContact(x));
                        from.ContactTypes.ForEach(x => this.AddContactType(x));
                        from.CountryRegions.ForEach(x => this.AddCountryRegion(x));
                        from.EmailAddresses.ForEach(x => this.AddEmailAddress(x));
                        from.Passwords.ForEach(x => this.AddPassword(x));
                        from.People.ForEach(x => this.AddPerson(x));
                        from.PersonPhones.ForEach(x => this.AddPersonPhone(x));
                        from.PhoneNumberTypes.ForEach(x => this.AddPhoneNumberType(x));
                        from.StateProvinces.ForEach(x => this.AddStateProvince(x));
                        from.BillOfMaterials.ForEach(x => this.AddBillOfMaterial(x));
                        from.Cultures.ForEach(x => this.AddCulture(x));
                        from.Documents.ForEach(x => this.AddDocument(x));
                        from.Illustrations.ForEach(x => this.AddIllustration(x));
                        from.Locations.ForEach(x => this.AddLocation(x));
                        from.Products.ForEach(x => this.AddProduct(x));
                        from.ProductCategories.ForEach(x => this.AddProductCategory(x));
                        from.ProductCostHistories.ForEach(x => this.AddProductCostHistory(x));
                        from.ProductDescriptions.ForEach(x => this.AddProductDescription(x));
                        from.ProductInventories.ForEach(x => this.AddProductInventory(x));
                        from.ProductListPriceHistories.ForEach(x => this.AddProductListPriceHistory(x));
                        from.ProductModels.ForEach(x => this.AddProductModel(x));
                        from.ProductModelIllustrations.ForEach(x => this.AddProductModelIllustration(x));
                        from.ProductModelProductDescriptionCultures.ForEach(x => this.AddProductModelProductDescriptionCulture(x));
                        from.ProductPhotoes.ForEach(x => this.AddProductPhoto(x));
                        from.ProductProductPhotoes.ForEach(x => this.AddProductProductPhoto(x));
                        from.ProductReviews.ForEach(x => this.AddProductReview(x));
                        from.ProductSubcategories.ForEach(x => this.AddProductSubcategory(x));
                        from.ScrapReasons.ForEach(x => this.AddScrapReason(x));
                        from.TransactionHistories.ForEach(x => this.AddTransactionHistory(x));
                        from.TransactionHistoryArchives.ForEach(x => this.AddTransactionHistoryArchive(x));
                        from.UnitMeasures.ForEach(x => this.AddUnitMeasure(x));
                        from.WorkOrders.ForEach(x => this.AddWorkOrder(x));
                        from.WorkOrderRoutings.ForEach(x => this.AddWorkOrderRouting(x));
                        from.ProductVendors.ForEach(x => this.AddProductVendor(x));
                        from.PurchaseOrderDetails.ForEach(x => this.AddPurchaseOrderDetail(x));
                        from.PurchaseOrderHeaders.ForEach(x => this.AddPurchaseOrderHeader(x));
                        from.ShipMethods.ForEach(x => this.AddShipMethod(x));
                        from.Vendors.ForEach(x => this.AddVendor(x));
                        from.CountryRegionCurrencies.ForEach(x => this.AddCountryRegionCurrency(x));
                        from.CreditCards.ForEach(x => this.AddCreditCard(x));
                        from.Currencies.ForEach(x => this.AddCurrency(x));
                        from.CurrencyRates.ForEach(x => this.AddCurrencyRate(x));
                        from.Customers.ForEach(x => this.AddCustomer(x));
                        from.PersonCreditCards.ForEach(x => this.AddPersonCreditCard(x));
                        from.SalesOrderDetails.ForEach(x => this.AddSalesOrderDetail(x));
                        from.SalesOrderHeaders.ForEach(x => this.AddSalesOrderHeader(x));
                        from.SalesOrderHeaderSalesReasons.ForEach(x => this.AddSalesOrderHeaderSalesReason(x));
                        from.SalesPersons.ForEach(x => this.AddSalesPerson(x));
                        from.SalesPersonQuotaHistories.ForEach(x => this.AddSalesPersonQuotaHistory(x));
                        from.SalesReasons.ForEach(x => this.AddSalesReason(x));
                        from.SalesTaxRates.ForEach(x => this.AddSalesTaxRate(x));
                        from.SalesTerritories.ForEach(x => this.AddSalesTerritory(x));
                        from.SalesTerritoryHistories.ForEach(x => this.AddSalesTerritoryHistory(x));
                        from.ShoppingCartItems.ForEach(x => this.AddShoppingCartItem(x));
                        from.SpecialOffers.ForEach(x => this.AddSpecialOffer(x));
                        from.SpecialOfferProducts.ForEach(x => this.AddSpecialOfferProduct(x));
                        from.Stores.ForEach(x => this.AddStore(x));
                }

                public List<ApiAWBuildVersionResponseModel> AWBuildVersions { get; private set; } = new List<ApiAWBuildVersionResponseModel>();

                public List<ApiDatabaseLogResponseModel> DatabaseLogs { get; private set; } = new List<ApiDatabaseLogResponseModel>();

                public List<ApiErrorLogResponseModel> ErrorLogs { get; private set; } = new List<ApiErrorLogResponseModel>();

                public List<ApiDepartmentResponseModel> Departments { get; private set; } = new List<ApiDepartmentResponseModel>();

                public List<ApiEmployeeResponseModel> Employees { get; private set; } = new List<ApiEmployeeResponseModel>();

                public List<ApiEmployeeDepartmentHistoryResponseModel> EmployeeDepartmentHistories { get; private set; } = new List<ApiEmployeeDepartmentHistoryResponseModel>();

                public List<ApiEmployeePayHistoryResponseModel> EmployeePayHistories { get; private set; } = new List<ApiEmployeePayHistoryResponseModel>();

                public List<ApiJobCandidateResponseModel> JobCandidates { get; private set; } = new List<ApiJobCandidateResponseModel>();

                public List<ApiShiftResponseModel> Shifts { get; private set; } = new List<ApiShiftResponseModel>();

                public List<ApiAddressResponseModel> Addresses { get; private set; } = new List<ApiAddressResponseModel>();

                public List<ApiAddressTypeResponseModel> AddressTypes { get; private set; } = new List<ApiAddressTypeResponseModel>();

                public List<ApiBusinessEntityResponseModel> BusinessEntities { get; private set; } = new List<ApiBusinessEntityResponseModel>();

                public List<ApiBusinessEntityAddressResponseModel> BusinessEntityAddresses { get; private set; } = new List<ApiBusinessEntityAddressResponseModel>();

                public List<ApiBusinessEntityContactResponseModel> BusinessEntityContacts { get; private set; } = new List<ApiBusinessEntityContactResponseModel>();

                public List<ApiContactTypeResponseModel> ContactTypes { get; private set; } = new List<ApiContactTypeResponseModel>();

                public List<ApiCountryRegionResponseModel> CountryRegions { get; private set; } = new List<ApiCountryRegionResponseModel>();

                public List<ApiEmailAddressResponseModel> EmailAddresses { get; private set; } = new List<ApiEmailAddressResponseModel>();

                public List<ApiPasswordResponseModel> Passwords { get; private set; } = new List<ApiPasswordResponseModel>();

                public List<ApiPersonResponseModel> People { get; private set; } = new List<ApiPersonResponseModel>();

                public List<ApiPersonPhoneResponseModel> PersonPhones { get; private set; } = new List<ApiPersonPhoneResponseModel>();

                public List<ApiPhoneNumberTypeResponseModel> PhoneNumberTypes { get; private set; } = new List<ApiPhoneNumberTypeResponseModel>();

                public List<ApiStateProvinceResponseModel> StateProvinces { get; private set; } = new List<ApiStateProvinceResponseModel>();

                public List<ApiBillOfMaterialResponseModel> BillOfMaterials { get; private set; } = new List<ApiBillOfMaterialResponseModel>();

                public List<ApiCultureResponseModel> Cultures { get; private set; } = new List<ApiCultureResponseModel>();

                public List<ApiDocumentResponseModel> Documents { get; private set; } = new List<ApiDocumentResponseModel>();

                public List<ApiIllustrationResponseModel> Illustrations { get; private set; } = new List<ApiIllustrationResponseModel>();

                public List<ApiLocationResponseModel> Locations { get; private set; } = new List<ApiLocationResponseModel>();

                public List<ApiProductResponseModel> Products { get; private set; } = new List<ApiProductResponseModel>();

                public List<ApiProductCategoryResponseModel> ProductCategories { get; private set; } = new List<ApiProductCategoryResponseModel>();

                public List<ApiProductCostHistoryResponseModel> ProductCostHistories { get; private set; } = new List<ApiProductCostHistoryResponseModel>();

                public List<ApiProductDescriptionResponseModel> ProductDescriptions { get; private set; } = new List<ApiProductDescriptionResponseModel>();

                public List<ApiProductInventoryResponseModel> ProductInventories { get; private set; } = new List<ApiProductInventoryResponseModel>();

                public List<ApiProductListPriceHistoryResponseModel> ProductListPriceHistories { get; private set; } = new List<ApiProductListPriceHistoryResponseModel>();

                public List<ApiProductModelResponseModel> ProductModels { get; private set; } = new List<ApiProductModelResponseModel>();

                public List<ApiProductModelIllustrationResponseModel> ProductModelIllustrations { get; private set; } = new List<ApiProductModelIllustrationResponseModel>();

                public List<ApiProductModelProductDescriptionCultureResponseModel> ProductModelProductDescriptionCultures { get; private set; } = new List<ApiProductModelProductDescriptionCultureResponseModel>();

                public List<ApiProductPhotoResponseModel> ProductPhotoes { get; private set; } = new List<ApiProductPhotoResponseModel>();

                public List<ApiProductProductPhotoResponseModel> ProductProductPhotoes { get; private set; } = new List<ApiProductProductPhotoResponseModel>();

                public List<ApiProductReviewResponseModel> ProductReviews { get; private set; } = new List<ApiProductReviewResponseModel>();

                public List<ApiProductSubcategoryResponseModel> ProductSubcategories { get; private set; } = new List<ApiProductSubcategoryResponseModel>();

                public List<ApiScrapReasonResponseModel> ScrapReasons { get; private set; } = new List<ApiScrapReasonResponseModel>();

                public List<ApiTransactionHistoryResponseModel> TransactionHistories { get; private set; } = new List<ApiTransactionHistoryResponseModel>();

                public List<ApiTransactionHistoryArchiveResponseModel> TransactionHistoryArchives { get; private set; } = new List<ApiTransactionHistoryArchiveResponseModel>();

                public List<ApiUnitMeasureResponseModel> UnitMeasures { get; private set; } = new List<ApiUnitMeasureResponseModel>();

                public List<ApiWorkOrderResponseModel> WorkOrders { get; private set; } = new List<ApiWorkOrderResponseModel>();

                public List<ApiWorkOrderRoutingResponseModel> WorkOrderRoutings { get; private set; } = new List<ApiWorkOrderRoutingResponseModel>();

                public List<ApiProductVendorResponseModel> ProductVendors { get; private set; } = new List<ApiProductVendorResponseModel>();

                public List<ApiPurchaseOrderDetailResponseModel> PurchaseOrderDetails { get; private set; } = new List<ApiPurchaseOrderDetailResponseModel>();

                public List<ApiPurchaseOrderHeaderResponseModel> PurchaseOrderHeaders { get; private set; } = new List<ApiPurchaseOrderHeaderResponseModel>();

                public List<ApiShipMethodResponseModel> ShipMethods { get; private set; } = new List<ApiShipMethodResponseModel>();

                public List<ApiVendorResponseModel> Vendors { get; private set; } = new List<ApiVendorResponseModel>();

                public List<ApiCountryRegionCurrencyResponseModel> CountryRegionCurrencies { get; private set; } = new List<ApiCountryRegionCurrencyResponseModel>();

                public List<ApiCreditCardResponseModel> CreditCards { get; private set; } = new List<ApiCreditCardResponseModel>();

                public List<ApiCurrencyResponseModel> Currencies { get; private set; } = new List<ApiCurrencyResponseModel>();

                public List<ApiCurrencyRateResponseModel> CurrencyRates { get; private set; } = new List<ApiCurrencyRateResponseModel>();

                public List<ApiCustomerResponseModel> Customers { get; private set; } = new List<ApiCustomerResponseModel>();

                public List<ApiPersonCreditCardResponseModel> PersonCreditCards { get; private set; } = new List<ApiPersonCreditCardResponseModel>();

                public List<ApiSalesOrderDetailResponseModel> SalesOrderDetails { get; private set; } = new List<ApiSalesOrderDetailResponseModel>();

                public List<ApiSalesOrderHeaderResponseModel> SalesOrderHeaders { get; private set; } = new List<ApiSalesOrderHeaderResponseModel>();

                public List<ApiSalesOrderHeaderSalesReasonResponseModel> SalesOrderHeaderSalesReasons { get; private set; } = new List<ApiSalesOrderHeaderSalesReasonResponseModel>();

                public List<ApiSalesPersonResponseModel> SalesPersons { get; private set; } = new List<ApiSalesPersonResponseModel>();

                public List<ApiSalesPersonQuotaHistoryResponseModel> SalesPersonQuotaHistories { get; private set; } = new List<ApiSalesPersonQuotaHistoryResponseModel>();

                public List<ApiSalesReasonResponseModel> SalesReasons { get; private set; } = new List<ApiSalesReasonResponseModel>();

                public List<ApiSalesTaxRateResponseModel> SalesTaxRates { get; private set; } = new List<ApiSalesTaxRateResponseModel>();

                public List<ApiSalesTerritoryResponseModel> SalesTerritories { get; private set; } = new List<ApiSalesTerritoryResponseModel>();

                public List<ApiSalesTerritoryHistoryResponseModel> SalesTerritoryHistories { get; private set; } = new List<ApiSalesTerritoryHistoryResponseModel>();

                public List<ApiShoppingCartItemResponseModel> ShoppingCartItems { get; private set; } = new List<ApiShoppingCartItemResponseModel>();

                public List<ApiSpecialOfferResponseModel> SpecialOffers { get; private set; } = new List<ApiSpecialOfferResponseModel>();

                public List<ApiSpecialOfferProductResponseModel> SpecialOfferProducts { get; private set; } = new List<ApiSpecialOfferProductResponseModel>();

                public List<ApiStoreResponseModel> Stores { get; private set; } = new List<ApiStoreResponseModel>();

                [JsonIgnore]
                public bool ShouldSerializeAWBuildVersionsValue { get; private set; } = true;

                public bool ShouldSerializeAWBuildVersions()
                {
                        return this.ShouldSerializeAWBuildVersionsValue;
                }

                public void AddAWBuildVersion(ApiAWBuildVersionResponseModel item)
                {
                        if (!this.AWBuildVersions.Any(x => x.SystemInformationID == item.SystemInformationID))
                        {
                                this.AWBuildVersions.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeDatabaseLogsValue { get; private set; } = true;

                public bool ShouldSerializeDatabaseLogs()
                {
                        return this.ShouldSerializeDatabaseLogsValue;
                }

                public void AddDatabaseLog(ApiDatabaseLogResponseModel item)
                {
                        if (!this.DatabaseLogs.Any(x => x.DatabaseLogID == item.DatabaseLogID))
                        {
                                this.DatabaseLogs.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeErrorLogsValue { get; private set; } = true;

                public bool ShouldSerializeErrorLogs()
                {
                        return this.ShouldSerializeErrorLogsValue;
                }

                public void AddErrorLog(ApiErrorLogResponseModel item)
                {
                        if (!this.ErrorLogs.Any(x => x.ErrorLogID == item.ErrorLogID))
                        {
                                this.ErrorLogs.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeDepartmentsValue { get; private set; } = true;

                public bool ShouldSerializeDepartments()
                {
                        return this.ShouldSerializeDepartmentsValue;
                }

                public void AddDepartment(ApiDepartmentResponseModel item)
                {
                        if (!this.Departments.Any(x => x.DepartmentID == item.DepartmentID))
                        {
                                this.Departments.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeEmployeesValue { get; private set; } = true;

                public bool ShouldSerializeEmployees()
                {
                        return this.ShouldSerializeEmployeesValue;
                }

                public void AddEmployee(ApiEmployeeResponseModel item)
                {
                        if (!this.Employees.Any(x => x.BusinessEntityID == item.BusinessEntityID))
                        {
                                this.Employees.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeEmployeeDepartmentHistoriesValue { get; private set; } = true;

                public bool ShouldSerializeEmployeeDepartmentHistories()
                {
                        return this.ShouldSerializeEmployeeDepartmentHistoriesValue;
                }

                public void AddEmployeeDepartmentHistory(ApiEmployeeDepartmentHistoryResponseModel item)
                {
                        if (!this.EmployeeDepartmentHistories.Any(x => x.BusinessEntityID == item.BusinessEntityID))
                        {
                                this.EmployeeDepartmentHistories.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeEmployeePayHistoriesValue { get; private set; } = true;

                public bool ShouldSerializeEmployeePayHistories()
                {
                        return this.ShouldSerializeEmployeePayHistoriesValue;
                }

                public void AddEmployeePayHistory(ApiEmployeePayHistoryResponseModel item)
                {
                        if (!this.EmployeePayHistories.Any(x => x.BusinessEntityID == item.BusinessEntityID))
                        {
                                this.EmployeePayHistories.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeJobCandidatesValue { get; private set; } = true;

                public bool ShouldSerializeJobCandidates()
                {
                        return this.ShouldSerializeJobCandidatesValue;
                }

                public void AddJobCandidate(ApiJobCandidateResponseModel item)
                {
                        if (!this.JobCandidates.Any(x => x.JobCandidateID == item.JobCandidateID))
                        {
                                this.JobCandidates.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeShiftsValue { get; private set; } = true;

                public bool ShouldSerializeShifts()
                {
                        return this.ShouldSerializeShiftsValue;
                }

                public void AddShift(ApiShiftResponseModel item)
                {
                        if (!this.Shifts.Any(x => x.ShiftID == item.ShiftID))
                        {
                                this.Shifts.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeAddressesValue { get; private set; } = true;

                public bool ShouldSerializeAddresses()
                {
                        return this.ShouldSerializeAddressesValue;
                }

                public void AddAddress(ApiAddressResponseModel item)
                {
                        if (!this.Addresses.Any(x => x.AddressID == item.AddressID))
                        {
                                this.Addresses.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeAddressTypesValue { get; private set; } = true;

                public bool ShouldSerializeAddressTypes()
                {
                        return this.ShouldSerializeAddressTypesValue;
                }

                public void AddAddressType(ApiAddressTypeResponseModel item)
                {
                        if (!this.AddressTypes.Any(x => x.AddressTypeID == item.AddressTypeID))
                        {
                                this.AddressTypes.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeBusinessEntitiesValue { get; private set; } = true;

                public bool ShouldSerializeBusinessEntities()
                {
                        return this.ShouldSerializeBusinessEntitiesValue;
                }

                public void AddBusinessEntity(ApiBusinessEntityResponseModel item)
                {
                        if (!this.BusinessEntities.Any(x => x.BusinessEntityID == item.BusinessEntityID))
                        {
                                this.BusinessEntities.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeBusinessEntityAddressesValue { get; private set; } = true;

                public bool ShouldSerializeBusinessEntityAddresses()
                {
                        return this.ShouldSerializeBusinessEntityAddressesValue;
                }

                public void AddBusinessEntityAddress(ApiBusinessEntityAddressResponseModel item)
                {
                        if (!this.BusinessEntityAddresses.Any(x => x.BusinessEntityID == item.BusinessEntityID))
                        {
                                this.BusinessEntityAddresses.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeBusinessEntityContactsValue { get; private set; } = true;

                public bool ShouldSerializeBusinessEntityContacts()
                {
                        return this.ShouldSerializeBusinessEntityContactsValue;
                }

                public void AddBusinessEntityContact(ApiBusinessEntityContactResponseModel item)
                {
                        if (!this.BusinessEntityContacts.Any(x => x.BusinessEntityID == item.BusinessEntityID))
                        {
                                this.BusinessEntityContacts.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeContactTypesValue { get; private set; } = true;

                public bool ShouldSerializeContactTypes()
                {
                        return this.ShouldSerializeContactTypesValue;
                }

                public void AddContactType(ApiContactTypeResponseModel item)
                {
                        if (!this.ContactTypes.Any(x => x.ContactTypeID == item.ContactTypeID))
                        {
                                this.ContactTypes.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeCountryRegionsValue { get; private set; } = true;

                public bool ShouldSerializeCountryRegions()
                {
                        return this.ShouldSerializeCountryRegionsValue;
                }

                public void AddCountryRegion(ApiCountryRegionResponseModel item)
                {
                        if (!this.CountryRegions.Any(x => x.CountryRegionCode == item.CountryRegionCode))
                        {
                                this.CountryRegions.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeEmailAddressesValue { get; private set; } = true;

                public bool ShouldSerializeEmailAddresses()
                {
                        return this.ShouldSerializeEmailAddressesValue;
                }

                public void AddEmailAddress(ApiEmailAddressResponseModel item)
                {
                        if (!this.EmailAddresses.Any(x => x.BusinessEntityID == item.BusinessEntityID))
                        {
                                this.EmailAddresses.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializePasswordsValue { get; private set; } = true;

                public bool ShouldSerializePasswords()
                {
                        return this.ShouldSerializePasswordsValue;
                }

                public void AddPassword(ApiPasswordResponseModel item)
                {
                        if (!this.Passwords.Any(x => x.BusinessEntityID == item.BusinessEntityID))
                        {
                                this.Passwords.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializePeopleValue { get; private set; } = true;

                public bool ShouldSerializePeople()
                {
                        return this.ShouldSerializePeopleValue;
                }

                public void AddPerson(ApiPersonResponseModel item)
                {
                        if (!this.People.Any(x => x.BusinessEntityID == item.BusinessEntityID))
                        {
                                this.People.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializePersonPhonesValue { get; private set; } = true;

                public bool ShouldSerializePersonPhones()
                {
                        return this.ShouldSerializePersonPhonesValue;
                }

                public void AddPersonPhone(ApiPersonPhoneResponseModel item)
                {
                        if (!this.PersonPhones.Any(x => x.BusinessEntityID == item.BusinessEntityID))
                        {
                                this.PersonPhones.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializePhoneNumberTypesValue { get; private set; } = true;

                public bool ShouldSerializePhoneNumberTypes()
                {
                        return this.ShouldSerializePhoneNumberTypesValue;
                }

                public void AddPhoneNumberType(ApiPhoneNumberTypeResponseModel item)
                {
                        if (!this.PhoneNumberTypes.Any(x => x.PhoneNumberTypeID == item.PhoneNumberTypeID))
                        {
                                this.PhoneNumberTypes.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeStateProvincesValue { get; private set; } = true;

                public bool ShouldSerializeStateProvinces()
                {
                        return this.ShouldSerializeStateProvincesValue;
                }

                public void AddStateProvince(ApiStateProvinceResponseModel item)
                {
                        if (!this.StateProvinces.Any(x => x.StateProvinceID == item.StateProvinceID))
                        {
                                this.StateProvinces.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeBillOfMaterialsValue { get; private set; } = true;

                public bool ShouldSerializeBillOfMaterials()
                {
                        return this.ShouldSerializeBillOfMaterialsValue;
                }

                public void AddBillOfMaterial(ApiBillOfMaterialResponseModel item)
                {
                        if (!this.BillOfMaterials.Any(x => x.BillOfMaterialsID == item.BillOfMaterialsID))
                        {
                                this.BillOfMaterials.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeCulturesValue { get; private set; } = true;

                public bool ShouldSerializeCultures()
                {
                        return this.ShouldSerializeCulturesValue;
                }

                public void AddCulture(ApiCultureResponseModel item)
                {
                        if (!this.Cultures.Any(x => x.CultureID == item.CultureID))
                        {
                                this.Cultures.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeDocumentsValue { get; private set; } = true;

                public bool ShouldSerializeDocuments()
                {
                        return this.ShouldSerializeDocumentsValue;
                }

                public void AddDocument(ApiDocumentResponseModel item)
                {
                        if (!this.Documents.Any(x => x.Rowguid == item.Rowguid))
                        {
                                this.Documents.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeIllustrationsValue { get; private set; } = true;

                public bool ShouldSerializeIllustrations()
                {
                        return this.ShouldSerializeIllustrationsValue;
                }

                public void AddIllustration(ApiIllustrationResponseModel item)
                {
                        if (!this.Illustrations.Any(x => x.IllustrationID == item.IllustrationID))
                        {
                                this.Illustrations.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeLocationsValue { get; private set; } = true;

                public bool ShouldSerializeLocations()
                {
                        return this.ShouldSerializeLocationsValue;
                }

                public void AddLocation(ApiLocationResponseModel item)
                {
                        if (!this.Locations.Any(x => x.LocationID == item.LocationID))
                        {
                                this.Locations.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeProductsValue { get; private set; } = true;

                public bool ShouldSerializeProducts()
                {
                        return this.ShouldSerializeProductsValue;
                }

                public void AddProduct(ApiProductResponseModel item)
                {
                        if (!this.Products.Any(x => x.ProductID == item.ProductID))
                        {
                                this.Products.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeProductCategoriesValue { get; private set; } = true;

                public bool ShouldSerializeProductCategories()
                {
                        return this.ShouldSerializeProductCategoriesValue;
                }

                public void AddProductCategory(ApiProductCategoryResponseModel item)
                {
                        if (!this.ProductCategories.Any(x => x.ProductCategoryID == item.ProductCategoryID))
                        {
                                this.ProductCategories.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeProductCostHistoriesValue { get; private set; } = true;

                public bool ShouldSerializeProductCostHistories()
                {
                        return this.ShouldSerializeProductCostHistoriesValue;
                }

                public void AddProductCostHistory(ApiProductCostHistoryResponseModel item)
                {
                        if (!this.ProductCostHistories.Any(x => x.ProductID == item.ProductID))
                        {
                                this.ProductCostHistories.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeProductDescriptionsValue { get; private set; } = true;

                public bool ShouldSerializeProductDescriptions()
                {
                        return this.ShouldSerializeProductDescriptionsValue;
                }

                public void AddProductDescription(ApiProductDescriptionResponseModel item)
                {
                        if (!this.ProductDescriptions.Any(x => x.ProductDescriptionID == item.ProductDescriptionID))
                        {
                                this.ProductDescriptions.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeProductInventoriesValue { get; private set; } = true;

                public bool ShouldSerializeProductInventories()
                {
                        return this.ShouldSerializeProductInventoriesValue;
                }

                public void AddProductInventory(ApiProductInventoryResponseModel item)
                {
                        if (!this.ProductInventories.Any(x => x.ProductID == item.ProductID))
                        {
                                this.ProductInventories.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeProductListPriceHistoriesValue { get; private set; } = true;

                public bool ShouldSerializeProductListPriceHistories()
                {
                        return this.ShouldSerializeProductListPriceHistoriesValue;
                }

                public void AddProductListPriceHistory(ApiProductListPriceHistoryResponseModel item)
                {
                        if (!this.ProductListPriceHistories.Any(x => x.ProductID == item.ProductID))
                        {
                                this.ProductListPriceHistories.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeProductModelsValue { get; private set; } = true;

                public bool ShouldSerializeProductModels()
                {
                        return this.ShouldSerializeProductModelsValue;
                }

                public void AddProductModel(ApiProductModelResponseModel item)
                {
                        if (!this.ProductModels.Any(x => x.ProductModelID == item.ProductModelID))
                        {
                                this.ProductModels.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeProductModelIllustrationsValue { get; private set; } = true;

                public bool ShouldSerializeProductModelIllustrations()
                {
                        return this.ShouldSerializeProductModelIllustrationsValue;
                }

                public void AddProductModelIllustration(ApiProductModelIllustrationResponseModel item)
                {
                        if (!this.ProductModelIllustrations.Any(x => x.ProductModelID == item.ProductModelID))
                        {
                                this.ProductModelIllustrations.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeProductModelProductDescriptionCulturesValue { get; private set; } = true;

                public bool ShouldSerializeProductModelProductDescriptionCultures()
                {
                        return this.ShouldSerializeProductModelProductDescriptionCulturesValue;
                }

                public void AddProductModelProductDescriptionCulture(ApiProductModelProductDescriptionCultureResponseModel item)
                {
                        if (!this.ProductModelProductDescriptionCultures.Any(x => x.ProductModelID == item.ProductModelID))
                        {
                                this.ProductModelProductDescriptionCultures.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeProductPhotoesValue { get; private set; } = true;

                public bool ShouldSerializeProductPhotoes()
                {
                        return this.ShouldSerializeProductPhotoesValue;
                }

                public void AddProductPhoto(ApiProductPhotoResponseModel item)
                {
                        if (!this.ProductPhotoes.Any(x => x.ProductPhotoID == item.ProductPhotoID))
                        {
                                this.ProductPhotoes.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeProductProductPhotoesValue { get; private set; } = true;

                public bool ShouldSerializeProductProductPhotoes()
                {
                        return this.ShouldSerializeProductProductPhotoesValue;
                }

                public void AddProductProductPhoto(ApiProductProductPhotoResponseModel item)
                {
                        if (!this.ProductProductPhotoes.Any(x => x.ProductID == item.ProductID))
                        {
                                this.ProductProductPhotoes.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeProductReviewsValue { get; private set; } = true;

                public bool ShouldSerializeProductReviews()
                {
                        return this.ShouldSerializeProductReviewsValue;
                }

                public void AddProductReview(ApiProductReviewResponseModel item)
                {
                        if (!this.ProductReviews.Any(x => x.ProductReviewID == item.ProductReviewID))
                        {
                                this.ProductReviews.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeProductSubcategoriesValue { get; private set; } = true;

                public bool ShouldSerializeProductSubcategories()
                {
                        return this.ShouldSerializeProductSubcategoriesValue;
                }

                public void AddProductSubcategory(ApiProductSubcategoryResponseModel item)
                {
                        if (!this.ProductSubcategories.Any(x => x.ProductSubcategoryID == item.ProductSubcategoryID))
                        {
                                this.ProductSubcategories.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeScrapReasonsValue { get; private set; } = true;

                public bool ShouldSerializeScrapReasons()
                {
                        return this.ShouldSerializeScrapReasonsValue;
                }

                public void AddScrapReason(ApiScrapReasonResponseModel item)
                {
                        if (!this.ScrapReasons.Any(x => x.ScrapReasonID == item.ScrapReasonID))
                        {
                                this.ScrapReasons.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeTransactionHistoriesValue { get; private set; } = true;

                public bool ShouldSerializeTransactionHistories()
                {
                        return this.ShouldSerializeTransactionHistoriesValue;
                }

                public void AddTransactionHistory(ApiTransactionHistoryResponseModel item)
                {
                        if (!this.TransactionHistories.Any(x => x.TransactionID == item.TransactionID))
                        {
                                this.TransactionHistories.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeTransactionHistoryArchivesValue { get; private set; } = true;

                public bool ShouldSerializeTransactionHistoryArchives()
                {
                        return this.ShouldSerializeTransactionHistoryArchivesValue;
                }

                public void AddTransactionHistoryArchive(ApiTransactionHistoryArchiveResponseModel item)
                {
                        if (!this.TransactionHistoryArchives.Any(x => x.TransactionID == item.TransactionID))
                        {
                                this.TransactionHistoryArchives.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeUnitMeasuresValue { get; private set; } = true;

                public bool ShouldSerializeUnitMeasures()
                {
                        return this.ShouldSerializeUnitMeasuresValue;
                }

                public void AddUnitMeasure(ApiUnitMeasureResponseModel item)
                {
                        if (!this.UnitMeasures.Any(x => x.UnitMeasureCode == item.UnitMeasureCode))
                        {
                                this.UnitMeasures.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeWorkOrdersValue { get; private set; } = true;

                public bool ShouldSerializeWorkOrders()
                {
                        return this.ShouldSerializeWorkOrdersValue;
                }

                public void AddWorkOrder(ApiWorkOrderResponseModel item)
                {
                        if (!this.WorkOrders.Any(x => x.WorkOrderID == item.WorkOrderID))
                        {
                                this.WorkOrders.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeWorkOrderRoutingsValue { get; private set; } = true;

                public bool ShouldSerializeWorkOrderRoutings()
                {
                        return this.ShouldSerializeWorkOrderRoutingsValue;
                }

                public void AddWorkOrderRouting(ApiWorkOrderRoutingResponseModel item)
                {
                        if (!this.WorkOrderRoutings.Any(x => x.WorkOrderID == item.WorkOrderID))
                        {
                                this.WorkOrderRoutings.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeProductVendorsValue { get; private set; } = true;

                public bool ShouldSerializeProductVendors()
                {
                        return this.ShouldSerializeProductVendorsValue;
                }

                public void AddProductVendor(ApiProductVendorResponseModel item)
                {
                        if (!this.ProductVendors.Any(x => x.ProductID == item.ProductID))
                        {
                                this.ProductVendors.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializePurchaseOrderDetailsValue { get; private set; } = true;

                public bool ShouldSerializePurchaseOrderDetails()
                {
                        return this.ShouldSerializePurchaseOrderDetailsValue;
                }

                public void AddPurchaseOrderDetail(ApiPurchaseOrderDetailResponseModel item)
                {
                        if (!this.PurchaseOrderDetails.Any(x => x.PurchaseOrderID == item.PurchaseOrderID))
                        {
                                this.PurchaseOrderDetails.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializePurchaseOrderHeadersValue { get; private set; } = true;

                public bool ShouldSerializePurchaseOrderHeaders()
                {
                        return this.ShouldSerializePurchaseOrderHeadersValue;
                }

                public void AddPurchaseOrderHeader(ApiPurchaseOrderHeaderResponseModel item)
                {
                        if (!this.PurchaseOrderHeaders.Any(x => x.PurchaseOrderID == item.PurchaseOrderID))
                        {
                                this.PurchaseOrderHeaders.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeShipMethodsValue { get; private set; } = true;

                public bool ShouldSerializeShipMethods()
                {
                        return this.ShouldSerializeShipMethodsValue;
                }

                public void AddShipMethod(ApiShipMethodResponseModel item)
                {
                        if (!this.ShipMethods.Any(x => x.ShipMethodID == item.ShipMethodID))
                        {
                                this.ShipMethods.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeVendorsValue { get; private set; } = true;

                public bool ShouldSerializeVendors()
                {
                        return this.ShouldSerializeVendorsValue;
                }

                public void AddVendor(ApiVendorResponseModel item)
                {
                        if (!this.Vendors.Any(x => x.BusinessEntityID == item.BusinessEntityID))
                        {
                                this.Vendors.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeCountryRegionCurrenciesValue { get; private set; } = true;

                public bool ShouldSerializeCountryRegionCurrencies()
                {
                        return this.ShouldSerializeCountryRegionCurrenciesValue;
                }

                public void AddCountryRegionCurrency(ApiCountryRegionCurrencyResponseModel item)
                {
                        if (!this.CountryRegionCurrencies.Any(x => x.CountryRegionCode == item.CountryRegionCode))
                        {
                                this.CountryRegionCurrencies.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeCreditCardsValue { get; private set; } = true;

                public bool ShouldSerializeCreditCards()
                {
                        return this.ShouldSerializeCreditCardsValue;
                }

                public void AddCreditCard(ApiCreditCardResponseModel item)
                {
                        if (!this.CreditCards.Any(x => x.CreditCardID == item.CreditCardID))
                        {
                                this.CreditCards.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeCurrenciesValue { get; private set; } = true;

                public bool ShouldSerializeCurrencies()
                {
                        return this.ShouldSerializeCurrenciesValue;
                }

                public void AddCurrency(ApiCurrencyResponseModel item)
                {
                        if (!this.Currencies.Any(x => x.CurrencyCode == item.CurrencyCode))
                        {
                                this.Currencies.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeCurrencyRatesValue { get; private set; } = true;

                public bool ShouldSerializeCurrencyRates()
                {
                        return this.ShouldSerializeCurrencyRatesValue;
                }

                public void AddCurrencyRate(ApiCurrencyRateResponseModel item)
                {
                        if (!this.CurrencyRates.Any(x => x.CurrencyRateID == item.CurrencyRateID))
                        {
                                this.CurrencyRates.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeCustomersValue { get; private set; } = true;

                public bool ShouldSerializeCustomers()
                {
                        return this.ShouldSerializeCustomersValue;
                }

                public void AddCustomer(ApiCustomerResponseModel item)
                {
                        if (!this.Customers.Any(x => x.CustomerID == item.CustomerID))
                        {
                                this.Customers.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializePersonCreditCardsValue { get; private set; } = true;

                public bool ShouldSerializePersonCreditCards()
                {
                        return this.ShouldSerializePersonCreditCardsValue;
                }

                public void AddPersonCreditCard(ApiPersonCreditCardResponseModel item)
                {
                        if (!this.PersonCreditCards.Any(x => x.BusinessEntityID == item.BusinessEntityID))
                        {
                                this.PersonCreditCards.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeSalesOrderDetailsValue { get; private set; } = true;

                public bool ShouldSerializeSalesOrderDetails()
                {
                        return this.ShouldSerializeSalesOrderDetailsValue;
                }

                public void AddSalesOrderDetail(ApiSalesOrderDetailResponseModel item)
                {
                        if (!this.SalesOrderDetails.Any(x => x.SalesOrderID == item.SalesOrderID))
                        {
                                this.SalesOrderDetails.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeSalesOrderHeadersValue { get; private set; } = true;

                public bool ShouldSerializeSalesOrderHeaders()
                {
                        return this.ShouldSerializeSalesOrderHeadersValue;
                }

                public void AddSalesOrderHeader(ApiSalesOrderHeaderResponseModel item)
                {
                        if (!this.SalesOrderHeaders.Any(x => x.SalesOrderID == item.SalesOrderID))
                        {
                                this.SalesOrderHeaders.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeSalesOrderHeaderSalesReasonsValue { get; private set; } = true;

                public bool ShouldSerializeSalesOrderHeaderSalesReasons()
                {
                        return this.ShouldSerializeSalesOrderHeaderSalesReasonsValue;
                }

                public void AddSalesOrderHeaderSalesReason(ApiSalesOrderHeaderSalesReasonResponseModel item)
                {
                        if (!this.SalesOrderHeaderSalesReasons.Any(x => x.SalesOrderID == item.SalesOrderID))
                        {
                                this.SalesOrderHeaderSalesReasons.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeSalesPersonsValue { get; private set; } = true;

                public bool ShouldSerializeSalesPersons()
                {
                        return this.ShouldSerializeSalesPersonsValue;
                }

                public void AddSalesPerson(ApiSalesPersonResponseModel item)
                {
                        if (!this.SalesPersons.Any(x => x.BusinessEntityID == item.BusinessEntityID))
                        {
                                this.SalesPersons.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeSalesPersonQuotaHistoriesValue { get; private set; } = true;

                public bool ShouldSerializeSalesPersonQuotaHistories()
                {
                        return this.ShouldSerializeSalesPersonQuotaHistoriesValue;
                }

                public void AddSalesPersonQuotaHistory(ApiSalesPersonQuotaHistoryResponseModel item)
                {
                        if (!this.SalesPersonQuotaHistories.Any(x => x.BusinessEntityID == item.BusinessEntityID))
                        {
                                this.SalesPersonQuotaHistories.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeSalesReasonsValue { get; private set; } = true;

                public bool ShouldSerializeSalesReasons()
                {
                        return this.ShouldSerializeSalesReasonsValue;
                }

                public void AddSalesReason(ApiSalesReasonResponseModel item)
                {
                        if (!this.SalesReasons.Any(x => x.SalesReasonID == item.SalesReasonID))
                        {
                                this.SalesReasons.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeSalesTaxRatesValue { get; private set; } = true;

                public bool ShouldSerializeSalesTaxRates()
                {
                        return this.ShouldSerializeSalesTaxRatesValue;
                }

                public void AddSalesTaxRate(ApiSalesTaxRateResponseModel item)
                {
                        if (!this.SalesTaxRates.Any(x => x.SalesTaxRateID == item.SalesTaxRateID))
                        {
                                this.SalesTaxRates.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeSalesTerritoriesValue { get; private set; } = true;

                public bool ShouldSerializeSalesTerritories()
                {
                        return this.ShouldSerializeSalesTerritoriesValue;
                }

                public void AddSalesTerritory(ApiSalesTerritoryResponseModel item)
                {
                        if (!this.SalesTerritories.Any(x => x.TerritoryID == item.TerritoryID))
                        {
                                this.SalesTerritories.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeSalesTerritoryHistoriesValue { get; private set; } = true;

                public bool ShouldSerializeSalesTerritoryHistories()
                {
                        return this.ShouldSerializeSalesTerritoryHistoriesValue;
                }

                public void AddSalesTerritoryHistory(ApiSalesTerritoryHistoryResponseModel item)
                {
                        if (!this.SalesTerritoryHistories.Any(x => x.BusinessEntityID == item.BusinessEntityID))
                        {
                                this.SalesTerritoryHistories.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeShoppingCartItemsValue { get; private set; } = true;

                public bool ShouldSerializeShoppingCartItems()
                {
                        return this.ShouldSerializeShoppingCartItemsValue;
                }

                public void AddShoppingCartItem(ApiShoppingCartItemResponseModel item)
                {
                        if (!this.ShoppingCartItems.Any(x => x.ShoppingCartItemID == item.ShoppingCartItemID))
                        {
                                this.ShoppingCartItems.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeSpecialOffersValue { get; private set; } = true;

                public bool ShouldSerializeSpecialOffers()
                {
                        return this.ShouldSerializeSpecialOffersValue;
                }

                public void AddSpecialOffer(ApiSpecialOfferResponseModel item)
                {
                        if (!this.SpecialOffers.Any(x => x.SpecialOfferID == item.SpecialOfferID))
                        {
                                this.SpecialOffers.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeSpecialOfferProductsValue { get; private set; } = true;

                public bool ShouldSerializeSpecialOfferProducts()
                {
                        return this.ShouldSerializeSpecialOfferProductsValue;
                }

                public void AddSpecialOfferProduct(ApiSpecialOfferProductResponseModel item)
                {
                        if (!this.SpecialOfferProducts.Any(x => x.SpecialOfferID == item.SpecialOfferID))
                        {
                                this.SpecialOfferProducts.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeStoresValue { get; private set; } = true;

                public bool ShouldSerializeStores()
                {
                        return this.ShouldSerializeStoresValue;
                }

                public void AddStore(ApiStoreResponseModel item)
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
    <Hash>14d9e84436cab16c26bf384c5301a419</Hash>
</Codenesium>*/