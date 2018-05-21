using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOFamily
	{
		Task<CreateResponse<POCOFamily>> Create(
			ApiFamilyModel model);

		Task<ActionResponse> Update(int id,
		                            ApiFamilyModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOFamily> Get(int id);

		Task<List<POCOFamily>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f185c0e68032886e0e5d6c199e050e82</Hash>
</Codenesium>*/