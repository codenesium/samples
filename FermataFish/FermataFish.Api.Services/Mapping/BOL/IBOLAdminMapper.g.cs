using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public interface IBOLAdminMapper
	{
		BOAdmin MapModelToBO(
			int id,
			ApiAdminRequestModel model);

		ApiAdminResponseModel MapBOToModel(
			BOAdmin boAdmin);

		List<ApiAdminResponseModel> MapBOToModel(
			List<BOAdmin> items);
	}
}

/*<Codenesium>
    <Hash>354279aea42d3a61b543ee4ed6207103</Hash>
</Codenesium>*/