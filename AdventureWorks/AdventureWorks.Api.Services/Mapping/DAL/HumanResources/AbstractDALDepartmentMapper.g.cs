using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALDepartmentMapper
	{
		public virtual Department MapModelToBO(
			short departmentID,
			ApiDepartmentServerRequestModel model
			)
		{
			Department item = new Department();
			item.SetProperties(
				departmentID,
				model.GroupName,
				model.ModifiedDate,
				model.Name);
			return item;
		}

		public virtual ApiDepartmentServerResponseModel MapBOToModel(
			Department item)
		{
			var model = new ApiDepartmentServerResponseModel();

			model.SetProperties(item.DepartmentID, item.GroupName, item.ModifiedDate, item.Name);

			return model;
		}

		public virtual List<ApiDepartmentServerResponseModel> MapBOToModel(
			List<Department> items)
		{
			List<ApiDepartmentServerResponseModel> response = new List<ApiDepartmentServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>933eec9429cb4c90d63f82f66c102c60</Hash>
</Codenesium>*/