using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLActionTemplateVersionMapper
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
    <Hash>8dbb455cc964ed9e8957e5ef4d67c5e5</Hash>
</Codenesium>*/