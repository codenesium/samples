using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IDALEventStudentMapper
	{
		EventStudent MapModelToEntity(
			int id,
			ApiEventStudentServerRequestModel model);

		ApiEventStudentServerResponseModel MapEntityToModel(
			EventStudent item);

		List<ApiEventStudentServerResponseModel> MapEntityToModel(
			List<EventStudent> items);
	}
}

/*<Codenesium>
    <Hash>7ba550b377087990d6e641a92c2497fc</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/