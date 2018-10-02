using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface ICompositePrimaryKeyService
	{
		Task<CreateResponse<ApiCompositePrimaryKeyResponseModel>> Create(
			ApiCompositePrimaryKeyRequestModel model);

		Task<UpdateResponse<ApiCompositePrimaryKeyResponseModel>> Update(int id,
		                                                                  ApiCompositePrimaryKeyRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCompositePrimaryKeyResponseModel> Get(int id);

		Task<List<ApiCompositePrimaryKeyResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7be45109324686952b9d226f1aa17fea</Hash>
</Codenesium>*/