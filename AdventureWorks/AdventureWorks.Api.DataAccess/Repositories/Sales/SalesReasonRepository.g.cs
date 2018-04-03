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
	public abstract class AbstractSalesReasonRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractSalesReasonRepository(ILogger logger,
		                                     ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string name,
		                          string reasonType,
		                          DateTime modifiedDate)
		{
			var record = new EFSalesReason ();

			MapPOCOToEF(0, name,
			            reasonType,
			            modifiedDate, record);

			this._context.Set<EFSalesReason>().Add(record);
			this._context.SaveChanges();
			return record.salesReasonID;
		}

		public virtual void Update(int salesReasonID, string name,
		                           string reasonType,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.salesReasonID == salesReasonID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",salesReasonID);
			}
			else
			{
				MapPOCOToEF(salesReasonID,  name,
				            reasonType,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int salesReasonID)
		{
			var record = this.SearchLinqEF(x => x.salesReasonID == salesReasonID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFSalesReason>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int salesReasonID, Response response)
		{
			this.SearchLinqPOCO(x => x.salesReasonID == salesReasonID,response);
		}

		protected virtual List<EFSalesReason> SearchLinqEF(Expression<Func<EFSalesReason, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesReason> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFSalesReason, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFSalesReason, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSalesReason> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSalesReason> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int salesReasonID, string name,
		                               string reasonType,
		                               DateTime modifiedDate, EFSalesReason   efSalesReason)
		{
			efSalesReason.salesReasonID = salesReasonID;
			efSalesReason.name = name;
			efSalesReason.reasonType = reasonType;
			efSalesReason.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFSalesReason efSalesReason,Response response)
		{
			if(efSalesReason == null)
			{
				return;
			}
			response.AddSalesReason(new POCOSalesReason()
			{
				SalesReasonID = efSalesReason.salesReasonID.ToInt(),
				Name = efSalesReason.name,
				ReasonType = efSalesReason.reasonType,
				ModifiedDate = efSalesReason.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>252756a836d998db7d446ebe5be9d299</Hash>
</Codenesium>*/