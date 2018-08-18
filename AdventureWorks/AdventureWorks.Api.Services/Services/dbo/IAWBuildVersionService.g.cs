using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IAWBuildVersionService
	{
		Task<CreateResponse<ApiAWBuildVersionResponseModel>> Create(
			ApiAWBuildVersionRequestModel model);

		Task<UpdateResponse<ApiAWBuildVersionResponseModel>> Update(int systemInformationID,
		                                                             ApiAWBuildVersionRequestModel model);

		Task<ActionResponse> Delete(int systemInformationID);

		Task<ApiAWBuildVersionResponseModel> Get(int systemInformationID);

		Task<List<ApiAWBuildVersionResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>02c2fc8ee4fbe1d415a9a9ee0a280656</Hash>
</Codenesium>*/