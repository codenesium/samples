using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IDALMessageMapper
	{
		Message MapModelToEntity(
			int messageId,
			ApiMessageServerRequestModel model);

		ApiMessageServerResponseModel MapEntityToModel(
			Message item);

		List<ApiMessageServerResponseModel> MapEntityToModel(
			List<Message> items);
	}
}

/*<Codenesium>
    <Hash>851242e9d0c9bf63ee5efd8c18c0dea8</Hash>
</Codenesium>*/