using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>f171553a7cfaa20b6f319b04300ddd29</Hash>
</Codenesium>*/