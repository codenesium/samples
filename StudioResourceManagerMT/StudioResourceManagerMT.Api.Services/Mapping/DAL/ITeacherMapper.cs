using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>d905ce50d8f714b34351a1afe209fd75</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/