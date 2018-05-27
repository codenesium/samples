using System;
using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.DataAccess
{
	public abstract class AbstractDALFileMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOFile dto,
			File efFile)
		{
			efFile.SetProperties(
				id,
				dto.BucketId,
				dto.DateCreated,
				dto.Description,
				dto.Expiration,
				dto.Extension,
				dto.ExternalId,
				dto.FileSizeInBytes,
				dto.FileTypeId,
				dto.Location,
				dto.PrivateKey,
				dto.PublicKey);
		}

		public virtual DTOFile MapEFToDTO(
			File ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOFile();

			dto.SetProperties(
				ef.Id,
				ef.BucketId,
				ef.DateCreated,
				ef.Description,
				ef.Expiration,
				ef.Extension,
				ef.ExternalId,
				ef.FileSizeInBytes,
				ef.FileTypeId,
				ef.Location,
				ef.PrivateKey,
				ef.PublicKey);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>669cd087b45f3bdea266169b84c21019</Hash>
</Codenesium>*/