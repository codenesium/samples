using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;

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

                public Mock<IApiHandlerPipelineStepRequestModelValidator> HandlerPipelineStepModelValidatorMock { get; set; } = new Mock<IApiHandlerPipelineStepRequestModelValidator>();

                public Mock<IApiOtherTransportRequestModelValidator> OtherTransportModelValidatorMock { get; set; } = new Mock<IApiOtherTransportRequestModelValidator>();

                public Mock<IApiPetRequestModelValidator> PetModelValidatorMock { get; set; } = new Mock<IApiPetRequestModelValidator>();

                public Mock<IApiPipelineRequestModelValidator> PipelineModelValidatorMock { get; set; } = new Mock<IApiPipelineRequestModelValidator>();

                public Mock<IApiPipelineStatusRequestModelValidator> PipelineStatusModelValidatorMock { get; set; } = new Mock<IApiPipelineStatusRequestModelValidator>();

                public Mock<IApiPipelineStepRequestModelValidator> PipelineStepModelValidatorMock { get; set; } = new Mock<IApiPipelineStepRequestModelValidator>();

                public Mock<IApiPipelineStepDestinationRequestModelValidator> PipelineStepDestinationModelValidatorMock { get; set; } = new Mock<IApiPipelineStepDestinationRequestModelValidator>();

                public Mock<IApiPipelineStepNoteRequestModelValidator> PipelineStepNoteModelValidatorMock { get; set; } = new Mock<IApiPipelineStepNoteRequestModelValidator>();

                public Mock<IApiPipelineStepStatusRequestModelValidator> PipelineStepStatusModelValidatorMock { get; set; } = new Mock<IApiPipelineStepStatusRequestModelValidator>();

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

                        this.HandlerPipelineStepModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiHandlerPipelineStepRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.HandlerPipelineStepModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiHandlerPipelineStepRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.HandlerPipelineStepModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.OtherTransportModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiOtherTransportRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.OtherTransportModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOtherTransportRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.OtherTransportModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.PetModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPetRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PetModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPetRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PetModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.PipelineModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PipelineModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PipelineModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.PipelineStatusModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStatusRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PipelineStatusModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStatusRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PipelineStatusModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.PipelineStepModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PipelineStepModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PipelineStepModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.PipelineStepDestinationModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepDestinationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PipelineStepDestinationModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepDestinationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PipelineStepDestinationModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.PipelineStepNoteModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepNoteRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PipelineStepNoteModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepNoteRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PipelineStepNoteModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.PipelineStepStatusModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepStatusRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PipelineStepStatusModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepStatusRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.PipelineStepStatusModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

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
    <Hash>a7b465a40a57173c40e2c0ce88b39d5d</Hash>
</Codenesium>*/