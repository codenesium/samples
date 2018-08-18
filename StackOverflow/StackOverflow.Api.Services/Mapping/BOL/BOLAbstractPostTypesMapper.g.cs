using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractPostTypesMapper
	{
		public virtual BOPostTypes MapModelToBO(
			int id,
			ApiPostTypesRequestModel model
			)
		{
			BOPostTypes boPostTypes = new BOPostTypes();
			boPostTypes.SetProperties(
				id,
				model.Type);
			return boPostTypes;
		}

		public virtual ApiPostTypesResponseModel MapBOToModel(
			BOPostTypes boPostTypes)
		{
			var model = new ApiPostTypesResponseModel();

			model.SetProperties(boPostTypes.Id, boPostTypes.Type);

			return model;
		}

		public virtual List<ApiPostTypesResponseModel> MapBOToModel(
			List<BOPostTypes> items)
		{
			List<ApiPostTypesResponseModel> response = new List<ApiPostTypesResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>574417bba8820d22b3e0202ac47e4751</Hash>
</Codenesium>*/