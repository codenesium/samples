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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractSalesReasonRepository(ILogger logger,
		                                     ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(string name,
		                          string reasonType,
		                          DateTime modifiedDate)
		{
			var record = new EFSalesReason ();

			MapPOCOToEF(0, name,
			            reasonType,
			            modifiedDate, record);

			this.context.Set<EFSalesReason>().Add(record);
			this.context.SaveChanges();
			return record.SalesReasonID;
		}

		public virtual void Update(int salesReasonID, string name,
		                           string reasonType,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.SalesReasonID == salesReasonID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{salesReasonID}");
			}
			else
			{
				MapPOCOToEF(salesReasonID,  name,
				            reasonType,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int salesReasonID)
		{
			var record = this.SearchLinqEF(x => x.SalesReasonID == salesReasonID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFSalesReason>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int salesReasonID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.SalesReasonID == salesReasonID,response);
			return response;
		}

		public virtual POCOSalesReason GetByIdDirect(int salesReasonID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.SalesReasonID == salesReasonID,response);
			return response.SalesReasons.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFSalesReason, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
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

		public virtual List<POCOSalesReason> GetWhereDirect(Expression<Func<EFSalesReason, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.SalesReasons;
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

		protected virtual List<EFSalesReason> SearchLinqEF(Expression<Func<EFSalesReason, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesReason> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(int salesReasonID, string name,
		                               string reasonType,
		                               DateTime modifiedDate, EFSalesReason   efSalesReason)
		{
			efSalesReason.SetProperties(salesReasonID.ToInt(),name,reasonType,modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(EFSalesReason efSalesReason,Response response)
		{
			if(efSalesReason == null)
			{
				return;
			}
			response.AddSalesReason(new POCOSalesReason(efSalesReason.SalesReasonID.ToInt(),efSalesReason.Name,efSalesReason.ReasonType,efSalesReason.ModifiedDate.ToDateTime()));
		}
	}
}

/*<Codenesium>
    <Hash>1c63668b06487af3981c7c0fefe53f7a</Hash>
</Codenesium>*/