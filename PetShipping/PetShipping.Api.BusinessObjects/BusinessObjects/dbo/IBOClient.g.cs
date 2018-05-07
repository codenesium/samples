using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOClient
	{
		Task<CreateResponse<int>> Create(
			ClientModel model);

		Task<ActionResponse> Update(int id,
		                            ClientModel model);

		Task<ActionResponse> Delete(int id);

		POCOClient Get(int id);

		List<POCOClient> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8e86ce70ea870f1e80f21c4dbf583aa0</Hash>
</Codenesium>*/