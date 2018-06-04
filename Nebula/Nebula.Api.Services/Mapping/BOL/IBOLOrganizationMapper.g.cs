using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services
{
	public interface IBOLOrganizationMapper
	{
		BOOrganization MapModelToBO(
			int id,
			ApiOrganizationRequestModel model);

		ApiOrganizationResponseModel MapBOToModel(
			BOOrganization boOrganization);

		List<ApiOrganizationResponseModel> MapBOToModel(
			List<BOOrganization> bos);
	}
}

/*<Codenesium>
    <Hash>f846ea854a4500e54727fc1b89a5ef29</Hash>
</Codenesium>*/