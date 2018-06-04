using System;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.Services
{
	public abstract class BOLAbstractFileTypeMapper
	{
		public virtual BOFileType MapModelToBO(
			int id,
			ApiFileTypeRequestModel model
			)
		{
			BOFileType BOFileType = new BOFileType();

			BOFileType.SetProperties(
				id,
				model.Name);
			return BOFileType;
		}

		public virtual ApiFileTypeResponseModel MapBOToModel(
			BOFileType BOFileType)
		{
			if (BOFileType == null)
			{
				return null;
			}

			var model = new ApiFileTypeResponseModel();

			model.SetProperties(BOFileType.Id, BOFileType.Name);

			return model;
		}

		public virtual List<ApiFileTypeResponseModel> MapBOToModel(
			List<BOFileType> BOs)
		{
			List<ApiFileTypeResponseModel> response = new List<ApiFileTypeResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2d83858115131db9b494f5b204b3f114</Hash>
</Codenesium>*/