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
			List<BOVersionInfo> bos);
	}
}

/*<Codenesium>
    <Hash>727fdffeddcca572181717360db32498</Hash>
</Codenesium>*/