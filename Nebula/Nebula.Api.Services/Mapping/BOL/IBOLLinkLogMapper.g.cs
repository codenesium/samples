using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
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
    <Hash>380227c65efb786c89ad1ff4263285f8</Hash>
</Codenesium>*/