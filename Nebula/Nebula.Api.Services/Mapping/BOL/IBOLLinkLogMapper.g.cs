using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IBOLLinkLogMapper
	{
		BOLinkLog MapModelToBO(
			int id,
			ApiLinkLogServerRequestModel model);

		ApiLinkLogServerResponseModel MapBOToModel(
			BOLinkLog boLinkLog);

		List<ApiLinkLogServerResponseModel> MapBOToModel(
			List<BOLinkLog> items);
	}
}

/*<Codenesium>
    <Hash>aad570a7e6388b120d7aa6572faa5436</Hash>
</Codenesium>*/