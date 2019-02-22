using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALOfficerMapper
	{
		Officer MapModelToEntity(
			int id,
			ApiOfficerServerRequestModel model);

		ApiOfficerServerResponseModel MapEntityToModel(
			Officer item);

		List<ApiOfficerServerResponseModel> MapEntityToModel(
			List<Officer> items);
	}
}

/*<Codenesium>
    <Hash>9efdaeb5375cc62c26f04f4826ae05e1</Hash>
</Codenesium>*/