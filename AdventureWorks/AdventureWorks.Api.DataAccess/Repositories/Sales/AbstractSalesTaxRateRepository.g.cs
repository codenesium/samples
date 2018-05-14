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
	public abstract class AbstractSalesTaxRateRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSalesTaxRateRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOSalesTaxRate> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOSalesTaxRate Get(int salesTaxRateID)
		{
			return this.SearchLinqPOCO(x => x.SalesTaxRateID == salesTaxRateID).FirstOrDefault();
		}

		public virtual POCOSalesTaxRate Create(
			ApiSalesTaxRateModel model)
		{
			SalesTaxRate record = new SalesTaxRate();

			this.Mapper.SalesTaxRateMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SalesTaxRate>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.SalesTaxRateMapEFToPOCO(record);
		}

		public virtual void Update(
			int salesTaxRateID,
			ApiSalesTaxRateModel model)
		{
			SalesTaxRate record = this.SearchLinqEF(x => x.SalesTaxRateID == salesTaxRateID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{salesTaxRateID}");
			}
			else
			{
				this.Mapper.SalesTaxRateMapModelToEF(
					salesTaxRateID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int salesTaxRateID)
		{
			SalesTaxRate record = this.SearchLinqEF(x => x.SalesTaxRateID == salesTaxRateID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesTaxRate>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOSalesTaxRate GetStateProvinceIDTaxType(int stateProvinceID,int taxType)
		{
			return this.SearchLinqPOCO(x => x.StateProvinceID == stateProvinceID && x.TaxType == taxType).FirstOrDefault();
		}

		protected List<POCOSalesTaxRate> Where(Expression<Func<SalesTaxRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOSalesTaxRate> SearchLinqPOCO(Expression<Func<SalesTaxRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesTaxRate> response = new List<POCOSalesTaxRate>();
			List<SalesTaxRate> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.SalesTaxRateMapEFToPOCO(x)));
			return response;
		}

		private List<SalesTaxRate> SearchLinqEF(Expression<Func<SalesTaxRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesTaxRate.SalesTaxRateID)} ASC";
			}
			return this.Context.Set<SalesTaxRate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SalesTaxRate>();
		}

		private List<SalesTaxRate> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesTaxRate.SalesTaxRateID)} ASC";
			}

			return this.Context.Set<SalesTaxRate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SalesTaxRate>();
		}
	}
}

/*<Codenesium>
    <Hash>10599c3824a5f3e9147a1a8781b6e9cc</Hash>
</Codenesium>*/