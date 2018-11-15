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
			ApiPenServerRequestModel model);

		ApiPenServerResponseModel MapBOToModel(
			BOPen boPen);

		List<ApiPenServerResponseModel> MapBOToModel(
			List<BOPen> items);
	}
}

/*<Codenesium>
    <Hash>fdf484c63fe59630f6dd46f9578e5d5e</Hash>
</Codenesium>*/