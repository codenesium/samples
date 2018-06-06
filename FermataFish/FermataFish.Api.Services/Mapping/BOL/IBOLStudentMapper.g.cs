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
			List<BOStudent> items);
	}
}

/*<Codenesium>
    <Hash>c5e8485db6d70ffeacefcec7faa2b366</Hash>
</Codenesium>*/