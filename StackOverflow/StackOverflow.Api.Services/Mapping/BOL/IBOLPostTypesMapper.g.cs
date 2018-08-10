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
    <Hash>0fc1aa95f03974bd5990fda3dad0c646</Hash>
</Codenesium>*/