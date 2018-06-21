using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALAWBuildVersionMapper
        {
                AWBuildVersion MapBOToEF(
                        BOAWBuildVersion bo);

                BOAWBuildVersion MapEFToBO(
                        AWBuildVersion efAWBuildVersion);

                List<BOAWBuildVersion> MapEFToBO(
                        List<AWBuildVersion> records);
        }
}

/*<Codenesium>
    <Hash>746fa1ba56e09b616b33e0a38ba59abc</Hash>
</Codenesium>*/