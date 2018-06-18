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

                Task<List<Venue>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Venue>> GetAdminId(int adminId);
                Task<List<Venue>> GetProvinceId(int provinceId);

                Task<Admin> GetAdmin(int adminId);
                Task<Province> GetProvince(int provinceId);
        }
}

/*<Codenesium>
    <Hash>5b4ba0bcd685684a07f2de5f27b7f8e5</Hash>
</Codenesium>*/