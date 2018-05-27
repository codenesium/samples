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
		protected IDALSalesTaxRateMapper Mapper { get; }

		public AbstractSalesTaxRateRepository(
			IDALSalesTaxRateMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOSalesTaxRate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOSalesTaxRate> Get(int salesTaxRateID)
		{
			SalesTaxRate record = await this.GetById(salesTaxRateID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOSalesTaxRate> Create(
			DTOSalesTaxRate dto)
		{
			SalesTaxRate record = new SalesTaxRate();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<SalesTaxRate>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int salesTaxRateID,
			DTOSalesTaxRate dto)
		{
			SalesTaxRate record = await this.GetById(salesTaxRateID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{salesTaxRateID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					salesTaxRateID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
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

		public async Task<DTOSalesTaxRate> GetStateProvinceIDTaxType(int stateProvinceID,int taxType)
		{
			var records = await this.SearchLinqDTO(x => x.StateProvinceID == stateProvinceID && x.TaxType == taxType);

			return records.FirstOrDefault();
		}

		protected async Task<List<DTOSalesTaxRate>> Where(Expression<Func<SalesTaxRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOSalesTaxRate> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOSalesTaxRate>> SearchLinqDTO(Expression<Func<SalesTaxRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOSalesTaxRate> response = new List<DTOSalesTaxRate>();
			List<SalesTaxRate> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>d7dabc913f9b6e5888f401c6c6a14c64</Hash>
</Codenesium>*/