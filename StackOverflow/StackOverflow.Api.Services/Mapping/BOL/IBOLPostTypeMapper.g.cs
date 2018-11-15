using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLPostTypeMapper
	{
		BOPostType MapModelToBO(
			int id,
			ApiPostTypeServerRequestModel model);

		ApiPostTypeServerResponseModel MapBOToModel(
			BOPostType boPostType);

		List<ApiPostTypeServerResponseModel> MapBOToModel(
			List<BOPostType> items);
	}
}

/*<Codenesium>
    <Hash>6418ce8cfd8918a67735cde42ebdea55</Hash>
</Codenesium>*/