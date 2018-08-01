using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
			List<BOStudent> items);
	}
}

/*<Codenesium>
    <Hash>0bfe488f3f94d5dfa0b02ba25dbf6f61</Hash>
</Codenesium>*/