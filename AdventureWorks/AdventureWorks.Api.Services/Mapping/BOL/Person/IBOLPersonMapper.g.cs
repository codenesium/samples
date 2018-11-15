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
			ApiPersonServerRequestModel model);

		ApiPersonServerResponseModel MapBOToModel(
			BOPerson boPerson);

		List<ApiPersonServerResponseModel> MapBOToModel(
			List<BOPerson> items);
	}
}

/*<Codenesium>
    <Hash>415276bb6ba9ace720cf9142720b9af9</Hash>
</Codenesium>*/