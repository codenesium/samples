using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOCountry
	{
		Task<CreateResponse<int>> Create(
			CountryModel model);

		Task<ActionResponse> Update(int id,
		                            CountryModel model);

		Task<ActionResponse> Delete(int id);

		POCOCountry Get(int id);

		List<POCOCountry> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>60a7878eead2964951c89915956fcd1e</Hash>
</Codenesium>*/