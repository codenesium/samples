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
    <Hash>04b02729f1dc84539946fdf803fc6583</Hash>
</Codenesium>*/