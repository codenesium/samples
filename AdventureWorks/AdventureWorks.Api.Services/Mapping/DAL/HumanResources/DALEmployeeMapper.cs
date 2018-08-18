using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALEmployeeMapper : DALAbstractEmployeeMapper, IDALEmployeeMapper
	{
		public DALEmployeeMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>651ad9125a48a8c185074cb727329d7a</Hash>
</Codenesium>*/