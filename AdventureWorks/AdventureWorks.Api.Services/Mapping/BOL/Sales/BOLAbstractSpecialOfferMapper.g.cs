using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractSpecialOfferMapper
	{
		public virtual BOSpecialOffer MapModelToBO(
			int specialOfferID,
			ApiSpecialOfferServerRequestModel model
			)
		{
			BOSpecialOffer boSpecialOffer = new BOSpecialOffer();
			boSpecialOffer.SetProperties(
				specialOfferID,
				model.Category,
				model.Description,
				model.DiscountPct,
				model.EndDate,
				model.MaxQty,
				model.MinQty,
				model.ModifiedDate,
				model.Rowguid,
				model.StartDate,
				model.Type);
			return boSpecialOffer;
		}

		public virtual ApiSpecialOfferServerResponseModel MapBOToModel(
			BOSpecialOffer boSpecialOffer)
		{
			var model = new ApiSpecialOfferServerResponseModel();

			model.SetProperties(boSpecialOffer.SpecialOfferID, boSpecialOffer.Category, boSpecialOffer.Description, boSpecialOffer.DiscountPct, boSpecialOffer.EndDate, boSpecialOffer.MaxQty, boSpecialOffer.MinQty, boSpecialOffer.ModifiedDate, boSpecialOffer.Rowguid, boSpecialOffer.StartDate, boSpecialOffer.Type);

			return model;
		}

		public virtual List<ApiSpecialOfferServerResponseModel> MapBOToModel(
			List<BOSpecialOffer> items)
		{
			List<ApiSpecialOfferServerResponseModel> response = new List<ApiSpecialOfferServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>dcb3354b4cd87204928edac87481487c</Hash>
</Codenesium>*/