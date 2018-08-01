using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractProductModelRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractProductModelRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ProductModel>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
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

		public async Task<ProductModel> ByName(string name)
		{
			var records = await this.Where(x => x.Name == name);

			return records.FirstOrDefault();
		}

		public async Task<List<ProductModel>> ByCatalogDescription(string catalogDescription)
		{
			var records = await this.Where(x => x.CatalogDescription == catalogDescription);

			return records;
		}

		public async Task<List<ProductModel>> ByInstruction(string instruction)
		{
			var records = await this.Where(x => x.Instruction == instruction);

			return records;
		}

		public async virtual Task<List<Product>> Products(int productModelID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Product>().Where(x => x.ProductModelID == productModelID).AsQueryable().Skip(offset).Take(limit).ToListAsync<Product>();
		}

		public async virtual Task<List<ProductModelIllustration>> ProductModelIllustrations(int productModelID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<ProductModelIllustration>().Where(x => x.ProductModelID == productModelID).AsQueryable().Skip(offset).Take(limit).ToListAsync<ProductModelIllustration>();
		}

		public async virtual Task<List<ProductModelProductDescriptionCulture>> ProductModelProductDescriptionCultures(int productModelID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<ProductModelProductDescriptionCulture>().Where(x => x.ProductModelID == productModelID).AsQueryable().Skip(offset).Take(limit).ToListAsync<ProductModelProductDescriptionCulture>();
		}

		protected async Task<List<ProductModel>> Where(
			Expression<Func<ProductModel, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<ProductModel, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.ProductModelID;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<ProductModel>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ProductModel>();
			}
			else
			{
				return await this.Context.Set<ProductModel>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<ProductModel>();
			}
		}

		private async Task<ProductModel> GetById(int productModelID)
		{
			List<ProductModel> records = await this.Where(x => x.ProductModelID == productModelID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>5560f6b1afbecbf86b425f0cf22fdaff</Hash>
</Codenesium>*/