using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractEmployeeMapper
	{
		public virtual BOEmployee MapModelToBO(
			int id,
			ApiEmployeeServerRequestModel model
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

		public virtual ApiEmployeeServerResponseModel MapBOToModel(
			BOEmployee boEmployee)
		{
			var model = new ApiEmployeeServerResponseModel();

			model.SetProperties(boEmployee.Id, boEmployee.FirstName, boEmployee.IsSalesPerson, boEmployee.IsShipper, boEmployee.LastName);

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
    <Hash>b4015ac7e6ea34df87ab21ee4c55355c</Hash>
</Codenesium>*/