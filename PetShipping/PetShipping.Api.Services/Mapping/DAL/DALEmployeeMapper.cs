using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public class DALEmployeeMapper : IDALEmployeeMapper
	{
		public virtual Employee MapModelToEntity(
			int id,
			ApiEmployeeServerRequestModel model
			)
		{
			Employee item = new Employee();
			item.SetProperties(
				id,
				model.FirstName,
				model.IsSalesPerson,
				model.IsShipper,
				model.LastName);
			return item;
		}

		public virtual ApiEmployeeServerResponseModel MapEntityToModel(
			Employee item)
		{
			var model = new ApiEmployeeServerResponseModel();

			model.SetProperties(item.Id,
			                    item.FirstName,
			                    item.IsSalesPerson,
			                    item.IsShipper,
			                    item.LastName);

			return model;
		}

		public virtual List<ApiEmployeeServerResponseModel> MapEntityToModel(
			List<Employee> items)
		{
			List<ApiEmployeeServerResponseModel> response = new List<ApiEmployeeServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>71cc4e02bd1f27a18c266d85a742d9e5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/