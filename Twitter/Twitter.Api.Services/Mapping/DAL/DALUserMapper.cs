using Microsoft.EntityFrameworkCore;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class DALUserMapper : DALAbstractUserMapper, IDALUserMapper
	{
		public DALUserMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>aaa5af7e75d6ad39c886d5eab8569f1d</Hash>
</Codenesium>*/