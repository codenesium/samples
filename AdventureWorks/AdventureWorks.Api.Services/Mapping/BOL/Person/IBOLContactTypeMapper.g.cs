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
			ApiContactTypeRequestModel model);

		ApiContactTypeResponseModel MapBOToModel(
			BOContactType boContactType);

		List<ApiContactTypeResponseModel> MapBOToModel(
			List<BOContactType> items);
	}
}

/*<Codenesium>
    <Hash>637d29b861a9747e0c2e0f6ac77b3a0e</Hash>
</Codenesium>*/