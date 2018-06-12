using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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

                        model.SetProperties(boEventRelatedDocument.EventId, boEventRelatedDocument.Id, boEventRelatedDocument.RelatedDocumentId);

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
    <Hash>db6585811ab6cfe2f48b2e3413b73546</Hash>
</Codenesium>*/