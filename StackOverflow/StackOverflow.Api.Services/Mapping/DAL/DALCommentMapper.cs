using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class DALCommentMapper : DALAbstractCommentMapper, IDALCommentMapper
	{
		public DALCommentMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>c9ea089b83bf60ed2f5890193e20bebe</Hash>
</Codenesium>*/