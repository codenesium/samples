using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public interface IBOPen
	{
		Task<CreateResponse<POCOPen>> Create(
			ApiPenModel model);

		Task<ActionResponse> Update(int id,
		                            ApiPenModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOPen> Get(int id);

		Task<List<POCOPen>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>504dd01da3515d15378ccce3d86f542f</Hash>
</Codenesium>*/