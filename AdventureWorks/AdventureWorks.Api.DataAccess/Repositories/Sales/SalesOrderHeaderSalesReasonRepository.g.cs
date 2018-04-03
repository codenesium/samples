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
	public abstract class AbstractSalesOrderHeaderSalesReasonRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractSalesOrderHeaderSalesReasonRepository(ILogger logger,
		                                                     ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int salesReasonID,
		                          DateTime modifiedDate)
		{
			var record = new EFSalesOrderHeaderSalesReason ();

			MapPOCOToEF(0, salesReasonID,
			            modifiedDate, record);

			this._context.Set<EFSalesOrderHeaderSalesReason>().Add(record);
			this._context.SaveChanges();
			return record.salesOrderID;
		}

		public virtual void Update(int salesOrderID, int salesReasonID,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.salesOrderID == salesOrderID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",salesOrderID);
			}
			else
			{
				MapPOCOToEF(salesOrderID,  salesReasonID,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int salesOrderID)
		{
			var record = this.SearchLinqEF(x => x.salesOrderID == salesOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFSalesOrderHeaderSalesReason>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int salesOrderID, Response response)
		{
			this.SearchLinqPOCO(x => x.salesOrderID == salesOrderID,response);
		}

		protected virtual List<EFSalesOrderHeaderSalesReason> SearchLinqEF(Expression<Func<EFSalesOrderHeaderSalesReason, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesOrderHeaderSalesReason> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFSalesOrderHeaderSalesReason, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFSalesOrderHeaderSalesReason, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSalesOrderHeaderSalesReason> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSalesOrderHeaderSalesReason> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int salesOrderID, int salesReasonID,
		                               DateTime modifiedDate, EFSalesOrderHeaderSalesReason   efSalesOrderHeaderSalesReason)
		{
			efSalesOrderHeaderSalesReason.salesOrderID = salesOrderID;
			efSalesOrderHeaderSalesReason.salesReasonID = salesReasonID;
			efSalesOrderHeaderSalesReason.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFSalesOrderHeaderSalesReason efSalesOrderHeaderSalesReason,Response response)
		{
			if(efSalesOrderHeaderSalesReason == null)
			{
				return;
			}
			response.AddSalesOrderHeaderSalesReason(new POCOSalesOrderHeaderSalesReason()
			{
				SalesOrderID = efSalesOrderHeaderSalesReason.salesOrderID.ToInt(),
				SalesReasonID = efSalesOrderHeaderSalesReason.salesReasonID.ToInt(),
				ModifiedDate = efSalesOrderHeaderSalesReason.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>360b1c65ac26e6047a8ada905e655fe4</Hash>
</Codenesium>*/