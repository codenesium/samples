using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOAirline
	{
		Task<CreateResponse<POCOAirline>> Create(
			AirlineModel model);

		Task<ActionResponse> Update(int id,
		                            AirlineModel model);

		Task<ActionResponse> Delete(int id);

		POCOAirline Get(int id);

		List<POCOAirline> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0bca56cf407384f885c6795b5493eb52</Hash>
</Codenesium>*/