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
	public abstract class AbstractScrapReasonRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractScrapReasonRepository(ILogger logger,
		                                     ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual short Create(string name,
		                            DateTime modifiedDate)
		{
			var record = new EFScrapReason ();

			MapPOCOToEF(0, name,
			            modifiedDate, record);

			this._context.Set<EFScrapReason>().Add(record);
			this._context.SaveChanges();
			return record.scrapReasonID;
		}

		public virtual void Update(short scrapReasonID, string name,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.scrapReasonID == scrapReasonID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",scrapReasonID);
			}
			else
			{
				MapPOCOToEF(scrapReasonID,  name,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(short scrapReasonID)
		{
			var record = this.SearchLinqEF(x => x.scrapReasonID == scrapReasonID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFScrapReason>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(short scrapReasonID, Response response)
		{
			this.SearchLinqPOCO(x => x.scrapReasonID == scrapReasonID,response);
		}

		protected virtual List<EFScrapReason> SearchLinqEF(Expression<Func<EFScrapReason, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFScrapReason> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFScrapReason, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFScrapReason, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFScrapReason> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFScrapReason> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(short scrapReasonID, string name,
		                               DateTime modifiedDate, EFScrapReason   efScrapReason)
		{
			efScrapReason.scrapReasonID = scrapReasonID;
			efScrapReason.name = name;
			efScrapReason.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFScrapReason efScrapReason,Response response)
		{
			if(efScrapReason == null)
			{
				return;
			}
			response.AddScrapReason(new POCOScrapReason()
			{
				ScrapReasonID = efScrapReason.scrapReasonID,
				Name = efScrapReason.name,
				ModifiedDate = efScrapReason.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>8603f7e9a6a65e22175a24c0ae88d102</Hash>
</Codenesium>*/