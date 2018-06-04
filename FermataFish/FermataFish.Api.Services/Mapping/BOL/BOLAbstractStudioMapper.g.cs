using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public abstract class BOLAbstractStudioMapper
	{
		public virtual BOStudio MapModelToBO(
			int id,
			ApiStudioRequestModel model
			)
		{
			BOStudio BOStudio = new BOStudio();

			BOStudio.SetProperties(
				id,
				model.Address1,
				model.Address2,
				model.City,
				model.Name,
				model.StateId,
				model.Website,
				model.Zip);
			return BOStudio;
		}

		public virtual ApiStudioResponseModel MapBOToModel(
			BOStudio BOStudio)
		{
			if (BOStudio == null)
			{
				return null;
			}

			var model = new ApiStudioResponseModel();

			model.SetProperties(BOStudio.Address1, BOStudio.Address2, BOStudio.City, BOStudio.Id, BOStudio.Name, BOStudio.StateId, BOStudio.Website, BOStudio.Zip);

			return model;
		}

		public virtual List<ApiStudioResponseModel> MapBOToModel(
			List<BOStudio> BOs)
		{
			List<ApiStudioResponseModel> response = new List<ApiStudioResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9897933eae26d3efd46576e9ee7d7549</Hash>
</Codenesium>*/