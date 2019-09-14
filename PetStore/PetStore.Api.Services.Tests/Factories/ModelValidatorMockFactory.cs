using Moq;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services.Tests
{
	public class ModelValidatorMockFactory
	{
		public Mock<IApiBreedServerRequestModelValidator> BreedModelValidatorMock { get; set; } = new Mock<IApiBreedServerRequestModelValidator>();

		public Mock<IApiPaymentTypeServerRequestModelValidator> PaymentTypeModelValidatorMock { get; set; } = new Mock<IApiPaymentTypeServerRequestModelValidator>();

		public Mock<IApiPenServerRequestModelValidator> PenModelValidatorMock { get; set; } = new Mock<IApiPenServerRequestModelValidator>();

		public Mock<IApiPetServerRequestModelValidator> PetModelValidatorMock { get; set; } = new Mock<IApiPetServerRequestModelValidator>();

		public Mock<IApiSaleServerRequestModelValidator> SaleModelValidatorMock { get; set; } = new Mock<IApiSaleServerRequestModelValidator>();

		public Mock<IApiSpeciesServerRequestModelValidator> SpeciesModelValidatorMock { get; set; } = new Mock<IApiSpeciesServerRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.BreedModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiBreedServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.BreedModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBreedServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.BreedModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PaymentTypeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPaymentTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PaymentTypeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPaymentTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PaymentTypeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PenModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPenServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PenModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPenServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PenModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PetModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPetServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PetModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPetServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PetModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SaleModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSaleServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SaleModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSaleServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SaleModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SpeciesModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSpeciesServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SpeciesModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpeciesServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SpeciesModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
		}
	}
}

/*<Codenesium>
    <Hash>5492dee27c08c3e0861f9f840b25c48f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/