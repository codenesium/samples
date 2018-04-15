using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractProductReviewRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractProductReviewRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			ProductReviewModel model)
		{
			var record = new EFProductReview();

			this.mapper.ProductReviewMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFProductReview>().Add(record);
			this.context.SaveChanges();
			return record.ProductReviewID;
		}

		public virtual void Update(
			int productReviewID,
			ProductReviewModel model)
		{
			var record = this.SearchLinqEF(x => x.ProductReviewID == productReviewID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{productReviewID}");
			}
			else
			{
				this.mapper.ProductReviewMapModelToEF(
					productReviewID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productReviewID)
		{
			var record = this.SearchLinqEF(x => x.ProductReviewID == productReviewID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFProductReview>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int productReviewID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ProductReviewID == productReviewID, response);
			return response;
		}

		public virtual POCOProductReview GetByIdDirect(int productReviewID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ProductReviewID == productReviewID, response);
			return response.ProductReviews.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductReview, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOProductReview> GetWhereDirect(Expression<Func<EFProductReview, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ProductReviews;
		}

		private void SearchLinqPOCO(Expression<Func<EFProductReview, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProductReview> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ProductReviewMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProductReview> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ProductReviewMapEFToPOCO(x, response));
		}

		protected virtual List<EFProductReview> SearchLinqEF(Expression<Func<EFProductReview, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductReview> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>8f7f7dc6d5f244896e2e932b4c80d50b</Hash>
</Codenesium>*/