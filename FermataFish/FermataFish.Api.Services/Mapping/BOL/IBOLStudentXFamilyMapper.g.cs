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
    <Hash>8fb9e99333be133c1ca4e48774ec8820</Hash>
</Codenesium>*/