using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALCallMapper
	{
		Call MapModelToEntity(
			int id,
			ApiCallServerRequestModel model);

		ApiCallServerResponseModel MapEntityToModel(
			Call item);

		List<ApiCallServerResponseModel> MapEntityToModel(
			List<Call> items);
	}
}

/*<Codenesium>
    <Hash>d64a0f890e1e0aac2967b16ab6ea3ca2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/