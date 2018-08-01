using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public interface IClaspService
	{
		Task<CreateResponse<ApiClaspResponseModel>> Create(
			ApiClaspRequestModel model);

		Task<UpdateResponse<ApiClaspResponseModel>> Update(int id,
		                                                    ApiClaspRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiClaspResponseModel> Get(int id);

		Task<List<ApiClaspResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>43a8e1e3d3eda49f8e68291f51057a8a</Hash>
</Codenesium>*/