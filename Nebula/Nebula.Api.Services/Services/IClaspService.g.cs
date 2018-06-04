using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public interface IClaspService
	{
		Task<CreateResponse<ApiClaspResponseModel>> Create(
			ApiClaspRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiClaspRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiClaspResponseModel> Get(int id);

		Task<List<ApiClaspResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1effb569d55f35984aba790d630a20de</Hash>
</Codenesium>*/