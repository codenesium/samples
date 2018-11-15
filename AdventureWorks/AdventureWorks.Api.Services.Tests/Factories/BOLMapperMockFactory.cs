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

		public IBOLJobCandidateMapper BOLJobCandidateMapperMock { get; set; } = new BOLJobCandidateMapper();

		public IBOLShiftMapper BOLShiftMapperMock { get; set; } = new BOLShiftMapper();

		public IBOLAddressMapper BOLAddressMapperMock { get; set; } = new BOLAddressMapper();

		public IBOLAddressTypeMapper BOLAddressTypeMapperMock { get; set; } = new BOLAddressTypeMapper();

		public IBOLBusinessEntityMapper BOLBusinessEntityMapperMock { get; set; } = new BOLBusinessEntityMapper();

		public IBOLContactTypeMapper BOLContactTypeMapperMock { get; set; } = new BOLContactTypeMapper();

		public IBOLCountryRegionMapper BOLCountryRegionMapperMock { get; set; } = new BOLCountryRegionMapper();

		public IBOLPasswordMapper BOLPasswordMapperMock { get; set; } = new BOLPasswordMapper();

		public IBOLPersonMapper BOLPersonMapperMock { get; set; } = new BOLPersonMapper();

		public IBOLPhoneNumberTypeMapper BOLPhoneNumberTypeMapperMock { get; set; } = new BOLPhoneNumberTypeMapper();

		public IBOLStateProvinceMapper BOLStateProvinceMapperMock { get; set; } = new BOLStateProvinceMapper();

		public IBOLBillOfMaterialMapper BOLBillOfMaterialMapperMock { get; set; } = new BOLBillOfMaterialMapper();

		public IBOLCultureMapper BOLCultureMapperMock { get; set; } = new BOLCultureMapper();

		public IBOLDocumentMapper BOLDocumentMapperMock { get; set; } = new BOLDocumentMapper();

		public IBOLIllustrationMapper BOLIllustrationMapperMock { get; set; } = new BOLIllustrationMapper();

		public IBOLLocationMapper BOLLocationMapperMock { get; set; } = new BOLLocationMapper();

		public IBOLProductMapper BOLProductMapperMock { get; set; } = new BOLProductMapper();

		public IBOLProductCategoryMapper BOLProductCategoryMapperMock { get; set; } = new BOLProductCategoryMapper();

		public IBOLProductDescriptionMapper BOLProductDescriptionMapperMock { get; set; } = new BOLProductDescriptionMapper();

		public IBOLProductModelMapper BOLProductModelMapperMock { get; set; } = new BOLProductModelMapper();

		public IBOLProductPhotoMapper BOLProductPhotoMapperMock { get; set; } = new BOLProductPhotoMapper();

		public IBOLProductReviewMapper BOLProductReviewMapperMock { get; set; } = new BOLProductReviewMapper();

		public IBOLProductSubcategoryMapper BOLProductSubcategoryMapperMock { get; set; } = new BOLProductSubcategoryMapper();

		public IBOLScrapReasonMapper BOLScrapReasonMapperMock { get; set; } = new BOLScrapReasonMapper();

		public IBOLTransactionHistoryMapper BOLTransactionHistoryMapperMock { get; set; } = new BOLTransactionHistoryMapper();

		public IBOLTransactionHistoryArchiveMapper BOLTransactionHistoryArchiveMapperMock { get; set; } = new BOLTransactionHistoryArchiveMapper();

		public IBOLUnitMeasureMapper BOLUnitMeasureMapperMock { get; set; } = new BOLUnitMeasureMapper();

		public IBOLWorkOrderMapper BOLWorkOrderMapperMock { get; set; } = new BOLWorkOrderMapper();

		public IBOLPurchaseOrderHeaderMapper BOLPurchaseOrderHeaderMapperMock { get; set; } = new BOLPurchaseOrderHeaderMapper();

		public IBOLShipMethodMapper BOLShipMethodMapperMock { get; set; } = new BOLShipMethodMapper();

		public IBOLVendorMapper BOLVendorMapperMock { get; set; } = new BOLVendorMapper();

		public IBOLCreditCardMapper BOLCreditCardMapperMock { get; set; } = new BOLCreditCardMapper();

		public IBOLCurrencyMapper BOLCurrencyMapperMock { get; set; } = new BOLCurrencyMapper();

		public IBOLCurrencyRateMapper BOLCurrencyRateMapperMock { get; set; } = new BOLCurrencyRateMapper();

		public IBOLCustomerMapper BOLCustomerMapperMock { get; set; } = new BOLCustomerMapper();

		public IBOLSalesOrderHeaderMapper BOLSalesOrderHeaderMapperMock { get; set; } = new BOLSalesOrderHeaderMapper();

		public IBOLSalesPersonMapper BOLSalesPersonMapperMock { get; set; } = new BOLSalesPersonMapper();

		public IBOLSalesReasonMapper BOLSalesReasonMapperMock { get; set; } = new BOLSalesReasonMapper();

		public IBOLSalesTaxRateMapper BOLSalesTaxRateMapperMock { get; set; } = new BOLSalesTaxRateMapper();

		public IBOLSalesTerritoryMapper BOLSalesTerritoryMapperMock { get; set; } = new BOLSalesTerritoryMapper();

		public IBOLShoppingCartItemMapper BOLShoppingCartItemMapperMock { get; set; } = new BOLShoppingCartItemMapper();

		public IBOLSpecialOfferMapper BOLSpecialOfferMapperMock { get; set; } = new BOLSpecialOfferMapper();

		public IBOLStoreMapper BOLStoreMapperMock { get; set; } = new BOLStoreMapper();

		public BOLMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>def37854b5e9e7302f8ed27397cbc6e4</Hash>
</Codenesium>*/