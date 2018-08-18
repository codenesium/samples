using Moq;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services.Tests
{
	public class BOLMapperMockFactory
	{
		public IBOLBreedMapper BOLBreedMapperMock { get; set; } = new BOLBreedMapper();

		public IBOLPaymentTypeMapper BOLPaymentTypeMapperMock { get; set; } = new BOLPaymentTypeMapper();

		public IBOLPenMapper BOLPenMapperMock { get; set; } = new BOLPenMapper();

		public IBOLPetMapper BOLPetMapperMock { get; set; } = new BOLPetMapper();

		public IBOLSaleMapper BOLSaleMapperMock { get; set; } = new BOLSaleMapper();

		public IBOLSpeciesMapper BOLSpeciesMapperMock { get; set; } = new BOLSpeciesMapper();

		public BOLMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>f003266dd3f641ebfb7e524507124137</Hash>
</Codenesium>*/