using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public interface IDALUsersMapper
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
    <Hash>d759054b67458afff75360886d313efd</Hash>
</Codenesium>*/