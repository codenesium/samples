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
			List<BOFamily> bos);
	}
}

/*<Codenesium>
    <Hash>a6e3c1edd83a7efd922f126bed74777c</Hash>
</Codenesium>*/