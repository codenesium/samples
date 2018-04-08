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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractSalesOrderHeaderSalesReasonRepository(ILogger logger,
		                                                     ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(int salesReasonID,
		                          DateTime modifiedDate)
		{
			var record = new EFSalesOrderHeaderSalesReason ();

			MapPOCOToEF(0, salesReasonID,
			            modifiedDate, record);

			this.context.Set<EFSalesOrderHeaderSalesReason>().Add(record);
			this.context.SaveChanges();
			return record.SalesOrderID;
		}

		public virtual void Update(int salesOrderID, int salesReasonID,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.SalesOrderID == salesOrderID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",salesOrderID);
			}
			else
			{
				MapPOCOToEF(salesOrderID,  salesReasonID,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int salesOrderID)
		{
			var record = this.SearchLinqEF(x => x.SalesOrderID == salesOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFSalesOrderHeaderSalesReason>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int salesOrderID, Response response)
		{
			this.SearchLinqPOCO(x => x.SalesOrderID == salesOrderID,response);
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

		public virtual List<POCOSalesOrderHeaderSalesReason> GetWhereDirect(Expression<Func<EFSalesOrderHeaderSalesReason, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.SalesOrderHeaderSalesReasons;
		}
		public virtual POCOSalesOrderHeaderSalesReason GetByIdDirect(int salesOrderID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.SalesOrderID == salesOrderID,response);
			return response.SalesOrderHeaderSalesReasons.FirstOrDefault();
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
			efSalesOrderHeaderSalesReason.SalesOrderID = salesOrderID;
			efSalesOrderHeaderSalesReason.SalesReasonID = salesReasonID;
			efSalesOrderHeaderSalesReason.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFSalesOrderHeaderSalesReason efSalesOrderHeaderSalesReason,Response response)
		{
			if(efSalesOrderHeaderSalesReason == null)
			{
				return;
			}
			response.AddSalesOrderHeaderSalesReason(new POCOSalesOrderHeaderSalesReason()
			{
				ModifiedDate = efSalesOrderHeaderSalesReason.ModifiedDate.ToDateTime(),

				SalesOrderID = new ReferenceEntity<int>(efSalesOrderHeaderSalesReason.SalesOrderID,
				                                        "SalesOrderHeaders"),
				SalesReasonID = new ReferenceEntity<int>(efSalesOrderHeaderSalesReason.SalesReasonID,
				                                         "SalesReasons"),
			});

			SalesOrderHeaderRepository.MapEFToPOCO(efSalesOrderHeaderSalesReason.SalesOrderHeader, response);

			SalesReasonRepository.MapEFToPOCO(efSalesOrderHeaderSalesReason.SalesReason, response);
		}
	}
}

/*<Codenesium>
    <Hash>4564db2216e687dcb9e927c1fc025037</Hash>
</Codenesium>*/