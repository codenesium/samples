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
	public abstract class AbstractProductProductPhotoRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractProductProductPhotoRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ProductProductPhoto>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.ModifiedDate == query.ToDateTime() ||
				                  x.Primary == query.ToBoolean() ||
				                  x.ProductID == query.ToInt() ||
				                  x.ProductPhotoID == query.ToInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<ProductProductPhoto> Get(int productID)
		{
			return await this.GetById(productID);
		}

		public async virtual Task<ProductProductPhoto> Create(ProductProductPhoto item)
		{
			this.Context.Set<ProductProductPhoto>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(ProductProductPhoto item)
		{
			var entity = this.Context.Set<ProductProductPhoto>().Local.FirstOrDefault(x => x.ProductID == item.ProductID);
			if (entity == null)
			{
				this.Context.Set<ProductProductPhoto>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int productID)
		{
			ProductProductPhoto record = await this.GetById(productID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductProductPhoto>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to table Product via productID.
		public async virtual Task<Product> ProductByProductID(int productID)
		{
			return await this.Context.Set<Product>()
			       .SingleOrDefaultAsync(x => x.ProductID == productID);
		}

		// Foreign key reference to table ProductPhoto via productPhotoID.
		public async virtual Task<ProductPhoto> ProductPhotoByProductPhotoID(int productPhotoID)
		{
			return await this.Context.Set<ProductPhoto>()
			       .SingleOrDefaultAsync(x => x.ProductPhotoID == productPhotoID);
		}

		protected async Task<List<ProductProductPhoto>> Where(
			Expression<Func<ProductProductPhoto, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<ProductProductPhoto, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.ProductID;
			}

			return await this.Context.Set<ProductProductPhoto>()
			       .Include(x => x.ProductIDNavigation)
			       .Include(x => x.ProductPhotoIDNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ProductProductPhoto>();
		}

		private async Task<ProductProductPhoto> GetById(int productID)
		{
			List<ProductProductPhoto> records = await this.Where(x => x.ProductID == productID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>269728d4b8fff7505db6344991e889e9</Hash>
</Codenesium>*/