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
        public class PhoneNumberTypeService: AbstractPhoneNumberTypeService, IPhoneNumberTypeService
        {
                public PhoneNumberTypeService(
                        ILogger<PhoneNumberTypeRepository> logger,
                        IPhoneNumberTypeRepository phoneNumberTypeRepository,
                        IApiPhoneNumberTypeRequestModelValidator phoneNumberTypeModelValidator,
                        IBOLPhoneNumberTypeMapper bolphoneNumberTypeMapper,
                        IDALPhoneNumberTypeMapper dalphoneNumberTypeMapper
                        ,
                        IBOLPersonPhoneMapper bolPersonPhoneMapper,
                        IDALPersonPhoneMapper dalPersonPhoneMapper

                        )
                        : base(logger,
                               phoneNumberTypeRepository,
                               phoneNumberTypeModelValidator,
                               bolphoneNumberTypeMapper,
                               dalphoneNumberTypeMapper
                               ,
                               bolPersonPhoneMapper,
                               dalPersonPhoneMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>23350f3bca986f848db26dc4008c6fdd</Hash>
</Codenesium>*/