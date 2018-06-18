using Moq;
using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

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
    <Hash>14da286219ce822d506382946b76ed47</Hash>
</Codenesium>*/