using Moq;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services.Tests
{
	public class DALMapperMockFactory
	{
		public IDALBreedMapper DALBreedMapperMock { get; set; } = new DALBreedMapper();

		public IDALPaymentTypeMapper DALPaymentTypeMapperMock { get; set; } = new DALPaymentTypeMapper();

		public IDALPenMapper DALPenMapperMock { get; set; } = new DALPenMapper();

		public IDALPetMapper DALPetMapperMock { get; set; } = new DALPetMapper();

		public IDALSaleMapper DALSaleMapperMock { get; set; } = new DALSaleMapper();

		public IDALSpeciesMapper DALSpeciesMapperMock { get; set; } = new DALSpeciesMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>3773b5fe97e27f7a48d8af9e81df4abc</Hash>
</Codenesium>*/