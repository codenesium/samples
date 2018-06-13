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

                Task<List<City>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<City>> GetProvinceId(int provinceId);

                Task<List<Event>> Events(int cityId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>94119f6741a7ca1ce52d09c46d635ca2</Hash>
</Codenesium>*/