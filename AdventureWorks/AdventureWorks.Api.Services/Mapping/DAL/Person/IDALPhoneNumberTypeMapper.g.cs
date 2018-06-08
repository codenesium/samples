using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALPhoneNumberTypeMapper
        {
                PhoneNumberType MapBOToEF(
                        BOPhoneNumberType bo);

                BOPhoneNumberType MapEFToBO(
                        PhoneNumberType efPhoneNumberType);

                List<BOPhoneNumberType> MapEFToBO(
                        List<PhoneNumberType> records);
        }
}

/*<Codenesium>
    <Hash>e975dc59e142b42b98e401d2d07a262b</Hash>
</Codenesium>*/