using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractStudioMapper
	{
		public virtual BOStudio MapModelToBO(
			int id,
			ApiStudioRequestModel model
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
				model.Zip,
				model.IsDeleted);
			return boStudio;
		}

		public virtual ApiStudioResponseModel MapBOToModel(
			BOStudio boStudio)
		{
			var model = new ApiStudioResponseModel();

			model.SetProperties(boStudio.Id, boStudio.Address1, boStudio.Address2, boStudio.City, boStudio.Name, boStudio.Province, boStudio.Website, boStudio.Zip, boStudio.IsDeleted);

			return model;
		}

		public virtual List<ApiStudioResponseModel> MapBOToModel(
			List<BOStudio> items)
		{
			List<ApiStudioResponseModel> response = new List<ApiStudioResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9fc191edd94528745f1e2502e900a5c4</Hash>
</Codenesium>*/