using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
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
    <Hash>b13df9927037921c3ab2f6f445a7e8af</Hash>
</Codenesium>*/