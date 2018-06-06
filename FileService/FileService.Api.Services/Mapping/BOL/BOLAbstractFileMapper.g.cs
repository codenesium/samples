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
			BOFile boFile = new BOFile();

			boFile.SetProperties(
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
			return boFile;
		}

		public virtual ApiFileResponseModel MapBOToModel(
			BOFile boFile)
		{
			var model = new ApiFileResponseModel();

			model.SetProperties(boFile.BucketId, boFile.DateCreated, boFile.Description, boFile.Expiration, boFile.Extension, boFile.ExternalId, boFile.FileSizeInBytes, boFile.FileTypeId, boFile.Id, boFile.Location, boFile.PrivateKey, boFile.PublicKey);

			return model;
		}

		public virtual List<ApiFileResponseModel> MapBOToModel(
			List<BOFile> items)
		{
			List<ApiFileResponseModel> response = new List<ApiFileResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ffa259e20d69ba8104fa8c4b452a363a</Hash>
</Codenesium>*/