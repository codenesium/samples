using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLBusinessEntityMapper
	{
		BOBusinessEntity MapModelToBO(
			int businessEntityID,
			ApiBusinessEntityRequestModel model);

		ApiBusinessEntityResponseModel MapBOToModel(
			BOBusinessEntity boBusinessEntity);

		List<ApiBusinessEntityResponseModel> MapBOToModel(
			List<BOBusinessEntity> items);
	}
}

/*<Codenesium>
    <Hash>2d54038f4d8bd23b3b9a90d3aa125f82</Hash>
</Codenesium>*/