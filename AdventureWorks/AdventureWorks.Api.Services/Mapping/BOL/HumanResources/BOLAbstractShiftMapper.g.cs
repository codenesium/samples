using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractShiftMapper
	{
		public virtual BOShift MapModelToBO(
			int shiftID,
			ApiShiftServerRequestModel model
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

		public virtual ApiShiftServerResponseModel MapBOToModel(
			BOShift boShift)
		{
			var model = new ApiShiftServerResponseModel();

			model.SetProperties(boShift.ShiftID, boShift.EndTime, boShift.ModifiedDate, boShift.Name, boShift.StartTime);

			return model;
		}

		public virtual List<ApiShiftServerResponseModel> MapBOToModel(
			List<BOShift> items)
		{
			List<ApiShiftServerResponseModel> response = new List<ApiShiftServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>aaca3dafaf7bf69cdf38178ffc405aae</Hash>
</Codenesium>*/