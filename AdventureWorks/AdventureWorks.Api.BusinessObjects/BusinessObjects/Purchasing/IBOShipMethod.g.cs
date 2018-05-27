using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOShipMethod
	{
		Task<CreateResponse<ApiShipMethodResponseModel>> Create(
			ApiShipMethodRequestModel model);

		Task<ActionResponse> Update(int shipMethodID,
		                            ApiShipMethodRequestModel model);

		Task<ActionResponse> Delete(int shipMethodID);

		Task<ApiShipMethodResponseModel> Get(int shipMethodID);

		Task<List<ApiShipMethodResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiShipMethodResponseModel> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>77e3029b394f570ee0f5814b0d7cc5b9</Hash>
</Codenesium>*/