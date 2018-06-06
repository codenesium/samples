using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLAWBuildVersionMapper
	{
		BOAWBuildVersion MapModelToBO(
			int systemInformationID,
			ApiAWBuildVersionRequestModel model);

		ApiAWBuildVersionResponseModel MapBOToModel(
			BOAWBuildVersion boAWBuildVersion);

		List<ApiAWBuildVersionResponseModel> MapBOToModel(
			List<BOAWBuildVersion> items);
	}
}

/*<Codenesium>
    <Hash>e075ea820d5f192afa987df707844299</Hash>
</Codenesium>*/