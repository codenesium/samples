using System;
using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.DataAccess
{
	public abstract class AbstractObjectMapper
	{
		public virtual void BucketMapModelToEF(
			int id,
			ApiBucketModel model,
			Bucket efBucket)
		{
			efBucket.SetProperties(
				id,
				model.ExternalId,
				model.Name);
		}

		public virtual POCOBucket BucketMapEFToPOCO(
			Bucket efBucket)
		{
			if (efBucket == null)
			{
				return null;
			}

			return new POCOBucket(efBucket.ExternalId, efBucket.Id, efBucket.Name);
		}

		public virtual void FileMapModelToEF(
			int id,
			ApiFileModel model,
			File efFile)
		{
			efFile.SetProperties(
				id,
				model.BucketId,
				model.DateCreated,
				model.Description,
				model.Expiration,
				model.Extension,
				model.ExternalId,
				model.FileSizeInBytes,
				model.FileTypeId,
				model.Location,
				model.PrivateKey,
				model.PublicKey);
		}

		public virtual POCOFile FileMapEFToPOCO(
			File efFile)
		{
			if (efFile == null)
			{
				return null;
			}

			return new POCOFile(efFile.BucketId, efFile.DateCreated, efFile.Description, efFile.Expiration, efFile.Extension, efFile.ExternalId, efFile.FileSizeInBytes, efFile.FileTypeId, efFile.Id, efFile.Location, efFile.PrivateKey, efFile.PublicKey);
		}

		public virtual void FileTypeMapModelToEF(
			int id,
			ApiFileTypeModel model,
			FileType efFileType)
		{
			efFileType.SetProperties(
				id,
				model.Name);
		}

		public virtual POCOFileType FileTypeMapEFToPOCO(
			FileType efFileType)
		{
			if (efFileType == null)
			{
				return null;
			}

			return new POCOFileType(efFileType.Id, efFileType.Name);
		}

		public virtual void VersionInfoMapModelToEF(
			long version,
			ApiVersionInfoModel model,
			VersionInfo efVersionInfo)
		{
			efVersionInfo.SetProperties(
				version,
				model.AppliedOn,
				model.Description);
		}

		public virtual POCOVersionInfo VersionInfoMapEFToPOCO(
			VersionInfo efVersionInfo)
		{
			if (efVersionInfo == null)
			{
				return null;
			}

			return new POCOVersionInfo(efVersionInfo.AppliedOn, efVersionInfo.Description, efVersionInfo.Version);
		}
	}
}

/*<Codenesium>
    <Hash>1168b09271e94862cac9cf516b1d109d</Hash>
</Codenesium>*/