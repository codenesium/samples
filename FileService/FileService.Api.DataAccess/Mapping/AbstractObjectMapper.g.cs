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
				model.Name,
				model.ExternalId);
		}

		public virtual void BucketMapEFToPOCO(
			EFBucket efBucket,
			ApiResponse response)
		{
			if (efBucket == null)
			{
				return;
			}

			response.AddBucket(new POCOBucket(efBucket.Id, efBucket.Name, efBucket.ExternalId));
		}

		public virtual void FileMapModelToEF(
			int id,
			FileModel model,
			EFFile efFile)
		{
			efFile.SetProperties(
				id,
				model.ExternalId,
				model.PrivateKey,
				model.PublicKey,
				model.Location,
				model.Expiration,
				model.Extension,
				model.DateCreated,
				model.FileSizeInBytes,
				model.FileTypeId,
				model.BucketId,
				model.Description);
		}

		public virtual void FileMapEFToPOCO(
			EFFile efFile,
			ApiResponse response)
		{
			if (efFile == null)
			{
				return;
			}

			response.AddFile(new POCOFile(efFile.Id, efFile.ExternalId, efFile.PrivateKey, efFile.PublicKey, efFile.Location, efFile.Expiration, efFile.Extension, efFile.DateCreated, efFile.FileSizeInBytes, efFile.FileTypeId, efFile.BucketId, efFile.Description));

			this.FileTypeMapEFToPOCO(efFile.FileType, response);

			this.BucketMapEFToPOCO(efFile.Bucket, response);
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
	}
}

/*<Codenesium>
    <Hash>3ee84ecf1935ac5d89b4e523564c24ab</Hash>
</Codenesium>*/