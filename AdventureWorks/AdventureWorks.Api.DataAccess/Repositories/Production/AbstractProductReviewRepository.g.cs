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

		public AbstractProductReviewRepository(ILogger logger,
		                                       ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(int productID,
		                          string reviewerName,
		                          DateTime reviewDate,
		                          string emailAddress,
		                          int rating,
		                          string comments,
		                          DateTime modifiedDate)
		{
			var record = new EFProductReview ();

			MapPOCOToEF(0, productID,
			            reviewerName,
			            reviewDate,
			            emailAddress,
			            rating,
			            comments,
			            modifiedDate, record);

			this.context.Set<EFProductReview>().Add(record);
			this.context.SaveChanges();
			return record.ProductReviewID;
		}

		public virtual void Update(int productReviewID, int productID,
		                           string reviewerName,
		                           DateTime reviewDate,
		                           string emailAddress,
		                           int rating,
		                           string comments,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.ProductReviewID == productReviewID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",productReviewID);
			}
			else
			{
				MapPOCOToEF(productReviewID,  productID,
				            reviewerName,
				            reviewDate,
				            emailAddress,
				            rating,
				            comments,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int productReviewID)
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

		public virtual void GetById(int productReviewID, Response response)
		{
			this.SearchLinqPOCO(x => x.ProductReviewID == productReviewID,response);
		}

		protected virtual List<EFProductReview> SearchLinqEF(Expression<Func<EFProductReview, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductReview> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFProductReview, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		public virtual List<POCOProductReview > GetWhereDirect(Expression<Func<EFProductReview, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ProductReviews;
		}
		public virtual POCOProductReview GetByIdDirect(int productReviewID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ProductReviewID == productReviewID,response);
			return response.ProductReviews.FirstOrDefault();
		}

		private void SearchLinqPOCO(Expression<Func<EFProductReview, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductReview> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductReview> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int productReviewID, int productID,
		                               string reviewerName,
		                               DateTime reviewDate,
		                               string emailAddress,
		                               int rating,
		                               string comments,
		                               DateTime modifiedDate, EFProductReview   efProductReview)
		{
			efProductReview.ProductReviewID = productReviewID;
			efProductReview.ProductID = productID;
			efProductReview.ReviewerName = reviewerName;
			efProductReview.ReviewDate = reviewDate;
			efProductReview.EmailAddress = emailAddress;
			efProductReview.Rating = rating;
			efProductReview.Comments = comments;
			efProductReview.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFProductReview efProductReview,Response response)
		{
			if(efProductReview == null)
			{
				return;
			}
			response.AddProductReview(new POCOProductReview()
			{
				ProductReviewID = efProductReview.ProductReviewID.ToInt(),
				ReviewerName = efProductReview.ReviewerName,
				ReviewDate = efProductReview.ReviewDate.ToDateTime(),
				EmailAddress = efProductReview.EmailAddress,
				Rating = efProductReview.Rating.ToInt(),
				Comments = efProductReview.Comments,
				ModifiedDate = efProductReview.ModifiedDate.ToDateTime(),

				ProductID = new ReferenceEntity<int>(efProductReview.ProductID,
				                                     "Products"),
			});

			ProductRepository.MapEFToPOCO(efProductReview.Product, response);
		}
	}
}

/*<Codenesium>
    <Hash>550df9a8ed11d56c1d9711ed4d195c10</Hash>
</Codenesium>*/