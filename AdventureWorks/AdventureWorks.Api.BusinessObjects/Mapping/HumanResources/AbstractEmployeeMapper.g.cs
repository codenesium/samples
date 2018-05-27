using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLEmployeeMapper
	{
		public virtual DTOEmployee MapModelToDTO(
			int businessEntityID,
			ApiEmployeeRequestModel model
			)
		{
			DTOEmployee dtoEmployee = new DTOEmployee();

			dtoEmployee.SetProperties(
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
			return dtoEmployee;
		}

		public virtual ApiEmployeeResponseModel MapDTOToModel(
			DTOEmployee dtoEmployee)
		{
			if (dtoEmployee == null)
			{
				return null;
			}

			var model = new ApiEmployeeResponseModel();

			model.SetProperties(dtoEmployee.BirthDate, dtoEmployee.BusinessEntityID, dtoEmployee.CurrentFlag, dtoEmployee.Gender, dtoEmployee.HireDate, dtoEmployee.JobTitle, dtoEmployee.LoginID, dtoEmployee.MaritalStatus, dtoEmployee.ModifiedDate, dtoEmployee.NationalIDNumber, dtoEmployee.OrganizationLevel, dtoEmployee.OrganizationNode, dtoEmployee.Rowguid, dtoEmployee.SalariedFlag, dtoEmployee.SickLeaveHours, dtoEmployee.VacationHours);

			return model;
		}

		public virtual List<ApiEmployeeResponseModel> MapDTOToModel(
			List<DTOEmployee> dtos)
		{
			List<ApiEmployeeResponseModel> response = new List<ApiEmployeeResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>26acf9adea37041dcbf3a935acb56576</Hash>
</Codenesium>*/