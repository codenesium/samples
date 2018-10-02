using Microsoft.EntityFrameworkCore;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class DALMessageMapper : DALAbstractMessageMapper, IDALMessageMapper
	{
		public DALMessageMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>60d2b364f5c42b2cee907290a29d8c1e</Hash>
</Codenesium>*/