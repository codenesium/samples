using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLIllustrationMapper
	{
		public virtual DTOIllustration MapModelToDTO(
			int illustrationID,
			ApiIllustrationRequestModel model
			)
		{
			DTOIllustration dtoIllustration = new DTOIllustration();

			dtoIllustration.SetProperties(
				illustrationID,
				model.Diagram,
				model.ModifiedDate);
			return dtoIllustration;
		}

		public virtual ApiIllustrationResponseModel MapDTOToModel(
			DTOIllustration dtoIllustration)
		{
			if (dtoIllustration == null)
			{
				return null;
			}

			var model = new ApiIllustrationResponseModel();

			model.SetProperties(dtoIllustration.Diagram, dtoIllustration.IllustrationID, dtoIllustration.ModifiedDate);

			return model;
		}

		public virtual List<ApiIllustrationResponseModel> MapDTOToModel(
			List<DTOIllustration> dtos)
		{
			List<ApiIllustrationResponseModel> response = new List<ApiIllustrationResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b5582d04f546288a0f4ff87c979c4931</Hash>
</Codenesium>*/