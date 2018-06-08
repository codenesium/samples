using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALCultureMapper
        {
                Culture MapBOToEF(
                        BOCulture bo);

                BOCulture MapEFToBO(
                        Culture efCulture);

                List<BOCulture> MapEFToBO(
                        List<Culture> records);
        }
}

/*<Codenesium>
    <Hash>88dda855b686b075f6048175168665e9</Hash>
</Codenesium>*/