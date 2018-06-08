using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALIllustrationMapper
        {
                Illustration MapBOToEF(
                        BOIllustration bo);

                BOIllustration MapEFToBO(
                        Illustration efIllustration);

                List<BOIllustration> MapEFToBO(
                        List<Illustration> records);
        }
}

/*<Codenesium>
    <Hash>de2e803e03f0b1cf75a92ed426a84f69</Hash>
</Codenesium>*/