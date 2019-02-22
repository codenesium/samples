using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public abstract class AbstractDALUnitOfficerMapper
	{
		public virtual UnitOfficer MapModelToEntity(
			int id,
			ApiUnitOfficerServerRequestModel model
			)
		{
			UnitOfficer item = new UnitOfficer();
			item.SetProperties(
				id,
				model.OfficerId,
				model.UnitId);
			return item;
		}

		public virtual ApiUnitOfficerServerResponseModel MapEntityToModel(
			UnitOfficer item)
		{
			var model = new ApiUnitOfficerServerResponseModel();

			model.SetProperties(item.Id,
			                    item.OfficerId,
			                    item.UnitId);
			if (item.OfficerIdNavigation != null)
			{
				var officerIdModel = new ApiOfficerServerResponseModel();
				officerIdModel.SetProperties(
					item.OfficerIdNavigation.Id,
					item.OfficerIdNavigation.Badge,
					item.OfficerIdNavigation.Email,
					item.OfficerIdNavigation.FirstName,
					item.OfficerIdNavigation.LastName,
					item.OfficerIdNavigation.Password);

				model.SetOfficerIdNavigation(officerIdModel);
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

		public virtual List<ApiUnitOfficerServerResponseModel> MapEntityToModel(
			List<UnitOfficer> items)
		{
			List<ApiUnitOfficerServerResponseModel> response = new List<ApiUnitOfficerServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f2a4f5c928611483c98505c466dd6574</Hash>
</Codenesium>*/