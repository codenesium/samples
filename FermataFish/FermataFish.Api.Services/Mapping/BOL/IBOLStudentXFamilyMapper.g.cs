using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IBOLStudentXFamilyMapper
	{
		BOStudentXFamily MapModelToBO(
			int id,
			ApiStudentXFamilyRequestModel model);

		ApiStudentXFamilyResponseModel MapBOToModel(
			BOStudentXFamily boStudentXFamily);

		List<ApiStudentXFamilyResponseModel> MapBOToModel(
			List<BOStudentXFamily> items);
	}
}

/*<Codenesium>
    <Hash>9f1508bfe1a7da403b0de17474aef496</Hash>
</Codenesium>*/