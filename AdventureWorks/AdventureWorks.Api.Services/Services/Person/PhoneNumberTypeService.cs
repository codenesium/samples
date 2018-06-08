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
                        IDALPhoneNumberTypeMapper dalphoneNumberTypeMapper)
                        : base(logger,
                               phoneNumberTypeRepository,
                               phoneNumberTypeModelValidator,
                               bolphoneNumberTypeMapper,
                               dalphoneNumberTypeMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>2cb7f251e6ae13bb919703a56fe533ea</Hash>
</Codenesium>*/