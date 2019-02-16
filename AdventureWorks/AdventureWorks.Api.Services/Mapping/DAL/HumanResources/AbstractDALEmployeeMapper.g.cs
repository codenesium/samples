using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALEmployeeMapper
	{
		public virtual Employee MapModelToBO(
			int businessEntityID,
			ApiEmployeeServerRequestModel model
			)
		{
			Employee item = new Employee();
			item.SetProperties(
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
			return item;
		}

		public virtual ApiEmployeeServerResponseModel MapBOToModel(
			Employee item)
		{
			var model = new ApiEmployeeServerResponseModel();

			model.SetProperties(item.BusinessEntityID, item.BirthDate, item.CurrentFlag, item.Gender, item.HireDate, item.JobTitle, item.LoginID, item.MaritalStatu, item.ModifiedDate, item.NationalIDNumber, item.OrganizationLevel, item.Rowguid, item.SalariedFlag, item.SickLeaveHour, item.VacationHour);

			return model;
		}

		public virtual List<ApiEmployeeServerResponseModel> MapBOToModel(
			List<Employee> items)
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
    <Hash>d833a2da02c6f5d113e177c95ef07700</Hash>
</Codenesium>*/