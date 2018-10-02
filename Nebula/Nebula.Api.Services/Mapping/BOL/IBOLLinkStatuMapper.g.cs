using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IBOLLinkStatuMapper
	{
		BOLinkStatu MapModelToBO(
			int id,
			ApiLinkStatuRequestModel model);

		ApiLinkStatuResponseModel MapBOToModel(
			BOLinkStatu boLinkStatu);

		List<ApiLinkStatuResponseModel> MapBOToModel(
			List<BOLinkStatu> items);
	}
}

/*<Codenesium>
    <Hash>12a127c0c4cf40cd52d5996e84833008</Hash>
</Codenesium>*/