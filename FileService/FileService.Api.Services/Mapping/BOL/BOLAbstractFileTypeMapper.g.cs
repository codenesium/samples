using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public abstract class BOLAbstractFileTypeMapper
	{
		public virtual BOFileType MapModelToBO(
			int id,
			ApiFileTypeServerRequestModel model
			)
		{
			BOFileType boFileType = new BOFileType();
			boFileType.SetProperties(
				id,
				model.Name);
			return boFileType;
		}

		public virtual ApiFileTypeServerResponseModel MapBOToModel(
			BOFileType boFileType)
		{
			var model = new ApiFileTypeServerResponseModel();

			model.SetProperties(boFileType.Id, boFileType.Name);

			return model;
		}

		public virtual List<ApiFileTypeServerResponseModel> MapBOToModel(
			List<BOFileType> items)
		{
			List<ApiFileTypeServerResponseModel> response = new List<ApiFileTypeServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>cf7d9e7e7da94b7189acddf00d37a52f</Hash>
</Codenesium>*/