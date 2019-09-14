using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public class DALCallPersonMapper : IDALCallPersonMapper
	{
		public virtual CallPerson MapModelToEntity(
			int id,
			ApiCallPersonServerRequestModel model
			)
		{
			CallPerson item = new CallPerson();
			item.SetProperties(
				id,
				model.Note,
				model.PersonId,
				model.PersonTypeId);
			return item;
		}

		public virtual ApiCallPersonServerResponseModel MapEntityToModel(
			CallPerson item)
		{
			var model = new ApiCallPersonServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Note,
			                    item.PersonId,
			                    item.PersonTypeId);
			if (item.PersonIdNavigation != null)
			{
				var personIdModel = new ApiPersonServerResponseModel();
				personIdModel.SetProperties(
					item.PersonIdNavigation.Id,
					item.PersonIdNavigation.FirstName,
					item.PersonIdNavigation.LastName,
					item.PersonIdNavigation.Phone,
					item.PersonIdNavigation.Ssn);

				model.SetPersonIdNavigation(personIdModel);
			}

			if (item.PersonTypeIdNavigation != null)
			{
				var personTypeIdModel = new ApiPersonTypeServerResponseModel();
				personTypeIdModel.SetProperties(
					item.PersonTypeIdNavigation.Id,
					item.PersonTypeIdNavigation.Name);

				model.SetPersonTypeIdNavigation(personTypeIdModel);
			}

			return model;
		}

		public virtual List<ApiCallPersonServerResponseModel> MapEntityToModel(
			List<CallPerson> items)
		{
			List<ApiCallPersonServerResponseModel> response = new List<ApiCallPersonServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e166c3736d076120cc779ca0951f252d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/