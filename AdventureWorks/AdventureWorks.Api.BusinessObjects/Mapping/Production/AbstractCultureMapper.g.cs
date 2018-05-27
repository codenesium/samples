using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLCultureMapper
	{
		public virtual DTOCulture MapModelToDTO(
			string cultureID,
			ApiCultureRequestModel model
			)
		{
			DTOCulture dtoCulture = new DTOCulture();

			dtoCulture.SetProperties(
				cultureID,
				model.ModifiedDate,
				model.Name);
			return dtoCulture;
		}

		public virtual ApiCultureResponseModel MapDTOToModel(
			DTOCulture dtoCulture)
		{
			if (dtoCulture == null)
			{
				return null;
			}

			var model = new ApiCultureResponseModel();

			model.SetProperties(dtoCulture.CultureID, dtoCulture.ModifiedDate, dtoCulture.Name);

			return model;
		}

		public virtual List<ApiCultureResponseModel> MapDTOToModel(
			List<DTOCulture> dtos)
		{
			List<ApiCultureResponseModel> response = new List<ApiCultureResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ae814ea804506b641509b3f0ed0f4189</Hash>
</Codenesium>*/