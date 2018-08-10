using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public partial interface IDALBucketMapper
	{
		Bucket MapBOToEF(
			BOBucket bo);

		BOBucket MapEFToBO(
			Bucket efBucket);

		List<BOBucket> MapEFToBO(
			List<Bucket> records);
	}
}

/*<Codenesium>
    <Hash>4db14e129e8729a72af78bdfd9614c1a</Hash>
</Codenesium>*/