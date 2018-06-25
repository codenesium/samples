using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
        public partial class DALUsersMapper : DALAbstractUsersMapper, IDALUsersMapper
        {
                public DALUsersMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>fce4a2e9f302cbbb45f253e817c138da</Hash>
</Codenesium>*/