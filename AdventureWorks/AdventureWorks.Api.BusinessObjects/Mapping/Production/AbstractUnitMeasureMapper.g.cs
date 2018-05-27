using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLUnitMeasureMapper
	{
		public virtual DTOUnitMeasure MapModelToDTO(
			string unitMeasureCode,
			ApiUnitMeasureRequestModel model
			)
		{
			DTOUnitMeasure dtoUnitMeasure = new DTOUnitMeasure();

			dtoUnitMeasure.SetProperties(
				unitMeasureCode,
				model.ModifiedDate,
				model.Name);
			return dtoUnitMeasure;
		}

		public virtual ApiUnitMeasureResponseModel MapDTOToModel(
			DTOUnitMeasure dtoUnitMeasure)
		{
			if (dtoUnitMeasure == null)
			{
				return null;
			}

			var model = new ApiUnitMeasureResponseModel();

			model.SetProperties(dtoUnitMeasure.ModifiedDate, dtoUnitMeasure.Name, dtoUnitMeasure.UnitMeasureCode);

			return model;
		}

		public virtual List<ApiUnitMeasureResponseModel> MapDTOToModel(
			List<DTOUnitMeasure> dtos)
		{
			List<ApiUnitMeasureResponseModel> response = new List<ApiUnitMeasureResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f7acee50a6eab68212722570f98030fb</Hash>
</Codenesium>*/