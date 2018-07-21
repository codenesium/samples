using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public interface IDALTimestampCheckMapper
        {
                TimestampCheck MapBOToEF(
                        BOTimestampCheck bo);

                BOTimestampCheck MapEFToBO(
                        TimestampCheck efTimestampCheck);

                List<BOTimestampCheck> MapEFToBO(
                        List<TimestampCheck> records);
        }
}

/*<Codenesium>
    <Hash>f5135aa905d2a48e980d78b2e47dfe42</Hash>
</Codenesium>*/