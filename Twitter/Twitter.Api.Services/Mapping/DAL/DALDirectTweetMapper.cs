using Microsoft.EntityFrameworkCore;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class DALDirectTweetMapper : DALAbstractDirectTweetMapper, IDALDirectTweetMapper
	{
		public DALDirectTweetMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>70db18afc72b91bbe39bdd1992b876d7</Hash>
</Codenesium>*/