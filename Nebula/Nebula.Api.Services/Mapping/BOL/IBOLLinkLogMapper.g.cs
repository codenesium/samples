using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public interface IBOLLinkLogMapper
	{
		BOLinkLog MapModelToBO(
			int id,
			ApiLinkLogRequestModel model);

		ApiLinkLogResponseModel MapBOToModel(
			BOLinkLog boLinkLog);

		List<ApiLinkLogResponseModel> MapBOToModel(
			List<BOLinkLog> items);
	}
}

/*<Codenesium>
    <Hash>c840f37ea49b4208f616617820286beb</Hash>
</Codenesium>*/