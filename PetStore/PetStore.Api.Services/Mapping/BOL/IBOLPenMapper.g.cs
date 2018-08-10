using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public partial interface IBOLPenMapper
	{
		BOPen MapModelToBO(
			int id,
			ApiPenRequestModel model);

		ApiPenResponseModel MapBOToModel(
			BOPen boPen);

		List<ApiPenResponseModel> MapBOToModel(
			List<BOPen> items);
	}
}

/*<Codenesium>
    <Hash>5bef05b98fcbaf952b429c6c094919fc</Hash>
</Codenesium>*/