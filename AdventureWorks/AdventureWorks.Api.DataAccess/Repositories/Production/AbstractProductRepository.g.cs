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
	public abstract class AbstractProductRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }

		public AbstractProductRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Product>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
		}

		public async virtual Task<Product> Get(int productID)
		{
			return await this.GetById(productID);
		}

		public async virtual Task<Product> Create(Product item)
		{
			this.Context.Set<Product>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Product item)
		{
			var entity = this.Context.Set<Product>().Local.FirstOrDefault(x => x.ProductID == item.ProductID);
			if (entity == null)
			{
				this.Context.Set<Product>().Attach(item);
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
			Product record = await this.GetById(productID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Product>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<Product> GetName(string name)
		{
			var records = await this.SearchLinqEF(x => x.Name == name);

			return records.FirstOrDefault();
		}
		public async Task<Product> GetProductNumber(string productNumber)
		{
			var records = await this.SearchLinqEF(x => x.ProductNumber == productNumber);

			return records.FirstOrDefault();
		}

		protected async Task<List<Product>> Where(Expression<Func<Product, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<Product> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<Product>> SearchLinqEF(Expression<Func<Product, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Product.ProductID)} ASC";
			}
			return await this.Context.Set<Product>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Product>();
		}

		private async Task<List<Product>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Product.ProductID)} ASC";
			}

			return await this.Context.Set<Product>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Product>();
		}

		private async Task<Product> GetById(int productID)
		{
			List<Product> records = await this.SearchLinqEF(x => x.ProductID == productID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>12a1158388a177cb5edcb6b45b060ef4</Hash>
</Codenesium>*/