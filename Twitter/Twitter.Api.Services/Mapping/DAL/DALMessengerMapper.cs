using Microsoft.EntityFrameworkCore;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class DALMessengerMapper : DALAbstractMessengerMapper, IDALMessengerMapper
	{
		public DALMessengerMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>4b3aa9bb6351b8e3a296280bca49be58</Hash>
</Codenesium>*/