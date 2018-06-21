using Codenesium.DataConversionExtensions;
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
        public class ProvinceService : AbstractProvinceService, IProvinceService
        {
                public ProvinceService(
                        ILogger<IProvinceRepository> logger,
                        IProvinceRepository provinceRepository,
                        IApiProvinceRequestModelValidator provinceModelValidator,
                        IBOLProvinceMapper bolprovinceMapper,
                        IDALProvinceMapper dalprovinceMapper,
                        IBOLCityMapper bolCityMapper,
                        IDALCityMapper dalCityMapper,
                        IBOLVenueMapper bolVenueMapper,
                        IDALVenueMapper dalVenueMapper
                        )
                        : base(logger,
                               provinceRepository,
                               provinceModelValidator,
                               bolprovinceMapper,
                               dalprovinceMapper,
                               bolCityMapper,
                               dalCityMapper,
                               bolVenueMapper,
                               dalVenueMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>2a9e2a69868f6a18f46aaafe1a6fdaf5</Hash>
</Codenesium>*/