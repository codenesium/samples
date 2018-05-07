using System;
using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.DataAccess
{
	public abstract class AbstractObjectMapper
	{
		public virtual void BucketMapModelToEF(
			int id,
			BucketModel model,
			EFBucket efBucket)
		{
			efBucket.SetProperties(
				id,
				model.ExternalId,
				model.Name);
		}

		public virtual POCOBucket BucketMapEFToPOCO(
			EFBucket efBucket)
		{
			if (efBucket == null)
			{
				return null;
			}

			return new POCOBucket(efBucket.ExternalId, efBucket.Id, efBucket.Name);
		}

		public virtual void FileMapModelToEF(
			int id,
			FileModel model,
			EFFile efFile)
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
			EFFile efFile)
		{
			if (efFile == null)
			{
				return null;
			}

			return new POCOFile(efFile.BucketId, efFile.DateCreated, efFile.Description, efFile.Expiration, efFile.Extension, efFile.ExternalId, efFile.FileSizeInBytes, efFile.FileTypeId, efFile.Id, efFile.Location, efFile.PrivateKey, efFile.PublicKey);
		}

		public virtual void FileTypeMapModelToEF(
			int id,
			FileTypeModel model,
			EFFileType efFileType)
		{
			efFileType.SetProperties(
				id,
				model.Name);
		}

		public virtual POCOFileType FileTypeMapEFToPOCO(
			EFFileType efFileType)
		{
			if (efFileType == null)
			{
				return null;
			}

			return new POCOFileType(efFileType.Id, efFileType.Name);
		}

		public virtual void VersionInfoMapModelToEF(
			long version,
			VersionInfoModel model,
			EFVersionInfo efVersionInfo)
		{
			efVersionInfo.SetProperties(
				version,
				model.AppliedOn,
				model.Description);
		}

		public virtual POCOVersionInfo VersionInfoMapEFToPOCO(
			EFVersionInfo efVersionInfo)
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
    <Hash>9e15e64a7daa02f3fbd70c1858fd112f</Hash>
</Codenesium>*/