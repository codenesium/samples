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

		public IDALPipelineStatuMapper DALPipelineStatuMapperMock { get; set; } = new DALPipelineStatuMapper();

		public IDALPipelineStepMapper DALPipelineStepMapperMock { get; set; } = new DALPipelineStepMapper();

		public IDALPipelineStepDestinationMapper DALPipelineStepDestinationMapperMock { get; set; } = new DALPipelineStepDestinationMapper();

		public IDALPipelineStepNoteMapper DALPipelineStepNoteMapperMock { get; set; } = new DALPipelineStepNoteMapper();

		public IDALPipelineStepStatuMapper DALPipelineStepStatuMapperMock { get; set; } = new DALPipelineStepStatuMapper();

		public IDALPipelineStepStepRequirementMapper DALPipelineStepStepRequirementMapperMock { get; set; } = new DALPipelineStepStepRequirementMapper();

		public IDALSaleMapper DALSaleMapperMock { get; set; } = new DALSaleMapper();

		public IDALSpeciesMapper DALSpeciesMapperMock { get; set; } = new DALSpeciesMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>9b4a528c7e57855e5af4f2b3f1371082</Hash>
</Codenesium>*/