using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiDocumentModelMapper
        {
                public virtual ApiDocumentResponseModel MapRequestToResponse(
                        Guid rowguid,
                        ApiDocumentRequestModel request)
                {
                        var response = new ApiDocumentResponseModel();
                        response.SetProperties(rowguid,
                                               request.ChangeNumber,
                                               request.Document1,
                                               request.DocumentLevel,
                                               request.DocumentSummary,
                                               request.FileExtension,
                                               request.FileName,
                                               request.FolderFlag,
                                               request.ModifiedDate,
                                               request.Owner,
                                               request.Revision,
                                               request.Status,
                                               request.Title);
                        return response;
                }

                public virtual ApiDocumentRequestModel MapResponseToRequest(
                        ApiDocumentResponseModel response)
                {
                        var request = new ApiDocumentRequestModel();
                        request.SetProperties(
                                response.ChangeNumber,
                                response.Document1,
                                response.DocumentLevel,
                                response.DocumentSummary,
                                response.FileExtension,
                                response.FileName,
                                response.FolderFlag,
                                response.ModifiedDate,
                                response.Owner,
                                response.Revision,
                                response.Status,
                                response.Title);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>fc91e09bba5ac4d545f4683a5d5e4c4e</Hash>
</Codenesium>*/