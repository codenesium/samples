using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>66ba8c5540cbf0d545b51591476e0bb1</Hash>
</Codenesium>*/