using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public partial interface IBOLBucketMapper
	{
		BOBucket MapModelToBO(
			int id,
			ApiBucketRequestModel model);

		ApiBucketResponseModel MapBOToModel(
			BOBucket boBucket);

		List<ApiBucketResponseModel> MapBOToModel(
			List<BOBucket> items);
	}
}

/*<Codenesium>
    <Hash>18fb93de4452fe5c87e9319c032a8da1</Hash>
</Codenesium>*/