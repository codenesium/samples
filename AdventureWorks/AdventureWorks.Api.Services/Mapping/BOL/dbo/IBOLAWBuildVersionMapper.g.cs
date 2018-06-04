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
			List<BOAWBuildVersion> bos);
	}
}

/*<Codenesium>
    <Hash>9812dfd173f12907346f3feec98d5f3a</Hash>
</Codenesium>*/