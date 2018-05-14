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
	public abstract class AbstractSalesPersonRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSalesPersonRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOSalesPerson> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOSalesPerson Get(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
		}

		public virtual POCOSalesPerson Create(
			ApiSalesPersonModel model)
		{
			SalesPerson record = new SalesPerson();

			this.Mapper.SalesPersonMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SalesPerson>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.SalesPersonMapEFToPOCO(record);
		}

		public virtual void Update(
			int businessEntityID,
			ApiSalesPersonModel model)
		{
			SalesPerson record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.SalesPersonMapModelToEF(
					businessEntityID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int businessEntityID)
		{
			SalesPerson record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesPerson>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOSalesPerson> Where(Expression<Func<SalesPerson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOSalesPerson> SearchLinqPOCO(Expression<Func<SalesPerson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesPerson> response = new List<POCOSalesPerson>();
			List<SalesPerson> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.SalesPersonMapEFToPOCO(x)));
			return response;
		}

		private List<SalesPerson> SearchLinqEF(Expression<Func<SalesPerson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesPerson.BusinessEntityID)} ASC";
			}
			return this.Context.Set<SalesPerson>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SalesPerson>();
		}

		private List<SalesPerson> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesPerson.BusinessEntityID)} ASC";
			}

			return this.Context.Set<SalesPerson>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SalesPerson>();
		}
	}
}

/*<Codenesium>
    <Hash>2ee01f4cf4f350d2fd0268facfb6bef2</Hash>
</Codenesium>*/