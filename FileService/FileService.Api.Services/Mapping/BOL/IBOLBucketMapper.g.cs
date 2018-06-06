using System;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
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
    <Hash>c561d4f3329c1b960ce85d612221b419</Hash>
</Codenesium>*/