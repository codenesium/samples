using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractEmployeeMapper
	{
		public virtual BOEmployee MapModelToBO(
			int id,
			ApiEmployeeRequestModel model
			)
		{
			BOEmployee BOEmployee = new BOEmployee();

			BOEmployee.SetProperties(
				id,
				model.FirstName,
				model.IsSalesPerson,
				model.IsShipper,
				model.LastName);
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

			model.SetProperties(BOEmployee.FirstName, BOEmployee.Id, BOEmployee.IsSalesPerson, BOEmployee.IsShipper, BOEmployee.LastName);

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
    <Hash>427ab43358fe23e9c1b3041bfc425c71</Hash>
</Codenesium>*/