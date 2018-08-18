using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductReviewMapper
	{
		ProductReview MapBOToEF(
			BOProductReview bo);

		BOProductReview MapEFToBO(
			ProductReview efProductReview);

		List<BOProductReview> MapEFToBO(
			List<ProductReview> records);
	}
}

/*<Codenesium>
    <Hash>252e5d70640435c57997b5c4fb9d78cb</Hash>
</Codenesium>*/