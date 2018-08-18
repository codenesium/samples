using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IBOLStudentMapper
	{
		BOStudent MapModelToBO(
			int id,
			ApiStudentRequestModel model);

		ApiStudentResponseModel MapBOToModel(
			BOStudent boStudent);

		List<ApiStudentResponseModel> MapBOToModel(
			List<BOStudent> items);
	}
}

/*<Codenesium>
    <Hash>051422dd79121df64948cde958086181</Hash>
</Codenesium>*/