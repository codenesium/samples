using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALCommentsMapper
	{
		Comments MapModelToEntity(
			int id,
			ApiCommentsServerRequestModel model);

		ApiCommentsServerResponseModel MapEntityToModel(
			Comments item);

		List<ApiCommentsServerResponseModel> MapEntityToModel(
			List<Comments> items);
	}
}

/*<Codenesium>
    <Hash>77cd6bcf04352fbc9b25ec4df4fd54a5</Hash>
</Codenesium>*/