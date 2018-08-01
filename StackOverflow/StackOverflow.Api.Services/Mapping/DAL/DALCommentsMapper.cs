using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class DALCommentsMapper : DALAbstractCommentsMapper, IDALCommentsMapper
	{
		public DALCommentsMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>0813c32141380d0239edadbb8aee450f</Hash>
</Codenesium>*/