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
    <Hash>2e999631e69ccccb5cac6113bbb6c4ed</Hash>
</Codenesium>*/