using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractStudioMapper
	{
		public virtual BOStudio MapModelToBO(
			int id,
			ApiStudioServerRequestModel model
			)
		{
			BOStudio boStudio = new BOStudio();
			boStudio.SetProperties(
				id,
				model.Address1,
				model.Address2,
				model.City,
				model.Name,
				model.Province,
				model.Website,
				model.Zip);
			return boStudio;
		}

		public virtual ApiStudioServerResponseModel MapBOToModel(
			BOStudio boStudio)
		{
			var model = new ApiStudioServerResponseModel();

			model.SetProperties(boStudio.Id, boStudio.Address1, boStudio.Address2, boStudio.City, boStudio.Name, boStudio.Province, boStudio.Website, boStudio.Zip);

			return model;
		}

		public virtual List<ApiStudioServerResponseModel> MapBOToModel(
			List<BOStudio> items)
		{
			List<ApiStudioServerResponseModel> response = new List<ApiStudioServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>690b3f240b65260f826b21b783bdeba9</Hash>
</Codenesium>*/