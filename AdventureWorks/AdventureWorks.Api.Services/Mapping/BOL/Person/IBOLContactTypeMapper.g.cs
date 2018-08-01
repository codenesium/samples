using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLContactTypeMapper
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
    <Hash>727b46eae242de8aedb460b7fe258bde</Hash>
</Codenesium>*/