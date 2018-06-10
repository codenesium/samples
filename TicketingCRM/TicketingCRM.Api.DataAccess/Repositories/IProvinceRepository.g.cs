using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public interface IProvinceRepository
        {
                Task<Province> Create(Province item);

                Task Update(Province item);

                Task Delete(int id);

                Task<Province> Get(int id);

                Task<List<Province>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<Province>> GetCountryId(int countryId);
        }
}

/*<Codenesium>
    <Hash>8b4370a76bc1617e07f689d85c36567d</Hash>
</Codenesium>*/