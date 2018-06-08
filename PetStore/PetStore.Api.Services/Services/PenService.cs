using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public class PenService: AbstractPenService, IPenService
        {
                public PenService(
                        ILogger<PenRepository> logger,
                        IPenRepository penRepository,
                        IApiPenRequestModelValidator penModelValidator,
                        IBOLPenMapper bolpenMapper,
                        IDALPenMapper dalpenMapper)
                        : base(logger,
                               penRepository,
                               penModelValidator,
                               bolpenMapper,
                               dalpenMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>4ef5581cc6ad3e031bd77fbfeb2a7a99</Hash>
</Codenesium>*/