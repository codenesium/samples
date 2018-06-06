using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public interface IBOLFamilyMapper
	{
		BOFamily MapModelToBO(
			int id,
			ApiFamilyRequestModel model);

		ApiFamilyResponseModel MapBOToModel(
			BOFamily boFamily);

		List<ApiFamilyResponseModel> MapBOToModel(
			List<BOFamily> items);
	}
}

/*<Codenesium>
    <Hash>0bc4f80f5bdd291709e4fce3b022a262</Hash>
</Codenesium>*/