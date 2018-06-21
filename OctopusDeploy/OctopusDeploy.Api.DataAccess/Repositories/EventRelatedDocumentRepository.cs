using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class EventRelatedDocumentRepository : AbstractEventRelatedDocumentRepository, IEventRelatedDocumentRepository
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
    <Hash>80637df23a41e22f26f1c990367475de</Hash>
</Codenesium>*/