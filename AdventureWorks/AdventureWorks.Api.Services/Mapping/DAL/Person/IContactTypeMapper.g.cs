using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALContactTypeMapper
	{
		ContactType MapModelToBO(
			int contactTypeID,
			ApiContactTypeServerRequestModel model);

		ApiContactTypeServerResponseModel MapBOToModel(
			ContactType item);

		List<ApiContactTypeServerResponseModel> MapBOToModel(
			List<ContactType> items);
	}
}

/*<Codenesium>
    <Hash>060c74bc822f5c15526e02320e2381bd</Hash>
</Codenesium>*/