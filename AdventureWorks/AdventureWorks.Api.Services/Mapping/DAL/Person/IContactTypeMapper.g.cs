using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALContactTypeMapper
	{
		ContactType MapModelToEntity(
			int contactTypeID,
			ApiContactTypeServerRequestModel model);

		ApiContactTypeServerResponseModel MapEntityToModel(
			ContactType item);

		List<ApiContactTypeServerResponseModel> MapEntityToModel(
			List<ContactType> items);
	}
}

/*<Codenesium>
    <Hash>76ea082a8090f48d689d41003a5b2776</Hash>
</Codenesium>*/