using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOClasp
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
    <Hash>c0df4d1c9872e65cfa2ae3e976df0526</Hash>
</Codenesium>*/