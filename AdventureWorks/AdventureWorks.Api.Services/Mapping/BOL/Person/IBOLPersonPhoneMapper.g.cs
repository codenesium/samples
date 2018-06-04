using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLPersonPhoneMapper
	{
		BOPersonPhone MapModelToBO(
			int businessEntityID,
			ApiPersonPhoneRequestModel model);

		ApiPersonPhoneResponseModel MapBOToModel(
			BOPersonPhone boPersonPhone);

		List<ApiPersonPhoneResponseModel> MapBOToModel(
			List<BOPersonPhone> bos);
	}
}

/*<Codenesium>
    <Hash>ace3a336c75d6b463d613c86aaf30d65</Hash>
</Codenesium>*/