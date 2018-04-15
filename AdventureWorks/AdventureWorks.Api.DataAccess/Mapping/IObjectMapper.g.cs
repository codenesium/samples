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

		void AWBuildVersionMapEFToPOCO(
			EFAWBuildVersion efAWBuildVersion,
			ApiResponse response);

		void DatabaseLogMapModelToEF(
			int databaseLogID,
			DatabaseLogModel model,
			EFDatabaseLog efDatabaseLog);

		void DatabaseLogMapEFToPOCO(
			EFDatabaseLog efDatabaseLog,
			ApiResponse response);

		void ErrorLogMapModelToEF(
			int errorLogID,
			ErrorLogModel model,
			EFErrorLog efErrorLog);

		void ErrorLogMapEFToPOCO(
			EFErrorLog efErrorLog,
			ApiResponse response);

		void DepartmentMapModelToEF(
			short departmentID,
			DepartmentModel model,
			EFDepartment efDepartment);

		void DepartmentMapEFToPOCO(
			EFDepartment efDepartment,
			ApiResponse response);

		void EmployeeMapModelToEF(
			int businessEntityID,
			EmployeeModel model,
			EFEmployee efEmployee);

		void EmployeeMapEFToPOCO(
			EFEmployee efEmployee,
			ApiResponse response);

		void EmployeeDepartmentHistoryMapModelToEF(
			int businessEntityID,
			EmployeeDepartmentHistoryModel model,
			EFEmployeeDepartmentHistory efEmployeeDepartmentHistory);

		void EmployeeDepartmentHistoryMapEFToPOCO(
			EFEmployeeDepartmentHistory efEmployeeDepartmentHistory,
			ApiResponse response);

		void EmployeePayHistoryMapModelToEF(
			int businessEntityID,
			EmployeePayHistoryModel model,
			EFEmployeePayHistory efEmployeePayHistory);

		void EmployeePayHistoryMapEFToPOCO(
			EFEmployeePayHistory efEmployeePayHistory,
			ApiResponse response);

		void JobCandidateMapModelToEF(
			int jobCandidateID,
			JobCandidateModel model,
			EFJobCandidate efJobCandidate);

		void JobCandidateMapEFToPOCO(
			EFJobCandidate efJobCandidate,
			ApiResponse response);

		void ShiftMapModelToEF(
			int shiftID,
			ShiftModel model,
			EFShift efShift);

		void ShiftMapEFToPOCO(
			EFShift efShift,
			ApiResponse response);

		void AddressMapModelToEF(
			int addressID,
			AddressModel model,
			EFAddress efAddress);

		void AddressMapEFToPOCO(
			EFAddress efAddress,
			ApiResponse response);

		void AddressTypeMapModelToEF(
			int addressTypeID,
			AddressTypeModel model,
			EFAddressType efAddressType);

		void AddressTypeMapEFToPOCO(
			EFAddressType efAddressType,
			ApiResponse response);

		void BusinessEntityMapModelToEF(
			int businessEntityID,
			BusinessEntityModel model,
			EFBusinessEntity efBusinessEntity);

		void BusinessEntityMapEFToPOCO(
			EFBusinessEntity efBusinessEntity,
			ApiResponse response);

		void BusinessEntityAddressMapModelToEF(
			int businessEntityID,
			BusinessEntityAddressModel model,
			EFBusinessEntityAddress efBusinessEntityAddress);

		void BusinessEntityAddressMapEFToPOCO(
			EFBusinessEntityAddress efBusinessEntityAddress,
			ApiResponse response);

		void BusinessEntityContactMapModelToEF(
			int businessEntityID,
			BusinessEntityContactModel model,
			EFBusinessEntityContact efBusinessEntityContact);

		void BusinessEntityContactMapEFToPOCO(
			EFBusinessEntityContact efBusinessEntityContact,
			ApiResponse response);

		void ContactTypeMapModelToEF(
			int contactTypeID,
			ContactTypeModel model,
			EFContactType efContactType);

		void ContactTypeMapEFToPOCO(
			EFContactType efContactType,
			ApiResponse response);

		void CountryRegionMapModelToEF(
			string countryRegionCode,
			CountryRegionModel model,
			EFCountryRegion efCountryRegion);

		void CountryRegionMapEFToPOCO(
			EFCountryRegion efCountryRegion,
			ApiResponse response);

		void EmailAddressMapModelToEF(
			int businessEntityID,
			EmailAddressModel model,
			EFEmailAddress efEmailAddress);

		void EmailAddressMapEFToPOCO(
			EFEmailAddress efEmailAddress,
			ApiResponse response);

		void PasswordMapModelToEF(
			int businessEntityID,
			PasswordModel model,
			EFPassword efPassword);

		void PasswordMapEFToPOCO(
			EFPassword efPassword,
			ApiResponse response);

		void PersonMapModelToEF(
			int businessEntityID,
			PersonModel model,
			EFPerson efPerson);

		void PersonMapEFToPOCO(
			EFPerson efPerson,
			ApiResponse response);

		void PersonPhoneMapModelToEF(
			int businessEntityID,
			PersonPhoneModel model,
			EFPersonPhone efPersonPhone);

		void PersonPhoneMapEFToPOCO(
			EFPersonPhone efPersonPhone,
			ApiResponse response);

		void PhoneNumberTypeMapModelToEF(
			int phoneNumberTypeID,
			PhoneNumberTypeModel model,
			EFPhoneNumberType efPhoneNumberType);

		void PhoneNumberTypeMapEFToPOCO(
			EFPhoneNumberType efPhoneNumberType,
			ApiResponse response);

		void StateProvinceMapModelToEF(
			int stateProvinceID,
			StateProvinceModel model,
			EFStateProvince efStateProvince);

		void StateProvinceMapEFToPOCO(
			EFStateProvince efStateProvince,
			ApiResponse response);

		void BillOfMaterialsMapModelToEF(
			int billOfMaterialsID,
			BillOfMaterialsModel model,
			EFBillOfMaterials efBillOfMaterials);

		void BillOfMaterialsMapEFToPOCO(
			EFBillOfMaterials efBillOfMaterials,
			ApiResponse response);

		void CultureMapModelToEF(
			string cultureID,
			CultureModel model,
			EFCulture efCulture);

		void CultureMapEFToPOCO(
			EFCulture efCulture,
			ApiResponse response);

		void DocumentMapModelToEF(
			Guid documentNode,
			DocumentModel model,
			EFDocument efDocument);

		void DocumentMapEFToPOCO(
			EFDocument efDocument,
			ApiResponse response);

		void IllustrationMapModelToEF(
			int illustrationID,
			IllustrationModel model,
			EFIllustration efIllustration);

		void IllustrationMapEFToPOCO(
			EFIllustration efIllustration,
			ApiResponse response);

		void LocationMapModelToEF(
			short locationID,
			LocationModel model,
			EFLocation efLocation);

		void LocationMapEFToPOCO(
			EFLocation efLocation,
			ApiResponse response);

		void ProductMapModelToEF(
			int productID,
			ProductModel model,
			EFProduct efProduct);

		void ProductMapEFToPOCO(
			EFProduct efProduct,
			ApiResponse response);

		void ProductCategoryMapModelToEF(
			int productCategoryID,
			ProductCategoryModel model,
			EFProductCategory efProductCategory);

		void ProductCategoryMapEFToPOCO(
			EFProductCategory efProductCategory,
			ApiResponse response);

		void ProductCostHistoryMapModelToEF(
			int productID,
			ProductCostHistoryModel model,
			EFProductCostHistory efProductCostHistory);

		void ProductCostHistoryMapEFToPOCO(
			EFProductCostHistory efProductCostHistory,
			ApiResponse response);

		void ProductDescriptionMapModelToEF(
			int productDescriptionID,
			ProductDescriptionModel model,
			EFProductDescription efProductDescription);

		void ProductDescriptionMapEFToPOCO(
			EFProductDescription efProductDescription,
			ApiResponse response);

		void ProductDocumentMapModelToEF(
			int productID,
			ProductDocumentModel model,
			EFProductDocument efProductDocument);

		void ProductDocumentMapEFToPOCO(
			EFProductDocument efProductDocument,
			ApiResponse response);

		void ProductInventoryMapModelToEF(
			int productID,
			ProductInventoryModel model,
			EFProductInventory efProductInventory);

		void ProductInventoryMapEFToPOCO(
			EFProductInventory efProductInventory,
			ApiResponse response);

		void ProductListPriceHistoryMapModelToEF(
			int productID,
			ProductListPriceHistoryModel model,
			EFProductListPriceHistory efProductListPriceHistory);

		void ProductListPriceHistoryMapEFToPOCO(
			EFProductListPriceHistory efProductListPriceHistory,
			ApiResponse response);

		void ProductModelMapModelToEF(
			int productModelID,
			ProductModelModel model,
			EFProductModel efProductModel);

		void ProductModelMapEFToPOCO(
			EFProductModel efProductModel,
			ApiResponse response);

		void ProductModelIllustrationMapModelToEF(
			int productModelID,
			ProductModelIllustrationModel model,
			EFProductModelIllustration efProductModelIllustration);

		void ProductModelIllustrationMapEFToPOCO(
			EFProductModelIllustration efProductModelIllustration,
			ApiResponse response);

		void ProductModelProductDescriptionCultureMapModelToEF(
			int productModelID,
			ProductModelProductDescriptionCultureModel model,
			EFProductModelProductDescriptionCulture efProductModelProductDescriptionCulture);

		void ProductModelProductDescriptionCultureMapEFToPOCO(
			EFProductModelProductDescriptionCulture efProductModelProductDescriptionCulture,
			ApiResponse response);

		void ProductPhotoMapModelToEF(
			int productPhotoID,
			ProductPhotoModel model,
			EFProductPhoto efProductPhoto);

		void ProductPhotoMapEFToPOCO(
			EFProductPhoto efProductPhoto,
			ApiResponse response);

		void ProductProductPhotoMapModelToEF(
			int productID,
			ProductProductPhotoModel model,
			EFProductProductPhoto efProductProductPhoto);

		void ProductProductPhotoMapEFToPOCO(
			EFProductProductPhoto efProductProductPhoto,
			ApiResponse response);

		void ProductReviewMapModelToEF(
			int productReviewID,
			ProductReviewModel model,
			EFProductReview efProductReview);

		void ProductReviewMapEFToPOCO(
			EFProductReview efProductReview,
			ApiResponse response);

		void ProductSubcategoryMapModelToEF(
			int productSubcategoryID,
			ProductSubcategoryModel model,
			EFProductSubcategory efProductSubcategory);

		void ProductSubcategoryMapEFToPOCO(
			EFProductSubcategory efProductSubcategory,
			ApiResponse response);

		void ScrapReasonMapModelToEF(
			short scrapReasonID,
			ScrapReasonModel model,
			EFScrapReason efScrapReason);

		void ScrapReasonMapEFToPOCO(
			EFScrapReason efScrapReason,
			ApiResponse response);

		void TransactionHistoryMapModelToEF(
			int transactionID,
			TransactionHistoryModel model,
			EFTransactionHistory efTransactionHistory);

		void TransactionHistoryMapEFToPOCO(
			EFTransactionHistory efTransactionHistory,
			ApiResponse response);

		void TransactionHistoryArchiveMapModelToEF(
			int transactionID,
			TransactionHistoryArchiveModel model,
			EFTransactionHistoryArchive efTransactionHistoryArchive);

		void TransactionHistoryArchiveMapEFToPOCO(
			EFTransactionHistoryArchive efTransactionHistoryArchive,
			ApiResponse response);

		void UnitMeasureMapModelToEF(
			string unitMeasureCode,
			UnitMeasureModel model,
			EFUnitMeasure efUnitMeasure);

		void UnitMeasureMapEFToPOCO(
			EFUnitMeasure efUnitMeasure,
			ApiResponse response);

		void WorkOrderMapModelToEF(
			int workOrderID,
			WorkOrderModel model,
			EFWorkOrder efWorkOrder);

		void WorkOrderMapEFToPOCO(
			EFWorkOrder efWorkOrder,
			ApiResponse response);

		void WorkOrderRoutingMapModelToEF(
			int workOrderID,
			WorkOrderRoutingModel model,
			EFWorkOrderRouting efWorkOrderRouting);

		void WorkOrderRoutingMapEFToPOCO(
			EFWorkOrderRouting efWorkOrderRouting,
			ApiResponse response);

		void ProductVendorMapModelToEF(
			int productID,
			ProductVendorModel model,
			EFProductVendor efProductVendor);

		void ProductVendorMapEFToPOCO(
			EFProductVendor efProductVendor,
			ApiResponse response);

		void PurchaseOrderDetailMapModelToEF(
			int purchaseOrderID,
			PurchaseOrderDetailModel model,
			EFPurchaseOrderDetail efPurchaseOrderDetail);

		void PurchaseOrderDetailMapEFToPOCO(
			EFPurchaseOrderDetail efPurchaseOrderDetail,
			ApiResponse response);

		void PurchaseOrderHeaderMapModelToEF(
			int purchaseOrderID,
			PurchaseOrderHeaderModel model,
			EFPurchaseOrderHeader efPurchaseOrderHeader);

		void PurchaseOrderHeaderMapEFToPOCO(
			EFPurchaseOrderHeader efPurchaseOrderHeader,
			ApiResponse response);

		void ShipMethodMapModelToEF(
			int shipMethodID,
			ShipMethodModel model,
			EFShipMethod efShipMethod);

		void ShipMethodMapEFToPOCO(
			EFShipMethod efShipMethod,
			ApiResponse response);

		void VendorMapModelToEF(
			int businessEntityID,
			VendorModel model,
			EFVendor efVendor);

		void VendorMapEFToPOCO(
			EFVendor efVendor,
			ApiResponse response);

		void CountryRegionCurrencyMapModelToEF(
			string countryRegionCode,
			CountryRegionCurrencyModel model,
			EFCountryRegionCurrency efCountryRegionCurrency);

		void CountryRegionCurrencyMapEFToPOCO(
			EFCountryRegionCurrency efCountryRegionCurrency,
			ApiResponse response);

		void CreditCardMapModelToEF(
			int creditCardID,
			CreditCardModel model,
			EFCreditCard efCreditCard);

		void CreditCardMapEFToPOCO(
			EFCreditCard efCreditCard,
			ApiResponse response);

		void CurrencyMapModelToEF(
			string currencyCode,
			CurrencyModel model,
			EFCurrency efCurrency);

		void CurrencyMapEFToPOCO(
			EFCurrency efCurrency,
			ApiResponse response);

		void CurrencyRateMapModelToEF(
			int currencyRateID,
			CurrencyRateModel model,
			EFCurrencyRate efCurrencyRate);

		void CurrencyRateMapEFToPOCO(
			EFCurrencyRate efCurrencyRate,
			ApiResponse response);

		void CustomerMapModelToEF(
			int customerID,
			CustomerModel model,
			EFCustomer efCustomer);

		void CustomerMapEFToPOCO(
			EFCustomer efCustomer,
			ApiResponse response);

		void PersonCreditCardMapModelToEF(
			int businessEntityID,
			PersonCreditCardModel model,
			EFPersonCreditCard efPersonCreditCard);

		void PersonCreditCardMapEFToPOCO(
			EFPersonCreditCard efPersonCreditCard,
			ApiResponse response);

		void SalesOrderDetailMapModelToEF(
			int salesOrderID,
			SalesOrderDetailModel model,
			EFSalesOrderDetail efSalesOrderDetail);

		void SalesOrderDetailMapEFToPOCO(
			EFSalesOrderDetail efSalesOrderDetail,
			ApiResponse response);

		void SalesOrderHeaderMapModelToEF(
			int salesOrderID,
			SalesOrderHeaderModel model,
			EFSalesOrderHeader efSalesOrderHeader);

		void SalesOrderHeaderMapEFToPOCO(
			EFSalesOrderHeader efSalesOrderHeader,
			ApiResponse response);

		void SalesOrderHeaderSalesReasonMapModelToEF(
			int salesOrderID,
			SalesOrderHeaderSalesReasonModel model,
			EFSalesOrderHeaderSalesReason efSalesOrderHeaderSalesReason);

		void SalesOrderHeaderSalesReasonMapEFToPOCO(
			EFSalesOrderHeaderSalesReason efSalesOrderHeaderSalesReason,
			ApiResponse response);

		void SalesPersonMapModelToEF(
			int businessEntityID,
			SalesPersonModel model,
			EFSalesPerson efSalesPerson);

		void SalesPersonMapEFToPOCO(
			EFSalesPerson efSalesPerson,
			ApiResponse response);

		void SalesPersonQuotaHistoryMapModelToEF(
			int businessEntityID,
			SalesPersonQuotaHistoryModel model,
			EFSalesPersonQuotaHistory efSalesPersonQuotaHistory);

		void SalesPersonQuotaHistoryMapEFToPOCO(
			EFSalesPersonQuotaHistory efSalesPersonQuotaHistory,
			ApiResponse response);

		void SalesReasonMapModelToEF(
			int salesReasonID,
			SalesReasonModel model,
			EFSalesReason efSalesReason);

		void SalesReasonMapEFToPOCO(
			EFSalesReason efSalesReason,
			ApiResponse response);

		void SalesTaxRateMapModelToEF(
			int salesTaxRateID,
			SalesTaxRateModel model,
			EFSalesTaxRate efSalesTaxRate);

		void SalesTaxRateMapEFToPOCO(
			EFSalesTaxRate efSalesTaxRate,
			ApiResponse response);

		void SalesTerritoryMapModelToEF(
			int territoryID,
			SalesTerritoryModel model,
			EFSalesTerritory efSalesTerritory);

		void SalesTerritoryMapEFToPOCO(
			EFSalesTerritory efSalesTerritory,
			ApiResponse response);

		void SalesTerritoryHistoryMapModelToEF(
			int businessEntityID,
			SalesTerritoryHistoryModel model,
			EFSalesTerritoryHistory efSalesTerritoryHistory);

		void SalesTerritoryHistoryMapEFToPOCO(
			EFSalesTerritoryHistory efSalesTerritoryHistory,
			ApiResponse response);

		void ShoppingCartItemMapModelToEF(
			int shoppingCartItemID,
			ShoppingCartItemModel model,
			EFShoppingCartItem efShoppingCartItem);

		void ShoppingCartItemMapEFToPOCO(
			EFShoppingCartItem efShoppingCartItem,
			ApiResponse response);

		void SpecialOfferMapModelToEF(
			int specialOfferID,
			SpecialOfferModel model,
			EFSpecialOffer efSpecialOffer);

		void SpecialOfferMapEFToPOCO(
			EFSpecialOffer efSpecialOffer,
			ApiResponse response);

		void SpecialOfferProductMapModelToEF(
			int specialOfferID,
			SpecialOfferProductModel model,
			EFSpecialOfferProduct efSpecialOfferProduct);

		void SpecialOfferProductMapEFToPOCO(
			EFSpecialOfferProduct efSpecialOfferProduct,
			ApiResponse response);

		void StoreMapModelToEF(
			int businessEntityID,
			StoreModel model,
			EFStore efStore);

		void StoreMapEFToPOCO(
			EFStore efStore,
			ApiResponse response);
	}
}

/*<Codenesium>
    <Hash>616e33849d683902f79238adc591bb51</Hash>
</Codenesium>*/