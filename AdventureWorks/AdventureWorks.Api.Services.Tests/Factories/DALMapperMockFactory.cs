using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using Moq;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services.Tests
{
        public class DALMapperMockFactory
        {
                public IDALAWBuildVersionMapper DALAWBuildVersionMapperMock { get; set; } = new DALAWBuildVersionMapper();

                public IDALDatabaseLogMapper DALDatabaseLogMapperMock { get; set; } = new DALDatabaseLogMapper();

                public IDALErrorLogMapper DALErrorLogMapperMock { get; set; } = new DALErrorLogMapper();

                public IDALDepartmentMapper DALDepartmentMapperMock { get; set; } = new DALDepartmentMapper();

                public IDALEmployeeMapper DALEmployeeMapperMock { get; set; } = new DALEmployeeMapper();

                public IDALEmployeeDepartmentHistoryMapper DALEmployeeDepartmentHistoryMapperMock { get; set; } = new DALEmployeeDepartmentHistoryMapper();

                public IDALEmployeePayHistoryMapper DALEmployeePayHistoryMapperMock { get; set; } = new DALEmployeePayHistoryMapper();

                public IDALJobCandidateMapper DALJobCandidateMapperMock { get; set; } = new DALJobCandidateMapper();

                public IDALShiftMapper DALShiftMapperMock { get; set; } = new DALShiftMapper();

                public IDALAddressMapper DALAddressMapperMock { get; set; } = new DALAddressMapper();

                public IDALAddressTypeMapper DALAddressTypeMapperMock { get; set; } = new DALAddressTypeMapper();

                public IDALBusinessEntityMapper DALBusinessEntityMapperMock { get; set; } = new DALBusinessEntityMapper();

                public IDALBusinessEntityAddressMapper DALBusinessEntityAddressMapperMock { get; set; } = new DALBusinessEntityAddressMapper();

                public IDALBusinessEntityContactMapper DALBusinessEntityContactMapperMock { get; set; } = new DALBusinessEntityContactMapper();

                public IDALContactTypeMapper DALContactTypeMapperMock { get; set; } = new DALContactTypeMapper();

                public IDALCountryRegionMapper DALCountryRegionMapperMock { get; set; } = new DALCountryRegionMapper();

                public IDALEmailAddressMapper DALEmailAddressMapperMock { get; set; } = new DALEmailAddressMapper();

                public IDALPasswordMapper DALPasswordMapperMock { get; set; } = new DALPasswordMapper();

                public IDALPersonMapper DALPersonMapperMock { get; set; } = new DALPersonMapper();

                public IDALPersonPhoneMapper DALPersonPhoneMapperMock { get; set; } = new DALPersonPhoneMapper();

                public IDALPhoneNumberTypeMapper DALPhoneNumberTypeMapperMock { get; set; } = new DALPhoneNumberTypeMapper();

                public IDALStateProvinceMapper DALStateProvinceMapperMock { get; set; } = new DALStateProvinceMapper();

                public IDALBillOfMaterialMapper DALBillOfMaterialMapperMock { get; set; } = new DALBillOfMaterialMapper();

                public IDALCultureMapper DALCultureMapperMock { get; set; } = new DALCultureMapper();

                public IDALDocumentMapper DALDocumentMapperMock { get; set; } = new DALDocumentMapper();

                public IDALIllustrationMapper DALIllustrationMapperMock { get; set; } = new DALIllustrationMapper();

                public IDALLocationMapper DALLocationMapperMock { get; set; } = new DALLocationMapper();

                public IDALProductMapper DALProductMapperMock { get; set; } = new DALProductMapper();

                public IDALProductCategoryMapper DALProductCategoryMapperMock { get; set; } = new DALProductCategoryMapper();

                public IDALProductCostHistoryMapper DALProductCostHistoryMapperMock { get; set; } = new DALProductCostHistoryMapper();

                public IDALProductDescriptionMapper DALProductDescriptionMapperMock { get; set; } = new DALProductDescriptionMapper();

                public IDALProductInventoryMapper DALProductInventoryMapperMock { get; set; } = new DALProductInventoryMapper();

                public IDALProductListPriceHistoryMapper DALProductListPriceHistoryMapperMock { get; set; } = new DALProductListPriceHistoryMapper();

                public IDALProductModelMapper DALProductModelMapperMock { get; set; } = new DALProductModelMapper();

                public IDALProductModelIllustrationMapper DALProductModelIllustrationMapperMock { get; set; } = new DALProductModelIllustrationMapper();

                public IDALProductModelProductDescriptionCultureMapper DALProductModelProductDescriptionCultureMapperMock { get; set; } = new DALProductModelProductDescriptionCultureMapper();

                public IDALProductPhotoMapper DALProductPhotoMapperMock { get; set; } = new DALProductPhotoMapper();

                public IDALProductProductPhotoMapper DALProductProductPhotoMapperMock { get; set; } = new DALProductProductPhotoMapper();

                public IDALProductReviewMapper DALProductReviewMapperMock { get; set; } = new DALProductReviewMapper();

                public IDALProductSubcategoryMapper DALProductSubcategoryMapperMock { get; set; } = new DALProductSubcategoryMapper();

                public IDALScrapReasonMapper DALScrapReasonMapperMock { get; set; } = new DALScrapReasonMapper();

                public IDALTransactionHistoryMapper DALTransactionHistoryMapperMock { get; set; } = new DALTransactionHistoryMapper();

                public IDALTransactionHistoryArchiveMapper DALTransactionHistoryArchiveMapperMock { get; set; } = new DALTransactionHistoryArchiveMapper();

                public IDALUnitMeasureMapper DALUnitMeasureMapperMock { get; set; } = new DALUnitMeasureMapper();

                public IDALWorkOrderMapper DALWorkOrderMapperMock { get; set; } = new DALWorkOrderMapper();

                public IDALWorkOrderRoutingMapper DALWorkOrderRoutingMapperMock { get; set; } = new DALWorkOrderRoutingMapper();

                public IDALProductVendorMapper DALProductVendorMapperMock { get; set; } = new DALProductVendorMapper();

                public IDALPurchaseOrderDetailMapper DALPurchaseOrderDetailMapperMock { get; set; } = new DALPurchaseOrderDetailMapper();

                public IDALPurchaseOrderHeaderMapper DALPurchaseOrderHeaderMapperMock { get; set; } = new DALPurchaseOrderHeaderMapper();

                public IDALShipMethodMapper DALShipMethodMapperMock { get; set; } = new DALShipMethodMapper();

                public IDALVendorMapper DALVendorMapperMock { get; set; } = new DALVendorMapper();

                public IDALCountryRegionCurrencyMapper DALCountryRegionCurrencyMapperMock { get; set; } = new DALCountryRegionCurrencyMapper();

                public IDALCreditCardMapper DALCreditCardMapperMock { get; set; } = new DALCreditCardMapper();

                public IDALCurrencyMapper DALCurrencyMapperMock { get; set; } = new DALCurrencyMapper();

                public IDALCurrencyRateMapper DALCurrencyRateMapperMock { get; set; } = new DALCurrencyRateMapper();

                public IDALCustomerMapper DALCustomerMapperMock { get; set; } = new DALCustomerMapper();

                public IDALPersonCreditCardMapper DALPersonCreditCardMapperMock { get; set; } = new DALPersonCreditCardMapper();

                public IDALSalesOrderDetailMapper DALSalesOrderDetailMapperMock { get; set; } = new DALSalesOrderDetailMapper();

                public IDALSalesOrderHeaderMapper DALSalesOrderHeaderMapperMock { get; set; } = new DALSalesOrderHeaderMapper();

                public IDALSalesOrderHeaderSalesReasonMapper DALSalesOrderHeaderSalesReasonMapperMock { get; set; } = new DALSalesOrderHeaderSalesReasonMapper();

                public IDALSalesPersonMapper DALSalesPersonMapperMock { get; set; } = new DALSalesPersonMapper();

                public IDALSalesPersonQuotaHistoryMapper DALSalesPersonQuotaHistoryMapperMock { get; set; } = new DALSalesPersonQuotaHistoryMapper();

                public IDALSalesReasonMapper DALSalesReasonMapperMock { get; set; } = new DALSalesReasonMapper();

                public IDALSalesTaxRateMapper DALSalesTaxRateMapperMock { get; set; } = new DALSalesTaxRateMapper();

                public IDALSalesTerritoryMapper DALSalesTerritoryMapperMock { get; set; } = new DALSalesTerritoryMapper();

                public IDALSalesTerritoryHistoryMapper DALSalesTerritoryHistoryMapperMock { get; set; } = new DALSalesTerritoryHistoryMapper();

                public IDALShoppingCartItemMapper DALShoppingCartItemMapperMock { get; set; } = new DALShoppingCartItemMapper();

                public IDALSpecialOfferMapper DALSpecialOfferMapperMock { get; set; } = new DALSpecialOfferMapper();

                public IDALSpecialOfferProductMapper DALSpecialOfferProductMapperMock { get; set; } = new DALSpecialOfferProductMapper();

                public IDALStoreMapper DALStoreMapperMock { get; set; } = new DALStoreMapper();

                public DALMapperMockFactory()
                {
                }
        }
}

/*<Codenesium>
    <Hash>72220fe125f5807626eaef0d51220e79</Hash>
</Codenesium>*/