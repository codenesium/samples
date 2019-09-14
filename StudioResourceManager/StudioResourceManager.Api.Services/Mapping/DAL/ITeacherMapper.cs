using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IDALTeacherMapper
	{
		Teacher MapModelToEntity(
			int id,
			ApiTeacherServerRequestModel model);

		ApiTeacherServerResponseModel MapEntityToModel(
			Teacher item);

		List<ApiTeacherServerResponseModel> MapEntityToModel(
			List<Teacher> items);
	}
}

/*<Codenesium>
    <Hash>e80c426ef194e3509d94b054251480d5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/