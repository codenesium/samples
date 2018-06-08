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
                        IDALDocumentMapper daldocumentMapper)
                        : base(logger,
                               documentRepository,
                               documentModelValidator,
                               boldocumentMapper,
                               daldocumentMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>850350b392326d761192a5f0bed0d08d</Hash>
</Codenesium>*/