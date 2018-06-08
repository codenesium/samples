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
        public class PersonService: AbstractPersonService, IPersonService
        {
                public PersonService(
                        ILogger<PersonRepository> logger,
                        IPersonRepository personRepository,
                        IApiPersonRequestModelValidator personModelValidator,
                        IBOLPersonMapper bolpersonMapper,
                        IDALPersonMapper dalpersonMapper)
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
    <Hash>521551727b9934fa34ec6b530ffc400d</Hash>
</Codenesium>*/