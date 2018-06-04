using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public interface IOrganizationService
	{
		Task<CreateResponse<ApiOrganizationResponseModel>> Create(
			ApiOrganizationRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiOrganizationRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiOrganizationResponseModel> Get(int id);

		Task<List<ApiOrganizationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a3dbf79a70a9d26eaa39713864f7efd8</Hash>
</Codenesium>*/