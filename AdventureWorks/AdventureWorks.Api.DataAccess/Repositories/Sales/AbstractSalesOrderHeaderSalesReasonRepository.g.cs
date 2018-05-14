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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSalesOrderHeaderSalesReasonRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOSalesOrderHeaderSalesReason> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOSalesOrderHeaderSalesReason Get(int salesOrderID)
		{
			return this.SearchLinqPOCO(x => x.SalesOrderID == salesOrderID).FirstOrDefault();
		}

		public virtual POCOSalesOrderHeaderSalesReason Create(
			ApiSalesOrderHeaderSalesReasonModel model)
		{
			SalesOrderHeaderSalesReason record = new SalesOrderHeaderSalesReason();

			this.Mapper.SalesOrderHeaderSalesReasonMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SalesOrderHeaderSalesReason>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.SalesOrderHeaderSalesReasonMapEFToPOCO(record);
		}

		public virtual void Update(
			int salesOrderID,
			ApiSalesOrderHeaderSalesReasonModel model)
		{
			SalesOrderHeaderSalesReason record = this.SearchLinqEF(x => x.SalesOrderID == salesOrderID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{salesOrderID}");
			}
			else
			{
				this.Mapper.SalesOrderHeaderSalesReasonMapModelToEF(
					salesOrderID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int salesOrderID)
		{
			SalesOrderHeaderSalesReason record = this.SearchLinqEF(x => x.SalesOrderID == salesOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesOrderHeaderSalesReason>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOSalesOrderHeaderSalesReason> Where(Expression<Func<SalesOrderHeaderSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOSalesOrderHeaderSalesReason> SearchLinqPOCO(Expression<Func<SalesOrderHeaderSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesOrderHeaderSalesReason> response = new List<POCOSalesOrderHeaderSalesReason>();
			List<SalesOrderHeaderSalesReason> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.SalesOrderHeaderSalesReasonMapEFToPOCO(x)));
			return response;
		}

		private List<SalesOrderHeaderSalesReason> SearchLinqEF(Expression<Func<SalesOrderHeaderSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesOrderHeaderSalesReason.SalesOrderID)} ASC";
			}
			return this.Context.Set<SalesOrderHeaderSalesReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SalesOrderHeaderSalesReason>();
		}

		private List<SalesOrderHeaderSalesReason> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesOrderHeaderSalesReason.SalesOrderID)} ASC";
			}

			return this.Context.Set<SalesOrderHeaderSalesReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SalesOrderHeaderSalesReason>();
		}
	}
}

/*<Codenesium>
    <Hash>86348f285b250f72dc0245130c0dc270</Hash>
</Codenesium>*/