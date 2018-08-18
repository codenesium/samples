using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IPersonPhoneService
	{
		Task<CreateResponse<ApiPersonPhoneResponseModel>> Create(
			ApiPersonPhoneRequestModel model);

		Task<UpdateResponse<ApiPersonPhoneResponseModel>> Update(int businessEntityID,
		                                                          ApiPersonPhoneRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiPersonPhoneResponseModel> Get(int businessEntityID);

		Task<List<ApiPersonPhoneResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPersonPhoneResponseModel>> ByPhoneNumber(string phoneNumber, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>afb6eb4c47f620f1424ee994c0308683</Hash>
</Codenesium>*/