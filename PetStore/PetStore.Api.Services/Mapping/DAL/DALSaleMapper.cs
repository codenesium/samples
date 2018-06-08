using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public class DALSaleMapper: DALAbstractSaleMapper, IDALSaleMapper
        {
                public DALSaleMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>ccb8fe280cdb2475c28b272c7b237d35</Hash>
</Codenesium>*/