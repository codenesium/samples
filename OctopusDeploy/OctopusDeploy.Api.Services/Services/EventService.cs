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
                        ILogger<IEventRepository> logger,
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
    <Hash>a825856a007cbd96c62dc72585522ea0</Hash>
</Codenesium>*/