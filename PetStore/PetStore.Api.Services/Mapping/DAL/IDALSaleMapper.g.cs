using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

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
    <Hash>9c9f1faed7fd1572bb9eb0f589b60e51</Hash>
</Codenesium>*/