using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLActionTemplateMapper
	{
		BOActionTemplate MapModelToBO(
			string id,
			ApiActionTemplateRequestModel model);

		ApiActionTemplateResponseModel MapBOToModel(
			BOActionTemplate boActionTemplate);

		List<ApiActionTemplateResponseModel> MapBOToModel(
			List<BOActionTemplate> items);
	}
}

/*<Codenesium>
    <Hash>ba9d4e308f1eb870787fb6dbb49a1cc0</Hash>
</Codenesium>*/