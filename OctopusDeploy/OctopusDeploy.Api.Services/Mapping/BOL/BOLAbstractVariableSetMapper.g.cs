using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractVariableSetMapper
	{
		public virtual BOVariableSet MapModelToBO(
			string id,
			ApiVariableSetRequestModel model
			)
		{
			BOVariableSet boVariableSet = new BOVariableSet();
			boVariableSet.SetProperties(
				id,
				model.IsFrozen,
				model.JSON,
				model.OwnerId,
				model.RelatedDocumentIds,
				model.Version);
			return boVariableSet;
		}

		public virtual ApiVariableSetResponseModel MapBOToModel(
			BOVariableSet boVariableSet)
		{
			var model = new ApiVariableSetResponseModel();

			model.SetProperties(boVariableSet.Id, boVariableSet.IsFrozen, boVariableSet.JSON, boVariableSet.OwnerId, boVariableSet.RelatedDocumentIds, boVariableSet.Version);

			return model;
		}

		public virtual List<ApiVariableSetResponseModel> MapBOToModel(
			List<BOVariableSet> items)
		{
			List<ApiVariableSetResponseModel> response = new List<ApiVariableSetResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f6b4ac0ee01921417024a6cecdae5399</Hash>
</Codenesium>*/