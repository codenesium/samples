using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractTagSetMapper
	{
		public virtual BOTagSet MapModelToBO(
			string id,
			ApiTagSetRequestModel model
			)
		{
			BOTagSet boTagSet = new BOTagSet();
			boTagSet.SetProperties(
				id,
				model.DataVersion,
				model.JSON,
				model.Name,
				model.SortOrder);
			return boTagSet;
		}

		public virtual ApiTagSetResponseModel MapBOToModel(
			BOTagSet boTagSet)
		{
			var model = new ApiTagSetResponseModel();

			model.SetProperties(boTagSet.Id, boTagSet.DataVersion, boTagSet.JSON, boTagSet.Name, boTagSet.SortOrder);

			return model;
		}

		public virtual List<ApiTagSetResponseModel> MapBOToModel(
			List<BOTagSet> items)
		{
			List<ApiTagSetResponseModel> response = new List<ApiTagSetResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2f03c2c12679b4e1eebc4ddf26053159</Hash>
</Codenesium>*/