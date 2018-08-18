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
		public Mock<IApiBreedRequestModelValidator> BreedModelValidatorMock { get; set; } = new Mock<IApiBreedRequestModelValidator>();

		public Mock<IApiPaymentTypeRequestModelValidator> PaymentTypeModelValidatorMock { get; set; } = new Mock<IApiPaymentTypeRequestModelValidator>();

		public Mock<IApiPenRequestModelValidator> PenModelValidatorMock { get; set; } = new Mock<IApiPenRequestModelValidator>();

		public Mock<IApiPetRequestModelValidator> PetModelValidatorMock { get; set; } = new Mock<IApiPetRequestModelValidator>();

		public Mock<IApiSaleRequestModelValidator> SaleModelValidatorMock { get; set; } = new Mock<IApiSaleRequestModelValidator>();

		public Mock<IApiSpeciesRequestModelValidator> SpeciesModelValidatorMock { get; set; } = new Mock<IApiSpeciesRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.BreedModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiBreedRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.BreedModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBreedRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.BreedModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PaymentTypeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPaymentTypeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PaymentTypeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPaymentTypeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PaymentTypeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PenModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPenRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PenModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPenRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PenModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PetModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPetRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PetModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPetRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PetModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SaleModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSaleRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SaleModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSaleRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SaleModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SpeciesModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSpeciesRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SpeciesModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpeciesRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SpeciesModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
		}
	}
}

/*<Codenesium>
    <Hash>0a52faed9708d42184d85e95b59da957</Hash>
</Codenesium>*/