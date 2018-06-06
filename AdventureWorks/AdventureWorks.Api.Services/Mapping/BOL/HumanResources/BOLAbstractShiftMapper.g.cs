using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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

			model.SetProperties(boShift.EndTime, boShift.ModifiedDate, boShift.Name, boShift.ShiftID, boShift.StartTime);

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
    <Hash>6df08b6bf22fd70a9f84efbcd3439ed8</Hash>
</Codenesium>*/