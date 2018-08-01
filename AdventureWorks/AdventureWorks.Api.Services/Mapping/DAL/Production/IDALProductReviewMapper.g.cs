using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALProductReviewMapper
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
    <Hash>95f3f4ade6db15409494f87bc4a5df76</Hash>
</Codenesium>*/