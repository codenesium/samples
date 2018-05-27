using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOStudio
	{
		Task<CreateResponse<ApiStudioResponseModel>> Create(
			ApiStudioRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiStudioRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiStudioResponseModel> Get(int id);

		Task<List<ApiStudioResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4c7fde74450aa4c6d39f6ae2946d030b</Hash>
</Codenesium>*/