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
    <Hash>e070ef891c526e5296915ec20bd212d1</Hash>
</Codenesium>*/