using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services.Tests
{
	public class ModelValidatorMockFactory
	{
		public Mock<IApiAirlineServerRequestModelValidator> AirlineModelValidatorMock { get; set; } = new Mock<IApiAirlineServerRequestModelValidator>();

		public Mock<IApiAirTransportServerRequestModelValidator> AirTransportModelValidatorMock { get; set; } = new Mock<IApiAirTransportServerRequestModelValidator>();

		public Mock<IApiBreedServerRequestModelValidator> BreedModelValidatorMock { get; set; } = new Mock<IApiBreedServerRequestModelValidator>();

		public Mock<IApiCountryServerRequestModelValidator> CountryModelValidatorMock { get; set; } = new Mock<IApiCountryServerRequestModelValidator>();

		public Mock<IApiCountryRequirementServerRequestModelValidator> CountryRequirementModelValidatorMock { get; set; } = new Mock<IApiCountryRequirementServerRequestModelValidator>();

		public Mock<IApiCustomerServerRequestModelValidator> CustomerModelValidatorMock { get; set; } = new Mock<IApiCustomerServerRequestModelValidator>();

		public Mock<IApiCustomerCommunicationServerRequestModelValidator> CustomerCommunicationModelValidatorMock { get; set; } = new Mock<IApiCustomerCommunicationServerRequestModelValidator>();

		public Mock<IApiDestinationServerRequestModelValidator> DestinationModelValidatorMock { get; set; } = new Mock<IApiDestinationServerRequestModelValidator>();

		public Mock<IApiEmployeeServerRequestModelValidator> EmployeeModelValidatorMock { get; set; } = new Mock<IApiEmployeeServerRequestModelValidator>();

		public Mock<IApiHandlerServerRequestModelValidator> HandlerModelValidatorMock { get; set; } = new Mock<IApiHandlerServerRequestModelValidator>();

		public Mock<IApiHandlerPipelineStepServerRequestModelValidator> HandlerPipelineStepModelValidatorMock { get; set; } = new Mock<IApiHandlerPipelineStepServerRequestModelValidator>();

		public Mock<IApiOtherTransportServerRequestModelValidator> OtherTransportModelValidatorMock { get; set; } = new Mock<IApiOtherTransportServerRequestModelValidator>();

		public Mock<IApiPetServerRequestModelValidator> PetModelValidatorMock { get; set; } = new Mock<IApiPetServerRequestModelValidator>();

		public Mock<IApiPipelineServerRequestModelValidator> PipelineModelValidatorMock { get; set; } = new Mock<IApiPipelineServerRequestModelValidator>();

		public Mock<IApiPipelineStatusServerRequestModelValidator> PipelineStatusModelValidatorMock { get; set; } = new Mock<IApiPipelineStatusServerRequestModelValidator>();

		public Mock<IApiPipelineStepServerRequestModelValidator> PipelineStepModelValidatorMock { get; set; } = new Mock<IApiPipelineStepServerRequestModelValidator>();

		public Mock<IApiPipelineStepDestinationServerRequestModelValidator> PipelineStepDestinationModelValidatorMock { get; set; } = new Mock<IApiPipelineStepDestinationServerRequestModelValidator>();

		public Mock<IApiPipelineStepNoteServerRequestModelValidator> PipelineStepNoteModelValidatorMock { get; set; } = new Mock<IApiPipelineStepNoteServerRequestModelValidator>();

		public Mock<IApiPipelineStepStatusServerRequestModelValidator> PipelineStepStatusModelValidatorMock { get; set; } = new Mock<IApiPipelineStepStatusServerRequestModelValidator>();

		public Mock<IApiPipelineStepStepRequirementServerRequestModelValidator> PipelineStepStepRequirementModelValidatorMock { get; set; } = new Mock<IApiPipelineStepStepRequirementServerRequestModelValidator>();

		public Mock<IApiSaleServerRequestModelValidator> SaleModelValidatorMock { get; set; } = new Mock<IApiSaleServerRequestModelValidator>();

		public Mock<IApiSpeciesServerRequestModelValidator> SpeciesModelValidatorMock { get; set; } = new Mock<IApiSpeciesServerRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.AirlineModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiAirlineServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AirlineModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAirlineServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AirlineModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.AirTransportModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiAirTransportServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AirTransportModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAirTransportServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AirTransportModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.BreedModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiBreedServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.BreedModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBreedServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.BreedModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CountryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCountryServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CountryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCountryServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CountryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CountryRequirementModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCountryRequirementServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CountryRequirementModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCountryRequirementServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CountryRequirementModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CustomerModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCustomerServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CustomerModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCustomerServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CustomerModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CustomerCommunicationModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCustomerCommunicationServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CustomerCommunicationModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCustomerCommunicationServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CustomerCommunicationModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.DestinationModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDestinationServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DestinationModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDestinationServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DestinationModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.EmployeeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiEmployeeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EmployeeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEmployeeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EmployeeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.HandlerModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiHandlerServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.HandlerModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiHandlerServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.HandlerModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.HandlerPipelineStepModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiHandlerPipelineStepServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.HandlerPipelineStepModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiHandlerPipelineStepServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.HandlerPipelineStepModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.OtherTransportModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiOtherTransportServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.OtherTransportModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOtherTransportServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.OtherTransportModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PetModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPetServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PetModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPetServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PetModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PipelineModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PipelineStatusModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStatusServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineStatusModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStatusServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineStatusModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PipelineStepModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineStepModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineStepModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PipelineStepDestinationModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepDestinationServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineStepDestinationModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepDestinationServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineStepDestinationModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PipelineStepNoteModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepNoteServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineStepNoteModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepNoteServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineStepNoteModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PipelineStepStatusModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepStatusServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineStepStatusModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepStatusServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineStepStatusModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PipelineStepStepRequirementModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepStepRequirementServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineStepStepRequirementModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepStepRequirementServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineStepStepRequirementModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

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
    <Hash>51202c1ee0829e22d8424dfae6e088a5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/