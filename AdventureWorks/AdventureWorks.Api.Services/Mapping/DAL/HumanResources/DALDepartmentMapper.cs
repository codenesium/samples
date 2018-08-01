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
    <Hash>583ecdbe136587d3150b2b56208a03f9</Hash>
</Codenesium>*/