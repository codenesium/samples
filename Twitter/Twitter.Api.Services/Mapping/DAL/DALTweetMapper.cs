using Microsoft.EntityFrameworkCore;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class DALTweetMapper : DALAbstractTweetMapper, IDALTweetMapper
	{
		public DALTweetMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>a616913b3b0f5959430d4ecba7803210</Hash>
</Codenesium>*/