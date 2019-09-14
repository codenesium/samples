using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IDALStudentMapper
	{
		Student MapModelToEntity(
			int id,
			ApiStudentServerRequestModel model);

		ApiStudentServerResponseModel MapEntityToModel(
			Student item);

		List<ApiStudentServerResponseModel> MapEntityToModel(
			List<Student> items);
	}
}

/*<Codenesium>
    <Hash>525d92df44c722a88bc8d80f7a2eb65b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/