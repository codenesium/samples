using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class DocumentService : AbstractDocumentService, IDocumentService
        {
                public DocumentService(
                        ILogger<IDocumentRepository> logger,
                        IDocumentRepository documentRepository,
                        IApiDocumentRequestModelValidator documentModelValidator,
                        IBOLDocumentMapper boldocumentMapper,
                        IDALDocumentMapper daldocumentMapper
                        )
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
    <Hash>f69a8bc9357a6f3680c6ed7627c22d03</Hash>
</Codenesium>*/