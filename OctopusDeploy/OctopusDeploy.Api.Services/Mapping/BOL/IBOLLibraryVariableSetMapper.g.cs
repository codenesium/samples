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
    <Hash>da96300e40c70f6f64710c99db12de99</Hash>
</Codenesium>*/