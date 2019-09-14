using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IDALPersonMapper
	{
		Person MapModelToEntity(
			int personId,
			ApiPersonServerRequestModel model);

		ApiPersonServerResponseModel MapEntityToModel(
			Person item);

		List<ApiPersonServerResponseModel> MapEntityToModel(
			List<Person> items);
	}
}

/*<Codenesium>
    <Hash>74c72cf8396e0960a95fd57d766ae9ee</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/