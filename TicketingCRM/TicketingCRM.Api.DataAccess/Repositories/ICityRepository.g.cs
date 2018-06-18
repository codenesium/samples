using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public interface ICityRepository
        {
                Task<City> Create(City item);

                Task Update(City item);

                Task Delete(int id);

                Task<City> Get(int id);

                Task<List<City>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<City>> GetProvinceId(int provinceId);

                Task<List<Event>> Events(int cityId, int limit = int.MaxValue, int offset = 0);

                Task<Province> GetProvince(int provinceId);
        }
}

/*<Codenesium>
    <Hash>a93dd1de251092ce4b375f83fb5168b6</Hash>
</Codenesium>*/