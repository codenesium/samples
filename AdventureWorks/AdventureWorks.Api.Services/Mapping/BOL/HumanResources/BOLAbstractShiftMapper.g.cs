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
			BOShift BOShift = new BOShift();

			BOShift.SetProperties(
				shiftID,
				model.EndTime,
				model.ModifiedDate,
				model.Name,
				model.StartTime);
			return BOShift;
		}

		public virtual ApiShiftResponseModel MapBOToModel(
			BOShift BOShift)
		{
			if (BOShift == null)
			{
				return null;
			}

			var model = new ApiShiftResponseModel();

			model.SetProperties(BOShift.EndTime, BOShift.ModifiedDate, BOShift.Name, BOShift.ShiftID, BOShift.StartTime);

			return model;
		}

		public virtual List<ApiShiftResponseModel> MapBOToModel(
			List<BOShift> BOs)
		{
			List<ApiShiftResponseModel> response = new List<ApiShiftResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c56697bb0a10383c09aabf5d16b62fcb</Hash>
</Codenesium>*/