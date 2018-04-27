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

		void VersionInfoMapModelToEF(
			long version,
			VersionInfoModel model,
			EFVersionInfo efVersionInfo);

		void VersionInfoMapEFToPOCO(
			EFVersionInfo efVersionInfo,
			ApiResponse response);
	}
}

/*<Codenesium>
    <Hash>57046c0661ace6eba741ef35d137ab96</Hash>
</Codenesium>*/