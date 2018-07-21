using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public interface IDALTableMapper
        {
                Table MapBOToEF(
                        BOTable bo);

                BOTable MapEFToBO(
                        Table efTable);

                List<BOTable> MapEFToBO(
                        List<Table> records);
        }
}

/*<Codenesium>
    <Hash>688864a6eed204cfec5177833bf4c647</Hash>
</Codenesium>*/