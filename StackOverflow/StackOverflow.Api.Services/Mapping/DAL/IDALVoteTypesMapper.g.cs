using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public interface IDALVoteTypesMapper
        {
                VoteTypes MapBOToEF(
                        BOVoteTypes bo);

                BOVoteTypes MapEFToBO(
                        VoteTypes efVoteTypes);

                List<BOVoteTypes> MapEFToBO(
                        List<VoteTypes> records);
        }
}

/*<Codenesium>
    <Hash>c1d929e2331848d9d0e917fd13a4e274</Hash>
</Codenesium>*/