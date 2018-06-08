using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
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
    <Hash>d58f0934a570aeae2ed494b3dfb70350</Hash>
</Codenesium>*/