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
			List<BOBucket> bos);
	}
}

/*<Codenesium>
    <Hash>9760fadaa87d60c8de7784ece811658b</Hash>
</Codenesium>*/