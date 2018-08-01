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
    <Hash>7973d642e1d492e92cf25559065707e0</Hash>
</Codenesium>*/