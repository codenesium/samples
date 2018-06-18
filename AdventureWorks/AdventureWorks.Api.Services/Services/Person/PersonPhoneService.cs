using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class PersonPhoneService: AbstractPersonPhoneService, IPersonPhoneService
        {
                public PersonPhoneService(
                        ILogger<IPersonPhoneRepository> logger,
                        IPersonPhoneRepository personPhoneRepository,
                        IApiPersonPhoneRequestModelValidator personPhoneModelValidator,
                        IBOLPersonPhoneMapper bolpersonPhoneMapper,
                        IDALPersonPhoneMapper dalpersonPhoneMapper

                        )
                        : base(logger,
                               personPhoneRepository,
                               personPhoneModelValidator,
                               bolpersonPhoneMapper,
                               dalpersonPhoneMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>95ac65995432862a29e7ae4d98c424d6</Hash>
</Codenesium>*/