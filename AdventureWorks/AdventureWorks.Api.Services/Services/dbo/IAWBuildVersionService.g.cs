using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IAWBuildVersionService
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
    <Hash>edaec21c73e993b8ae0df71bf25e7413</Hash>
</Codenesium>*/