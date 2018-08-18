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
    <Hash>5c9cd2ad5f954744c6911b57e4e96545</Hash>
</Codenesium>*/