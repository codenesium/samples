using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IBOLVPersonMapper
	{
		BOVPerson MapModelToBO(
			int personId,
			ApiVPersonRequestModel model);

		ApiVPersonResponseModel MapBOToModel(
			BOVPerson boVPerson);

		List<ApiVPersonResponseModel> MapBOToModel(
			List<BOVPerson> items);
	}
}

/*<Codenesium>
    <Hash>86262fba777f04a8e77afd5d276f0572</Hash>
</Codenesium>*/