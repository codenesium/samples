using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class DocumentRepository : AbstractDocumentRepository, IDocumentRepository
        {
                public DocumentRepository(
                        ILogger<DocumentRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>046494a0e07fd719cf6bd4728141b40a</Hash>
</Codenesium>*/