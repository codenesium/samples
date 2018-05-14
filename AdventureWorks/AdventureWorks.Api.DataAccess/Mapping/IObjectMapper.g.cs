using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IObjectMapper
	{
		void AWBuildVersionMapModelToEF(
			int systemInformationID,
			ApiAWBuildVersionModel model,
			AWBuildVersion efAWBuildVersion);

		POCOAWBuildVersion AWBuildVersionMapEFToPOCO(
			AWBuildVersion efAWBuildVersion);

		void DatabaseLogMapModelToEF(
			int databaseLogID,
			ApiDatabaseLogModel model,
			DatabaseLog efDatabaseLog);

		POCODatabaseLog DatabaseLogMapEFToPOCO(
			DatabaseLog efDatabaseLog);

		void ErrorLogMapModelToEF(
			int errorLogID,
			ApiErrorLogModel model,
			ErrorLog efErrorLog);

		POCOErrorLog ErrorLogMapEFToPOCO(
			ErrorLog efErrorLog);

		void DepartmentMapModelToEF(
			short departmentID,
			ApiDepartmentModel model,
			Department efDepartment);

		POCODepartment DepartmentMapEFToPOCO(
			Department efDepartment);

		void EmployeeMapModelToEF(
			int businessEntityID,
			ApiEmployeeModel model,
			Employee efEmployee);

		POCOEmployee EmployeeMapEFToPOCO(
			Employee efEmployee);

		void EmployeeDepartmentHistoryMapModelToEF(
			int businessEntityID,
			ApiEmployeeDepartmentHistoryModel model,
			EmployeeDepartmentHistory efEmployeeDepartmentHistory);

		POCOEmployeeDepartmentHistory EmployeeDepartmentHistoryMapEFToPOCO(
			EmployeeDepartmentHistory efEmployeeDepartmentHistory);

		void EmployeePayHistoryMapModelToEF(
			int businessEntityID,
			ApiEmployeePayHistoryModel model,
			EmployeePayHistory efEmployeePayHistory);

		POCOEmployeePayHistory EmployeePayHistoryMapEFToPOCO(
			EmployeePayHistory efEmployeePayHistory);

		void JobCandidateMapModelToEF(
			int jobCandidateID,
			ApiJobCandidateModel model,
			JobCandidate efJobCandidate);

		POCOJobCandidate JobCandidateMapEFToPOCO(
			JobCandidate efJobCandidate);

		void ShiftMapModelToEF(
			int shiftID,
			ApiShiftModel model,
			Shift efShift);

		POCOShift ShiftMapEFToPOCO(
			Shift efShift);

		void AddressMapModelToEF(
			int addressID,
			ApiAddressModel model,
			Address efAddress);

		POCOAddress AddressMapEFToPOCO(
			Address efAddress);

		void AddressTypeMapModelToEF(
			int addressTypeID,
			ApiAddressTypeModel model,
			AddressType efAddressType);

		POCOAddressType AddressTypeMapEFToPOCO(
			AddressType efAddressType);

		void BusinessEntityMapModelToEF(
			int businessEntityID,
			ApiBusinessEntityModel model,
			BusinessEntity efBusinessEntity);

		POCOBusinessEntity BusinessEntityMapEFToPOCO(
			BusinessEntity efBusinessEntity);

		void BusinessEntityAddressMapModelToEF(
			int businessEntityID,
			ApiBusinessEntityAddressModel model,
			BusinessEntityAddress efBusinessEntityAddress);

		POCOBusinessEntityAddress BusinessEntityAddressMapEFToPOCO(
			BusinessEntityAddress efBusinessEntityAddress);

		void BusinessEntityContactMapModelToEF(
			int businessEntityID,
			ApiBusinessEntityContactModel model,
			BusinessEntityContact efBusinessEntityContact);

		POCOBusinessEntityContact BusinessEntityContactMapEFToPOCO(
			BusinessEntityContact efBusinessEntityContact);

		void ContactTypeMapModelToEF(
			int contactTypeID,
			ApiContactTypeModel model,
			ContactType efContactType);

		POCOContactType ContactTypeMapEFToPOCO(
			ContactType efContactType);

		void CountryRegionMapModelToEF(
			string countryRegionCode,
			ApiCountryRegionModel model,
			CountryRegion efCountryRegion);

		POCOCountryRegion CountryRegionMapEFToPOCO(
			CountryRegion efCountryRegion);

		void EmailAddressMapModelToEF(
			int businessEntityID,
			ApiEmailAddressModel model,
			EmailAddress efEmailAddress);

		POCOEmailAddress EmailAddressMapEFToPOCO(
			EmailAddress efEmailAddress);

		void PasswordMapModelToEF(
			int businessEntityID,
			ApiPasswordModel model,
			Password efPassword);

		POCOPassword PasswordMapEFToPOCO(
			Password efPassword);

		void PersonMapModelToEF(
			int businessEntityID,
			ApiPersonModel model,
			Person efPerson);

		POCOPerson PersonMapEFToPOCO(
			Person efPerson);

		void PersonPhoneMapModelToEF(
			int businessEntityID,
			ApiPersonPhoneModel model,
			PersonPhone efPersonPhone);

		POCOPersonPhone PersonPhoneMapEFToPOCO(
			PersonPhone efPersonPhone);

		void PhoneNumberTypeMapModelToEF(
			int phoneNumberTypeID,
			ApiPhoneNumberTypeModel model,
			PhoneNumberType efPhoneNumberType);

		POCOPhoneNumberType PhoneNumberTypeMapEFToPOCO(
			PhoneNumberType efPhoneNumberType);

		void StateProvinceMapModelToEF(
			int stateProvinceID,
			ApiStateProvinceModel model,
			StateProvince efStateProvince);

		POCOStateProvince StateProvinceMapEFToPOCO(
			StateProvince efStateProvince);

		void BillOfMaterialsMapModelToEF(
			int billOfMaterialsID,
			ApiBillOfMaterialsModel model,
			BillOfMaterials efBillOfMaterials);

		POCOBillOfMaterials BillOfMaterialsMapEFToPOCO(
			BillOfMaterials efBillOfMaterials);

		void CultureMapModelToEF(
			string cultureID,
			ApiCultureModel model,
			Culture efCulture);

		POCOCulture CultureMapEFToPOCO(
			Culture efCulture);

		void DocumentMapModelToEF(
			Guid documentNode,
			ApiDocumentModel model,
			Document efDocument);

		POCODocument DocumentMapEFToPOCO(
			Document efDocument);

		void IllustrationMapModelToEF(
			int illustrationID,
			ApiIllustrationModel model,
			Illustration efIllustration);

		POCOIllustration IllustrationMapEFToPOCO(
			Illustration efIllustration);

		void LocationMapModelToEF(
			short locationID,
			ApiLocationModel model,
			Location efLocation);

		POCOLocation LocationMapEFToPOCO(
			Location efLocation);

		void ProductMapModelToEF(
			int productID,
			ApiProductModel model,
			Product efProduct);

		POCOProduct ProductMapEFToPOCO(
			Product efProduct);

		void ProductCategoryMapModelToEF(
			int productCategoryID,
			ApiProductCategoryModel model,
			ProductCategory efProductCategory);

		POCOProductCategory ProductCategoryMapEFToPOCO(
			ProductCategory efProductCategory);

		void ProductCostHistoryMapModelToEF(
			int productID,
			ApiProductCostHistoryModel model,
			ProductCostHistory efProductCostHistory);

		POCOProductCostHistory ProductCostHistoryMapEFToPOCO(
			ProductCostHistory efProductCostHistory);

		void ProductDescriptionMapModelToEF(
			int productDescriptionID,
			ApiProductDescriptionModel model,
			ProductDescription efProductDescription);

		POCOProductDescription ProductDescriptionMapEFToPOCO(
			ProductDescription efProductDescription);

		void ProductDocumentMapModelToEF(
			int productID,
			ApiProductDocumentModel model,
			ProductDocument efProductDocument);

		POCOProductDocument ProductDocumentMapEFToPOCO(
			ProductDocument efProductDocument);

		void ProductInventoryMapModelToEF(
			int productID,
			ApiProductInventoryModel model,
			ProductInventory efProductInventory);

		POCOProductInventory ProductInventoryMapEFToPOCO(
			ProductInventory efProductInventory);

		void ProductListPriceHistoryMapModelToEF(
			int productID,
			ApiProductListPriceHistoryModel model,
			ProductListPriceHistory efProductListPriceHistory);

		POCOProductListPriceHistory ProductListPriceHistoryMapEFToPOCO(
			ProductListPriceHistory efProductListPriceHistory);

		void ProductModelMapModelToEF(
			int productModelID,
			ApiProductModelModel model,
			ProductModel efProductModel);

		POCOProductModel ProductModelMapEFToPOCO(
			ProductModel efProductModel);

		void ProductModelIllustrationMapModelToEF(
			int productModelID,
			ApiProductModelIllustrationModel model,
			ProductModelIllustration efProductModelIllustration);

		POCOProductModelIllustration ProductModelIllustrationMapEFToPOCO(
			ProductModelIllustration efProductModelIllustration);

		void ProductModelProductDescriptionCultureMapModelToEF(
			int productModelID,
			ApiProductModelProductDescriptionCultureModel model,
			ProductModelProductDescriptionCulture efProductModelProductDescriptionCulture);

		POCOProductModelProductDescriptionCulture ProductModelProductDescriptionCultureMapEFToPOCO(
			ProductModelProductDescriptionCulture efProductModelProductDescriptionCulture);

		void ProductPhotoMapModelToEF(
			int productPhotoID,
			ApiProductPhotoModel model,
			ProductPhoto efProductPhoto);

		POCOProductPhoto ProductPhotoMapEFToPOCO(
			ProductPhoto efProductPhoto);

		void ProductProductPhotoMapModelToEF(
			int productID,
			ApiProductProductPhotoModel model,
			ProductProductPhoto efProductProductPhoto);

		POCOProductProductPhoto ProductProductPhotoMapEFToPOCO(
			ProductProductPhoto efProductProductPhoto);

		void ProductReviewMapModelToEF(
			int productReviewID,
			ApiProductReviewModel model,
			ProductReview efProductReview);

		POCOProductReview ProductReviewMapEFToPOCO(
			ProductReview efProductReview);

		void ProductSubcategoryMapModelToEF(
			int productSubcategoryID,
			ApiProductSubcategoryModel model,
			ProductSubcategory efProductSubcategory);

		POCOProductSubcategory ProductSubcategoryMapEFToPOCO(
			ProductSubcategory efProductSubcategory);

		void ScrapReasonMapModelToEF(
			short scrapReasonID,
			ApiScrapReasonModel model,
			ScrapReason efScrapReason);

		POCOScrapReason ScrapReasonMapEFToPOCO(
			ScrapReason efScrapReason);

		void TransactionHistoryMapModelToEF(
			int transactionID,
			ApiTransactionHistoryModel model,
			TransactionHistory efTransactionHistory);

		POCOTransactionHistory TransactionHistoryMapEFToPOCO(
			TransactionHistory efTransactionHistory);

		void TransactionHistoryArchiveMapModelToEF(
			int transactionID,
			ApiTransactionHistoryArchiveModel model,
			TransactionHistoryArchive efTransactionHistoryArchive);

		POCOTransactionHistoryArchive TransactionHistoryArchiveMapEFToPOCO(
			TransactionHistoryArchive efTransactionHistoryArchive);

		void UnitMeasureMapModelToEF(
			string unitMeasureCode,
			ApiUnitMeasureModel model,
			UnitMeasure efUnitMeasure);

		POCOUnitMeasure UnitMeasureMapEFToPOCO(
			UnitMeasure efUnitMeasure);

		void WorkOrderMapModelToEF(
			int workOrderID,
			ApiWorkOrderModel model,
			WorkOrder efWorkOrder);

		POCOWorkOrder WorkOrderMapEFToPOCO(
			WorkOrder efWorkOrder);

		void WorkOrderRoutingMapModelToEF(
			int workOrderID,
			ApiWorkOrderRoutingModel model,
			WorkOrderRouting efWorkOrderRouting);

		POCOWorkOrderRouting WorkOrderRoutingMapEFToPOCO(
			WorkOrderRouting efWorkOrderRouting);

		void ProductVendorMapModelToEF(
			int productID,
			ApiProductVendorModel model,
			ProductVendor efProductVendor);

		POCOProductVendor ProductVendorMapEFToPOCO(
			ProductVendor efProductVendor);

		void PurchaseOrderDetailMapModelToEF(
			int purchaseOrderID,
			ApiPurchaseOrderDetailModel model,
			PurchaseOrderDetail efPurchaseOrderDetail);

		POCOPurchaseOrderDetail PurchaseOrderDetailMapEFToPOCO(
			PurchaseOrderDetail efPurchaseOrderDetail);

		void PurchaseOrderHeaderMapModelToEF(
			int purchaseOrderID,
			ApiPurchaseOrderHeaderModel model,
			PurchaseOrderHeader efPurchaseOrderHeader);

		POCOPurchaseOrderHeader PurchaseOrderHeaderMapEFToPOCO(
			PurchaseOrderHeader efPurchaseOrderHeader);

		void ShipMethodMapModelToEF(
			int shipMethodID,
			ApiShipMethodModel model,
			ShipMethod efShipMethod);

		POCOShipMethod ShipMethodMapEFToPOCO(
			ShipMethod efShipMethod);

		void VendorMapModelToEF(
			int businessEntityID,
			ApiVendorModel model,
			Vendor efVendor);

		POCOVendor VendorMapEFToPOCO(
			Vendor efVendor);

		void CountryRegionCurrencyMapModelToEF(
			string countryRegionCode,
			ApiCountryRegionCurrencyModel model,
			CountryRegionCurrency efCountryRegionCurrency);

		POCOCountryRegionCurrency CountryRegionCurrencyMapEFToPOCO(
			CountryRegionCurrency efCountryRegionCurrency);

		void CreditCardMapModelToEF(
			int creditCardID,
			ApiCreditCardModel model,
			CreditCard efCreditCard);

		POCOCreditCard CreditCardMapEFToPOCO(
			CreditCard efCreditCard);

		void CurrencyMapModelToEF(
			string currencyCode,
			ApiCurrencyModel model,
			Currency efCurrency);

		POCOCurrency CurrencyMapEFToPOCO(
			Currency efCurrency);

		void CurrencyRateMapModelToEF(
			int currencyRateID,
			ApiCurrencyRateModel model,
			CurrencyRate efCurrencyRate);

		POCOCurrencyRate CurrencyRateMapEFToPOCO(
			CurrencyRate efCurrencyRate);

		void CustomerMapModelToEF(
			int customerID,
			ApiCustomerModel model,
			Customer efCustomer);

		POCOCustomer CustomerMapEFToPOCO(
			Customer efCustomer);

		void PersonCreditCardMapModelToEF(
			int businessEntityID,
			ApiPersonCreditCardModel model,
			PersonCreditCard efPersonCreditCard);

		POCOPersonCreditCard PersonCreditCardMapEFToPOCO(
			PersonCreditCard efPersonCreditCard);

		void SalesOrderDetailMapModelToEF(
			int salesOrderID,
			ApiSalesOrderDetailModel model,
			SalesOrderDetail efSalesOrderDetail);

		POCOSalesOrderDetail SalesOrderDetailMapEFToPOCO(
			SalesOrderDetail efSalesOrderDetail);

		void SalesOrderHeaderMapModelToEF(
			int salesOrderID,
			ApiSalesOrderHeaderModel model,
			SalesOrderHeader efSalesOrderHeader);

		POCOSalesOrderHeader SalesOrderHeaderMapEFToPOCO(
			SalesOrderHeader efSalesOrderHeader);

		void SalesOrderHeaderSalesReasonMapModelToEF(
			int salesOrderID,
			ApiSalesOrderHeaderSalesReasonModel model,
			SalesOrderHeaderSalesReason efSalesOrderHeaderSalesReason);

		POCOSalesOrderHeaderSalesReason SalesOrderHeaderSalesReasonMapEFToPOCO(
			SalesOrderHeaderSalesReason efSalesOrderHeaderSalesReason);

		void SalesPersonMapModelToEF(
			int businessEntityID,
			ApiSalesPersonModel model,
			SalesPerson efSalesPerson);

		POCOSalesPerson SalesPersonMapEFToPOCO(
			SalesPerson efSalesPerson);

		void SalesPersonQuotaHistoryMapModelToEF(
			int businessEntityID,
			ApiSalesPersonQuotaHistoryModel model,
			SalesPersonQuotaHistory efSalesPersonQuotaHistory);

		POCOSalesPersonQuotaHistory SalesPersonQuotaHistoryMapEFToPOCO(
			SalesPersonQuotaHistory efSalesPersonQuotaHistory);

		void SalesReasonMapModelToEF(
			int salesReasonID,
			ApiSalesReasonModel model,
			SalesReason efSalesReason);

		POCOSalesReason SalesReasonMapEFToPOCO(
			SalesReason efSalesReason);

		void SalesTaxRateMapModelToEF(
			int salesTaxRateID,
			ApiSalesTaxRateModel model,
			SalesTaxRate efSalesTaxRate);

		POCOSalesTaxRate SalesTaxRateMapEFToPOCO(
			SalesTaxRate efSalesTaxRate);

		void SalesTerritoryMapModelToEF(
			int territoryID,
			ApiSalesTerritoryModel model,
			SalesTerritory efSalesTerritory);

		POCOSalesTerritory SalesTerritoryMapEFToPOCO(
			SalesTerritory efSalesTerritory);

		void SalesTerritoryHistoryMapModelToEF(
			int businessEntityID,
			ApiSalesTerritoryHistoryModel model,
			SalesTerritoryHistory efSalesTerritoryHistory);

		POCOSalesTerritoryHistory SalesTerritoryHistoryMapEFToPOCO(
			SalesTerritoryHistory efSalesTerritoryHistory);

		void ShoppingCartItemMapModelToEF(
			int shoppingCartItemID,
			ApiShoppingCartItemModel model,
			ShoppingCartItem efShoppingCartItem);

		POCOShoppingCartItem ShoppingCartItemMapEFToPOCO(
			ShoppingCartItem efShoppingCartItem);

		void SpecialOfferMapModelToEF(
			int specialOfferID,
			ApiSpecialOfferModel model,
			SpecialOffer efSpecialOffer);

		POCOSpecialOffer SpecialOfferMapEFToPOCO(
			SpecialOffer efSpecialOffer);

		void SpecialOfferProductMapModelToEF(
			int specialOfferID,
			ApiSpecialOfferProductModel model,
			SpecialOfferProduct efSpecialOfferProduct);

		POCOSpecialOfferProduct SpecialOfferProductMapEFToPOCO(
			SpecialOfferProduct efSpecialOfferProduct);

		void StoreMapModelToEF(
			int businessEntityID,
			ApiStoreModel model,
			Store efStore);

		POCOStore StoreMapEFToPOCO(
			Store efStore);
	}
}

/*<Codenesium>
    <Hash>713c3062a6d4731cc5953212ebe57b1e</Hash>
</Codenesium>*/