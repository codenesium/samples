using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public abstract class BOLAbstractFileTypeMapper
	{
		public virtual BOFileType MapModelToBO(
			int id,
			ApiFileTypeRequestModel model
			)
		{
			BOFileType boFileType = new BOFileType();
			boFileType.SetProperties(
				id,
				model.Name);
			return boFileType;
		}

		public virtual ApiFileTypeResponseModel MapBOToModel(
			BOFileType boFileType)
		{
			var model = new ApiFileTypeResponseModel();

			model.SetProperties(boFileType.Id, boFileType.Name);

			return model;
		}

		public virtual List<ApiFileTypeResponseModel> MapBOToModel(
			List<BOFileType> items)
		{
			List<ApiFileTypeResponseModel> response = new List<ApiFileTypeResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fb83da09bd4fea1266d400ed24810f24</Hash>
</Codenesium>*/