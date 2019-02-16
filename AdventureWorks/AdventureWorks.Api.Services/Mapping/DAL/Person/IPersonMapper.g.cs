using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALPersonMapper
	{
		Person MapModelToBO(
			int businessEntityID,
			ApiPersonServerRequestModel model);

		ApiPersonServerResponseModel MapBOToModel(
			Person item);

		List<ApiPersonServerResponseModel> MapBOToModel(
			List<Person> items);
	}
}

/*<Codenesium>
    <Hash>9243e0638c306d91d7bd618f64a644fc</Hash>
</Codenesium>*/