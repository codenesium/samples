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

		public virtual void BucketMapEFToPOCO(
			EFBucket efBucket,
			ApiResponse response)
		{
			if (efBucket == null)
			{
				return;
			}

			response.AddBucket(new POCOBucket(efBucket.ExternalId, efBucket.Id, efBucket.Name));
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

		public virtual void FileMapEFToPOCO(
			EFFile efFile,
			ApiResponse response)
		{
			if (efFile == null)
			{
				return;
			}

			response.AddFile(new POCOFile(efFile.BucketId, efFile.DateCreated, efFile.Description, efFile.Expiration, efFile.Extension, efFile.ExternalId, efFile.FileSizeInBytes, efFile.FileTypeId, efFile.Id, efFile.Location, efFile.PrivateKey, efFile.PublicKey));

			this.BucketMapEFToPOCO(efFile.Bucket, response);

			this.FileTypeMapEFToPOCO(efFile.FileType, response);
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

		public virtual void FileTypeMapEFToPOCO(
			EFFileType efFileType,
			ApiResponse response)
		{
			if (efFileType == null)
			{
				return;
			}

			response.AddFileType(new POCOFileType(efFileType.Id, efFileType.Name));
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

		public virtual void VersionInfoMapEFToPOCO(
			EFVersionInfo efVersionInfo,
			ApiResponse response)
		{
			if (efVersionInfo == null)
			{
				return;
			}

			response.AddVersionInfo(new POCOVersionInfo(efVersionInfo.AppliedOn, efVersionInfo.Description, efVersionInfo.Version));
		}
	}
}

/*<Codenesium>
    <Hash>434a65a65327d6d70e74014f4a109fab</Hash>
</Codenesium>*/