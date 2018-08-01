using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public interface IBOLPersonMapper
	{
		BOPerson MapModelToBO(
			int personId,
			ApiPersonRequestModel model);

		ApiPersonResponseModel MapBOToModel(
			BOPerson boPerson);

		List<ApiPersonResponseModel> MapBOToModel(
			List<BOPerson> items);
	}
}

/*<Codenesium>
    <Hash>351baf7c73083be802b0c0902eaf12f2</Hash>
</Codenesium>*/