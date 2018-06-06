using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.Services
{
	public interface IBOLPenMapper
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
    <Hash>99eed9eceb0682d792001fbbe30ffffd</Hash>
</Codenesium>*/