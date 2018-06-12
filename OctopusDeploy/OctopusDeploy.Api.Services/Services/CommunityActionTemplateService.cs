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
        public class CommunityActionTemplateService: AbstractCommunityActionTemplateService, ICommunityActionTemplateService
        {
                public CommunityActionTemplateService(
                        ILogger<CommunityActionTemplateRepository> logger,
                        ICommunityActionTemplateRepository communityActionTemplateRepository,
                        IApiCommunityActionTemplateRequestModelValidator communityActionTemplateModelValidator,
                        IBOLCommunityActionTemplateMapper bolcommunityActionTemplateMapper,
                        IDALCommunityActionTemplateMapper dalcommunityActionTemplateMapper)
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
    <Hash>1c240b2bb8d3bd9b6e38067eb902ca0d</Hash>
</Codenesium>*/