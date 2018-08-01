using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLLibraryVariableSetMapper
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
    <Hash>750c56a77b318562293a5dc02b3807a1</Hash>
</Codenesium>*/