using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
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
    <Hash>6267b6e1675a27186b24610ab274dcd8</Hash>
</Codenesium>*/