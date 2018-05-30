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
		Task<CreateResponse<ApiAirlineResponseModel>> Create(
			ApiAirlineRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiAirlineRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiAirlineResponseModel> Get(int id);

		Task<List<ApiAirlineResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b6b1a8189aac89dccd8f64700033ae32</Hash>
</Codenesium>*/