using Codenesium.DataConversionExtensions;
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
    <Hash>6648c98f16530d8307cd571f8ee971ab</Hash>
</Codenesium>*/