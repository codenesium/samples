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
    <Hash>12f03a870c4c97716119a8b1025bbd79</Hash>
</Codenesium>*/