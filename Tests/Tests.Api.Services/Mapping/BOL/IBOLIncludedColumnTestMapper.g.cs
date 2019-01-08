using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IBOLIncludedColumnTestMapper
	{
		BOIncludedColumnTest MapModelToBO(
			int id,
			ApiIncludedColumnTestServerRequestModel model);

		ApiIncludedColumnTestServerResponseModel MapBOToModel(
			BOIncludedColumnTest boIncludedColumnTest);

		List<ApiIncludedColumnTestServerResponseModel> MapBOToModel(
			List<BOIncludedColumnTest> items);
	}
}

/*<Codenesium>
    <Hash>f98e2948ea4f41b586f6a2f80fd6b781</Hash>
</Codenesium>*/