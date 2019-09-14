using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALCommentMapper
	{
		Comment MapModelToEntity(
			int id,
			ApiCommentServerRequestModel model);

		ApiCommentServerResponseModel MapEntityToModel(
			Comment item);

		List<ApiCommentServerResponseModel> MapEntityToModel(
			List<Comment> items);
	}
}

/*<Codenesium>
    <Hash>b2600da8dc0705857a2dc390e2cdc271</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/