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

                Task<List<Admin>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Venue>> Venues(int adminId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>a0be897c807f4d80fbf5199f1b2f32ce</Hash>
</Codenesium>*/