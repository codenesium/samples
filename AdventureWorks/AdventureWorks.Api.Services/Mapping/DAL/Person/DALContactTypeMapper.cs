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
    <Hash>92373c87f26947381b072eb868a477d1</Hash>
</Codenesium>*/