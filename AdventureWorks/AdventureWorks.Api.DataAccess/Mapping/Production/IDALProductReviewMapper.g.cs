using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALProductReviewMapper
	{
		void MapDTOToEF(
			int productReviewID,
			DTOProductReview dto,
			ProductReview efProductReview);

		DTOProductReview MapEFToDTO(
			ProductReview efProductReview);
	}
}

/*<Codenesium>
    <Hash>f282e9f5bed1b03558670e7c514dcef1</Hash>
</Codenesium>*/