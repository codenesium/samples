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
			List<BOBusinessEntity> bos);
	}
}

/*<Codenesium>
    <Hash>d9f7699c90189848291d3f1e567a158f</Hash>
</Codenesium>*/