using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface ICountryRepository
	{
		POCOCountry Create(ApiCountryModel model);

		void Update(int id,
		            ApiCountryModel model);

		void Delete(int id);

		POCOCountry Get(int id);

		List<POCOCountry> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>aa64108ce673535caeea59eb707ed3ce</Hash>
</Codenesium>*/