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

                Task<List<Admin>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>d5607458707b12a531445b8913f98836</Hash>
</Codenesium>*/