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
    <Hash>78be3511896f652d3e6d60570b304bda</Hash>
</Codenesium>*/