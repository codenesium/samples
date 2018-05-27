using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLEmployeeDepartmentHistoryMapper
	{
		public virtual DTOEmployeeDepartmentHistory MapModelToDTO(
			int businessEntityID,
			ApiEmployeeDepartmentHistoryRequestModel model
			)
		{
			DTOEmployeeDepartmentHistory dtoEmployeeDepartmentHistory = new DTOEmployeeDepartmentHistory();

			dtoEmployeeDepartmentHistory.SetProperties(
				businessEntityID,
				model.DepartmentID,
				model.EndDate,
				model.ModifiedDate,
				model.ShiftID,
				model.StartDate);
			return dtoEmployeeDepartmentHistory;
		}

		public virtual ApiEmployeeDepartmentHistoryResponseModel MapDTOToModel(
			DTOEmployeeDepartmentHistory dtoEmployeeDepartmentHistory)
		{
			if (dtoEmployeeDepartmentHistory == null)
			{
				return null;
			}

			var model = new ApiEmployeeDepartmentHistoryResponseModel();

			model.SetProperties(dtoEmployeeDepartmentHistory.BusinessEntityID, dtoEmployeeDepartmentHistory.DepartmentID, dtoEmployeeDepartmentHistory.EndDate, dtoEmployeeDepartmentHistory.ModifiedDate, dtoEmployeeDepartmentHistory.ShiftID, dtoEmployeeDepartmentHistory.StartDate);

			return model;
		}

		public virtual List<ApiEmployeeDepartmentHistoryResponseModel> MapDTOToModel(
			List<DTOEmployeeDepartmentHistory> dtos)
		{
			List<ApiEmployeeDepartmentHistoryResponseModel> response = new List<ApiEmployeeDepartmentHistoryResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>91a5677648b1f3a66d4c5f15454b43d0</Hash>
</Codenesium>*/