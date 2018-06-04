using System;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.Services
{
	public abstract class BOLAbstractFileMapper
	{
		public virtual BOFile MapModelToBO(
			int id,
			ApiFileRequestModel model
			)
		{
			BOFile BOFile = new BOFile();

			BOFile.SetProperties(
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
			return BOFile;
		}

		public virtual ApiFileResponseModel MapBOToModel(
			BOFile BOFile)
		{
			if (BOFile == null)
			{
				return null;
			}

			var model = new ApiFileResponseModel();

			model.SetProperties(BOFile.BucketId, BOFile.DateCreated, BOFile.Description, BOFile.Expiration, BOFile.Extension, BOFile.ExternalId, BOFile.FileSizeInBytes, BOFile.FileTypeId, BOFile.Id, BOFile.Location, BOFile.PrivateKey, BOFile.PublicKey);

			return model;
		}

		public virtual List<ApiFileResponseModel> MapBOToModel(
			List<BOFile> BOs)
		{
			List<ApiFileResponseModel> response = new List<ApiFileResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>992d9339ee762766d178efdf22269dc4</Hash>
</Codenesium>*/