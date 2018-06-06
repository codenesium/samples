using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public interface IBOLStudentXFamilyMapper
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
    <Hash>6b8ff5354ff998d18b78a1138d23f8cf</Hash>
</Codenesium>*/