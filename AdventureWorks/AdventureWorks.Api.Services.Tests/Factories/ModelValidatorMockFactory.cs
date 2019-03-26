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
		public Mock<IApiAWBuildVersionServerRequestModelValidator> AWBuildVersionModelValidatorMock { get; set; } = new Mock<IApiAWBuildVersionServerRequestModelValidator>();

		public Mock<IApiDatabaseLogServerRequestModelValidator> DatabaseLogModelValidatorMock { get; set; } = new Mock<IApiDatabaseLogServerRequestModelValidator>();

		public Mock<IApiErrorLogServerRequestModelValidator> ErrorLogModelValidatorMock { get; set; } = new Mock<IApiErrorLogServerRequestModelValidator>();

		public Mock<IApiDepartmentServerRequestModelValidator> DepartmentModelValidatorMock { get; set; } = new Mock<IApiDepartmentServerRequestModelValidator>();

		public Mock<IApiEmployeeServerRequestModelValidator> EmployeeModelValidatorMock { get; set; } = new Mock<IApiEmployeeServerRequestModelValidator>();

		public Mock<IApiJobCandidateServerRequestModelValidator> JobCandidateModelValidatorMock { get; set; } = new Mock<IApiJobCandidateServerRequestModelValidator>();

		public Mock<IApiShiftServerRequestModelValidator> ShiftModelValidatorMock { get; set; } = new Mock<IApiShiftServerRequestModelValidator>();

		public Mock<IApiAddressServerRequestModelValidator> AddressModelValidatorMock { get; set; } = new Mock<IApiAddressServerRequestModelValidator>();

		public Mock<IApiAddressTypeServerRequestModelValidator> AddressTypeModelValidatorMock { get; set; } = new Mock<IApiAddressTypeServerRequestModelValidator>();

		public Mock<IApiBusinessEntityServerRequestModelValidator> BusinessEntityModelValidatorMock { get; set; } = new Mock<IApiBusinessEntityServerRequestModelValidator>();

		public Mock<IApiContactTypeServerRequestModelValidator> ContactTypeModelValidatorMock { get; set; } = new Mock<IApiContactTypeServerRequestModelValidator>();

		public Mock<IApiCountryRegionServerRequestModelValidator> CountryRegionModelValidatorMock { get; set; } = new Mock<IApiCountryRegionServerRequestModelValidator>();

		public Mock<IApiPasswordServerRequestModelValidator> PasswordModelValidatorMock { get; set; } = new Mock<IApiPasswordServerRequestModelValidator>();

		public Mock<IApiPersonServerRequestModelValidator> PersonModelValidatorMock { get; set; } = new Mock<IApiPersonServerRequestModelValidator>();

		public Mock<IApiPhoneNumberTypeServerRequestModelValidator> PhoneNumberTypeModelValidatorMock { get; set; } = new Mock<IApiPhoneNumberTypeServerRequestModelValidator>();

		public Mock<IApiStateProvinceServerRequestModelValidator> StateProvinceModelValidatorMock { get; set; } = new Mock<IApiStateProvinceServerRequestModelValidator>();

		public Mock<IApiBillOfMaterialServerRequestModelValidator> BillOfMaterialModelValidatorMock { get; set; } = new Mock<IApiBillOfMaterialServerRequestModelValidator>();

		public Mock<IApiCultureServerRequestModelValidator> CultureModelValidatorMock { get; set; } = new Mock<IApiCultureServerRequestModelValidator>();

		public Mock<IApiDocumentServerRequestModelValidator> DocumentModelValidatorMock { get; set; } = new Mock<IApiDocumentServerRequestModelValidator>();

		public Mock<IApiIllustrationServerRequestModelValidator> IllustrationModelValidatorMock { get; set; } = new Mock<IApiIllustrationServerRequestModelValidator>();

		public Mock<IApiLocationServerRequestModelValidator> LocationModelValidatorMock { get; set; } = new Mock<IApiLocationServerRequestModelValidator>();

		public Mock<IApiProductServerRequestModelValidator> ProductModelValidatorMock { get; set; } = new Mock<IApiProductServerRequestModelValidator>();

		public Mock<IApiProductCategoryServerRequestModelValidator> ProductCategoryModelValidatorMock { get; set; } = new Mock<IApiProductCategoryServerRequestModelValidator>();

		public Mock<IApiProductDescriptionServerRequestModelValidator> ProductDescriptionModelValidatorMock { get; set; } = new Mock<IApiProductDescriptionServerRequestModelValidator>();

		public Mock<IApiProductModelServerRequestModelValidator> ProductModelModelValidatorMock { get; set; } = new Mock<IApiProductModelServerRequestModelValidator>();

		public Mock<IApiProductPhotoServerRequestModelValidator> ProductPhotoModelValidatorMock { get; set; } = new Mock<IApiProductPhotoServerRequestModelValidator>();

		public Mock<IApiProductProductPhotoServerRequestModelValidator> ProductProductPhotoModelValidatorMock { get; set; } = new Mock<IApiProductProductPhotoServerRequestModelValidator>();

		public Mock<IApiProductReviewServerRequestModelValidator> ProductReviewModelValidatorMock { get; set; } = new Mock<IApiProductReviewServerRequestModelValidator>();

		public Mock<IApiProductSubcategoryServerRequestModelValidator> ProductSubcategoryModelValidatorMock { get; set; } = new Mock<IApiProductSubcategoryServerRequestModelValidator>();

		public Mock<IApiScrapReasonServerRequestModelValidator> ScrapReasonModelValidatorMock { get; set; } = new Mock<IApiScrapReasonServerRequestModelValidator>();

		public Mock<IApiTransactionHistoryServerRequestModelValidator> TransactionHistoryModelValidatorMock { get; set; } = new Mock<IApiTransactionHistoryServerRequestModelValidator>();

		public Mock<IApiTransactionHistoryArchiveServerRequestModelValidator> TransactionHistoryArchiveModelValidatorMock { get; set; } = new Mock<IApiTransactionHistoryArchiveServerRequestModelValidator>();

		public Mock<IApiUnitMeasureServerRequestModelValidator> UnitMeasureModelValidatorMock { get; set; } = new Mock<IApiUnitMeasureServerRequestModelValidator>();

		public Mock<IApiWorkOrderServerRequestModelValidator> WorkOrderModelValidatorMock { get; set; } = new Mock<IApiWorkOrderServerRequestModelValidator>();

		public Mock<IApiPurchaseOrderHeaderServerRequestModelValidator> PurchaseOrderHeaderModelValidatorMock { get; set; } = new Mock<IApiPurchaseOrderHeaderServerRequestModelValidator>();

		public Mock<IApiShipMethodServerRequestModelValidator> ShipMethodModelValidatorMock { get; set; } = new Mock<IApiShipMethodServerRequestModelValidator>();

		public Mock<IApiVendorServerRequestModelValidator> VendorModelValidatorMock { get; set; } = new Mock<IApiVendorServerRequestModelValidator>();

		public Mock<IApiCreditCardServerRequestModelValidator> CreditCardModelValidatorMock { get; set; } = new Mock<IApiCreditCardServerRequestModelValidator>();

		public Mock<IApiCurrencyServerRequestModelValidator> CurrencyModelValidatorMock { get; set; } = new Mock<IApiCurrencyServerRequestModelValidator>();

		public Mock<IApiCurrencyRateServerRequestModelValidator> CurrencyRateModelValidatorMock { get; set; } = new Mock<IApiCurrencyRateServerRequestModelValidator>();

		public Mock<IApiCustomerServerRequestModelValidator> CustomerModelValidatorMock { get; set; } = new Mock<IApiCustomerServerRequestModelValidator>();

		public Mock<IApiSalesOrderHeaderServerRequestModelValidator> SalesOrderHeaderModelValidatorMock { get; set; } = new Mock<IApiSalesOrderHeaderServerRequestModelValidator>();

		public Mock<IApiSalesPersonServerRequestModelValidator> SalesPersonModelValidatorMock { get; set; } = new Mock<IApiSalesPersonServerRequestModelValidator>();

		public Mock<IApiSalesReasonServerRequestModelValidator> SalesReasonModelValidatorMock { get; set; } = new Mock<IApiSalesReasonServerRequestModelValidator>();

		public Mock<IApiSalesTaxRateServerRequestModelValidator> SalesTaxRateModelValidatorMock { get; set; } = new Mock<IApiSalesTaxRateServerRequestModelValidator>();

		public Mock<IApiSalesTerritoryServerRequestModelValidator> SalesTerritoryModelValidatorMock { get; set; } = new Mock<IApiSalesTerritoryServerRequestModelValidator>();

		public Mock<IApiShoppingCartItemServerRequestModelValidator> ShoppingCartItemModelValidatorMock { get; set; } = new Mock<IApiShoppingCartItemServerRequestModelValidator>();

		public Mock<IApiSpecialOfferServerRequestModelValidator> SpecialOfferModelValidatorMock { get; set; } = new Mock<IApiSpecialOfferServerRequestModelValidator>();

		public Mock<IApiStoreServerRequestModelValidator> StoreModelValidatorMock { get; set; } = new Mock<IApiStoreServerRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.AWBuildVersionModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiAWBuildVersionServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AWBuildVersionModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAWBuildVersionServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AWBuildVersionModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.DatabaseLogModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDatabaseLogServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DatabaseLogModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDatabaseLogServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DatabaseLogModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ErrorLogModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiErrorLogServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ErrorLogModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiErrorLogServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ErrorLogModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.DepartmentModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDepartmentServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DepartmentModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<short>(), It.IsAny<ApiDepartmentServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DepartmentModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<short>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.EmployeeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiEmployeeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EmployeeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEmployeeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EmployeeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.JobCandidateModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiJobCandidateServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.JobCandidateModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiJobCandidateServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.JobCandidateModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ShiftModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiShiftServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ShiftModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiShiftServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ShiftModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.AddressModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiAddressServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AddressModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAddressServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AddressModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.AddressTypeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiAddressTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AddressTypeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAddressTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AddressTypeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.BusinessEntityModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiBusinessEntityServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.BusinessEntityModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBusinessEntityServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.BusinessEntityModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ContactTypeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiContactTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ContactTypeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiContactTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ContactTypeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CountryRegionModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCountryRegionServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CountryRegionModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiCountryRegionServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CountryRegionModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PasswordModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPasswordServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PasswordModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPasswordServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PasswordModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PersonModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPersonServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PersonModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PersonModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PhoneNumberTypeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPhoneNumberTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PhoneNumberTypeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPhoneNumberTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PhoneNumberTypeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.StateProvinceModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiStateProvinceServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.StateProvinceModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStateProvinceServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.StateProvinceModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.BillOfMaterialModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiBillOfMaterialServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.BillOfMaterialModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBillOfMaterialServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.BillOfMaterialModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CultureModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCultureServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CultureModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiCultureServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CultureModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.DocumentModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDocumentServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DocumentModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<Guid>(), It.IsAny<ApiDocumentServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DocumentModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<Guid>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.IllustrationModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiIllustrationServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.IllustrationModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiIllustrationServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.IllustrationModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.LocationModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLocationServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LocationModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<short>(), It.IsAny<ApiLocationServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LocationModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<short>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ProductModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProductModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProductModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ProductCategoryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductCategoryServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProductCategoryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductCategoryServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProductCategoryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ProductDescriptionModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductDescriptionServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProductDescriptionModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductDescriptionServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProductDescriptionModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ProductModelModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductModelServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProductModelModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductModelServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProductModelModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ProductPhotoModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductPhotoServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProductPhotoModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductPhotoServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProductPhotoModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ProductProductPhotoModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductProductPhotoServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProductProductPhotoModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductProductPhotoServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProductProductPhotoModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ProductReviewModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductReviewServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProductReviewModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductReviewServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProductReviewModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ProductSubcategoryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductSubcategoryServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProductSubcategoryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductSubcategoryServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProductSubcategoryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ScrapReasonModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiScrapReasonServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ScrapReasonModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<short>(), It.IsAny<ApiScrapReasonServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ScrapReasonModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<short>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TransactionHistoryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionHistoryServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TransactionHistoryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TransactionHistoryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TransactionHistoryArchiveModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionHistoryArchiveServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TransactionHistoryArchiveModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryArchiveServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TransactionHistoryArchiveModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.UnitMeasureModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiUnitMeasureServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UnitMeasureModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiUnitMeasureServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UnitMeasureModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.WorkOrderModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiWorkOrderServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.WorkOrderModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiWorkOrderServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.WorkOrderModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PurchaseOrderHeaderModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPurchaseOrderHeaderServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PurchaseOrderHeaderModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderHeaderServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PurchaseOrderHeaderModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ShipMethodModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiShipMethodServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ShipMethodModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiShipMethodServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ShipMethodModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.VendorModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVendorServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VendorModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVendorServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VendorModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CreditCardModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCreditCardServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CreditCardModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCreditCardServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CreditCardModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CurrencyModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCurrencyServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CurrencyModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiCurrencyServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CurrencyModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CurrencyRateModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCurrencyRateServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CurrencyRateModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCurrencyRateServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CurrencyRateModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CustomerModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCustomerServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CustomerModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCustomerServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CustomerModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SalesOrderHeaderModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSalesOrderHeaderServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SalesOrderHeaderModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SalesOrderHeaderModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SalesPersonModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSalesPersonServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SalesPersonModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesPersonServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SalesPersonModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SalesReasonModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSalesReasonServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SalesReasonModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesReasonServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SalesReasonModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SalesTaxRateModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSalesTaxRateServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SalesTaxRateModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesTaxRateServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SalesTaxRateModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SalesTerritoryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSalesTerritoryServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SalesTerritoryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesTerritoryServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SalesTerritoryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ShoppingCartItemModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiShoppingCartItemServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ShoppingCartItemModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiShoppingCartItemServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ShoppingCartItemModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SpecialOfferModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSpecialOfferServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SpecialOfferModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpecialOfferServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SpecialOfferModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.StoreModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiStoreServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.StoreModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStoreServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.StoreModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
		}
	}
}

/*<Codenesium>
    <Hash>c1104db306e900c9d4f30d151e48f21e</Hash>
</Codenesium>*/