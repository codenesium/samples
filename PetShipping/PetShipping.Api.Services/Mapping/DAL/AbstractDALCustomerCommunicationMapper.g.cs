using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALCustomerCommunicationMapper
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
				model.Note);
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
			                    item.Note);
			if (item.CustomerIdNavigation != null)
			{
				var customerIdModel = new ApiCustomerServerResponseModel();
				customerIdModel.SetProperties(
					item.Id,
					item.CustomerIdNavigation.Email,
					item.CustomerIdNavigation.FirstName,
					item.CustomerIdNavigation.LastName,
					item.CustomerIdNavigation.Note,
					item.CustomerIdNavigation.Phone);

				model.SetCustomerIdNavigation(customerIdModel);
			}

			if (item.EmployeeIdNavigation != null)
			{
				var employeeIdModel = new ApiEmployeeServerResponseModel();
				employeeIdModel.SetProperties(
					item.Id,
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
    <Hash>7567ab271cceb381e539605d8c8ef1aa</Hash>
</Codenesium>*/