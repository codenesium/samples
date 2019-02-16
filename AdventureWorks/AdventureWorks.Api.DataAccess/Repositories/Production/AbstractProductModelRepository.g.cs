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

		public virtual Task<List<ProductModel>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.CatalogDescription.StartsWith(query) ||
				                  x.Instruction.StartsWith(query) ||
				                  x.ModifiedDate == query.ToDateTime() ||
				                  x.Name.StartsWith(query) ||
				                  x.ProductModelID == query.ToInt() ||
				                  x.Rowguid == query.ToGuid(),
				                  limit,
				                  offset);
			}
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

		// unique constraint AK_ProductModel_Name.
		public async virtual Task<ProductModel> ByName(string name)
		{
			return await this.Context.Set<ProductModel>().FirstOrDefaultAsync(x => x.Name == name);
		}

		// unique constraint AK_ProductModel_rowguid.
		public async virtual Task<ProductModel> ByRowguid(Guid rowguid)
		{
			return await this.Context.Set<ProductModel>().FirstOrDefaultAsync(x => x.Rowguid == rowguid);
		}

		// Non-unique constraint PXML_ProductModel_CatalogDescription.
		public async virtual Task<List<ProductModel>> ByCatalogDescription(string catalogDescription, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.CatalogDescription == catalogDescription, limit, offset);
		}

		// Non-unique constraint PXML_ProductModel_Instructions.
		public async virtual Task<List<ProductModel>> ByInstruction(string instruction, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.Instruction == instruction, limit, offset);
		}

		// Foreign key reference to this table Product via productModelID.
		public async virtual Task<List<Product>> ProductsByProductModelID(int productModelID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Product>().Where(x => x.ProductModelID == productModelID).AsQueryable().Skip(offset).Take(limit).ToListAsync<Product>();
		}

		protected async Task<List<ProductModel>> Where(
			Expression<Func<ProductModel, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<ProductModel, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.ProductModelID;
			}

			return await this.Context.Set<ProductModel>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ProductModel>();
		}

		private async Task<ProductModel> GetById(int productModelID)
		{
			List<ProductModel> records = await this.Where(x => x.ProductModelID == productModelID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>acd9f5d3f364d97043396095ca66b762</Hash>
</Codenesium>*/