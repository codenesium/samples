using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public class DALCallMapper : IDALCallMapper
	{
		public virtual Call MapModelToEntity(
			int id,
			ApiCallServerRequestModel model
			)
		{
			Call item = new Call();
			item.SetProperties(
				id,
				model.AddressId,
				model.CallDispositionId,
				model.CallStatusId,
				model.CallString,
				model.CallTypeId,
				model.DateCleared,
				model.DateCreated,
				model.DateDispatched,
				model.QuickCallNumber);
			return item;
		}

		public virtual ApiCallServerResponseModel MapEntityToModel(
			Call item)
		{
			var model = new ApiCallServerResponseModel();

			model.SetProperties(item.Id,
			                    item.AddressId,
			                    item.CallDispositionId,
			                    item.CallStatusId,
			                    item.CallString,
			                    item.CallTypeId,
			                    item.DateCleared,
			                    item.DateCreated,
			                    item.DateDispatched,
			                    item.QuickCallNumber);
			if (item.AddressIdNavigation != null)
			{
				var addressIdModel = new ApiAddressServerResponseModel();
				addressIdModel.SetProperties(
					item.AddressIdNavigation.Id,
					item.AddressIdNavigation.Address1,
					item.AddressIdNavigation.Address2,
					item.AddressIdNavigation.City,
					item.AddressIdNavigation.State,
					item.AddressIdNavigation.Zip);

				model.SetAddressIdNavigation(addressIdModel);
			}

			if (item.CallDispositionIdNavigation != null)
			{
				var callDispositionIdModel = new ApiCallDispositionServerResponseModel();
				callDispositionIdModel.SetProperties(
					item.CallDispositionIdNavigation.Id,
					item.CallDispositionIdNavigation.Name);

				model.SetCallDispositionIdNavigation(callDispositionIdModel);
			}

			if (item.CallStatusIdNavigation != null)
			{
				var callStatusIdModel = new ApiCallStatusServerResponseModel();
				callStatusIdModel.SetProperties(
					item.CallStatusIdNavigation.Id,
					item.CallStatusIdNavigation.Name);

				model.SetCallStatusIdNavigation(callStatusIdModel);
			}

			if (item.CallTypeIdNavigation != null)
			{
				var callTypeIdModel = new ApiCallTypeServerResponseModel();
				callTypeIdModel.SetProperties(
					item.CallTypeIdNavigation.Id,
					item.CallTypeIdNavigation.Name);

				model.SetCallTypeIdNavigation(callTypeIdModel);
			}

			return model;
		}

		public virtual List<ApiCallServerResponseModel> MapEntityToModel(
			List<Call> items)
		{
			List<ApiCallServerResponseModel> response = new List<ApiCallServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e91001c16fa5e65aa2f5b1339b928e34</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/