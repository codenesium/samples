using Moq;
using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Services.Tests
{
	public class ModelValidatorMockFactory
	{
		public Mock<IApiCustomerServerRequestModelValidator> CustomerModelValidatorMock { get; set; } = new Mock<IApiCustomerServerRequestModelValidator>();

		public Mock<IApiProductServerRequestModelValidator> ProductModelValidatorMock { get; set; } = new Mock<IApiProductServerRequestModelValidator>();

		public Mock<IApiSaleServerRequestModelValidator> SaleModelValidatorMock { get; set; } = new Mock<IApiSaleServerRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.CustomerModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCustomerServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CustomerModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCustomerServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CustomerModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ProductModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProductModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProductModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SaleModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSaleServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SaleModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSaleServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SaleModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
		}
	}
}

/*<Codenesium>
    <Hash>16aa5bf02c7de99b60cb081b777dfa13</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/