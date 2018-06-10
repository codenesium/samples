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

                Task<List<Venue>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<Venue>> GetAdminId(int adminId);
                Task<List<Venue>> GetProvinceId(int provinceId);
        }
}

/*<Codenesium>
    <Hash>b4fdbe142975e5a43661ed27457dc650</Hash>
</Codenesium>*/