using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractDocumentMapper
        {
                public virtual BODocument MapModelToBO(
                        Guid rowguid,
                        ApiDocumentRequestModel model
                        )
                {
                        BODocument boDocument = new BODocument();

                        boDocument.SetProperties(
                                rowguid,
                                model.ChangeNumber,
                                model.Document1,
                                model.DocumentLevel,
                                model.DocumentSummary,
                                model.FileExtension,
                                model.FileName,
                                model.FolderFlag,
                                model.ModifiedDate,
                                model.Owner,
                                model.Revision,
                                model.Status,
                                model.Title);
                        return boDocument;
                }

                public virtual ApiDocumentResponseModel MapBOToModel(
                        BODocument boDocument)
                {
                        var model = new ApiDocumentResponseModel();

                        model.SetProperties(boDocument.ChangeNumber, boDocument.Document1, boDocument.DocumentLevel, boDocument.DocumentSummary, boDocument.FileExtension, boDocument.FileName, boDocument.FolderFlag, boDocument.ModifiedDate, boDocument.Owner, boDocument.Revision, boDocument.Rowguid, boDocument.Status, boDocument.Title);

                        return model;
                }

                public virtual List<ApiDocumentResponseModel> MapBOToModel(
                        List<BODocument> items)
                {
                        List<ApiDocumentResponseModel> response = new List<ApiDocumentResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>b4a1905a6adad041b16f5fa61df5dd74</Hash>
</Codenesium>*/