using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    <Hash>cc89c293171b70da8181efccaad067c8</Hash>
</Codenesium>*/