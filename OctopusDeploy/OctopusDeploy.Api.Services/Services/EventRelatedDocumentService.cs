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
        public partial class EventRelatedDocumentService : AbstractEventRelatedDocumentService, IEventRelatedDocumentService
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
    <Hash>e6dc5bafb58da7df6fa6d3cc8a1d365c</Hash>
</Codenesium>*/