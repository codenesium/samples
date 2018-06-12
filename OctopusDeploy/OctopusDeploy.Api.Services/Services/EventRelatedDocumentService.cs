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
        public class EventRelatedDocumentService: AbstractEventRelatedDocumentService, IEventRelatedDocumentService
        {
                public EventRelatedDocumentService(
                        ILogger<EventRelatedDocumentRepository> logger,
                        IEventRelatedDocumentRepository eventRelatedDocumentRepository,
                        IApiEventRelatedDocumentRequestModelValidator eventRelatedDocumentModelValidator,
                        IBOLEventRelatedDocumentMapper boleventRelatedDocumentMapper,
                        IDALEventRelatedDocumentMapper daleventRelatedDocumentMapper)
                        : base(logger,
                               eventRelatedDocumentRepository,
                               eventRelatedDocumentModelValidator,
                               boleventRelatedDocumentMapper,
                               daleventRelatedDocumentMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>fb1fe24af0ca807c92a916a42a257023</Hash>
</Codenesium>*/