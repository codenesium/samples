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
    <Hash>4a4d80ab2e6a8813012631d58a64b4d3</Hash>
</Codenesium>*/