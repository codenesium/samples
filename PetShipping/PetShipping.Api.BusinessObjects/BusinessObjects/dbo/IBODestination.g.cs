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
		Task<CreateResponse<POCODestination>> Create(
			DestinationModel model);

		Task<ActionResponse> Update(int id,
		                            DestinationModel model);

		Task<ActionResponse> Delete(int id);

		POCODestination Get(int id);

		List<POCODestination> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2cad2c81422e61157f1352c6cb62a505</Hash>
</Codenesium>*/