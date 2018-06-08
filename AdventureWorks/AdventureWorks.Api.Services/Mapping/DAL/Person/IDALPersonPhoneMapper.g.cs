using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALPersonPhoneMapper
        {
                PersonPhone MapBOToEF(
                        BOPersonPhone bo);

                BOPersonPhone MapEFToBO(
                        PersonPhone efPersonPhone);

                List<BOPersonPhone> MapEFToBO(
                        List<PersonPhone> records);
        }
}

/*<Codenesium>
    <Hash>181e4a390efa0af8a6735669434e89d6</Hash>
</Codenesium>*/