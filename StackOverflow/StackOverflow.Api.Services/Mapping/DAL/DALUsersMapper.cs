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
    <Hash>b1a46619c1c7dd18a087ba4d6272ed4d</Hash>
</Codenesium>*/