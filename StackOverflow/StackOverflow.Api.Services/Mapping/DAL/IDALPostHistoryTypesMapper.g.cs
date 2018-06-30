using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public interface IDALPostHistoryTypesMapper
        {
                PostHistoryTypes MapBOToEF(
                        BOPostHistoryTypes bo);

                BOPostHistoryTypes MapEFToBO(
                        PostHistoryTypes efPostHistoryTypes);

                List<BOPostHistoryTypes> MapEFToBO(
                        List<PostHistoryTypes> records);
        }
}

/*<Codenesium>
    <Hash>84c9563a53d70442a58fc533481cbc46</Hash>
</Codenesium>*/