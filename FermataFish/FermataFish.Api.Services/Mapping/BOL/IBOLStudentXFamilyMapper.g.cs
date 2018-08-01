using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>fd7a329de8e3f7a824db5e4ab3d9bc53</Hash>
</Codenesium>*/