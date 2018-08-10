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
    <Hash>5fb1b0084c766c7762be747e89bac8c4</Hash>
</Codenesium>*/