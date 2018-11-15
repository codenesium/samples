using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public abstract class BOLAbstractPenMapper
	{
		public virtual BOPen MapModelToBO(
			int id,
			ApiPenServerRequestModel model
			)
		{
			BOPen boPen = new BOPen();
			boPen.SetProperties(
				id,
				model.Name);
			return boPen;
		}

		public virtual ApiPenServerResponseModel MapBOToModel(
			BOPen boPen)
		{
			var model = new ApiPenServerResponseModel();

			model.SetProperties(boPen.Id, boPen.Name);

			return model;
		}

		public virtual List<ApiPenServerResponseModel> MapBOToModel(
			List<BOPen> items)
		{
			List<ApiPenServerResponseModel> response = new List<ApiPenServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>227a6252a0bf2f8801811d67ee4c6daf</Hash>
</Codenesium>*/