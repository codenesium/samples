using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>62e150f83acb080f0a5f24a36d6454be</Hash>
</Codenesium>*/