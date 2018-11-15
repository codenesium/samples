using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

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
    <Hash>2757c6cdf7b10f1c9c5e503d6e4aed7c</Hash>
</Codenesium>*/