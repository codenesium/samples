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

		public virtual int Create(
			ProductReviewModel model)
		{
			EFProductReview record = new EFProductReview();

			this.Mapper.ProductReviewMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFProductReview>().Add(record);
			this.Context.SaveChanges();
			return record.ProductReviewID;
		}

		public virtual void Update(
			int productReviewID,
			ProductReviewModel model)
		{
			EFProductReview record = this.SearchLinqEF(x => x.ProductReviewID == productReviewID).FirstOrDefault();
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
			EFProductReview record = this.SearchLinqEF(x => x.ProductReviewID == productReviewID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFProductReview>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual POCOProductReview Get(int productReviewID)
		{
			return this.SearchLinqPOCO(x => x.ProductReviewID == productReviewID).FirstOrDefault();
		}

		public virtual List<POCOProductReview> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		private List<POCOProductReview> Where(Expression<Func<EFProductReview, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOProductReview> SearchLinqPOCO(Expression<Func<EFProductReview, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductReview> response = new List<POCOProductReview>();
			List<EFProductReview> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ProductReviewMapEFToPOCO(x)));
			return response;
		}

		private List<EFProductReview> SearchLinqEF(Expression<Func<EFProductReview, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFProductReview>().Where(predicate).AsQueryable().OrderBy("ProductReviewID ASC").Skip(skip).Take(take).ToList<EFProductReview>();
			}
			else
			{
				return this.Context.Set<EFProductReview>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductReview>();
			}
		}

		private List<EFProductReview> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFProductReview>().Where(predicate).AsQueryable().OrderBy("ProductReviewID ASC").Skip(skip).Take(take).ToList<EFProductReview>();
			}
			else
			{
				return this.Context.Set<EFProductReview>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductReview>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>f8262878bf274d502124ba873b06e425</Hash>
</Codenesium>*/