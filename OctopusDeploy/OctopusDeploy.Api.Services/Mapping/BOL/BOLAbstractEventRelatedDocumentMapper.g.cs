using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractEventRelatedDocumentMapper
	{
		public virtual BOEventRelatedDocument MapModelToBO(
			int id,
			ApiEventRelatedDocumentRequestModel model
			)
		{
			BOEventRelatedDocument boEventRelatedDocument = new BOEventRelatedDocument();
			boEventRelatedDocument.SetProperties(
				id,
				model.EventId,
				model.RelatedDocumentId);
			return boEventRelatedDocument;
		}

		public virtual ApiEventRelatedDocumentResponseModel MapBOToModel(
			BOEventRelatedDocument boEventRelatedDocument)
		{
			var model = new ApiEventRelatedDocumentResponseModel();

			model.SetProperties(boEventRelatedDocument.Id, boEventRelatedDocument.EventId, boEventRelatedDocument.RelatedDocumentId);

			return model;
		}

		public virtual List<ApiEventRelatedDocumentResponseModel> MapBOToModel(
			List<BOEventRelatedDocument> items)
		{
			List<ApiEventRelatedDocumentResponseModel> response = new List<ApiEventRelatedDocumentResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d26622cd74eabf6935c30dacb1084651</Hash>
</Codenesium>*/