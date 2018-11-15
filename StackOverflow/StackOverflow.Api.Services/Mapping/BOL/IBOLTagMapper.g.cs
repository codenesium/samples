using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLTagMapper
	{
		BOTag MapModelToBO(
			int id,
			ApiTagServerRequestModel model);

		ApiTagServerResponseModel MapBOToModel(
			BOTag boTag);

		List<ApiTagServerResponseModel> MapBOToModel(
			List<BOTag> items);
	}
}

/*<Codenesium>
    <Hash>6d75ad8c32448da9b51830426137f9a9</Hash>
</Codenesium>*/