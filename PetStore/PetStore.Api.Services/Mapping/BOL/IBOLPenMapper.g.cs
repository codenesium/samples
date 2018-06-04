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
			List<BOPen> bos);
	}
}

/*<Codenesium>
    <Hash>26add6a552354552b641a32c4583aeba</Hash>
</Codenesium>*/