using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public interface IBOLStudentMapper
	{
		BOStudent MapModelToBO(
			int id,
			ApiStudentRequestModel model);

		ApiStudentResponseModel MapBOToModel(
			BOStudent boStudent);

		List<ApiStudentResponseModel> MapBOToModel(
			List<BOStudent> bos);
	}
}

/*<Codenesium>
    <Hash>6dc54264455753fcd0d449aebccac35c</Hash>
</Codenesium>*/