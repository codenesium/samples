using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>7ba028c51d4af28aa8fb198eb22ed7a5</Hash>
</Codenesium>*/