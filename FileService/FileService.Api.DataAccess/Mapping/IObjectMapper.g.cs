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

		POCOBucket BucketMapEFToPOCO(
			EFBucket efBucket);

		void FileMapModelToEF(
			int id,
			FileModel model,
			EFFile efFile);

		POCOFile FileMapEFToPOCO(
			EFFile efFile);

		void FileTypeMapModelToEF(
			int id,
			FileTypeModel model,
			EFFileType efFileType);

		POCOFileType FileTypeMapEFToPOCO(
			EFFileType efFileType);

		void VersionInfoMapModelToEF(
			long version,
			VersionInfoModel model,
			EFVersionInfo efVersionInfo);

		POCOVersionInfo VersionInfoMapEFToPOCO(
			EFVersionInfo efVersionInfo);
	}
}

/*<Codenesium>
    <Hash>fa68e23cc0fe87c107195428dd74df26</Hash>
</Codenesium>*/