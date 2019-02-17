using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALShiftMapper
	{
		public virtual Shift MapModelToEntity(
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

		public virtual ApiShiftServerResponseModel MapEntityToModel(
			Shift item)
		{
			var model = new ApiShiftServerResponseModel();

			model.SetProperties(item.ShiftID,
			                    item.EndTime,
			                    item.ModifiedDate,
			                    item.Name,
			                    item.StartTime);

			return model;
		}

		public virtual List<ApiShiftServerResponseModel> MapEntityToModel(
			List<Shift> items)
		{
			List<ApiShiftServerResponseModel> response = new List<ApiShiftServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b9c4ae10b9a88432700865c620b1bcdf</Hash>
</Codenesium>*/