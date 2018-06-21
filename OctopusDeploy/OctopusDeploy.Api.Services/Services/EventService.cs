using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
        public class EventService : AbstractEventService, IEventService
        {
                public EventService(
                        ILogger<IEventRepository> logger,
                        IEventRepository eventRepository,
                        IApiEventRequestModelValidator eventModelValidator,
                        IBOLEventMapper boleventMapper,
                        IDALEventMapper daleventMapper,
                        IBOLEventRelatedDocumentMapper bolEventRelatedDocumentMapper,
                        IDALEventRelatedDocumentMapper dalEventRelatedDocumentMapper
                        )
                        : base(logger,
                               eventRepository,
                               eventModelValidator,
                               boleventMapper,
                               daleventMapper,
                               bolEventRelatedDocumentMapper,
                               dalEventRelatedDocumentMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>8295280997e67dc7bbd046e7b28653b7</Hash>
</Codenesium>*/