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
			ApiPersonServerRequestModel model);

		ApiPersonServerResponseModel MapBOToModel(
			BOPerson boPerson);

		List<ApiPersonServerResponseModel> MapBOToModel(
			List<BOPerson> items);
	}
}

/*<Codenesium>
    <Hash>ea98000269068065cb17691acc66dffa</Hash>
</Codenesium>*/