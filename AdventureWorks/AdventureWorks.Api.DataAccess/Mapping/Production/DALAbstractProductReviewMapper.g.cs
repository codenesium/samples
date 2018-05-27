using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALProductReviewMapper
	{
		public virtual void MapDTOToEF(
			int productReviewID,
			DTOProductReview dto,
			ProductReview efProductReview)
		{
			efProductReview.SetProperties(
				productReviewID,
				dto.Comments,
				dto.EmailAddress,
				dto.ModifiedDate,
				dto.ProductID,
				dto.Rating,
				dto.ReviewDate,
				dto.ReviewerName);
		}

		public virtual DTOProductReview MapEFToDTO(
			ProductReview ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOProductReview();

			dto.SetProperties(
				ef.ProductReviewID,
				ef.Comments,
				ef.EmailAddress,
				ef.ModifiedDate,
				ef.ProductID,
				ef.Rating,
				ef.ReviewDate,
				ef.ReviewerName);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>423cdf3eb4cef4184e4a029249f7d3e2</Hash>
</Codenesium>*/