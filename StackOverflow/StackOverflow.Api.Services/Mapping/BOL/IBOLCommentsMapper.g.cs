using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public interface IBOLCommentsMapper
	{
		BOComments MapModelToBO(
			int id,
			ApiCommentsRequestModel model);

		ApiCommentsResponseModel MapBOToModel(
			BOComments boComments);

		List<ApiCommentsResponseModel> MapBOToModel(
			List<BOComments> items);
	}
}

/*<Codenesium>
    <Hash>09550e903e1879ea85c49eba76db7b9a</Hash>
</Codenesium>*/