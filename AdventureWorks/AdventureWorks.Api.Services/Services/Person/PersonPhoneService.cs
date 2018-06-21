using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class PersonPhoneService : AbstractPersonPhoneService, IPersonPhoneService
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
                               dalpersonPhoneMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>3b3be9460f6f6b15f0d2f90cbb645f04</Hash>
</Codenesium>*/