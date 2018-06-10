using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
    <Hash>5e89394aa6a0c41f4879070de1930f1d</Hash>
</Codenesium>*/