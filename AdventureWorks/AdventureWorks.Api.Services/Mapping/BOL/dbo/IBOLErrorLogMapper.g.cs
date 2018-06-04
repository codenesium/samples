using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLErrorLogMapper
	{
		BOErrorLog MapModelToBO(
			int errorLogID,
			ApiErrorLogRequestModel model);

		ApiErrorLogResponseModel MapBOToModel(
			BOErrorLog boErrorLog);

		List<ApiErrorLogResponseModel> MapBOToModel(
			List<BOErrorLog> bos);
	}
}

/*<Codenesium>
    <Hash>0c320dc6f4971d03d04ed8eaed912634</Hash>
</Codenesium>*/