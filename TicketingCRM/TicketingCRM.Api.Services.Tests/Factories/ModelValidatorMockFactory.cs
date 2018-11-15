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
		public Mock<IApiAdminServerRequestModelValidator> AdminModelValidatorMock { get; set; } = new Mock<IApiAdminServerRequestModelValidator>();

		public Mock<IApiCityServerRequestModelValidator> CityModelValidatorMock { get; set; } = new Mock<IApiCityServerRequestModelValidator>();

		public Mock<IApiCountryServerRequestModelValidator> CountryModelValidatorMock { get; set; } = new Mock<IApiCountryServerRequestModelValidator>();

		public Mock<IApiCustomerServerRequestModelValidator> CustomerModelValidatorMock { get; set; } = new Mock<IApiCustomerServerRequestModelValidator>();

		public Mock<IApiEventServerRequestModelValidator> EventModelValidatorMock { get; set; } = new Mock<IApiEventServerRequestModelValidator>();

		public Mock<IApiProvinceServerRequestModelValidator> ProvinceModelValidatorMock { get; set; } = new Mock<IApiProvinceServerRequestModelValidator>();

		public Mock<IApiSaleServerRequestModelValidator> SaleModelValidatorMock { get; set; } = new Mock<IApiSaleServerRequestModelValidator>();

		public Mock<IApiTicketServerRequestModelValidator> TicketModelValidatorMock { get; set; } = new Mock<IApiTicketServerRequestModelValidator>();

		public Mock<IApiTicketStatuServerRequestModelValidator> TicketStatuModelValidatorMock { get; set; } = new Mock<IApiTicketStatuServerRequestModelValidator>();

		public Mock<IApiTransactionServerRequestModelValidator> TransactionModelValidatorMock { get; set; } = new Mock<IApiTransactionServerRequestModelValidator>();

		public Mock<IApiTransactionStatuServerRequestModelValidator> TransactionStatuModelValidatorMock { get; set; } = new Mock<IApiTransactionStatuServerRequestModelValidator>();

		public Mock<IApiVenueServerRequestModelValidator> VenueModelValidatorMock { get; set; } = new Mock<IApiVenueServerRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.AdminModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiAdminServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AdminModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAdminServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AdminModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CityModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCityServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CityModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCityServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CityModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CountryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCountryServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CountryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCountryServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CountryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CustomerModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCustomerServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CustomerModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCustomerServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CustomerModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.EventModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiEventServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EventModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEventServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EventModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ProvinceModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProvinceServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProvinceModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProvinceServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProvinceModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SaleModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSaleServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SaleModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSaleServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SaleModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TicketModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTicketServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TicketModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTicketServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TicketModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TicketStatuModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTicketStatuServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TicketStatuModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTicketStatuServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TicketStatuModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TransactionModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TransactionModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TransactionModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TransactionStatuModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionStatuServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TransactionStatuModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionStatuServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TransactionStatuModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.VenueModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVenueServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VenueModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVenueServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VenueModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
		}
	}
}

/*<Codenesium>
    <Hash>c0a49adc9fe2cf995e8fda2cf6f1d8b5</Hash>
</Codenesium>*/