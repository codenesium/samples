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
                        IDALProvinceMapper dalprovinceMapper
                        ,
                        IBOLCityMapper bolCityMapper,
                        IDALCityMapper dalCityMapper
                        ,
                        IBOLVenueMapper bolVenueMapper,
                        IDALVenueMapper dalVenueMapper

                        )
                        : base(logger,
                               provinceRepository,
                               provinceModelValidator,
                               bolprovinceMapper,
                               dalprovinceMapper
                               ,
                               bolCityMapper,
                               dalCityMapper
                               ,
                               bolVenueMapper,
                               dalVenueMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>19c5ae819aba3acf8b410362c30ea63a</Hash>
</Codenesium>*/