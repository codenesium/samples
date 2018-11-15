using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public abstract class DALAbstractBucketMapper
	{
		public virtual Bucket MapBOToEF(
			BOBucket bo)
		{
			Bucket efBucket = new Bucket();
			efBucket.SetProperties(
				bo.ExternalId,
				bo.Id,
				bo.Name);
			return efBucket;
		}

		public virtual BOBucket MapEFToBO(
			Bucket ef)
		{
			var bo = new BOBucket();

			bo.SetProperties(
				ef.Id,
				ef.ExternalId,
				ef.Name);
			return bo;
		}

		public virtual List<BOBucket> MapEFToBO(
			List<Bucket> records)
		{
			List<BOBucket> response = new List<BOBucket>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7dbcd6c5498309f088a74170e585d88b</Hash>
</Codenesium>*/