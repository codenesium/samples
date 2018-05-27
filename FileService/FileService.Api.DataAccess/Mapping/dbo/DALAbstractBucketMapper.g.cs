using System;
using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.DataAccess
{
	public abstract class AbstractDALBucketMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOBucket dto,
			Bucket efBucket)
		{
			efBucket.SetProperties(
				id,
				dto.ExternalId,
				dto.Name);
		}

		public virtual DTOBucket MapEFToDTO(
			Bucket ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOBucket();

			dto.SetProperties(
				ef.Id,
				ef.ExternalId,
				ef.Name);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>a881e9be230c13a46e740845bff1d0fb</Hash>
</Codenesium>*/