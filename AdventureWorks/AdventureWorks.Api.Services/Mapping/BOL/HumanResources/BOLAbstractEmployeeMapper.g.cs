using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractEmployeeMapper
	{
		public virtual BOEmployee MapModelToBO(
			int businessEntityID,
			ApiEmployeeRequestModel model
			)
		{
			BOEmployee BOEmployee = new BOEmployee();

			BOEmployee.SetProperties(
				businessEntityID,
				model.BirthDate,
				model.CurrentFlag,
				model.Gender,
				model.HireDate,
				model.JobTitle,
				model.LoginID,
				model.MaritalStatus,
				model.ModifiedDate,
				model.NationalIDNumber,
				model.OrganizationLevel,
				model.OrganizationNode,
				model.Rowguid,
				model.SalariedFlag,
				model.SickLeaveHours,
				model.VacationHours);
			return BOEmployee;
		}

		public virtual ApiEmployeeResponseModel MapBOToModel(
			BOEmployee BOEmployee)
		{
			if (BOEmployee == null)
			{
				return null;
			}

			var model = new ApiEmployeeResponseModel();

			model.SetProperties(BOEmployee.BirthDate, BOEmployee.BusinessEntityID, BOEmployee.CurrentFlag, BOEmployee.Gender, BOEmployee.HireDate, BOEmployee.JobTitle, BOEmployee.LoginID, BOEmployee.MaritalStatus, BOEmployee.ModifiedDate, BOEmployee.NationalIDNumber, BOEmployee.OrganizationLevel, BOEmployee.OrganizationNode, BOEmployee.Rowguid, BOEmployee.SalariedFlag, BOEmployee.SickLeaveHours, BOEmployee.VacationHours);

			return model;
		}

		public virtual List<ApiEmployeeResponseModel> MapBOToModel(
			List<BOEmployee> BOs)
		{
			List<ApiEmployeeResponseModel> response = new List<ApiEmployeeResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6bd9b81d82ce80c114daf9150dc230ff</Hash>
</Codenesium>*/