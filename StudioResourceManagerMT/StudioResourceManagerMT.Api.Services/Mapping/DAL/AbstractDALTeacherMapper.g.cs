using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractDALTeacherMapper
	{
		public virtual Teacher MapModelToEntity(
			int id,
			ApiTeacherServerRequestModel model
			)
		{
			Teacher item = new Teacher();
			item.SetProperties(
				id,
				model.Birthday,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Phone,
				model.UserId);
			return item;
		}

		public virtual ApiTeacherServerResponseModel MapEntityToModel(
			Teacher item)
		{
			var model = new ApiTeacherServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Birthday,
			                    item.Email,
			                    item.FirstName,
			                    item.LastName,
			                    item.Phone,
			                    item.UserId);

			return model;
		}

		public virtual List<ApiTeacherServerResponseModel> MapEntityToModel(
			List<Teacher> items)
		{
			List<ApiTeacherServerResponseModel> response = new List<ApiTeacherServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>df2a73fb781dbc12682e41856a5f83c8</Hash>
</Codenesium>*/