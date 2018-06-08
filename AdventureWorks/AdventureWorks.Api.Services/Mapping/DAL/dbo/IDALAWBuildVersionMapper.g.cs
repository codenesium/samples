using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>fb45cf21d3dee09ae23b84575b1f7990</Hash>
</Codenesium>*/