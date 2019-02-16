using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALShiftMapper
	{
		public virtual Shift MapModelToBO(
			int shiftID,
			ApiShiftServerRequestModel model
			)
		{
			Shift item = new Shift();
			item.SetProperties(
				shiftID,
				model.EndTime,
				model.ModifiedDate,
				model.Name,
				model.StartTime);
			return item;
		}

		public virtual ApiShiftServerResponseModel MapBOToModel(
			Shift item)
		{
			var model = new ApiShiftServerResponseModel();

			model.SetProperties(item.ShiftID, item.EndTime, item.ModifiedDate, item.Name, item.StartTime);

			return model;
		}

		public virtual List<ApiShiftServerResponseModel> MapBOToModel(
			List<Shift> items)
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
    <Hash>0fef9e462f2aaa68288e29a5585f3170</Hash>
</Codenesium>*/