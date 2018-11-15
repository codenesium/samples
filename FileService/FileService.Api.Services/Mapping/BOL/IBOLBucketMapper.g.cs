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
			ApiBucketServerRequestModel model);

		ApiBucketServerResponseModel MapBOToModel(
			BOBucket boBucket);

		List<ApiBucketServerResponseModel> MapBOToModel(
			List<BOBucket> items);
	}
}

/*<Codenesium>
    <Hash>64162a457bca7b26cf6a2cf0c1ff3d07</Hash>
</Codenesium>*/