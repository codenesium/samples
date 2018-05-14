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
			PenModel model);

		Task<ActionResponse> Update(int id,
		                            PenModel model);

		Task<ActionResponse> Delete(int id);

		POCOPen Get(int id);

		List<POCOPen> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e51b070635e4425e364d0eb5276f7fad</Hash>
</Codenesium>*/