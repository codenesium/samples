using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>a70f531a8e39b5bceae8bfdfbe8f9102</Hash>
</Codenesium>*/