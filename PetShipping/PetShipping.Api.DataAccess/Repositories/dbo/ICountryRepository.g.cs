using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface ICountryRepository
	{
		POCOCountry Create(CountryModel model);

		void Update(int id,
		            CountryModel model);

		void Delete(int id);

		POCOCountry Get(int id);

		List<POCOCountry> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>33b2f642381972fca359b97b3b67d7db</Hash>
</Codenesium>*/