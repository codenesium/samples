using Moq;
using PetStoreNS.Api.DataAccess;
using PetStoreNS.Api.Services;
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
    <Hash>8f10fa95c980ad51272ccd8676d9ca52</Hash>
</Codenesium>*/