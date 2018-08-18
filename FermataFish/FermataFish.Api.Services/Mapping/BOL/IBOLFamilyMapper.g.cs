using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IBOLFamilyMapper
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
    <Hash>360cff2781acb01a1fd7b5ddd83b0a8e</Hash>
</Codenesium>*/