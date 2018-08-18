using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractShiftMapper
	{
		public virtual BOShift MapModelToBO(
			int shiftID,
			ApiShiftRequestModel model
			)
		{
			BOShift boShift = new BOShift();
			boShift.SetProperties(
				shiftID,
				model.EndTime,
				model.ModifiedDate,
				model.Name,
				model.StartTime);
			return boShift;
		}

		public virtual ApiShiftResponseModel MapBOToModel(
			BOShift boShift)
		{
			var model = new ApiShiftResponseModel();

			model.SetProperties(boShift.ShiftID, boShift.EndTime, boShift.ModifiedDate, boShift.Name, boShift.StartTime);

			return model;
		}

		public virtual List<ApiShiftResponseModel> MapBOToModel(
			List<BOShift> items)
		{
			List<ApiShiftResponseModel> response = new List<ApiShiftResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>77e6182f2b227917e0d5058148c7c955</Hash>
</Codenesium>*/