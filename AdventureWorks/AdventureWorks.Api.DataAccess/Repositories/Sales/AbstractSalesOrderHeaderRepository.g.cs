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
	public abstract class AbstractSalesOrderHeaderRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSalesOrderHeaderRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOSalesOrderHeader> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOSalesOrderHeader Get(int salesOrderID)
		{
			return this.SearchLinqPOCO(x => x.SalesOrderID == salesOrderID).FirstOrDefault();
		}

		public virtual POCOSalesOrderHeader Create(
			ApiSalesOrderHeaderModel model)
		{
			SalesOrderHeader record = new SalesOrderHeader();

			this.Mapper.SalesOrderHeaderMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SalesOrderHeader>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.SalesOrderHeaderMapEFToPOCO(record);
		}

		public virtual void Update(
			int salesOrderID,
			ApiSalesOrderHeaderModel model)
		{
			SalesOrderHeader record = this.SearchLinqEF(x => x.SalesOrderID == salesOrderID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{salesOrderID}");
			}
			else
			{
				this.Mapper.SalesOrderHeaderMapModelToEF(
					salesOrderID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int salesOrderID)
		{
			SalesOrderHeader record = this.SearchLinqEF(x => x.SalesOrderID == salesOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesOrderHeader>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOSalesOrderHeader GetSalesOrderNumber(string salesOrderNumber)
		{
			return this.SearchLinqPOCO(x => x.SalesOrderNumber == salesOrderNumber).FirstOrDefault();
		}

		public List<POCOSalesOrderHeader> GetCustomerID(int customerID)
		{
			return this.SearchLinqPOCO(x => x.CustomerID == customerID);
		}
		public List<POCOSalesOrderHeader> GetSalesPersonID(Nullable<int> salesPersonID)
		{
			return this.SearchLinqPOCO(x => x.SalesPersonID == salesPersonID);
		}

		protected List<POCOSalesOrderHeader> Where(Expression<Func<SalesOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOSalesOrderHeader> SearchLinqPOCO(Expression<Func<SalesOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesOrderHeader> response = new List<POCOSalesOrderHeader>();
			List<SalesOrderHeader> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.SalesOrderHeaderMapEFToPOCO(x)));
			return response;
		}

		private List<SalesOrderHeader> SearchLinqEF(Expression<Func<SalesOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesOrderHeader.SalesOrderID)} ASC";
			}
			return this.Context.Set<SalesOrderHeader>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SalesOrderHeader>();
		}

		private List<SalesOrderHeader> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesOrderHeader.SalesOrderID)} ASC";
			}

			return this.Context.Set<SalesOrderHeader>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SalesOrderHeader>();
		}
	}
}

/*<Codenesium>
    <Hash>def4caf7a73f4288c552dda2786fbbea</Hash>
</Codenesium>*/