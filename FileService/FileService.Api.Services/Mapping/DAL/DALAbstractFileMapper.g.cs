using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public abstract class DALAbstractFileMapper
	{
		public virtual File MapBOToEF(
			BOFile bo)
		{
			File efFile = new File();
			efFile.SetProperties(
				bo.BucketId,
				bo.DateCreated,
				bo.Description,
				bo.Expiration,
				bo.Extension,
				bo.ExternalId,
				bo.FileSizeInByte,
				bo.FileTypeId,
				bo.Id,
				bo.Location,
				bo.PrivateKey,
				bo.PublicKey);
			return efFile;
		}

		public virtual BOFile MapEFToBO(
			File ef)
		{
			var bo = new BOFile();

			bo.SetProperties(
				ef.Id,
				ef.BucketId,
				ef.DateCreated,
				ef.Description,
				ef.Expiration,
				ef.Extension,
				ef.ExternalId,
				ef.FileSizeInByte,
				ef.FileTypeId,
				ef.Location,
				ef.PrivateKey,
				ef.PublicKey);
			return bo;
		}

		public virtual List<BOFile> MapEFToBO(
			List<File> records)
		{
			List<BOFile> response = new List<BOFile>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>878cbfa120da3bc59d0c3207e913627e</Hash>
</Codenesium>*/