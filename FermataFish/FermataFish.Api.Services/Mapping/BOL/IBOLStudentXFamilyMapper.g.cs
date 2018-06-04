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
			List<BOStudentXFamily> bos);
	}
}

/*<Codenesium>
    <Hash>2ddc6f79dfe0582bc34218ffc82a86e8</Hash>
</Codenesium>*/