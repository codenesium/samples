using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALContactTypeMapper : DALAbstractContactTypeMapper, IDALContactTypeMapper
	{
		public DALContactTypeMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>4c8e75241824f672a23e5456fa867404</Hash>
</Codenesium>*/