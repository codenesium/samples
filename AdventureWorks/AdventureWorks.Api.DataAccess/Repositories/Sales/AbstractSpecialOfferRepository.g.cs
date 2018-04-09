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
				this.logger.LogError($"Unable to find id:{specialOfferID}");
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

		public virtual Response GetById(int specialOfferID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.SpecialOfferID == specialOfferID,response);
			return response;
		}

		public virtual POCOSpecialOffer GetByIdDirect(int specialOfferID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.SpecialOfferID == specialOfferID,response);
			return response.SpecialOffers.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFSpecialOffer, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOSpecialOffer> GetWhereDirect(Expression<Func<EFSpecialOffer, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.SpecialOffers;
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

		protected virtual List<EFSpecialOffer> SearchLinqEF(Expression<Func<EFSpecialOffer, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSpecialOffer> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
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
			efSpecialOffer.SetProperties(specialOfferID.ToInt(),description,discountPct,type,category,startDate.ToDateTime(),endDate.ToDateTime(),minQty.ToInt(),maxQty.ToNullableInt(),rowguid,modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(EFSpecialOffer efSpecialOffer,Response response)
		{
			if(efSpecialOffer == null)
			{
				return;
			}
			response.AddSpecialOffer(new POCOSpecialOffer(efSpecialOffer.SpecialOfferID.ToInt(),efSpecialOffer.Description,efSpecialOffer.DiscountPct,efSpecialOffer.Type,efSpecialOffer.Category,efSpecialOffer.StartDate.ToDateTime(),efSpecialOffer.EndDate.ToDateTime(),efSpecialOffer.MinQty.ToInt(),efSpecialOffer.MaxQty.ToNullableInt(),efSpecialOffer.Rowguid,efSpecialOffer.ModifiedDate.ToDateTime()));
		}
	}
}

/*<Codenesium>
    <Hash>d29ae64ff92bc8dfb7a24a6c0832ebe8</Hash>
</Codenesium>*/