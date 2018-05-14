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

		POCOPen Get(int id);

		List<POCOPen> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1dfe0a6d2779dbea05cf1a8f5830f376</Hash>
</Codenesium>*/