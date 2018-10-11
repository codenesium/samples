using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Services.Tests
{
	public class ModelValidatorMockFactory
	{
		public Mock<IApiAdminRequestModelValidator> AdminModelValidatorMock { get; set; } = new Mock<IApiAdminRequestModelValidator>();

		public Mock<IApiCityRequestModelValidator> CityModelValidatorMock { get; set; } = new Mock<IApiCityRequestModelValidator>();

		public Mock<IApiCountryRequestModelValidator> CountryModelValidatorMock { get; set; } = new Mock<IApiCountryRequestModelValidator>();

		public Mock<IApiCustomerRequestModelValidator> CustomerModelValidatorMock { get; set; } = new Mock<IApiCustomerRequestModelValidator>();

		public Mock<IApiEventRequestModelValidator> EventModelValidatorMock { get; set; } = new Mock<IApiEventRequestModelValidator>();

		public Mock<IApiProvinceRequestModelValidator> ProvinceModelValidatorMock { get; set; } = new Mock<IApiProvinceRequestModelValidator>();

		public Mock<IApiSaleRequestModelValidator> SaleModelValidatorMock { get; set; } = new Mock<IApiSaleRequestModelValidator>();

		public Mock<IApiTicketRequestModelValidator> TicketModelValidatorMock { get; set; } = new Mock<IApiTicketRequestModelValidator>();

		public Mock<IApiTicketStatuRequestModelValidator> TicketStatuModelValidatorMock { get; set; } = new Mock<IApiTicketStatuRequestModelValidator>();

		public Mock<IApiTransactionRequestModelValidator> TransactionModelValidatorMock { get; set; } = new Mock<IApiTransactionRequestModelValidator>();

		public Mock<IApiTransactionStatuRequestModelValidator> TransactionStatuModelValidatorMock { get; set; } = new Mock<IApiTransactionStatuRequestModelValidator>();

		public Mock<IApiVenueRequestModelValidator> VenueModelValidatorMock { get; set; } = new Mock<IApiVenueRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.AdminModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiAdminRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AdminModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAdminRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AdminModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CityModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCityRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CityModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCityRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CityModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CountryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCountryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CountryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCountryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CountryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CustomerModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCustomerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CustomerModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCustomerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CustomerModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.EventModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiEventRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EventModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEventRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EventModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ProvinceModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProvinceRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProvinceModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProvinceRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProvinceModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SaleModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSaleRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SaleModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSaleRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SaleModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TicketModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTicketRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TicketModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTicketRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TicketModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TicketStatuModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTicketStatuRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TicketStatuModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTicketStatuRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TicketStatuModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TransactionModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TransactionModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TransactionModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TransactionStatuModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionStatuRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TransactionStatuModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionStatuRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TransactionStatuModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.VenueModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVenueRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VenueModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVenueRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VenueModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
		}
	}
}

/*<Codenesium>
    <Hash>923233e8194f6ee1853de34b4138d528</Hash>
</Codenesium>*/