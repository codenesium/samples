using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLPostTypesMapper
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
    <Hash>74f72f7c9a75a5ce37d8074f7eb4df79</Hash>
</Codenesium>*/