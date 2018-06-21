using Codenesium.DataConversionExtensions;
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
        public class EventRelatedDocumentService : AbstractEventRelatedDocumentService, IEventRelatedDocumentService
        {
                public EventRelatedDocumentService(
                        ILogger<IEventRelatedDocumentRepository> logger,
                        IEventRelatedDocumentRepository eventRelatedDocumentRepository,
                        IApiEventRelatedDocumentRequestModelValidator eventRelatedDocumentModelValidator,
                        IBOLEventRelatedDocumentMapper boleventRelatedDocumentMapper,
                        IDALEventRelatedDocumentMapper daleventRelatedDocumentMapper
                        )
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
    <Hash>10487f9daace59b1d982d1850abc9427</Hash>
</Codenesium>*/