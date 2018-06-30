using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IDALProvinceMapper
        {
                Province MapBOToEF(
                        BOProvince bo);

                BOProvince MapEFToBO(
                        Province efProvince);

                List<BOProvince> MapEFToBO(
                        List<Province> records);
        }
}

/*<Codenesium>
    <Hash>281ee1e1678e6237e588bd438afe1121</Hash>
</Codenesium>*/