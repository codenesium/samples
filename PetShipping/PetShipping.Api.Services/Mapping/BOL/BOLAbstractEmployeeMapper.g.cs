using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractEmployeeMapper
	{
		public virtual BOEmployee MapModelToBO(
			int id,
			ApiEmployeeRequestModel model
			)
		{
			BOEmployee boEmployee = new BOEmployee();
			boEmployee.SetProperties(
				id,
				model.FirstName,
				model.IsSalesPerson,
				model.IsShipper,
				model.LastName);
			return boEmployee;
		}

		public virtual ApiEmployeeResponseModel MapBOToModel(
			BOEmployee boEmployee)
		{
			var model = new ApiEmployeeResponseModel();

			model.SetProperties(boEmployee.Id, boEmployee.FirstName, boEmployee.IsSalesPerson, boEmployee.IsShipper, boEmployee.LastName);

			return model;
		}

		public virtual List<ApiEmployeeResponseModel> MapBOToModel(
			List<BOEmployee> items)
		{
			List<ApiEmployeeResponseModel> response = new List<ApiEmployeeResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a19b77b3875095b3bc4a1b1b5737253a</Hash>
</Codenesium>*/