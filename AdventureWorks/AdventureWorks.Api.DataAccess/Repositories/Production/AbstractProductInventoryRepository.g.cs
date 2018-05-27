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
	public abstract class AbstractProductInventoryRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALProductInventoryMapper Mapper { get; }

		public AbstractProductInventoryRepository(
			IDALProductInventoryMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOProductInventory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOProductInventory> Get(int productID)
		{
			ProductInventory record = await this.GetById(productID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOProductInventory> Create(
			DTOProductInventory dto)
		{
			ProductInventory record = new ProductInventory();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<ProductInventory>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int productID,
			DTOProductInventory dto)
		{
			ProductInventory record = await this.GetById(productID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					productID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int productID)
		{
			ProductInventory record = await this.GetById(productID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductInventory>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<DTOProductInventory>> Where(Expression<Func<ProductInventory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOProductInventory> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOProductInventory>> SearchLinqDTO(Expression<Func<ProductInventory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOProductInventory> response = new List<DTOProductInventory>();
			List<ProductInventory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<ProductInventory>> SearchLinqEF(Expression<Func<ProductInventory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductInventory.ProductID)} ASC";
			}
			return await this.Context.Set<ProductInventory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductInventory>();
		}

		private async Task<List<ProductInventory>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductInventory.ProductID)} ASC";
			}

			return await this.Context.Set<ProductInventory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductInventory>();
		}

		private async Task<ProductInventory> GetById(int productID)
		{
			List<ProductInventory> records = await this.SearchLinqEF(x => x.ProductID == productID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>d6e6d7e6a299e067ddcf6ad02bf4b73c</Hash>
</Codenesium>*/