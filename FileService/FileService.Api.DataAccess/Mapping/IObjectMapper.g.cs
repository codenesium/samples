using System;
using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.DataAccess
{
	public interface IObjectMapper
	{
		void BucketMapModelToEF(
			int id,
			BucketModel model,
			EFBucket efBucket);

		void BucketMapEFToPOCO(
			EFBucket efBucket,
			ApiResponse response);

		void FileMapModelToEF(
			int id,
			FileModel model,
			EFFile efFile);

		void FileMapEFToPOCO(
			EFFile efFile,
			ApiResponse response);

		void FileTypeMapModelToEF(
			int id,
			FileTypeModel model,
			EFFileType efFileType);

		void FileTypeMapEFToPOCO(
			EFFileType efFileType,
			ApiResponse response);
	}
}

/*<Codenesium>
    <Hash>44f0765c20dd6536756fcd70e0a2c5ce</Hash>
</Codenesium>*/