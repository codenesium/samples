using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
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
    <Hash>c5ca07f39bde8e28cf04cc76578aca60</Hash>
</Codenesium>*/