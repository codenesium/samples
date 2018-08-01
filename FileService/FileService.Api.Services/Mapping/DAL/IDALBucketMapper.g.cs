using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public interface IDALBucketMapper
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
    <Hash>29e63051d291860befa98fb57e134c63</Hash>
</Codenesium>*/