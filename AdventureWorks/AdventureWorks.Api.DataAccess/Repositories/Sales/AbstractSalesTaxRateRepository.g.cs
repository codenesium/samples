using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractSalesTaxRateRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSalesTaxRateRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOSalesTaxRate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOSalesTaxRate> Get(int salesTaxRateID)
		{
			SalesTaxRate record = await this.GetById(salesTaxRateID);

			return this.Mapper.SalesTaxRateMapEFToPOCO(record);
		}

		public async virtual Task<POCOSalesTaxRate> Create(
			ApiSalesTaxRateModel model)
		{
			SalesTaxRate record = new SalesTaxRate();

			this.Mapper.SalesTaxRateMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SalesTaxRate>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.SalesTaxRateMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int salesTaxRateID,
			ApiSalesTaxRateModel model)
		{
			SalesTaxRate record = await this.GetById(salesTaxRateID);

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
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int salesTaxRateID)
		{
			SalesTaxRate record = await this.GetById(salesTaxRateID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesTaxRate>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOSalesTaxRate> GetStateProvinceIDTaxType(int stateProvinceID,int taxType)
		{
			var records = await this.SearchLinqPOCO(x => x.StateProvinceID == stateProvinceID && x.TaxType == taxType);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOSalesTaxRate>> Where(Expression<Func<SalesTaxRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesTaxRate> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOSalesTaxRate>> SearchLinqPOCO(Expression<Func<SalesTaxRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesTaxRate> response = new List<POCOSalesTaxRate>();
			List<SalesTaxRate> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.SalesTaxRateMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<SalesTaxRate>> SearchLinqEF(Expression<Func<SalesTaxRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesTaxRate.SalesTaxRateID)} ASC";
			}
			return await this.Context.Set<SalesTaxRate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesTaxRate>();
		}

		private async Task<List<SalesTaxRate>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesTaxRate.SalesTaxRateID)} ASC";
			}

			return await this.Context.Set<SalesTaxRate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesTaxRate>();
		}

		private async Task<SalesTaxRate> GetById(int salesTaxRateID)
		{
			List<SalesTaxRate> records = await this.SearchLinqEF(x => x.SalesTaxRateID == salesTaxRateID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>1116293dbc0bca8c9258fd44ca031c25</Hash>
</Codenesium>*/