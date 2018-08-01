using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public abstract class BOLAbstractPenMapper
	{
		public virtual BOPen MapModelToBO(
			int id,
			ApiPenRequestModel model
			)
		{
			BOPen boPen = new BOPen();
			boPen.SetProperties(
				id,
				model.Name);
			return boPen;
		}

		public virtual ApiPenResponseModel MapBOToModel(
			BOPen boPen)
		{
			var model = new ApiPenResponseModel();

			model.SetProperties(boPen.Id, boPen.Name);

			return model;
		}

		public virtual List<ApiPenResponseModel> MapBOToModel(
			List<BOPen> items)
		{
			List<ApiPenResponseModel> response = new List<ApiPenResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a04a650fce63699eb40ee43d2201ff24</Hash>
</Codenesium>*/