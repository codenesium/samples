using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public partial class DocumentService : AbstractDocumentService, IDocumentService
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
    <Hash>c3c9b82dbdbb367f3eaab3ddb717f440</Hash>
</Codenesium>*/