using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLSpecialOfferMapper
	{
		public virtual DTOSpecialOffer MapModelToDTO(
			int specialOfferID,
			ApiSpecialOfferRequestModel model
			)
		{
			DTOSpecialOffer dtoSpecialOffer = new DTOSpecialOffer();

			dtoSpecialOffer.SetProperties(
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
			return dtoSpecialOffer;
		}

		public virtual ApiSpecialOfferResponseModel MapDTOToModel(
			DTOSpecialOffer dtoSpecialOffer)
		{
			if (dtoSpecialOffer == null)
			{
				return null;
			}

			var model = new ApiSpecialOfferResponseModel();

			model.SetProperties(dtoSpecialOffer.Category, dtoSpecialOffer.Description, dtoSpecialOffer.DiscountPct, dtoSpecialOffer.EndDate, dtoSpecialOffer.MaxQty, dtoSpecialOffer.MinQty, dtoSpecialOffer.ModifiedDate, dtoSpecialOffer.Rowguid, dtoSpecialOffer.SpecialOfferID, dtoSpecialOffer.StartDate, dtoSpecialOffer.Type);

			return model;
		}

		public virtual List<ApiSpecialOfferResponseModel> MapDTOToModel(
			List<DTOSpecialOffer> dtos)
		{
			List<ApiSpecialOfferResponseModel> response = new List<ApiSpecialOfferResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>094de59a6019a9b832a94dd77e308e30</Hash>
</Codenesium>*/