using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALUsersMapper
	{
		Users MapBOToEF(
			BOUsers bo);

		BOUsers MapEFToBO(
			Users efUsers);

		List<BOUsers> MapEFToBO(
			List<Users> records);
	}
}

/*<Codenesium>
    <Hash>f63a8ab52687d1a59fa80636559af47e</Hash>
</Codenesium>*/