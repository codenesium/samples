using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public interface IDALPostTypesMapper
        {
                PostTypes MapBOToEF(
                        BOPostTypes bo);

                BOPostTypes MapEFToBO(
                        PostTypes efPostTypes);

                List<BOPostTypes> MapEFToBO(
                        List<PostTypes> records);
        }
}

/*<Codenesium>
    <Hash>ef54421c6b4b5a212322270b6065b8ce</Hash>
</Codenesium>*/