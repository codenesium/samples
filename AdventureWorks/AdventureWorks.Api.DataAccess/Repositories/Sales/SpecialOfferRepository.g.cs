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
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractSpecialOfferRepository(ILogger logger,
		                                      ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
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

			this._context.Set<EFSpecialOffer>().Add(record);
			this._context.SaveChanges();
			return record.specialOfferID;
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
			var record =  this.SearchLinqEF(x => x.specialOfferID == specialOfferID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",specialOfferID);
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
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int specialOfferID)
		{
			var record = this.SearchLinqEF(x => x.specialOfferID == specialOfferID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFSpecialOffer>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int specialOfferID, Response response)
		{
			this.SearchLinqPOCO(x => x.specialOfferID == specialOfferID,response);
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
			efSpecialOffer.specialOfferID = specialOfferID;
			efSpecialOffer.description = description;
			efSpecialOffer.discountPct = discountPct;
			efSpecialOffer.type = type;
			efSpecialOffer.category = category;
			efSpecialOffer.startDate = startDate;
			efSpecialOffer.endDate = endDate;
			efSpecialOffer.minQty = minQty;
			efSpecialOffer.maxQty = maxQty;
			efSpecialOffer.rowguid = rowguid;
			efSpecialOffer.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFSpecialOffer efSpecialOffer,Response response)
		{
			if(efSpecialOffer == null)
			{
				return;
			}
			response.AddSpecialOffer(new POCOSpecialOffer()
			{
				SpecialOfferID = efSpecialOffer.specialOfferID.ToInt(),
				Description = efSpecialOffer.description,
				DiscountPct = efSpecialOffer.discountPct,
				Type = efSpecialOffer.type,
				Category = efSpecialOffer.category,
				StartDate = efSpecialOffer.startDate.ToDateTime(),
				EndDate = efSpecialOffer.endDate.ToDateTime(),
				MinQty = efSpecialOffer.minQty.ToInt(),
				MaxQty = efSpecialOffer.maxQty.ToNullableInt(),
				Rowguid = efSpecialOffer.rowguid,
				ModifiedDate = efSpecialOffer.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>c90f95c7f9cc35ed45cbf17a835ee77c</Hash>
</Codenesium>*/