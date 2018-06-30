using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
        public partial class DALPostsMapper : DALAbstractPostsMapper, IDALPostsMapper
        {
                public DALPostsMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>954fd4ed99f4187aaafff8bd94f17518</Hash>
</Codenesium>*/