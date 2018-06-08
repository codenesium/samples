using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class DocumentRepository: AbstractDocumentRepository, IDocumentRepository
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
    <Hash>e4ded7d3aef2c587e5680745ff6d4baf</Hash>
</Codenesium>*/