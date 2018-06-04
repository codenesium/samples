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
			List<BOTeacher> bos);
	}
}

/*<Codenesium>
    <Hash>4ed2badfc735aaad5a0a85df341e3b5d</Hash>
</Codenesium>*/