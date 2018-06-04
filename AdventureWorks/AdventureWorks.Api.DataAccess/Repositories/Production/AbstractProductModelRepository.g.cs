using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractProductModelRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }

		public AbstractProductModelRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ProductModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
		}

		public async virtual Task<ProductModel> Get(int productModelID)
		{
			return await this.GetById(productModelID);
		}

		public async virtual Task<ProductModel> Create(ProductModel item)
		{
			this.Context.Set<ProductModel>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(ProductModel item)
		{
			var entity = this.Context.Set<ProductModel>().Local.FirstOrDefault(x => x.ProductModelID == item.ProductModelID);
			if (entity == null)
			{
				this.Context.Set<ProductModel>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int productModelID)
		{
			ProductModel record = await this.GetById(productModelID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductModel>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<ProductModel> GetName(string name)
		{
			var records = await this.SearchLinqEF(x => x.Name == name);

			return records.FirstOrDefault();
		}
		public async Task<List<ProductModel>> GetCatalogDescription(string catalogDescription)
		{
			var records = await this.SearchLinqEF(x => x.CatalogDescription == catalogDescription);

			return records;
		}
		public async Task<List<ProductModel>> GetInstructions(string instructions)
		{
			var records = await this.SearchLinqEF(x => x.Instructions == instructions);

			return records;
		}

		protected async Task<List<ProductModel>> Where(Expression<Func<ProductModel, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<ProductModel> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<ProductModel>> SearchLinqEF(Expression<Func<ProductModel, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductModel.ProductModelID)} ASC";
			}
			return await this.Context.Set<ProductModel>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductModel>();
		}

		private async Task<List<ProductModel>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductModel.ProductModelID)} ASC";
			}

			return await this.Context.Set<ProductModel>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductModel>();
		}

		private async Task<ProductModel> GetById(int productModelID)
		{
			List<ProductModel> records = await this.SearchLinqEF(x => x.ProductModelID == productModelID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>96fa0d3431425e5db94d7ac01b50b531</Hash>
</Codenesium>*/