using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALProductReviewMapper : DALAbstractProductReviewMapper, IDALProductReviewMapper
	{
		public DALProductReviewMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>feb26743ab93fbd982d8038ba608873b</Hash>
</Codenesium>*/