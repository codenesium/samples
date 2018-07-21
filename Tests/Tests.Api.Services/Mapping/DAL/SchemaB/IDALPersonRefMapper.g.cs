using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public interface IDALPersonRefMapper
        {
                PersonRef MapBOToEF(
                        BOPersonRef bo);

                BOPersonRef MapEFToBO(
                        PersonRef efPersonRef);

                List<BOPersonRef> MapEFToBO(
                        List<PersonRef> records);
        }
}

/*<Codenesium>
    <Hash>dfe07ec1a190efad3dc470958c13a3a0</Hash>
</Codenesium>*/