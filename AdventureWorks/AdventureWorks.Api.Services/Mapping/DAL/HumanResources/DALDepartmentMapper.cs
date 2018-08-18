using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALDepartmentMapper : DALAbstractDepartmentMapper, IDALDepartmentMapper
	{
		public DALDepartmentMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>08d9eee786c5f981fba5e00028f2ca5f</Hash>
</Codenesium>*/