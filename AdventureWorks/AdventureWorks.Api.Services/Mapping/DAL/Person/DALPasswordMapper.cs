using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALPasswordMapper : DALAbstractPasswordMapper, IDALPasswordMapper
	{
		public DALPasswordMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>4b0f949ee36c59c482b6d021ddb538dd</Hash>
</Codenesium>*/