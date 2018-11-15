using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLContactTypeMapper
	{
		BOContactType MapModelToBO(
			int contactTypeID,
			ApiContactTypeServerRequestModel model);

		ApiContactTypeServerResponseModel MapBOToModel(
			BOContactType boContactType);

		List<ApiContactTypeServerResponseModel> MapBOToModel(
			List<BOContactType> items);
	}
}

/*<Codenesium>
    <Hash>7fc9ae5ec1dd68adf0228fd9676d10f2</Hash>
</Codenesium>*/