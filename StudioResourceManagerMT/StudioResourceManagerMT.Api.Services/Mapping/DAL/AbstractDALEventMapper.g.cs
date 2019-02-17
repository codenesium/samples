using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractDALEventMapper
	{
		public virtual Event MapModelToEntity(
			int id,
			ApiEventServerRequestModel model
			)
		{
			Event item = new Event();
			item.SetProperties(
				id,
				model.ActualEndDate,
				model.ActualStartDate,
				model.BillAmount,
				model.EventStatusId,
				model.ScheduledEndDate,
				model.ScheduledStartDate,
				model.StudentNote,
				model.TeacherNote);
			return item;
		}

		public virtual ApiEventServerResponseModel MapEntityToModel(
			Event item)
		{
			var model = new ApiEventServerResponseModel();

			model.SetProperties(item.Id,
			                    item.ActualEndDate,
			                    item.ActualStartDate,
			                    item.BillAmount,
			                    item.EventStatusId,
			                    item.ScheduledEndDate,
			                    item.ScheduledStartDate,
			                    item.StudentNote,
			                    item.TeacherNote);
			if (item.EventStatusIdNavigation != null)
			{
				var eventStatusIdModel = new ApiEventStatuServerResponseModel();
				eventStatusIdModel.SetProperties(
					item.EventStatusIdNavigation.Id,
					item.EventStatusIdNavigation.Name);

				model.SetEventStatusIdNavigation(eventStatusIdModel);
			}

			if (item.TenantIdNavigation != null)
			{
				var tenantIdModel = new ApiEventStatuServerResponseModel();
				tenantIdModel.SetProperties(
					item.TenantIdNavigation.Id,
					item.TenantIdNavigation.Name);

				model.SetTenantIdNavigation(tenantIdModel);
			}

			return model;
		}

		public virtual List<ApiEventServerResponseModel> MapEntityToModel(
			List<Event> items)
		{
			List<ApiEventServerResponseModel> response = new List<ApiEventServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8a4689ac13d6cd22f29d86d8465248bd</Hash>
</Codenesium>*/