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
			Bucket efBucket);

		POCOBucket BucketMapEFToPOCO(
			Bucket efBucket);

		void FileMapModelToEF(
			int id,
			FileModel model,
			File efFile);

		POCOFile FileMapEFToPOCO(
			File efFile);

		void FileTypeMapModelToEF(
			int id,
			FileTypeModel model,
			FileType efFileType);

		POCOFileType FileTypeMapEFToPOCO(
			FileType efFileType);

		void VersionInfoMapModelToEF(
			long version,
			VersionInfoModel model,
			VersionInfo efVersionInfo);

		POCOVersionInfo VersionInfoMapEFToPOCO(
			VersionInfo efVersionInfo);
	}
}

/*<Codenesium>
    <Hash>22e210f17bfd6eead0a3b0c4e6fd526a</Hash>
</Codenesium>*/