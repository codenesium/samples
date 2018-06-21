using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALPasswordMapper
        {
                Password MapBOToEF(
                        BOPassword bo);

                BOPassword MapEFToBO(
                        Password efPassword);

                List<BOPassword> MapEFToBO(
                        List<Password> records);
        }
}

/*<Codenesium>
    <Hash>9b33ad7449324f374bf613f4421b503b</Hash>
</Codenesium>*/