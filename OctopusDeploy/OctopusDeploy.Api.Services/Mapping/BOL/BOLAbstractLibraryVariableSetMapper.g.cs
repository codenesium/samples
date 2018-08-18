using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractLibraryVariableSetMapper
	{
		public virtual BOLibraryVariableSet MapModelToBO(
			string id,
			ApiLibraryVariableSetRequestModel model
			)
		{
			BOLibraryVariableSet boLibraryVariableSet = new BOLibraryVariableSet();
			boLibraryVariableSet.SetProperties(
				id,
				model.ContentType,
				model.JSON,
				model.Name,
				model.VariableSetId);
			return boLibraryVariableSet;
		}

		public virtual ApiLibraryVariableSetResponseModel MapBOToModel(
			BOLibraryVariableSet boLibraryVariableSet)
		{
			var model = new ApiLibraryVariableSetResponseModel();

			model.SetProperties(boLibraryVariableSet.Id, boLibraryVariableSet.ContentType, boLibraryVariableSet.JSON, boLibraryVariableSet.Name, boLibraryVariableSet.VariableSetId);

			return model;
		}

		public virtual List<ApiLibraryVariableSetResponseModel> MapBOToModel(
			List<BOLibraryVariableSet> items)
		{
			List<ApiLibraryVariableSetResponseModel> response = new List<ApiLibraryVariableSetResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>596603c125badce267d8cbed2cba3c7a</Hash>
</Codenesium>*/