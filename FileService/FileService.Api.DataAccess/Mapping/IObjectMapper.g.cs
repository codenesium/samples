using System;
using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.DataAccess
{
	public interface IObjectMapper
	{
		void BucketMapModelToEF(
			int id,
			ApiBucketModel model,
			Bucket efBucket);

		POCOBucket BucketMapEFToPOCO(
			Bucket efBucket);

		void FileMapModelToEF(
			int id,
			ApiFileModel model,
			File efFile);

		POCOFile FileMapEFToPOCO(
			File efFile);

		void FileTypeMapModelToEF(
			int id,
			ApiFileTypeModel model,
			FileType efFileType);

		POCOFileType FileTypeMapEFToPOCO(
			FileType efFileType);

		void VersionInfoMapModelToEF(
			long version,
			ApiVersionInfoModel model,
			VersionInfo efVersionInfo);

		POCOVersionInfo VersionInfoMapEFToPOCO(
			VersionInfo efVersionInfo);
	}
}

/*<Codenesium>
    <Hash>7286805134bc66cf78c39fa85401650e</Hash>
</Codenesium>*/