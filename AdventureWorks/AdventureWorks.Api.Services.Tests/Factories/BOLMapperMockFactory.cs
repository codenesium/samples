using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Moq;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services.Tests
{
	public class BOLMapperMockFactory
	{
		public IBOLAWBuildVersionMapper BOLAWBuildVersionMapperMock { get; set; } = new BOLAWBuildVersionMapper();

		public IBOLDatabaseLogMapper BOLDatabaseLogMapperMock { get; set; } = new BOLDatabaseLogMapper();

		public IBOLErrorLogMapper BOLErrorLogMapperMock { get; set; } = new BOLErrorLogMapper();

		public IBOLDepartmentMapper BOLDepartmentMapperMock { get; set; } = new BOLDepartmentMapper();

		public IBOLEmployeeMapper BOLEmployeeMapperMock { get; set; } = new BOLEmployeeMapper();

		public IBOLEmployeeDepartmentHistoryMapper BOLEmployeeDepartmentHistoryMapperMock { get; set; } = new BOLEmployeeDepartmentHistoryMapper();

		public IBOLEmployeePayHistoryMapper BOLEmployeePayHistoryMapperMock { get; set; } = new BOLEmployeePayHistoryMapper();

		public IBOLJobCandidateMapper BOLJobCandidateMapperMock { get; set; } = new BOLJobCandidateMapper();

		public IBOLShiftMapper BOLShiftMapperMock { get; set; } = new BOLShiftMapper();

		public IBOLAddressMapper BOLAddressMapperMock { get; set; } = new BOLAddressMapper();

		public IBOLAddressTypeMapper BOLAddressTypeMapperMock { get; set; } = new BOLAddressTypeMapper();

		public IBOLBusinessEntityMapper BOLBusinessEntityMapperMock { get; set; } = new BOLBusinessEntityMapper();

		public IBOLBusinessEntityAddressMapper BOLBusinessEntityAddressMapperMock { get; set; } = new BOLBusinessEntityAddressMapper();

		public IBOLBusinessEntityContactMapper BOLBusinessEntityContactMapperMock { get; set; } = new BOLBusinessEntityContactMapper();

		public IBOLContactTypeMapper BOLContactTypeMapperMock { get; set; } = new BOLContactTypeMapper();

		public IBOLCountryRegionMapper BOLCountryRegionMapperMock { get; set; } = new BOLCountryRegionMapper();

		public IBOLEmailAddressMapper BOLEmailAddressMapperMock { get; set; } = new BOLEmailAddressMapper();

		public IBOLPasswordMapper BOLPasswordMapperMock { get; set; } = new BOLPasswordMapper();

		public IBOLPersonMapper BOLPersonMapperMock { get; set; } = new BOLPersonMapper();

		public IBOLPersonPhoneMapper BOLPersonPhoneMapperMock { get; set; } = new BOLPersonPhoneMapper();

		public IBOLPhoneNumberTypeMapper BOLPhoneNumberTypeMapperMock { get; set; } = new BOLPhoneNumberTypeMapper();

		public IBOLStateProvinceMapper BOLStateProvinceMapperMock { get; set; } = new BOLStateProvinceMapper();

		public IBOLVStateProvinceCountryRegionMapper BOLVStateProvinceCountryRegionMapperMock { get; set; } = new BOLVStateProvinceCountryRegionMapper();

		public IBOLBillOfMaterialMapper BOLBillOfMaterialMapperMock { get; set; } = new BOLBillOfMaterialMapper();

		public IBOLCultureMapper BOLCultureMapperMock { get; set; } = new BOLCultureMapper();

		public IBOLDocumentMapper BOLDocumentMapperMock { get; set; } = new BOLDocumentMapper();

		public IBOLIllustrationMapper BOLIllustrationMapperMock { get; set; } = new BOLIllustrationMapper();

		public IBOLLocationMapper BOLLocationMapperMock { get; set; } = new BOLLocationMapper();

		public IBOLProductMapper BOLProductMapperMock { get; set; } = new BOLProductMapper();

		public IBOLProductCategoryMapper BOLProductCategoryMapperMock { get; set; } = new BOLProductCategoryMapper();

		public IBOLProductCostHistoryMapper BOLProductCostHistoryMapperMock { get; set; } = new BOLProductCostHistoryMapper();

		public IBOLProductDescriptionMapper BOLProductDescriptionMapperMock { get; set; } = new BOLProductDescriptionMapper();

		public IBOLProductInventoryMapper BOLProductInventoryMapperMock { get; set; } = new BOLProductInventoryMapper();

		public IBOLProductListPriceHistoryMapper BOLProductListPriceHistoryMapperMock { get; set; } = new BOLProductListPriceHistoryMapper();

		public IBOLProductModelMapper BOLProductModelMapperMock { get; set; } = new BOLProductModelMapper();

		public IBOLProductModelIllustrationMapper BOLProductModelIllustrationMapperMock { get; set; } = new BOLProductModelIllustrationMapper();

		public IBOLProductModelProductDescriptionCultureMapper BOLProductModelProductDescriptionCultureMapperMock { get; set; } = new BOLProductModelProductDescriptionCultureMapper();

		public IBOLProductPhotoMapper BOLProductPhotoMapperMock { get; set; } = new BOLProductPhotoMapper();

		public IBOLProductProductPhotoMapper BOLProductProductPhotoMapperMock { get; set; } = new BOLProductProductPhotoMapper();

		public IBOLProductReviewMapper BOLProductReviewMapperMock { get; set; } = new BOLProductReviewMapper();

		public IBOLProductSubcategoryMapper BOLProductSubcategoryMapperMock { get; set; } = new BOLProductSubcategoryMapper();

		public IBOLScrapReasonMapper BOLScrapReasonMapperMock { get; set; } = new BOLScrapReasonMapper();

		public IBOLTransactionHistoryMapper BOLTransactionHistoryMapperMock { get; set; } = new BOLTransactionHistoryMapper();

		public IBOLTransactionHistoryArchiveMapper BOLTransactionHistoryArchiveMapperMock { get; set; } = new BOLTransactionHistoryArchiveMapper();

		public IBOLUnitMeasureMapper BOLUnitMeasureMapperMock { get; set; } = new BOLUnitMeasureMapper();

		public IBOLVProductAndDescriptionMapper BOLVProductAndDescriptionMapperMock { get; set; } = new BOLVProductAndDescriptionMapper();

		public IBOLWorkOrderMapper BOLWorkOrderMapperMock { get; set; } = new BOLWorkOrderMapper();

		public IBOLWorkOrderRoutingMapper BOLWorkOrderRoutingMapperMock { get; set; } = new BOLWorkOrderRoutingMapper();

		public IBOLProductVendorMapper BOLProductVendorMapperMock { get; set; } = new BOLProductVendorMapper();

		public IBOLPurchaseOrderDetailMapper BOLPurchaseOrderDetailMapperMock { get; set; } = new BOLPurchaseOrderDetailMapper();

		public IBOLPurchaseOrderHeaderMapper BOLPurchaseOrderHeaderMapperMock { get; set; } = new BOLPurchaseOrderHeaderMapper();

		public IBOLShipMethodMapper BOLShipMethodMapperMock { get; set; } = new BOLShipMethodMapper();

		public IBOLVendorMapper BOLVendorMapperMock { get; set; } = new BOLVendorMapper();

		public IBOLCountryRegionCurrencyMapper BOLCountryRegionCurrencyMapperMock { get; set; } = new BOLCountryRegionCurrencyMapper();

		public IBOLCreditCardMapper BOLCreditCardMapperMock { get; set; } = new BOLCreditCardMapper();

		public IBOLCurrencyMapper BOLCurrencyMapperMock { get; set; } = new BOLCurrencyMapper();

		public IBOLCurrencyRateMapper BOLCurrencyRateMapperMock { get; set; } = new BOLCurrencyRateMapper();

		public IBOLCustomerMapper BOLCustomerMapperMock { get; set; } = new BOLCustomerMapper();

		public IBOLPersonCreditCardMapper BOLPersonCreditCardMapperMock { get; set; } = new BOLPersonCreditCardMapper();

		public IBOLSalesOrderDetailMapper BOLSalesOrderDetailMapperMock { get; set; } = new BOLSalesOrderDetailMapper();

		public IBOLSalesOrderHeaderMapper BOLSalesOrderHeaderMapperMock { get; set; } = new BOLSalesOrderHeaderMapper();

		public IBOLSalesOrderHeaderSalesReasonMapper BOLSalesOrderHeaderSalesReasonMapperMock { get; set; } = new BOLSalesOrderHeaderSalesReasonMapper();

		public IBOLSalesPersonMapper BOLSalesPersonMapperMock { get; set; } = new BOLSalesPersonMapper();

		public IBOLSalesPersonQuotaHistoryMapper BOLSalesPersonQuotaHistoryMapperMock { get; set; } = new BOLSalesPersonQuotaHistoryMapper();

		public IBOLSalesReasonMapper BOLSalesReasonMapperMock { get; set; } = new BOLSalesReasonMapper();

		public IBOLSalesTaxRateMapper BOLSalesTaxRateMapperMock { get; set; } = new BOLSalesTaxRateMapper();

		public IBOLSalesTerritoryMapper BOLSalesTerritoryMapperMock { get; set; } = new BOLSalesTerritoryMapper();

		public IBOLSalesTerritoryHistoryMapper BOLSalesTerritoryHistoryMapperMock { get; set; } = new BOLSalesTerritoryHistoryMapper();

		public IBOLShoppingCartItemMapper BOLShoppingCartItemMapperMock { get; set; } = new BOLShoppingCartItemMapper();

		public IBOLSpecialOfferMapper BOLSpecialOfferMapperMock { get; set; } = new BOLSpecialOfferMapper();

		public IBOLSpecialOfferProductMapper BOLSpecialOfferProductMapperMock { get; set; } = new BOLSpecialOfferProductMapper();

		public IBOLStoreMapper BOLStoreMapperMock { get; set; } = new BOLStoreMapper();

		public BOLMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>e0f88c2452f1cc49b0ed8e6b23c3d11f</Hash>
</Codenesium>*/