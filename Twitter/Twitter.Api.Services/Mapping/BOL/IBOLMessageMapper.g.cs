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
			ApiMessageRequestModel model);

		ApiMessageResponseModel MapBOToModel(
			BOMessage boMessage);

		List<ApiMessageResponseModel> MapBOToModel(
			List<BOMessage> items);
	}
}

/*<Codenesium>
    <Hash>f79b46f72ba967811872dd9dc64d059b</Hash>
</Codenesium>*/