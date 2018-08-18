using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IBOLPersonMapper
	{
		BOPerson MapModelToBO(
			int personId,
			ApiPersonRequestModel model);

		ApiPersonResponseModel MapBOToModel(
			BOPerson boPerson);

		List<ApiPersonResponseModel> MapBOToModel(
			List<BOPerson> items);
	}
}

/*<Codenesium>
    <Hash>9ea2e11427ab24172f42237ea57ec046</Hash>
</Codenesium>*/