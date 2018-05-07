using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IObjectMapper
	{
		void AWBuildVersionMapModelToEF(
			int systemInformationID,
			AWBuildVersionModel model,
			EFAWBuildVersion efAWBuildVersion);

		POCOAWBuildVersion AWBuildVersionMapEFToPOCO(
			EFAWBuildVersion efAWBuildVersion);

		void DatabaseLogMapModelToEF(
			int databaseLogID,
			DatabaseLogModel model,
			EFDatabaseLog efDatabaseLog);

		POCODatabaseLog DatabaseLogMapEFToPOCO(
			EFDatabaseLog efDatabaseLog);

		void ErrorLogMapModelToEF(
			int errorLogID,
			ErrorLogModel model,
			EFErrorLog efErrorLog);

		POCOErrorLog ErrorLogMapEFToPOCO(
			EFErrorLog efErrorLog);

		void DepartmentMapModelToEF(
			short departmentID,
			DepartmentModel model,
			EFDepartment efDepartment);

		POCODepartment DepartmentMapEFToPOCO(
			EFDepartment efDepartment);

		void EmployeeMapModelToEF(
			int businessEntityID,
			EmployeeModel model,
			EFEmployee efEmployee);

		POCOEmployee EmployeeMapEFToPOCO(
			EFEmployee efEmployee);

		void EmployeeDepartmentHistoryMapModelToEF(
			int businessEntityID,
			EmployeeDepartmentHistoryModel model,
			EFEmployeeDepartmentHistory efEmployeeDepartmentHistory);

		POCOEmployeeDepartmentHistory EmployeeDepartmentHistoryMapEFToPOCO(
			EFEmployeeDepartmentHistory efEmployeeDepartmentHistory);

		void EmployeePayHistoryMapModelToEF(
			int businessEntityID,
			EmployeePayHistoryModel model,
			EFEmployeePayHistory efEmployeePayHistory);

		POCOEmployeePayHistory EmployeePayHistoryMapEFToPOCO(
			EFEmployeePayHistory efEmployeePayHistory);

		void JobCandidateMapModelToEF(
			int jobCandidateID,
			JobCandidateModel model,
			EFJobCandidate efJobCandidate);

		POCOJobCandidate JobCandidateMapEFToPOCO(
			EFJobCandidate efJobCandidate);

		void ShiftMapModelToEF(
			int shiftID,
			ShiftModel model,
			EFShift efShift);

		POCOShift ShiftMapEFToPOCO(
			EFShift efShift);

		void AddressMapModelToEF(
			int addressID,
			AddressModel model,
			EFAddress efAddress);

		POCOAddress AddressMapEFToPOCO(
			EFAddress efAddress);

		void AddressTypeMapModelToEF(
			int addressTypeID,
			AddressTypeModel model,
			EFAddressType efAddressType);

		POCOAddressType AddressTypeMapEFToPOCO(
			EFAddressType efAddressType);

		void BusinessEntityMapModelToEF(
			int businessEntityID,
			BusinessEntityModel model,
			EFBusinessEntity efBusinessEntity);

		POCOBusinessEntity BusinessEntityMapEFToPOCO(
			EFBusinessEntity efBusinessEntity);

		void BusinessEntityAddressMapModelToEF(
			int businessEntityID,
			BusinessEntityAddressModel model,
			EFBusinessEntityAddress efBusinessEntityAddress);

		POCOBusinessEntityAddress BusinessEntityAddressMapEFToPOCO(
			EFBusinessEntityAddress efBusinessEntityAddress);

		void BusinessEntityContactMapModelToEF(
			int businessEntityID,
			BusinessEntityContactModel model,
			EFBusinessEntityContact efBusinessEntityContact);

		POCOBusinessEntityContact BusinessEntityContactMapEFToPOCO(
			EFBusinessEntityContact efBusinessEntityContact);

		void ContactTypeMapModelToEF(
			int contactTypeID,
			ContactTypeModel model,
			EFContactType efContactType);

		POCOContactType ContactTypeMapEFToPOCO(
			EFContactType efContactType);

		void CountryRegionMapModelToEF(
			string countryRegionCode,
			CountryRegionModel model,
			EFCountryRegion efCountryRegion);

		POCOCountryRegion CountryRegionMapEFToPOCO(
			EFCountryRegion efCountryRegion);

		void EmailAddressMapModelToEF(
			int businessEntityID,
			EmailAddressModel model,
			EFEmailAddress efEmailAddress);

		POCOEmailAddress EmailAddressMapEFToPOCO(
			EFEmailAddress efEmailAddress);

		void PasswordMapModelToEF(
			int businessEntityID,
			PasswordModel model,
			EFPassword efPassword);

		POCOPassword PasswordMapEFToPOCO(
			EFPassword efPassword);

		void PersonMapModelToEF(
			int businessEntityID,
			PersonModel model,
			EFPerson efPerson);

		POCOPerson PersonMapEFToPOCO(
			EFPerson efPerson);

		void PersonPhoneMapModelToEF(
			int businessEntityID,
			PersonPhoneModel model,
			EFPersonPhone efPersonPhone);

		POCOPersonPhone PersonPhoneMapEFToPOCO(
			EFPersonPhone efPersonPhone);

		void PhoneNumberTypeMapModelToEF(
			int phoneNumberTypeID,
			PhoneNumberTypeModel model,
			EFPhoneNumberType efPhoneNumberType);

		POCOPhoneNumberType PhoneNumberTypeMapEFToPOCO(
			EFPhoneNumberType efPhoneNumberType);

		void StateProvinceMapModelToEF(
			int stateProvinceID,
			StateProvinceModel model,
			EFStateProvince efStateProvince);

		POCOStateProvince StateProvinceMapEFToPOCO(
			EFStateProvince efStateProvince);

		void BillOfMaterialsMapModelToEF(
			int billOfMaterialsID,
			BillOfMaterialsModel model,
			EFBillOfMaterials efBillOfMaterials);

		POCOBillOfMaterials BillOfMaterialsMapEFToPOCO(
			EFBillOfMaterials efBillOfMaterials);

		void CultureMapModelToEF(
			string cultureID,
			CultureModel model,
			EFCulture efCulture);

		POCOCulture CultureMapEFToPOCO(
			EFCulture efCulture);

		void DocumentMapModelToEF(
			Guid documentNode,
			DocumentModel model,
			EFDocument efDocument);

		POCODocument DocumentMapEFToPOCO(
			EFDocument efDocument);

		void IllustrationMapModelToEF(
			int illustrationID,
			IllustrationModel model,
			EFIllustration efIllustration);

		POCOIllustration IllustrationMapEFToPOCO(
			EFIllustration efIllustration);

		void LocationMapModelToEF(
			short locationID,
			LocationModel model,
			EFLocation efLocation);

		POCOLocation LocationMapEFToPOCO(
			EFLocation efLocation);

		void ProductMapModelToEF(
			int productID,
			ProductModel model,
			EFProduct efProduct);

		POCOProduct ProductMapEFToPOCO(
			EFProduct efProduct);

		void ProductCategoryMapModelToEF(
			int productCategoryID,
			ProductCategoryModel model,
			EFProductCategory efProductCategory);

		POCOProductCategory ProductCategoryMapEFToPOCO(
			EFProductCategory efProductCategory);

		void ProductCostHistoryMapModelToEF(
			int productID,
			ProductCostHistoryModel model,
			EFProductCostHistory efProductCostHistory);

		POCOProductCostHistory ProductCostHistoryMapEFToPOCO(
			EFProductCostHistory efProductCostHistory);

		void ProductDescriptionMapModelToEF(
			int productDescriptionID,
			ProductDescriptionModel model,
			EFProductDescription efProductDescription);

		POCOProductDescription ProductDescriptionMapEFToPOCO(
			EFProductDescription efProductDescription);

		void ProductDocumentMapModelToEF(
			int productID,
			ProductDocumentModel model,
			EFProductDocument efProductDocument);

		POCOProductDocument ProductDocumentMapEFToPOCO(
			EFProductDocument efProductDocument);

		void ProductInventoryMapModelToEF(
			int productID,
			ProductInventoryModel model,
			EFProductInventory efProductInventory);

		POCOProductInventory ProductInventoryMapEFToPOCO(
			EFProductInventory efProductInventory);

		void ProductListPriceHistoryMapModelToEF(
			int productID,
			ProductListPriceHistoryModel model,
			EFProductListPriceHistory efProductListPriceHistory);

		POCOProductListPriceHistory ProductListPriceHistoryMapEFToPOCO(
			EFProductListPriceHistory efProductListPriceHistory);

		void ProductModelMapModelToEF(
			int productModelID,
			ProductModelModel model,
			EFProductModel efProductModel);

		POCOProductModel ProductModelMapEFToPOCO(
			EFProductModel efProductModel);

		void ProductModelIllustrationMapModelToEF(
			int productModelID,
			ProductModelIllustrationModel model,
			EFProductModelIllustration efProductModelIllustration);

		POCOProductModelIllustration ProductModelIllustrationMapEFToPOCO(
			EFProductModelIllustration efProductModelIllustration);

		void ProductModelProductDescriptionCultureMapModelToEF(
			int productModelID,
			ProductModelProductDescriptionCultureModel model,
			EFProductModelProductDescriptionCulture efProductModelProductDescriptionCulture);

		POCOProductModelProductDescriptionCulture ProductModelProductDescriptionCultureMapEFToPOCO(
			EFProductModelProductDescriptionCulture efProductModelProductDescriptionCulture);

		void ProductPhotoMapModelToEF(
			int productPhotoID,
			ProductPhotoModel model,
			EFProductPhoto efProductPhoto);

		POCOProductPhoto ProductPhotoMapEFToPOCO(
			EFProductPhoto efProductPhoto);

		void ProductProductPhotoMapModelToEF(
			int productID,
			ProductProductPhotoModel model,
			EFProductProductPhoto efProductProductPhoto);

		POCOProductProductPhoto ProductProductPhotoMapEFToPOCO(
			EFProductProductPhoto efProductProductPhoto);

		void ProductReviewMapModelToEF(
			int productReviewID,
			ProductReviewModel model,
			EFProductReview efProductReview);

		POCOProductReview ProductReviewMapEFToPOCO(
			EFProductReview efProductReview);

		void ProductSubcategoryMapModelToEF(
			int productSubcategoryID,
			ProductSubcategoryModel model,
			EFProductSubcategory efProductSubcategory);

		POCOProductSubcategory ProductSubcategoryMapEFToPOCO(
			EFProductSubcategory efProductSubcategory);

		void ScrapReasonMapModelToEF(
			short scrapReasonID,
			ScrapReasonModel model,
			EFScrapReason efScrapReason);

		POCOScrapReason ScrapReasonMapEFToPOCO(
			EFScrapReason efScrapReason);

		void TransactionHistoryMapModelToEF(
			int transactionID,
			TransactionHistoryModel model,
			EFTransactionHistory efTransactionHistory);

		POCOTransactionHistory TransactionHistoryMapEFToPOCO(
			EFTransactionHistory efTransactionHistory);

		void TransactionHistoryArchiveMapModelToEF(
			int transactionID,
			TransactionHistoryArchiveModel model,
			EFTransactionHistoryArchive efTransactionHistoryArchive);

		POCOTransactionHistoryArchive TransactionHistoryArchiveMapEFToPOCO(
			EFTransactionHistoryArchive efTransactionHistoryArchive);

		void UnitMeasureMapModelToEF(
			string unitMeasureCode,
			UnitMeasureModel model,
			EFUnitMeasure efUnitMeasure);

		POCOUnitMeasure UnitMeasureMapEFToPOCO(
			EFUnitMeasure efUnitMeasure);

		void WorkOrderMapModelToEF(
			int workOrderID,
			WorkOrderModel model,
			EFWorkOrder efWorkOrder);

		POCOWorkOrder WorkOrderMapEFToPOCO(
			EFWorkOrder efWorkOrder);

		void WorkOrderRoutingMapModelToEF(
			int workOrderID,
			WorkOrderRoutingModel model,
			EFWorkOrderRouting efWorkOrderRouting);

		POCOWorkOrderRouting WorkOrderRoutingMapEFToPOCO(
			EFWorkOrderRouting efWorkOrderRouting);

		void ProductVendorMapModelToEF(
			int productID,
			ProductVendorModel model,
			EFProductVendor efProductVendor);

		POCOProductVendor ProductVendorMapEFToPOCO(
			EFProductVendor efProductVendor);

		void PurchaseOrderDetailMapModelToEF(
			int purchaseOrderID,
			PurchaseOrderDetailModel model,
			EFPurchaseOrderDetail efPurchaseOrderDetail);

		POCOPurchaseOrderDetail PurchaseOrderDetailMapEFToPOCO(
			EFPurchaseOrderDetail efPurchaseOrderDetail);

		void PurchaseOrderHeaderMapModelToEF(
			int purchaseOrderID,
			PurchaseOrderHeaderModel model,
			EFPurchaseOrderHeader efPurchaseOrderHeader);

		POCOPurchaseOrderHeader PurchaseOrderHeaderMapEFToPOCO(
			EFPurchaseOrderHeader efPurchaseOrderHeader);

		void ShipMethodMapModelToEF(
			int shipMethodID,
			ShipMethodModel model,
			EFShipMethod efShipMethod);

		POCOShipMethod ShipMethodMapEFToPOCO(
			EFShipMethod efShipMethod);

		void VendorMapModelToEF(
			int businessEntityID,
			VendorModel model,
			EFVendor efVendor);

		POCOVendor VendorMapEFToPOCO(
			EFVendor efVendor);

		void CountryRegionCurrencyMapModelToEF(
			string countryRegionCode,
			CountryRegionCurrencyModel model,
			EFCountryRegionCurrency efCountryRegionCurrency);

		POCOCountryRegionCurrency CountryRegionCurrencyMapEFToPOCO(
			EFCountryRegionCurrency efCountryRegionCurrency);

		void CreditCardMapModelToEF(
			int creditCardID,
			CreditCardModel model,
			EFCreditCard efCreditCard);

		POCOCreditCard CreditCardMapEFToPOCO(
			EFCreditCard efCreditCard);

		void CurrencyMapModelToEF(
			string currencyCode,
			CurrencyModel model,
			EFCurrency efCurrency);

		POCOCurrency CurrencyMapEFToPOCO(
			EFCurrency efCurrency);

		void CurrencyRateMapModelToEF(
			int currencyRateID,
			CurrencyRateModel model,
			EFCurrencyRate efCurrencyRate);

		POCOCurrencyRate CurrencyRateMapEFToPOCO(
			EFCurrencyRate efCurrencyRate);

		void CustomerMapModelToEF(
			int customerID,
			CustomerModel model,
			EFCustomer efCustomer);

		POCOCustomer CustomerMapEFToPOCO(
			EFCustomer efCustomer);

		void PersonCreditCardMapModelToEF(
			int businessEntityID,
			PersonCreditCardModel model,
			EFPersonCreditCard efPersonCreditCard);

		POCOPersonCreditCard PersonCreditCardMapEFToPOCO(
			EFPersonCreditCard efPersonCreditCard);

		void SalesOrderDetailMapModelToEF(
			int salesOrderID,
			SalesOrderDetailModel model,
			EFSalesOrderDetail efSalesOrderDetail);

		POCOSalesOrderDetail SalesOrderDetailMapEFToPOCO(
			EFSalesOrderDetail efSalesOrderDetail);

		void SalesOrderHeaderMapModelToEF(
			int salesOrderID,
			SalesOrderHeaderModel model,
			EFSalesOrderHeader efSalesOrderHeader);

		POCOSalesOrderHeader SalesOrderHeaderMapEFToPOCO(
			EFSalesOrderHeader efSalesOrderHeader);

		void SalesOrderHeaderSalesReasonMapModelToEF(
			int salesOrderID,
			SalesOrderHeaderSalesReasonModel model,
			EFSalesOrderHeaderSalesReason efSalesOrderHeaderSalesReason);

		POCOSalesOrderHeaderSalesReason SalesOrderHeaderSalesReasonMapEFToPOCO(
			EFSalesOrderHeaderSalesReason efSalesOrderHeaderSalesReason);

		void SalesPersonMapModelToEF(
			int businessEntityID,
			SalesPersonModel model,
			EFSalesPerson efSalesPerson);

		POCOSalesPerson SalesPersonMapEFToPOCO(
			EFSalesPerson efSalesPerson);

		void SalesPersonQuotaHistoryMapModelToEF(
			int businessEntityID,
			SalesPersonQuotaHistoryModel model,
			EFSalesPersonQuotaHistory efSalesPersonQuotaHistory);

		POCOSalesPersonQuotaHistory SalesPersonQuotaHistoryMapEFToPOCO(
			EFSalesPersonQuotaHistory efSalesPersonQuotaHistory);

		void SalesReasonMapModelToEF(
			int salesReasonID,
			SalesReasonModel model,
			EFSalesReason efSalesReason);

		POCOSalesReason SalesReasonMapEFToPOCO(
			EFSalesReason efSalesReason);

		void SalesTaxRateMapModelToEF(
			int salesTaxRateID,
			SalesTaxRateModel model,
			EFSalesTaxRate efSalesTaxRate);

		POCOSalesTaxRate SalesTaxRateMapEFToPOCO(
			EFSalesTaxRate efSalesTaxRate);

		void SalesTerritoryMapModelToEF(
			int territoryID,
			SalesTerritoryModel model,
			EFSalesTerritory efSalesTerritory);

		POCOSalesTerritory SalesTerritoryMapEFToPOCO(
			EFSalesTerritory efSalesTerritory);

		void SalesTerritoryHistoryMapModelToEF(
			int businessEntityID,
			SalesTerritoryHistoryModel model,
			EFSalesTerritoryHistory efSalesTerritoryHistory);

		POCOSalesTerritoryHistory SalesTerritoryHistoryMapEFToPOCO(
			EFSalesTerritoryHistory efSalesTerritoryHistory);

		void ShoppingCartItemMapModelToEF(
			int shoppingCartItemID,
			ShoppingCartItemModel model,
			EFShoppingCartItem efShoppingCartItem);

		POCOShoppingCartItem ShoppingCartItemMapEFToPOCO(
			EFShoppingCartItem efShoppingCartItem);

		void SpecialOfferMapModelToEF(
			int specialOfferID,
			SpecialOfferModel model,
			EFSpecialOffer efSpecialOffer);

		POCOSpecialOffer SpecialOfferMapEFToPOCO(
			EFSpecialOffer efSpecialOffer);

		void SpecialOfferProductMapModelToEF(
			int specialOfferID,
			SpecialOfferProductModel model,
			EFSpecialOfferProduct efSpecialOfferProduct);

		POCOSpecialOfferProduct SpecialOfferProductMapEFToPOCO(
			EFSpecialOfferProduct efSpecialOfferProduct);

		void StoreMapModelToEF(
			int businessEntityID,
			StoreModel model,
			EFStore efStore);

		POCOStore StoreMapEFToPOCO(
			EFStore efStore);
	}
}

/*<Codenesium>
    <Hash>a93bfbab7ad29ae84c8f2768fdfdf8b1</Hash>
</Codenesium>*/