using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALCallAssignmentMapper
	{
		CallAssignment MapModelToEntity(
			int id,
			ApiCallAssignmentServerRequestModel model);

		ApiCallAssignmentServerResponseModel MapEntityToModel(
			CallAssignment item);

		List<ApiCallAssignmentServerResponseModel> MapEntityToModel(
			List<CallAssignment> items);
	}
}

/*<Codenesium>
    <Hash>32c222e63b4d86f2ecc480c23c6306a5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/