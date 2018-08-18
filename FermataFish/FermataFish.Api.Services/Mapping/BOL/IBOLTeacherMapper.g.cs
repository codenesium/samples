using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IBOLTeacherMapper
	{
		BOTeacher MapModelToBO(
			int id,
			ApiTeacherRequestModel model);

		ApiTeacherResponseModel MapBOToModel(
			BOTeacher boTeacher);

		List<ApiTeacherResponseModel> MapBOToModel(
			List<BOTeacher> items);
	}
}

/*<Codenesium>
    <Hash>a679f9f79dcf49534b30b1b71a4759bf</Hash>
</Codenesium>*/