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
                               daleventRelatedDocumentMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>dde775fc1058b1342e7194bc1b10eb03</Hash>
</Codenesium>*/