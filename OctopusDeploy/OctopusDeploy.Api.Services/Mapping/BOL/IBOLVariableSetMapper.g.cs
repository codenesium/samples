using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLVariableSetMapper
	{
		BOVariableSet MapModelToBO(
			string id,
			ApiVariableSetRequestModel model);

		ApiVariableSetResponseModel MapBOToModel(
			BOVariableSet boVariableSet);

		List<ApiVariableSetResponseModel> MapBOToModel(
			List<BOVariableSet> items);
	}
}

/*<Codenesium>
    <Hash>0ac9955f5ea7bb394a4679d2c314f270</Hash>
</Codenesium>*/