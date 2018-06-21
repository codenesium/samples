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
        public class CommunityActionTemplateService : AbstractCommunityActionTemplateService, ICommunityActionTemplateService
        {
                public CommunityActionTemplateService(
                        ILogger<ICommunityActionTemplateRepository> logger,
                        ICommunityActionTemplateRepository communityActionTemplateRepository,
                        IApiCommunityActionTemplateRequestModelValidator communityActionTemplateModelValidator,
                        IBOLCommunityActionTemplateMapper bolcommunityActionTemplateMapper,
                        IDALCommunityActionTemplateMapper dalcommunityActionTemplateMapper
                        )
                        : base(logger,
                               communityActionTemplateRepository,
                               communityActionTemplateModelValidator,
                               bolcommunityActionTemplateMapper,
                               dalcommunityActionTemplateMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>b80f6a789a12c271037e3aa42aaea422</Hash>
</Codenesium>*/