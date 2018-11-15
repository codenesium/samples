using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IBOLMessageMapper
	{
		BOMessage MapModelToBO(
			int messageId,
			ApiMessageServerRequestModel model);

		ApiMessageServerResponseModel MapBOToModel(
			BOMessage boMessage);

		List<ApiMessageServerResponseModel> MapBOToModel(
			List<BOMessage> items);
	}
}

/*<Codenesium>
    <Hash>ab1223c7963a7e86c4de69b8a1d22276</Hash>
</Codenesium>*/