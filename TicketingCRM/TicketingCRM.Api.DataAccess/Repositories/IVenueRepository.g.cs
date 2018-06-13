using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public interface IVenueRepository
        {
                Task<Venue> Create(Venue item);

                Task Update(Venue item);

                Task Delete(int id);

                Task<Venue> Get(int id);

                Task<List<Venue>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Venue>> GetAdminId(int adminId);
                Task<List<Venue>> GetProvinceId(int provinceId);
        }
}

/*<Codenesium>
    <Hash>87a561ca77547a81bc658e487ddc36bb</Hash>
</Codenesium>*/