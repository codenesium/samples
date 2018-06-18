using Moq;
using System;
using System.Collections.Generic;
using PetStoreNS.Api.DataAccess;
using PetStoreNS.Api.Services;

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
    <Hash>5f50538ca59a019e4c270bd94b2d41c6</Hash>
</Codenesium>*/