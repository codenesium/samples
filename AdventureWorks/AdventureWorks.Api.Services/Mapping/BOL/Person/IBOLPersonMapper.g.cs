using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLPersonMapper
	{
		BOPerson MapModelToBO(
			int businessEntityID,
			ApiPersonRequestModel model);

		ApiPersonResponseModel MapBOToModel(
			BOPerson boPerson);

		List<ApiPersonResponseModel> MapBOToModel(
			List<BOPerson> items);
	}
}

/*<Codenesium>
    <Hash>53e6dd64d36c81f075b99192b82f03ba</Hash>
</Codenesium>*/