using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBODestination
	{
		Task<CreateResponse<int>> Create(
			DestinationModel model);

		Task<ActionResponse> Update(int id,
		                            DestinationModel model);

		Task<ActionResponse> Delete(int id);

		POCODestination Get(int id);

		List<POCODestination> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9aa3901558262b3e69ebb9bc0a8c33ee</Hash>
</Codenesium>*/