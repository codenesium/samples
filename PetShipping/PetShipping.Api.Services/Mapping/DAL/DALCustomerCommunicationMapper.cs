using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public class DALCustomerCommunicationMapper : IDALCustomerCommunicationMapper
	{
		public virtual CustomerCommunication MapModelToEntity(
			int id,
			ApiCustomerCommunicationServerRequestModel model
			)
		{
			CustomerCommunication item = new CustomerCommunication();
			item.SetProperties(
				id,
				model.CustomerId,
				model.DateCreated,
				model.EmployeeId,
				model.Notes);
			return item;
		}

		public virtual ApiCustomerCommunicationServerResponseModel MapEntityToModel(
			CustomerCommunication item)
		{
			var model = new ApiCustomerCommunicationServerResponseModel();

			model.SetProperties(item.Id,
			                    item.CustomerId,
			                    item.DateCreated,
			                    item.EmployeeId,
			                    item.Notes);
			if (item.CustomerIdNavigation != null)
			{
				var customerIdModel = new ApiCustomerServerResponseModel();
				customerIdModel.SetProperties(
					item.CustomerIdNavigation.Id,
					item.CustomerIdNavigation.Email,
					item.CustomerIdNavigation.FirstName,
					item.CustomerIdNavigation.LastName,
					item.CustomerIdNavigation.Notes,
					item.CustomerIdNavigation.Phone);

				model.SetCustomerIdNavigation(customerIdModel);
			}

			if (item.EmployeeIdNavigation != null)
			{
				var employeeIdModel = new ApiEmployeeServerResponseModel();
				employeeIdModel.SetProperties(
					item.EmployeeIdNavigation.Id,
					item.EmployeeIdNavigation.FirstName,
					item.EmployeeIdNavigation.IsSalesPerson,
					item.EmployeeIdNavigation.IsShipper,
					item.EmployeeIdNavigation.LastName);

				model.SetEmployeeIdNavigation(employeeIdModel);
			}

			return model;
		}

		public virtual List<ApiCustomerCommunicationServerResponseModel> MapEntityToModel(
			List<CustomerCommunication> items)
		{
			List<ApiCustomerCommunicationServerResponseModel> response = new List<ApiCustomerCommunicationServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e69e3cf0ae0d11c7f7dca8165f3c3b41</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/