using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public interface IDALVotesMapper
        {
                Votes MapBOToEF(
                        BOVotes bo);

                BOVotes MapEFToBO(
                        Votes efVotes);

                List<BOVotes> MapEFToBO(
                        List<Votes> records);
        }
}

/*<Codenesium>
    <Hash>22f4a18ee288387da52ce1e79c6de04e</Hash>
</Codenesium>*/