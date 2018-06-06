using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services
{
	public interface IBOLVersionInfoMapper
	{
		BOVersionInfo MapModelToBO(
			long version,
			ApiVersionInfoRequestModel model);

		ApiVersionInfoResponseModel MapBOToModel(
			BOVersionInfo boVersionInfo);

		List<ApiVersionInfoResponseModel> MapBOToModel(
			List<BOVersionInfo> items);
	}
}

/*<Codenesium>
    <Hash>4a6aef90c3b7af79a866a2e5d425e844</Hash>
</Codenesium>*/