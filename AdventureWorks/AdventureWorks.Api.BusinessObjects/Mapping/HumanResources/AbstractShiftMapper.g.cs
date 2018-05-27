using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLShiftMapper
	{
		public virtual DTOShift MapModelToDTO(
			int shiftID,
			ApiShiftRequestModel model
			)
		{
			DTOShift dtoShift = new DTOShift();

			dtoShift.SetProperties(
				shiftID,
				model.EndTime,
				model.ModifiedDate,
				model.Name,
				model.StartTime);
			return dtoShift;
		}

		public virtual ApiShiftResponseModel MapDTOToModel(
			DTOShift dtoShift)
		{
			if (dtoShift == null)
			{
				return null;
			}

			var model = new ApiShiftResponseModel();

			model.SetProperties(dtoShift.EndTime, dtoShift.ModifiedDate, dtoShift.Name, dtoShift.ShiftID, dtoShift.StartTime);

			return model;
		}

		public virtual List<ApiShiftResponseModel> MapDTOToModel(
			List<DTOShift> dtos)
		{
			List<ApiShiftResponseModel> response = new List<ApiShiftResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>079fc5fdb69282792e41fdf0019fb355</Hash>
</Codenesium>*/