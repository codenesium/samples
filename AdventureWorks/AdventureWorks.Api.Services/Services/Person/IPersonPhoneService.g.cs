using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IPersonPhoneService
	{
		Task<CreateResponse<ApiPersonPhoneResponseModel>> Create(
			ApiPersonPhoneRequestModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiPersonPhoneRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiPersonPhoneResponseModel> Get(int businessEntityID);

		Task<List<ApiPersonPhoneResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<ApiPersonPhoneResponseModel>> GetPhoneNumber(string phoneNumber);
	}
}

/*<Codenesium>
    <Hash>6177788c2092a251dc253ca3733549b9</Hash>
</Codenesium>*/