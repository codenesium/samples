using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public class DALCallAssignmentMapper : IDALCallAssignmentMapper
	{
		public virtual CallAssignment MapModelToEntity(
			int id,
			ApiCallAssignmentServerRequestModel model
			)
		{
			CallAssignment item = new CallAssignment();
			item.SetProperties(
				id,
				model.CallId,
				model.UnitId);
			return item;
		}

		public virtual ApiCallAssignmentServerResponseModel MapEntityToModel(
			CallAssignment item)
		{
			var model = new ApiCallAssignmentServerResponseModel();

			model.SetProperties(item.Id,
			                    item.CallId,
			                    item.UnitId);
			if (item.CallIdNavigation != null)
			{
				var callIdModel = new ApiCallServerResponseModel();
				callIdModel.SetProperties(
					item.CallIdNavigation.Id,
					item.CallIdNavigation.AddressId,
					item.CallIdNavigation.CallDispositionId,
					item.CallIdNavigation.CallStatusId,
					item.CallIdNavigation.CallString,
					item.CallIdNavigation.CallTypeId,
					item.CallIdNavigation.DateCleared,
					item.CallIdNavigation.DateCreated,
					item.CallIdNavigation.DateDispatched,
					item.CallIdNavigation.QuickCallNumber);

				model.SetCallIdNavigation(callIdModel);
			}

			if (item.UnitIdNavigation != null)
			{
				var unitIdModel = new ApiUnitServerResponseModel();
				unitIdModel.SetProperties(
					item.UnitIdNavigation.Id,
					item.UnitIdNavigation.CallSign);

				model.SetUnitIdNavigation(unitIdModel);
			}

			return model;
		}

		public virtual List<ApiCallAssignmentServerResponseModel> MapEntityToModel(
			List<CallAssignment> items)
		{
			List<ApiCallAssignmentServerResponseModel> response = new List<ApiCallAssignmentServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>dd36770ffee30b734238495457185e06</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/