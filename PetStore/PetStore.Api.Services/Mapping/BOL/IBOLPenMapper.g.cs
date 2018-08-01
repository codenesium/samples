using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>d6b7980715f8c877dcf7faef247923c8</Hash>
</Codenesium>*/