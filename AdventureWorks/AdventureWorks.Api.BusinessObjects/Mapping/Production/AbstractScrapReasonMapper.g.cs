using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLScrapReasonMapper
	{
		public virtual DTOScrapReason MapModelToDTO(
			short scrapReasonID,
			ApiScrapReasonRequestModel model
			)
		{
			DTOScrapReason dtoScrapReason = new DTOScrapReason();

			dtoScrapReason.SetProperties(
				scrapReasonID,
				model.ModifiedDate,
				model.Name);
			return dtoScrapReason;
		}

		public virtual ApiScrapReasonResponseModel MapDTOToModel(
			DTOScrapReason dtoScrapReason)
		{
			if (dtoScrapReason == null)
			{
				return null;
			}

			var model = new ApiScrapReasonResponseModel();

			model.SetProperties(dtoScrapReason.ModifiedDate, dtoScrapReason.Name, dtoScrapReason.ScrapReasonID);

			return model;
		}

		public virtual List<ApiScrapReasonResponseModel> MapDTOToModel(
			List<DTOScrapReason> dtos)
		{
			List<ApiScrapReasonResponseModel> response = new List<ApiScrapReasonResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5cf15a769815b462c828492d659c272f</Hash>
</Codenesium>*/