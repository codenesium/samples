using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLActionTemplateVersionMapper
	{
		BOActionTemplateVersion MapModelToBO(
			string id,
			ApiActionTemplateVersionRequestModel model);

		ApiActionTemplateVersionResponseModel MapBOToModel(
			BOActionTemplateVersion boActionTemplateVersion);

		List<ApiActionTemplateVersionResponseModel> MapBOToModel(
			List<BOActionTemplateVersion> items);
	}
}

/*<Codenesium>
    <Hash>0e547bf54df424f38eb561624e602ce7</Hash>
</Codenesium>*/