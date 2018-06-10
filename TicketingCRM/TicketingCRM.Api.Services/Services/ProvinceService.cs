using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class ProvinceService: AbstractProvinceService, IProvinceService
        {
                public ProvinceService(
                        ILogger<ProvinceRepository> logger,
                        IProvinceRepository provinceRepository,
                        IApiProvinceRequestModelValidator provinceModelValidator,
                        IBOLProvinceMapper bolprovinceMapper,
                        IDALProvinceMapper dalprovinceMapper)
                        : base(logger,
                               provinceRepository,
                               provinceModelValidator,
                               bolprovinceMapper,
                               dalprovinceMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>e911aa72715509df95ef35336f0d10f7</Hash>
</Codenesium>*/