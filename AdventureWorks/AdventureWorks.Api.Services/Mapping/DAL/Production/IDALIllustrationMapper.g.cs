using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>78ff5984e2ff31ac70c61df6a56f859c</Hash>
</Codenesium>*/