using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLLibraryVariableSetMapper
	{
		BOLibraryVariableSet MapModelToBO(
			string id,
			ApiLibraryVariableSetRequestModel model);

		ApiLibraryVariableSetResponseModel MapBOToModel(
			BOLibraryVariableSet boLibraryVariableSet);

		List<ApiLibraryVariableSetResponseModel> MapBOToModel(
			List<BOLibraryVariableSet> items);
	}
}

/*<Codenesium>
    <Hash>44997274b346a83afded843fff675c0a</Hash>
</Codenesium>*/