using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLStateProvinceMapper
	{
		BOStateProvince MapModelToBO(
			int stateProvinceID,
			ApiStateProvinceRequestModel model);

		ApiStateProvinceResponseModel MapBOToModel(
			BOStateProvince boStateProvince);

		List<ApiStateProvinceResponseModel> MapBOToModel(
			List<BOStateProvince> bos);
	}
}

/*<Codenesium>
    <Hash>985a2f6f0084614f8dadd173074856f7</Hash>
</Codenesium>*/