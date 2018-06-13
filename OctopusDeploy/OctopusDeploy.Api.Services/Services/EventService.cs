using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class EventService: AbstractEventService, IEventService
        {
                public EventService(
                        ILogger<EventRepository> logger,
                        IEventRepository eventRepository,
                        IApiEventRequestModelValidator eventModelValidator,
                        IBOLEventMapper boleventMapper,
                        IDALEventMapper daleventMapper
                        ,
                        IBOLEventRelatedDocumentMapper bolEventRelatedDocumentMapper,
                        IDALEventRelatedDocumentMapper dalEventRelatedDocumentMapper

                        )
                        : base(logger,
                               eventRepository,
                               eventModelValidator,
                               boleventMapper,
                               daleventMapper
                               ,
                               bolEventRelatedDocumentMapper,
                               dalEventRelatedDocumentMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>438a374e0e37d74d220ca40a98499add</Hash>
</Codenesium>*/