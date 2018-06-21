using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
        public interface IDALSaleMapper
        {
                Sale MapBOToEF(
                        BOSale bo);

                BOSale MapEFToBO(
                        Sale efSale);

                List<BOSale> MapEFToBO(
                        List<Sale> records);
        }
}

/*<Codenesium>
    <Hash>f6a67bd6af3288d21af1e636069e99b6</Hash>
</Codenesium>*/