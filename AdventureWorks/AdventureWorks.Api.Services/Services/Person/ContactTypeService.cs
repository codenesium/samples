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
        public class ContactTypeService: AbstractContactTypeService, IContactTypeService
        {
                public ContactTypeService(
                        ILogger<ContactTypeRepository> logger,
                        IContactTypeRepository contactTypeRepository,
                        IApiContactTypeRequestModelValidator contactTypeModelValidator,
                        IBOLContactTypeMapper bolcontactTypeMapper,
                        IDALContactTypeMapper dalcontactTypeMapper
                        ,
                        IBOLBusinessEntityContactMapper bolBusinessEntityContactMapper,
                        IDALBusinessEntityContactMapper dalBusinessEntityContactMapper

                        )
                        : base(logger,
                               contactTypeRepository,
                               contactTypeModelValidator,
                               bolcontactTypeMapper,
                               dalcontactTypeMapper
                               ,
                               bolBusinessEntityContactMapper,
                               dalBusinessEntityContactMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>89374e2460aea430f1b2f687f629b94d</Hash>
</Codenesium>*/