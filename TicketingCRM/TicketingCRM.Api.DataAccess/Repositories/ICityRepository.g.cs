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

                Task<List<City>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<City>> GetProvinceId(int provinceId);
        }
}

/*<Codenesium>
    <Hash>94b25e07e1019cb4175f1f989cb1cab4</Hash>
</Codenesium>*/