using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLVariableSetMapper
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
    <Hash>601bfb71290eaa05d775d15b405f8bfe</Hash>
</Codenesium>*/