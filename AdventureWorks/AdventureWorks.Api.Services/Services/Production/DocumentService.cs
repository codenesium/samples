using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DocumentService: AbstractDocumentService, IDocumentService
        {
                public DocumentService(
                        ILogger<DocumentRepository> logger,
                        IDocumentRepository documentRepository,
                        IApiDocumentRequestModelValidator documentModelValidator,
                        IBOLDocumentMapper boldocumentMapper,
                        IDALDocumentMapper daldocumentMapper
                        ,
                        IBOLProductDocumentMapper bolProductDocumentMapper,
                        IDALProductDocumentMapper dalProductDocumentMapper

                        )
                        : base(logger,
                               documentRepository,
                               documentModelValidator,
                               boldocumentMapper,
                               daldocumentMapper
                               ,
                               bolProductDocumentMapper,
                               dalProductDocumentMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>241796ef02a86063ad2a6dd3377e1ab8</Hash>
</Codenesium>*/