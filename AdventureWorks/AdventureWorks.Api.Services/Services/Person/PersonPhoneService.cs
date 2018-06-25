using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public partial class PersonPhoneService : AbstractPersonPhoneService, IPersonPhoneService
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
    <Hash>63b359ec1c09152f6e86a1abdadabbde</Hash>
</Codenesium>*/