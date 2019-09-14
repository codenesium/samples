using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALPersonMapper
	{
		Person MapModelToEntity(
			int id,
			ApiPersonServerRequestModel model);

		ApiPersonServerResponseModel MapEntityToModel(
			Person item);

		List<ApiPersonServerResponseModel> MapEntityToModel(
			List<Person> items);
	}
}

/*<Codenesium>
    <Hash>6039d5bd234f610771e1395395871cb5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/