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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductReviewRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOProductReview> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOProductReview Get(int productReviewID)
		{
			return this.SearchLinqPOCO(x => x.ProductReviewID == productReviewID).FirstOrDefault();
		}

		public virtual POCOProductReview Create(
			ApiProductReviewModel model)
		{
			ProductReview record = new ProductReview();

			this.Mapper.ProductReviewMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ProductReview>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ProductReviewMapEFToPOCO(record);
		}

		public virtual void Update(
			int productReviewID,
			ApiProductReviewModel model)
		{
			ProductReview record = this.SearchLinqEF(x => x.ProductReviewID == productReviewID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productReviewID}");
			}
			else
			{
				this.Mapper.ProductReviewMapModelToEF(
					productReviewID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productReviewID)
		{
			ProductReview record = this.SearchLinqEF(x => x.ProductReviewID == productReviewID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductReview>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public List<POCOProductReview> GetCommentsProductIDReviewerName(string comments,int productID,string reviewerName)
		{
			return this.SearchLinqPOCO(x => x.Comments == comments && x.ProductID == productID && x.ReviewerName == reviewerName);
		}

		protected List<POCOProductReview> Where(Expression<Func<ProductReview, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOProductReview> SearchLinqPOCO(Expression<Func<ProductReview, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductReview> response = new List<POCOProductReview>();
			List<ProductReview> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ProductReviewMapEFToPOCO(x)));
			return response;
		}

		private List<ProductReview> SearchLinqEF(Expression<Func<ProductReview, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductReview.ProductReviewID)} ASC";
			}
			return this.Context.Set<ProductReview>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductReview>();
		}

		private List<ProductReview> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductReview.ProductReviewID)} ASC";
			}

			return this.Context.Set<ProductReview>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductReview>();
		}
	}
}

/*<Codenesium>
    <Hash>be01f560c8fabeb441ff7ef3fcda2380</Hash>
</Codenesium>*/