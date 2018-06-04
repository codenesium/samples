using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface ICountryRepository
	{
		Task<Country> Create(Country item);

		Task Update(Country item);

		Task Delete(int id);

		Task<Country> Get(int id);

		Task<List<Country>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>678aaf1660e2d82518f5725594f2ec37</Hash>
</Codenesium>*/