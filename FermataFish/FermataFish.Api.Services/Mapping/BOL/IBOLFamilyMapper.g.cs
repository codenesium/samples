using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>9c117e76d933c1ba6ad9b951754ecd9e</Hash>
</Codenesium>*/