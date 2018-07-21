using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public interface IDALRowVersionCheckMapper
        {
                RowVersionCheck MapBOToEF(
                        BORowVersionCheck bo);

                BORowVersionCheck MapEFToBO(
                        RowVersionCheck efRowVersionCheck);

                List<BORowVersionCheck> MapEFToBO(
                        List<RowVersionCheck> records);
        }
}

/*<Codenesium>
    <Hash>18386ec70d96643e47531a6e171a5faf</Hash>
</Codenesium>*/