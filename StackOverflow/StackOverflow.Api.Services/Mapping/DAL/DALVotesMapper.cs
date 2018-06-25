using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
        public partial class DALVotesMapper : DALAbstractVotesMapper, IDALVotesMapper
        {
                public DALVotesMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>9f4aad8cafc353855727aa85411d18cd</Hash>
</Codenesium>*/