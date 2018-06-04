using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractEmployeeDepartmentHistoryMapper
	{
		public virtual BOEmployeeDepartmentHistory MapModelToBO(
			int businessEntityID,
			ApiEmployeeDepartmentHistoryRequestModel model
			)
		{
			BOEmployeeDepartmentHistory BOEmployeeDepartmentHistory = new BOEmployeeDepartmentHistory();

			BOEmployeeDepartmentHistory.SetProperties(
				businessEntityID,
				model.DepartmentID,
				model.EndDate,
				model.ModifiedDate,
				model.ShiftID,
				model.StartDate);
			return BOEmployeeDepartmentHistory;
		}

		public virtual ApiEmployeeDepartmentHistoryResponseModel MapBOToModel(
			BOEmployeeDepartmentHistory BOEmployeeDepartmentHistory)
		{
			if (BOEmployeeDepartmentHistory == null)
			{
				return null;
			}

			var model = new ApiEmployeeDepartmentHistoryResponseModel();

			model.SetProperties(BOEmployeeDepartmentHistory.BusinessEntityID, BOEmployeeDepartmentHistory.DepartmentID, BOEmployeeDepartmentHistory.EndDate, BOEmployeeDepartmentHistory.ModifiedDate, BOEmployeeDepartmentHistory.ShiftID, BOEmployeeDepartmentHistory.StartDate);

			return model;
		}

		public virtual List<ApiEmployeeDepartmentHistoryResponseModel> MapBOToModel(
			List<BOEmployeeDepartmentHistory> BOs)
		{
			List<ApiEmployeeDepartmentHistoryResponseModel> response = new List<ApiEmployeeDepartmentHistoryResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a192fa53b914a8db9f87cc99a574de33</Hash>
</Codenesium>*/