using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.Services
{
	public abstract class BOLAbstractPenMapper
	{
		public virtual BOPen MapModelToBO(
			int id,
			ApiPenRequestModel model
			)
		{
			BOPen BOPen = new BOPen();

			BOPen.SetProperties(
				id,
				model.Name);
			return BOPen;
		}

		public virtual ApiPenResponseModel MapBOToModel(
			BOPen BOPen)
		{
			if (BOPen == null)
			{
				return null;
			}

			var model = new ApiPenResponseModel();

			model.SetProperties(BOPen.Id, BOPen.Name);

			return model;
		}

		public virtual List<ApiPenResponseModel> MapBOToModel(
			List<BOPen> BOs)
		{
			List<ApiPenResponseModel> response = new List<ApiPenResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>900e38c73c409c1a4c35727d05d65cd6</Hash>
</Codenesium>*/