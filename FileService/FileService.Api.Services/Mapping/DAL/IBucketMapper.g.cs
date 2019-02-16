using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public partial interface IDALBucketMapper
	{
		Bucket MapModelToEntity(
			int id,
			ApiBucketServerRequestModel model);

		ApiBucketServerResponseModel MapEntityToModel(
			Bucket item);

		List<ApiBucketServerResponseModel> MapEntityToModel(
			List<Bucket> items);
	}
}

/*<Codenesium>
    <Hash>382f0a350dd1b28dee5d66199fb026f3</Hash>
</Codenesium>*/