using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractEmployeeMapper
	{
		public virtual BOEmployee MapModelToBO(
			int businessEntityID,
			ApiEmployeeServerRequestModel model
			)
		{
			BOEmployee boEmployee = new BOEmployee();
			boEmployee.SetProperties(
				businessEntityID,
				model.BirthDate,
				model.CurrentFlag,
				model.Gender,
				model.HireDate,
				model.JobTitle,
				model.LoginID,
				model.MaritalStatu,
				model.ModifiedDate,
				model.NationalIDNumber,
				model.OrganizationLevel,
				model.Rowguid,
				model.SalariedFlag,
				model.SickLeaveHour,
				model.VacationHour);
			return boEmployee;
		}

		public virtual ApiEmployeeServerResponseModel MapBOToModel(
			BOEmployee boEmployee)
		{
			var model = new ApiEmployeeServerResponseModel();

			model.SetProperties(boEmployee.BusinessEntityID, boEmployee.BirthDate, boEmployee.CurrentFlag, boEmployee.Gender, boEmployee.HireDate, boEmployee.JobTitle, boEmployee.LoginID, boEmployee.MaritalStatu, boEmployee.ModifiedDate, boEmployee.NationalIDNumber, boEmployee.OrganizationLevel, boEmployee.Rowguid, boEmployee.SalariedFlag, boEmployee.SickLeaveHour, boEmployee.VacationHour);

			return model;
		}

		public virtual List<ApiEmployeeServerResponseModel> MapBOToModel(
			List<BOEmployee> items)
		{
			List<ApiEmployeeServerResponseModel> response = new List<ApiEmployeeServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e9b13c2e908cf3b56492526b2a23c8ec</Hash>
</Codenesium>*/