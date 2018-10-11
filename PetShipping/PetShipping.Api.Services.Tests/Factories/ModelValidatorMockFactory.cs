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
		public Mock<IApiAirlineRequestModelValidator> AirlineModelValidatorMock { get; set; } = new Mock<IApiAirlineRequestModelValidator>();

		public Mock<IApiAirTransportRequestModelValidator> AirTransportModelValidatorMock { get; set; } = new Mock<IApiAirTransportRequestModelValidator>();

		public Mock<IApiBreedRequestModelValidator> BreedModelValidatorMock { get; set; } = new Mock<IApiBreedRequestModelValidator>();

		public Mock<IApiClientRequestModelValidator> ClientModelValidatorMock { get; set; } = new Mock<IApiClientRequestModelValidator>();

		public Mock<IApiClientCommunicationRequestModelValidator> ClientCommunicationModelValidatorMock { get; set; } = new Mock<IApiClientCommunicationRequestModelValidator>();

		public Mock<IApiCountryRequestModelValidator> CountryModelValidatorMock { get; set; } = new Mock<IApiCountryRequestModelValidator>();

		public Mock<IApiCountryRequirementRequestModelValidator> CountryRequirementModelValidatorMock { get; set; } = new Mock<IApiCountryRequirementRequestModelValidator>();

		public Mock<IApiDestinationRequestModelValidator> DestinationModelValidatorMock { get; set; } = new Mock<IApiDestinationRequestModelValidator>();

		public Mock<IApiEmployeeRequestModelValidator> EmployeeModelValidatorMock { get; set; } = new Mock<IApiEmployeeRequestModelValidator>();

		public Mock<IApiHandlerRequestModelValidator> HandlerModelValidatorMock { get; set; } = new Mock<IApiHandlerRequestModelValidator>();

		public Mock<IApiPetRequestModelValidator> PetModelValidatorMock { get; set; } = new Mock<IApiPetRequestModelValidator>();

		public Mock<IApiPipelineRequestModelValidator> PipelineModelValidatorMock { get; set; } = new Mock<IApiPipelineRequestModelValidator>();

		public Mock<IApiPipelineStatuRequestModelValidator> PipelineStatuModelValidatorMock { get; set; } = new Mock<IApiPipelineStatuRequestModelValidator>();

		public Mock<IApiPipelineStepRequestModelValidator> PipelineStepModelValidatorMock { get; set; } = new Mock<IApiPipelineStepRequestModelValidator>();

		public Mock<IApiPipelineStepNoteRequestModelValidator> PipelineStepNoteModelValidatorMock { get; set; } = new Mock<IApiPipelineStepNoteRequestModelValidator>();

		public Mock<IApiPipelineStepStatuRequestModelValidator> PipelineStepStatuModelValidatorMock { get; set; } = new Mock<IApiPipelineStepStatuRequestModelValidator>();

		public Mock<IApiPipelineStepStepRequirementRequestModelValidator> PipelineStepStepRequirementModelValidatorMock { get; set; } = new Mock<IApiPipelineStepStepRequirementRequestModelValidator>();

		public Mock<IApiSaleRequestModelValidator> SaleModelValidatorMock { get; set; } = new Mock<IApiSaleRequestModelValidator>();

		public Mock<IApiSpeciesRequestModelValidator> SpeciesModelValidatorMock { get; set; } = new Mock<IApiSpeciesRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.AirlineModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiAirlineRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AirlineModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAirlineRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AirlineModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.AirTransportModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiAirTransportRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AirTransportModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAirTransportRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AirTransportModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.BreedModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiBreedRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.BreedModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBreedRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.BreedModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ClientModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiClientRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ClientModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiClientRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ClientModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ClientCommunicationModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiClientCommunicationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ClientCommunicationModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiClientCommunicationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ClientCommunicationModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CountryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCountryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CountryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCountryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CountryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CountryRequirementModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCountryRequirementRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CountryRequirementModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCountryRequirementRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CountryRequirementModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.DestinationModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDestinationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DestinationModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDestinationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DestinationModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.EmployeeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiEmployeeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EmployeeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEmployeeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EmployeeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.HandlerModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiHandlerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.HandlerModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiHandlerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.HandlerModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PetModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPetRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PetModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPetRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PetModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PipelineModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PipelineStatuModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStatuRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineStatuModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStatuRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineStatuModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PipelineStepModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineStepModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineStepModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PipelineStepNoteModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepNoteRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineStepNoteModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepNoteRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineStepNoteModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PipelineStepStatuModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepStatuRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineStepStatuModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepStatuRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineStepStatuModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PipelineStepStepRequirementModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepStepRequirementRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineStepStepRequirementModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepStepRequirementRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PipelineStepStepRequirementModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

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
    <Hash>908b21e44c5cf40df7af38b17e594462</Hash>
</Codenesium>*/