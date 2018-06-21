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
        public class PersonService : AbstractPersonService, IPersonService
        {
                public PersonService(
                        ILogger<IPersonRepository> logger,
                        IPersonRepository personRepository,
                        IApiPersonRequestModelValidator personModelValidator,
                        IBOLPersonMapper bolpersonMapper,
                        IDALPersonMapper dalpersonMapper,
                        IBOLBusinessEntityContactMapper bolBusinessEntityContactMapper,
                        IDALBusinessEntityContactMapper dalBusinessEntityContactMapper,
                        IBOLEmailAddressMapper bolEmailAddressMapper,
                        IDALEmailAddressMapper dalEmailAddressMapper,
                        IBOLPasswordMapper bolPasswordMapper,
                        IDALPasswordMapper dalPasswordMapper,
                        IBOLPersonPhoneMapper bolPersonPhoneMapper,
                        IDALPersonPhoneMapper dalPersonPhoneMapper
                        )
                        : base(logger,
                               personRepository,
                               personModelValidator,
                               bolpersonMapper,
                               dalpersonMapper,
                               bolBusinessEntityContactMapper,
                               dalBusinessEntityContactMapper,
                               bolEmailAddressMapper,
                               dalEmailAddressMapper,
                               bolPasswordMapper,
                               dalPasswordMapper,
                               bolPersonPhoneMapper,
                               dalPersonPhoneMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>b75d08feaea995326fbba037849b65e5</Hash>
</Codenesium>*/