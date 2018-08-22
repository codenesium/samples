using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
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
				model.Zip);
			return boStudio;
		}

		public virtual ApiStudioResponseModel MapBOToModel(
			BOStudio boStudio)
		{
			var model = new ApiStudioResponseModel();

			model.SetProperties(boStudio.Id, boStudio.Address1, boStudio.Address2, boStudio.City, boStudio.Name, boStudio.Province, boStudio.Website, boStudio.Zip);

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
    <Hash>ada0f1a62fd9b017b314a808842985e7</Hash>
</Codenesium>*/