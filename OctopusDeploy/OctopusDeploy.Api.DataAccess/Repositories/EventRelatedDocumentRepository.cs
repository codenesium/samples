using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class EventRelatedDocumentRepository : AbstractEventRelatedDocumentRepository, IEventRelatedDocumentRepository
        {
                public EventRelatedDocumentRepository(
                        ILogger<EventRelatedDocumentRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>beba0e3de0e2e4c045601a37de1325f7</Hash>
</Codenesium>*/