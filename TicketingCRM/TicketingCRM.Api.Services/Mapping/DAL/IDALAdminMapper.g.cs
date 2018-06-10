using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IDALAdminMapper
        {
                Admin MapBOToEF(
                        BOAdmin bo);

                BOAdmin MapEFToBO(
                        Admin efAdmin);

                List<BOAdmin> MapEFToBO(
                        List<Admin> records);
        }
}

/*<Codenesium>
    <Hash>de2b3b323ad16842bd6326618a6fc63b</Hash>
</Codenesium>*/