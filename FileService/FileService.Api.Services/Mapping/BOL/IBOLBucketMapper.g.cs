using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public interface IBOLBucketMapper
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
    <Hash>f9c9f4a3c4f3d641b379699f79bc0f50</Hash>
</Codenesium>*/