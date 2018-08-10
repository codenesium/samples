using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLActionTemplateMapper
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
    <Hash>9517d8337d27216cd69133e7629f48ef</Hash>
</Codenesium>*/