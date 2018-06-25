using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class DocumentRepository : AbstractDocumentRepository, IDocumentRepository
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
    <Hash>59306ac03260fa19ca805e7b432ce008</Hash>
</Codenesium>*/