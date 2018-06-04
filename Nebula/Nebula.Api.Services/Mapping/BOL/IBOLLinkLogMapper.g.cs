using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services
{
	public interface IBOLLinkLogMapper
	{
		BOLinkLog MapModelToBO(
			int id,
			ApiLinkLogRequestModel model);

		ApiLinkLogResponseModel MapBOToModel(
			BOLinkLog boLinkLog);

		List<ApiLinkLogResponseModel> MapBOToModel(
			List<BOLinkLog> bos);
	}
}

/*<Codenesium>
    <Hash>a538ffac8d9f50ec49321f24168477cd</Hash>
</Codenesium>*/