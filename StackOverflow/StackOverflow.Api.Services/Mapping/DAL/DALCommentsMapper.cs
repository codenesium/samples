using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
        public partial class DALCommentsMapper : DALAbstractCommentsMapper, IDALCommentsMapper
        {
                public DALCommentsMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>c358458a25a7a04b76403e37b5e272cc</Hash>
</Codenesium>*/