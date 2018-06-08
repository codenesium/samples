using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>c168da0624f93bbac7db918ac7c39546</Hash>
</Codenesium>*/