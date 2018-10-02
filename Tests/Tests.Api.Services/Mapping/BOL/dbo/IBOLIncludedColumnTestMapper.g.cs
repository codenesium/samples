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
			ApiIncludedColumnTestRequestModel model);

		ApiIncludedColumnTestResponseModel MapBOToModel(
			BOIncludedColumnTest boIncludedColumnTest);

		List<ApiIncludedColumnTestResponseModel> MapBOToModel(
			List<BOIncludedColumnTest> items);
	}
}

/*<Codenesium>
    <Hash>65cc8902afffa82d1aaa9ff5f51b1c74</Hash>
</Codenesium>*/