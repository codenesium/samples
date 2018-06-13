using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public interface IAdminRepository
        {
                Task<Admin> Create(Admin item);

                Task Update(Admin item);

                Task Delete(int id);

                Task<Admin> Get(int id);

                Task<List<Admin>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Venue>> Venues(int adminId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>36377ab525d5913a78e1a90298caaa0e</Hash>
</Codenesium>*/