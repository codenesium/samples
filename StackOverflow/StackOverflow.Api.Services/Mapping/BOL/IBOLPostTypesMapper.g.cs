using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public interface IBOLPostTypesMapper
	{
		BOPostTypes MapModelToBO(
			int id,
			ApiPostTypesRequestModel model);

		ApiPostTypesResponseModel MapBOToModel(
			BOPostTypes boPostTypes);

		List<ApiPostTypesResponseModel> MapBOToModel(
			List<BOPostTypes> items);
	}
}

/*<Codenesium>
    <Hash>104f37deaf4d95ced4b8702ef10360d4</Hash>
</Codenesium>*/