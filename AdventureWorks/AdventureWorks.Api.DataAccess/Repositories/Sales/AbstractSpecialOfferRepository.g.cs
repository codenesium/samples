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
	public abstract class AbstractSpecialOfferRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractSpecialOfferRepository(ILogger logger,
		                                      ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(string description,
		                          decimal discountPct,
		                          string type,
		                          string category,
		                          DateTime startDate,
		                          DateTime endDate,
		                          int minQty,
		                          Nullable<int> maxQty,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFSpecialOffer ();

			MapPOCOToEF(0, description,
			            discountPct,
			            type,
			            category,
			            startDate,
			            endDate,
			            minQty,
			            maxQty,
			            rowguid,
			            modifiedDate, record);

			this.context.Set<EFSpecialOffer>().Add(record);
			this.context.SaveChanges();
			return record.SpecialOfferID;
		}

		public virtual void Update(int specialOfferID, string description,
		                           decimal discountPct,
		                           string type,
		                           string category,
		                           DateTime startDate,
		                           DateTime endDate,
		                           int minQty,
		                           Nullable<int> maxQty,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.SpecialOfferID == specialOfferID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",specialOfferID);
			}
			else
			{
				MapPOCOToEF(specialOfferID,  description,
				            discountPct,
				            type,
				            category,
				            startDate,
				            endDate,
				            minQty,
				            maxQty,
				            rowguid,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int specialOfferID)
		{
			var record = this.SearchLinqEF(x => x.SpecialOfferID == specialOfferID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFSpecialOffer>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int specialOfferID, Response response)
		{
			this.SearchLinqPOCO(x => x.SpecialOfferID == specialOfferID,response);
		}

		protected virtual List<EFSpecialOffer> SearchLinqEF(Expression<Func<EFSpecialOffer, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSpecialOffer> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFSpecialOffer, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		public virtual List<POCOSpecialOffer> GetWhereDirect(Expression<Func<EFSpecialOffer, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.SpecialOffers;
		}
		public virtual POCOSpecialOffer GetByIdDirect(int specialOfferID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.SpecialOfferID == specialOfferID,response);
			return response.SpecialOffers.FirstOrDefault();
		}

		private void SearchLinqPOCO(Expression<Func<EFSpecialOffer, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSpecialOffer> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSpecialOffer> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int specialOfferID, string description,
		                               decimal discountPct,
		                               string type,
		                               string category,
		                               DateTime startDate,
		                               DateTime endDate,
		                               int minQty,
		                               Nullable<int> maxQty,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFSpecialOffer   efSpecialOffer)
		{
			efSpecialOffer.SpecialOfferID = specialOfferID;
			efSpecialOffer.Description = description;
			efSpecialOffer.DiscountPct = discountPct;
			efSpecialOffer.Type = type;
			efSpecialOffer.Category = category;
			efSpecialOffer.StartDate = startDate;
			efSpecialOffer.EndDate = endDate;
			efSpecialOffer.MinQty = minQty;
			efSpecialOffer.MaxQty = maxQty;
			efSpecialOffer.Rowguid = rowguid;
			efSpecialOffer.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFSpecialOffer efSpecialOffer,Response response)
		{
			if(efSpecialOffer == null)
			{
				return;
			}
			response.AddSpecialOffer(new POCOSpecialOffer()
			{
				SpecialOfferID = efSpecialOffer.SpecialOfferID.ToInt(),
				Description = efSpecialOffer.Description,
				DiscountPct = efSpecialOffer.DiscountPct,
				Type = efSpecialOffer.Type,
				Category = efSpecialOffer.Category,
				StartDate = efSpecialOffer.StartDate.ToDateTime(),
				EndDate = efSpecialOffer.EndDate.ToDateTime(),
				MinQty = efSpecialOffer.MinQty.ToInt(),
				MaxQty = efSpecialOffer.MaxQty.ToNullableInt(),
				Rowguid = efSpecialOffer.Rowguid,
				ModifiedDate = efSpecialOffer.ModifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>5e01f277a95cb907b5ed93afd01cef97</Hash>
</Codenesium>*/