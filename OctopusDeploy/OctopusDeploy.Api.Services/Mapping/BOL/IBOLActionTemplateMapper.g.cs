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
    <Hash>3bbf681de1a369c89c3a5dbe39d97126</Hash>
</Codenesium>*/