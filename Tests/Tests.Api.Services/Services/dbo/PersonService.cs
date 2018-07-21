using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public partial class PersonService : AbstractPersonService, IPersonService
        {
                public PersonService(
                        ILogger<IPersonRepository> logger,
                        IPersonRepository personRepository,
                        IApiPersonRequestModelValidator personModelValidator,
                        IBOLPersonMapper bolpersonMapper,
                        IDALPersonMapper dalpersonMapper
                        )
                        : base(logger,
                               personRepository,
                               personModelValidator,
                               bolpersonMapper,
                               dalpersonMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>5e117d690b388e543d12766504308c06</Hash>
</Codenesium>*/