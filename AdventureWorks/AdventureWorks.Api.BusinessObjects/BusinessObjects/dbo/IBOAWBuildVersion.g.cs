using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOAWBuildVersion
	{
		Task<CreateResponse<ApiAWBuildVersionResponseModel>> Create(
			ApiAWBuildVersionRequestModel model);

		Task<ActionResponse> Update(int systemInformationID,
		                            ApiAWBuildVersionRequestModel model);

		Task<ActionResponse> Delete(int systemInformationID);

		Task<ApiAWBuildVersionResponseModel> Get(int systemInformationID);

		Task<List<ApiAWBuildVersionResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4ce3d887667dc3cd20c393df55df972b</Hash>
</Codenesium>*/