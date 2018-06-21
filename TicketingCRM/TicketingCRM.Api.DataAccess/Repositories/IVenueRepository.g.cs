using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public interface IVenueRepository
        {
                Task<Venue> Create(Venue item);

                Task Update(Venue item);

                Task Delete(int id);

                Task<Venue> Get(int id);

                Task<List<Venue>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Venue>> GetAdminId(int adminId);

                Task<List<Venue>> GetProvinceId(int provinceId);

                Task<Admin> GetAdmin(int adminId);

                Task<Province> GetProvince(int provinceId);
        }
}

/*<Codenesium>
    <Hash>57a8a477abfbde641a7086aa94c74c20</Hash>
</Codenesium>*/