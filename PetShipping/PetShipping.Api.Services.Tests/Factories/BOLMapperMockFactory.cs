using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services.Tests
{
	public class BOLMapperMockFactory
	{
		public IBOLAirlineMapper BOLAirlineMapperMock { get; set; } = new BOLAirlineMapper();

		public IBOLAirTransportMapper BOLAirTransportMapperMock { get; set; } = new BOLAirTransportMapper();

		public IBOLBreedMapper BOLBreedMapperMock { get; set; } = new BOLBreedMapper();

		public IBOLClientMapper BOLClientMapperMock { get; set; } = new BOLClientMapper();

		public IBOLClientCommunicationMapper BOLClientCommunicationMapperMock { get; set; } = new BOLClientCommunicationMapper();

		public IBOLCountryMapper BOLCountryMapperMock { get; set; } = new BOLCountryMapper();

		public IBOLCountryRequirementMapper BOLCountryRequirementMapperMock { get; set; } = new BOLCountryRequirementMapper();

		public IBOLDestinationMapper BOLDestinationMapperMock { get; set; } = new BOLDestinationMapper();

		public IBOLEmployeeMapper BOLEmployeeMapperMock { get; set; } = new BOLEmployeeMapper();

		public IBOLHandlerMapper BOLHandlerMapperMock { get; set; } = new BOLHandlerMapper();

		public IBOLHandlerPipelineStepMapper BOLHandlerPipelineStepMapperMock { get; set; } = new BOLHandlerPipelineStepMapper();

		public IBOLOtherTransportMapper BOLOtherTransportMapperMock { get; set; } = new BOLOtherTransportMapper();

		public IBOLPetMapper BOLPetMapperMock { get; set; } = new BOLPetMapper();

		public IBOLPipelineMapper BOLPipelineMapperMock { get; set; } = new BOLPipelineMapper();

		public IBOLPipelineStatusMapper BOLPipelineStatusMapperMock { get; set; } = new BOLPipelineStatusMapper();

		public IBOLPipelineStepMapper BOLPipelineStepMapperMock { get; set; } = new BOLPipelineStepMapper();

		public IBOLPipelineStepDestinationMapper BOLPipelineStepDestinationMapperMock { get; set; } = new BOLPipelineStepDestinationMapper();

		public IBOLPipelineStepNoteMapper BOLPipelineStepNoteMapperMock { get; set; } = new BOLPipelineStepNoteMapper();

		public IBOLPipelineStepStatusMapper BOLPipelineStepStatusMapperMock { get; set; } = new BOLPipelineStepStatusMapper();

		public IBOLPipelineStepStepRequirementMapper BOLPipelineStepStepRequirementMapperMock { get; set; } = new BOLPipelineStepStepRequirementMapper();

		public IBOLSaleMapper BOLSaleMapperMock { get; set; } = new BOLSaleMapper();

		public IBOLSpeciesMapper BOLSpeciesMapperMock { get; set; } = new BOLSpeciesMapper();

		public BOLMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>07e7aa05c3bfb8b00590fd46db1822cb</Hash>
</Codenesium>*/