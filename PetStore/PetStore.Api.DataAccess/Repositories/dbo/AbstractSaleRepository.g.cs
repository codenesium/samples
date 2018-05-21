using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public abstract class AbstractSaleRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSaleRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOSale>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOSale> Get(int id)
		{
			Sale record = await this.GetById(id);

			return this.Mapper.SaleMapEFToPOCO(record);
		}

		public async virtual Task<POCOSale> Create(
			ApiSaleModel model)
		{
			Sale record = new Sale();

			this.Mapper.SaleMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Sale>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.SaleMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiSaleModel model)
		{
			Sale record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.SaleMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			Sale record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Sale>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOSale>> Where(Expression<Func<Sale, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSale> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOSale>> SearchLinqPOCO(Expression<Func<Sale, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSale> response = new List<POCOSale>();
			List<Sale> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.SaleMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Sale>> SearchLinqEF(Expression<Func<Sale, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Sale.Id)} ASC";
			}
			return await this.Context.Set<Sale>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Sale>();
		}

		private async Task<List<Sale>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Sale.Id)} ASC";
			}

			return await this.Context.Set<Sale>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Sale>();
		}

		private async Task<Sale> GetById(int id)
		{
			List<Sale> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>6125ab209acc303c18b4c3dd091ad2de</Hash>
</Codenesium>*/