using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public interface IDALPostHistoryMapper
        {
                PostHistory MapBOToEF(
                        BOPostHistory bo);

                BOPostHistory MapEFToBO(
                        PostHistory efPostHistory);

                List<BOPostHistory> MapEFToBO(
                        List<PostHistory> records);
        }
}

/*<Codenesium>
    <Hash>53c9cee0fd2c0eaf6dc0253d7cff0e08</Hash>
</Codenesium>*/