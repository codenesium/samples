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
    <Hash>015e8f708b1828abb0486a4654a598af</Hash>
</Codenesium>*/