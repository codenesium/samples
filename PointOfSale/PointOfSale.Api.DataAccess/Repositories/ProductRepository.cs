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

namespace PointOfSaleNS.Api.DataAccess
{
	public class ProductRepository : AbstractRepository, IProductRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public ProductRepository(
			ILogger<IProductRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Product>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Active == query.ToBoolean() ||
				                  (x.Description == null?false : x.Description.StartsWith(query)) ||
				                  (x.Name == null?false : x.Name.StartsWith(query)) ||
				                  x.Price.ToDecimal() == query.ToDecimal() ||
				                  x.Quantity == query.ToInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Product> Get(int id)
		{
			return await this.GetById(id);
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
			var entity = this.Context.Set<Product>().Local.FirstOrDefault(x => x.Id == item.Id);
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
			int id)
		{
			Product record = await this.GetById(id);

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

		protected async Task<List<Product>> Where(
			Expression<Func<Product, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Product, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Product>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Product>();
		}

		private async Task<Product> GetById(int id)
		{
			List<Product> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>3a2553e43e1c799c5d7a9b7452f2f046</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/