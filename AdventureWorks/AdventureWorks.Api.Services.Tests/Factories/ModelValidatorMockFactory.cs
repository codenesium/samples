using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services.Tests
{
        public class ModelValidatorMockFactory
        {
                public Mock<IApiAWBuildVersionRequestModelValidator> AWBuildVersionModelValidatorMock { get; set; } = new Mock<IApiAWBuildVersionRequestModelValidator>();

                public Mock<IApiDatabaseLogRequestModelValidator> DatabaseLogModelValidatorMock { get; set; } = new Mock<IApiDatabaseLogRequestModelValidator>();

                public Mock<IApiErrorLogRequestModelValidator> ErrorLogModelValidatorMock { get; set; } = new Mock<IApiErrorLogRequestModelValidator>();

                public Mock<IApiDepartmentRequestModelValidator> DepartmentModelValidatorMock { get; set; } = new Mock<IApiDepartmentRequestModelValidator>();

                public Mock<IApiEmployeeRequestModelValidator> EmployeeModelValidatorMock { get; set; } = new Mock<IApiEmployeeRequestModelValidator>();

                public Mock<IApiEmployeeDepartmentHistoryRequestModelValidator> EmployeeDepartmentHistoryModelValidatorMock { get; set; } = new Mock<IApiEmployeeDepartmentHistoryRequestModelValidator>();

                public Mock<IApiEmployeePayHistoryRequestModelValidator> EmployeePayHistoryModelValidatorMock { get; set; } = new Mock<IApiEmployeePayHistoryRequestModelValidator>();

                public Mock<IApiJobCandidateRequestModelValidator> JobCandidateModelValidatorMock { get; set; } = new Mock<IApiJobCandidateRequestModelValidator>();

                public Mock<IApiShiftRequestModelValidator> ShiftModelValidatorMock { get; set; } = new Mock<IApiShiftRequestModelValidator>();

                public Mock<IApiAddressRequestModelValidator> AddressModelValidatorMock { get; set; } = new Mock<IApiAddressRequestModelValidator>();

                public Mock<IApiAddressTypeRequestModelValidator> AddressTypeModelValidatorMock { get; set; } = new Mock<IApiAddressTypeRequestModelValidator>();

                public Mock<IApiBusinessEntityRequestModelValidator> BusinessEntityModelValidatorMock { get; set; } = new Mock<IApiBusinessEntityRequestModelValidator>();

                public Mock<IApiBusinessEntityAddressRequestModelValidator> BusinessEntityAddressModelValidatorMock { get; set; } = new Mock<IApiBusinessEntityAddressRequestModelValidator>();

                public Mock<IApiBusinessEntityContactRequestModelValidator> BusinessEntityContactModelValidatorMock { get; set; } = new Mock<IApiBusinessEntityContactRequestModelValidator>();

                public Mock<IApiContactTypeRequestModelValidator> ContactTypeModelValidatorMock { get; set; } = new Mock<IApiContactTypeRequestModelValidator>();

                public Mock<IApiCountryRegionRequestModelValidator> CountryRegionModelValidatorMock { get; set; } = new Mock<IApiCountryRegionRequestModelValidator>();

                public Mock<IApiEmailAddressRequestModelValidator> EmailAddressModelValidatorMock { get; set; } = new Mock<IApiEmailAddressRequestModelValidator>();

                public Mock<IApiPasswordRequestModelValidator> PasswordModelValidatorMock { get; set; } = new Mock<IApiPasswordRequestModelValidator>();

                public Mock<IApiPersonRequestModelValidator> PersonModelValidatorMock { get; set; } = new Mock<IApiPersonRequestModelValidator>();

                public Mock<IApiPersonPhoneRequestModelValidator> PersonPhoneModelValidatorMock { get; set; } = new Mock<IApiPersonPhoneRequestModelValidator>();

                public Mock<IApiPhoneNumberTypeRequestModelValidator> PhoneNumberTypeModelValidatorMock { get; set; } = new Mock<IApiPhoneNumberTypeRequestModelValidator>();

                public Mock<IApiStateProvinceRequestModelValidator> StateProvinceModelValidatorMock { get; set; } = new Mock<IApiStateProvinceRequestModelValidator>();

                public Mock<IApiBillOfMaterialRequestModelValidator> BillOfMaterialModelValidatorMock { get; set; } = new Mock<IApiBillOfMaterialRequestModelValidator>();

                public Mock<IApiCultureRequestModelValidator> CultureModelValidatorMock { get; set; } = new Mock<IApiCultureRequestModelValidator>();

                public Mock<IApiDocumentRequestModelValidator> DocumentModelValidatorMock { get; set; } = new Mock<IApiDocumentRequestModelValidator>();

                public Mock<IApiIllustrationRequestModelValidator> IllustrationModelValidatorMock { get; set; } = new Mock<IApiIllustrationRequestModelValidator>();

                public Mock<IApiLocationRequestModelValidator> LocationModelValidatorMock { get; set; } = new Mock<IApiLocationRequestModelValidator>();

                public Mock<IApiProductRequestModelValidator> ProductModelValidatorMock { get; set; } = new Mock<IApiProductRequestModelValidator>();

                public Mock<IApiProductCategoryRequestModelValidator> ProductCategoryModelValidatorMock { get; set; } = new Mock<IApiProductCategoryRequestModelValidator>();

                public Mock<IApiProductCostHistoryRequestModelValidator> ProductCostHistoryModelValidatorMock { get; set; } = new Mock<IApiProductCostHistoryRequestModelValidator>();

                public Mock<IApiProductDescriptionRequestModelValidator> ProductDescriptionModelValidatorMock { get; set; } = new Mock<IApiProductDescriptionRequestModelValidator>();

                public Mock<IApiProductInventoryRequestModelValidator> ProductInventoryModelValidatorMock { get; set; } = new Mock<IApiProductInventoryRequestModelValidator>();

                public Mock<IApiProductListPriceHistoryRequestModelValidator> ProductListPriceHistoryModelValidatorMock { get; set; } = new Mock<IApiProductListPriceHistoryRequestModelValidator>();

                public Mock<IApiProductModelRequestModelValidator> ProductModelModelValidatorMock { get; set; } = new Mock<IApiProductModelRequestModelValidator>();

                public Mock<IApiProductModelIllustrationRequestModelValidator> ProductModelIllustrationModelValidatorMock { get; set; } = new Mock<IApiProductModelIllustrationRequestModelValidator>();

                public Mock<IApiProductModelProductDescriptionCultureRequestModelValidator> ProductModelProductDescriptionCultureModelValidatorMock { get; set; } = new Mock<IApiProductModelProductDescriptionCultureRequestModelValidator>();

                public Mock<IApiProductPhotoRequestModelValidator> ProductPhotoModelValidatorMock { get; set; } = new Mock<IApiProductPhotoRequestModelValidator>();

                public Mock<IApiProductProductPhotoRequestModelValidator> ProductProductPhotoModelValidatorMock { get; set; } = new Mock<IApiProductProductPhotoRequestModelValidator>();

                public Mock<IApiProductReviewRequestModelValidator> ProductReviewModelValidatorMock { get; set; } = new Mock<IApiProductReviewRequestModelValidator>();

                public Mock<IApiProductSubcategoryRequestModelValidator> ProductSubcategoryModelValidatorMock { get; set; } = new Mock<IApiProductSubcategoryRequestModelValidator>();

                public Mock<IApiScrapReasonRequestModelValidator> ScrapReasonModelValidatorMock { get; set; } = new Mock<IApiScrapReasonRequestModelValidator>();

                public Mock<IApiTransactionHistoryRequestModelValidator> TransactionHistoryModelValidatorMock { get; set; } = new Mock<IApiTransactionHistoryRequestModelValidator>();

                public Mock<IApiTransactionHistoryArchiveRequestModelValidator> TransactionHistoryArchiveModelValidatorMock { get; set; } = new Mock<IApiTransactionHistoryArchiveRequestModelValidator>();

                public Mock<IApiUnitMeasureRequestModelValidator> UnitMeasureModelValidatorMock { get; set; } = new Mock<IApiUnitMeasureRequestModelValidator>();

                public Mock<IApiWorkOrderRequestModelValidator> WorkOrderModelValidatorMock { get; set; } = new Mock<IApiWorkOrderRequestModelValidator>();

                public Mock<IApiWorkOrderRoutingRequestModelValidator> WorkOrderRoutingModelValidatorMock { get; set; } = new Mock<IApiWorkOrderRoutingRequestModelValidator>();

                public Mock<IApiProductVendorRequestModelValidator> ProductVendorModelValidatorMock { get; set; } = new Mock<IApiProductVendorRequestModelValidator>();

                public Mock<IApiPurchaseOrderDetailRequestModelValidator> PurchaseOrderDetailModelValidatorMock { get; set; } = new Mock<IApiPurchaseOrderDetailRequestModelValidator>();

                public Mock<IApiPurchaseOrderHeaderRequestModelValidator> PurchaseOrderHeaderModelValidatorMock { get; set; } = new Mock<IApiPurchaseOrderHeaderRequestModelValidator>();

                public Mock<IApiShipMethodRequestModelValidator> ShipMethodModelValidatorMock { get; set; } = new Mock<IApiShipMethodRequestModelValidator>();

                public Mock<IApiVendorRequestModelValidator> VendorModelValidatorMock { get; set; } = new Mock<IApiVendorRequestModelValidator>();

                public Mock<IApiCountryRegionCurrencyRequestModelValidator> CountryRegionCurrencyModelValidatorMock { get; set; } = new Mock<IApiCountryRegionCurrencyRequestModelValidator>();

                public Mock<IApiCreditCardRequestModelValidator> CreditCardModelValidatorMock { get; set; } = new Mock<IApiCreditCardRequestModelValidator>();

                public Mock<IApiCurrencyRequestModelValidator> CurrencyModelValidatorMock { get; set; } = new Mock<IApiCurrencyRequestModelValidator>();

                public Mock<IApiCurrencyRateRequestModelValidator> CurrencyRateModelValidatorMock { get; set; } = new Mock<IApiCurrencyRateRequestModelValidator>();

                public Mock<IApiCustomerRequestModelValidator> CustomerModelValidatorMock { get; set; } = new Mock<IApiCustomerRequestModelValidator>();

                public Mock<IApiPersonCreditCardRequestModelValidator> PersonCreditCardModelValidatorMock { get; set; } = new Mock<IApiPersonCreditCardRequestModelValidator>();

                public Mock<IApiSalesOrderDetailRequestModelValidator> SalesOrderDetailModelValidatorMock { get; set; } = new Mock<IApiSalesOrderDetailRequestModelValidator>();

                public Mock<IApiSalesOrderHeaderRequestModelValidator> SalesOrderHeaderModelValidatorMock { get; set; } = new Mock<IApiSalesOrderHeaderRequestModelValidator>();

                public Mock<IApiSalesOrderHeaderSalesReasonRequestModelValidator> SalesOrderHeaderSalesReasonModelValidatorMock { get; set; } = new Mock<IApiSalesOrderHeaderSalesReasonRequestModelValidator>();

                public Mock<IApiSalesPersonRequestModelValidator> SalesPersonModelValidatorMock { get; set; } = new Mock<IApiSalesPersonRequestModelValidator>();

                public Mock<IApiSalesPersonQuotaHistoryRequestModelValidator> SalesPersonQuotaHistoryModelValidatorMock { get; set; } = new Mock<IApiSalesPersonQuotaHistoryRequestModelValidator>();

                public Mock<IApiSalesReasonRequestModelValidator> SalesReasonModelValidatorMock { get; set; } = new Mock<IApiSalesReasonRequestModelValidator>();

                public Mock<IApiSalesTaxRateRequestModelValidator> SalesTaxRateModelValidatorMock { get; set; } = new Mock<IApiSalesTaxRateRequestModelValidator>();

                public Mock<IApiSalesTerritoryRequestModelValidator> SalesTerritoryModelValidatorMock { get; set; } = new Mock<IApiSalesTerritoryRequestModelValidator>();

                public Mock<IApiSalesTerritoryHistoryRequestModelValidator> SalesTerritoryHistoryModelValidatorMock { get; set; } = new Mock<IApiSalesTerritoryHistoryRequestModelValidator>();

                public Mock<IApiShoppingCartItemRequestModelValidator> ShoppingCartItemModelValidatorMock { get; set; } = new Mock<IApiShoppingCartItemRequestModelValidator>();

                public Mock<IApiSpecialOfferRequestModelValidator> SpecialOfferModelValidatorMock { get; set; } = new Mock<IApiSpecialOfferRequestModelValidator>();

                public Mock<IApiSpecialOfferProductRequestModelValidator> SpecialOfferProductModelValidatorMock { get; set; } = new Mock<IApiSpecialOfferProductRequestModelValidator>();

                public Mock<IApiStoreRequestModelValidator> StoreModelValidatorMock { get; set; } = new Mock<IApiStoreRequestModelValidator>();

                public ModelValidatorMockFactory()
                {
                        this.AWBuildVersionModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiAWBuildVersionRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.AWBuildVersionModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAWBuildVersionRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.AWBuildVersionModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.DatabaseLogModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDatabaseLogRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.DatabaseLogModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDatabaseLogRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.DatabaseLogModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.ErrorLogModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiErrorLogRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ErrorLogModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiErrorLogRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ErrorLogModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.DepartmentModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDepartmentRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.DepartmentModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<short>(), It.IsAny<ApiDepartmentRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.DepartmentModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<short>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.EmployeeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiEmployeeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.EmployeeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEmployeeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.EmployeeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.EmployeeDepartmentHistoryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiEmployeeDepartmentHistoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.EmployeeDepartmentHistoryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEmployeeDepartmentHistoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.EmployeeDepartmentHistoryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.EmployeePayHistoryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiEmployeePayHistoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.EmployeePayHistoryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEmployeePayHistoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.EmployeePayHistoryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.JobCandidateModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiJobCandidateRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.JobCandidateModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiJobCandidateRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.JobCandidateModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.ShiftModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiShiftRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ShiftModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiShiftRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ShiftModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.AddressModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiAddressRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.AddressModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAddressRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.AddressModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.AddressTypeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiAddressTypeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.AddressTypeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAddressTypeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.AddressTypeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.BusinessEntityModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiBusinessEntityRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.BusinessEntityModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBusinessEntityRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.BusinessEntityModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.BusinessEntityAddressModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiBusinessEntityAddressRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.BusinessEntityAddressModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBusinessEntityAddressRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.BusinessEntityAddressModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.BusinessEntityContactModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiBusinessEntityContactRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.BusinessEntityContactModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBusinessEntityContactRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.BusinessEntityContactModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.ContactTypeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiContactTypeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ContactTypeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiContactTypeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ContactTypeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.CountryRegionModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCountryRegionRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.CountryRegionModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiCountryRegionRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.CountryRegionModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.EmailAddressModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiEmailAddressRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.EmailAddressModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEmailAddressRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.EmailAddressModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.PasswordModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPasswordRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PasswordModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPasswordRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PasswordModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.PersonModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPersonRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PersonModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PersonModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.PersonPhoneModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPersonPhoneRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PersonPhoneModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonPhoneRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PersonPhoneModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.PhoneNumberTypeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPhoneNumberTypeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PhoneNumberTypeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPhoneNumberTypeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PhoneNumberTypeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.StateProvinceModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiStateProvinceRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.StateProvinceModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStateProvinceRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.StateProvinceModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.BillOfMaterialModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiBillOfMaterialRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.BillOfMaterialModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBillOfMaterialRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.BillOfMaterialModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.CultureModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCultureRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.CultureModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiCultureRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.CultureModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.DocumentModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDocumentRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.DocumentModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<Guid>(), It.IsAny<ApiDocumentRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.DocumentModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<Guid>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.IllustrationModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiIllustrationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.IllustrationModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiIllustrationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.IllustrationModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.LocationModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLocationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.LocationModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<short>(), It.IsAny<ApiLocationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.LocationModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<short>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.ProductModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.ProductCategoryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductCategoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductCategoryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductCategoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductCategoryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.ProductCostHistoryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductCostHistoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductCostHistoryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductCostHistoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductCostHistoryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.ProductDescriptionModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductDescriptionRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductDescriptionModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductDescriptionRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductDescriptionModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.ProductInventoryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductInventoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductInventoryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductInventoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductInventoryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.ProductListPriceHistoryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductListPriceHistoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductListPriceHistoryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductListPriceHistoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductListPriceHistoryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.ProductModelModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductModelRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductModelModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductModelRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductModelModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.ProductModelIllustrationModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductModelIllustrationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductModelIllustrationModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductModelIllustrationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductModelIllustrationModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.ProductModelProductDescriptionCultureModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductModelProductDescriptionCultureRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductModelProductDescriptionCultureModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductModelProductDescriptionCultureRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductModelProductDescriptionCultureModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.ProductPhotoModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductPhotoRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductPhotoModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductPhotoRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductPhotoModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.ProductProductPhotoModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductProductPhotoRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductProductPhotoModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductProductPhotoRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductProductPhotoModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.ProductReviewModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductReviewRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductReviewModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductReviewRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductReviewModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.ProductSubcategoryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductSubcategoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductSubcategoryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductSubcategoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductSubcategoryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.ScrapReasonModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiScrapReasonRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ScrapReasonModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<short>(), It.IsAny<ApiScrapReasonRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ScrapReasonModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<short>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.TransactionHistoryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionHistoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.TransactionHistoryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.TransactionHistoryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.TransactionHistoryArchiveModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionHistoryArchiveRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.TransactionHistoryArchiveModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryArchiveRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.TransactionHistoryArchiveModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.UnitMeasureModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiUnitMeasureRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.UnitMeasureModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiUnitMeasureRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.UnitMeasureModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.WorkOrderModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiWorkOrderRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.WorkOrderModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiWorkOrderRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.WorkOrderModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.WorkOrderRoutingModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiWorkOrderRoutingRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.WorkOrderRoutingModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiWorkOrderRoutingRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.WorkOrderRoutingModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.ProductVendorModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductVendorRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductVendorModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductVendorRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ProductVendorModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.PurchaseOrderDetailModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPurchaseOrderDetailRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PurchaseOrderDetailModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderDetailRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PurchaseOrderDetailModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.PurchaseOrderHeaderModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPurchaseOrderHeaderRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PurchaseOrderHeaderModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderHeaderRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PurchaseOrderHeaderModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.ShipMethodModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiShipMethodRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ShipMethodModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiShipMethodRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ShipMethodModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.VendorModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVendorRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.VendorModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVendorRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.VendorModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.CountryRegionCurrencyModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCountryRegionCurrencyRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.CountryRegionCurrencyModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiCountryRegionCurrencyRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.CountryRegionCurrencyModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.CreditCardModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCreditCardRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.CreditCardModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCreditCardRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.CreditCardModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.CurrencyModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCurrencyRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.CurrencyModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiCurrencyRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.CurrencyModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.CurrencyRateModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCurrencyRateRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.CurrencyRateModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCurrencyRateRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.CurrencyRateModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.CustomerModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCustomerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.CustomerModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCustomerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.CustomerModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.PersonCreditCardModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPersonCreditCardRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PersonCreditCardModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonCreditCardRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PersonCreditCardModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.SalesOrderDetailModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSalesOrderDetailRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SalesOrderDetailModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesOrderDetailRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SalesOrderDetailModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.SalesOrderHeaderModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSalesOrderHeaderRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SalesOrderHeaderModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SalesOrderHeaderModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.SalesOrderHeaderSalesReasonModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSalesOrderHeaderSalesReasonRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SalesOrderHeaderSalesReasonModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderSalesReasonRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SalesOrderHeaderSalesReasonModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.SalesPersonModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSalesPersonRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SalesPersonModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesPersonRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SalesPersonModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.SalesPersonQuotaHistoryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSalesPersonQuotaHistoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SalesPersonQuotaHistoryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesPersonQuotaHistoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SalesPersonQuotaHistoryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.SalesReasonModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSalesReasonRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SalesReasonModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesReasonRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SalesReasonModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.SalesTaxRateModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSalesTaxRateRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SalesTaxRateModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesTaxRateRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SalesTaxRateModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.SalesTerritoryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSalesTerritoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SalesTerritoryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesTerritoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SalesTerritoryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.SalesTerritoryHistoryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSalesTerritoryHistoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SalesTerritoryHistoryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesTerritoryHistoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SalesTerritoryHistoryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.ShoppingCartItemModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiShoppingCartItemRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ShoppingCartItemModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiShoppingCartItemRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.ShoppingCartItemModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.SpecialOfferModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSpecialOfferRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SpecialOfferModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpecialOfferRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SpecialOfferModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.SpecialOfferProductModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSpecialOfferProductRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SpecialOfferProductModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpecialOfferProductRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SpecialOfferProductModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.StoreModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiStoreRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.StoreModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStoreRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.StoreModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                }
        }
}

/*<Codenesium>
    <Hash>77d564790617c2e1be8bb37c488b7966</Hash>
</Codenesium>*/