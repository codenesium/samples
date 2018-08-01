using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public interface IBOLTeacherMapper
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
    <Hash>e3b859fbb0ea3e6a6b144452ff713c28</Hash>
</Codenesium>*/