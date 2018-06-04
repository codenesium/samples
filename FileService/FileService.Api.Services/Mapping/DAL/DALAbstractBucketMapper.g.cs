using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.Services
{
	public abstract class AbstractDALBucketMapper
	{
		public virtual Bucket MapBOToEF(
			BOBucket bo)
		{
			Bucket efBucket = new Bucket ();

			efBucket.SetProperties(
				bo.ExternalId,
				bo.Id,
				bo.Name);
			return efBucket;
		}

		public virtual BOBucket MapEFToBO(
			Bucket ef)
		{
			if (ef == null)
			{
				return null;
			}

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
    <Hash>7d34a7091d3d0bb8f6cbef873f8914e2</Hash>
</Codenesium>*/