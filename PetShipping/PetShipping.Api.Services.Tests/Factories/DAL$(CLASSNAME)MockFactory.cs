using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services.Tests
{
	public class DALMapperMockFactory
	{
		public IDALAirlineMapper DALAirlineMapperMock { get; set; } = new DALAirlineMapper();

		public IDALAirTransportMapper DALAirTransportMapperMock { get; set; } = new DALAirTransportMapper();

		public IDALBreedMapper DALBreedMapperMock { get; set; } = new DALBreedMapper();

		public IDALCountryMapper DALCountryMapperMock { get; set; } = new DALCountryMapper();

		public IDALCountryRequirementMapper DALCountryRequirementMapperMock { get; set; } = new DALCountryRequirementMapper();

		public IDALCustomerMapper DALCustomerMapperMock { get; set; } = new DALCustomerMapper();

		public IDALCustomerCommunicationMapper DALCustomerCommunicationMapperMock { get; set; } = new DALCustomerCommunicationMapper();

		public IDALDestinationMapper DALDestinationMapperMock { get; set; } = new DALDestinationMapper();

		public IDALEmployeeMapper DALEmployeeMapperMock { get; set; } = new DALEmployeeMapper();

		public IDALHandlerMapper DALHandlerMapperMock { get; set; } = new DALHandlerMapper();

		public IDALHandlerPipelineStepMapper DALHandlerPipelineStepMapperMock { get; set; } = new DALHandlerPipelineStepMapper();

		public IDALOtherTransportMapper DALOtherTransportMapperMock { get; set; } = new DALOtherTransportMapper();

		public IDALPetMapper DALPetMapperMock { get; set; } = new DALPetMapper();

		public IDALPipelineMapper DALPipelineMapperMock { get; set; } = new DALPipelineMapper();

		public IDALPipelineStatusMapper DALPipelineStatusMapperMock { get; set; } = new DALPipelineStatusMapper();

		public IDALPipelineStepMapper DALPipelineStepMapperMock { get; set; } = new DALPipelineStepMapper();

		public IDALPipelineStepDestinationMapper DALPipelineStepDestinationMapperMock { get; set; } = new DALPipelineStepDestinationMapper();

		public IDALPipelineStepNoteMapper DALPipelineStepNoteMapperMock { get; set; } = new DALPipelineStepNoteMapper();

		public IDALPipelineStepStatusMapper DALPipelineStepStatusMapperMock { get; set; } = new DALPipelineStepStatusMapper();

		public IDALPipelineStepStepRequirementMapper DALPipelineStepStepRequirementMapperMock { get; set; } = new DALPipelineStepStepRequirementMapper();

		public IDALSaleMapper DALSaleMapperMock { get; set; } = new DALSaleMapper();

		public IDALSpeciesMapper DALSpeciesMapperMock { get; set; } = new DALSpeciesMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>a305d6f8e27f628f674dce32f3bb7e17</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/