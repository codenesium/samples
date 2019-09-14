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
	public class SaleRepository : AbstractRepository, ISaleRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public SaleRepository(
			ILogger<ISaleRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Sale>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.CustomerId == query.ToInt() ||
				                  x.Date == query.ToDateTime(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Sale> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Sale> Create(Sale item)
		{
			this.Context.Set<Sale>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Sale item)
		{
			var entity = this.Context.Set<Sale>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Sale>().Attach(item);
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

		// Non-unique constraint IX_sale_customerId.
		public async virtual Task<List<Sale>> ByCustomerId(int customerId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.CustomerId == customerId, limit, offset);
		}

		protected async Task<List<Sale>> Where(
			Expression<Func<Sale, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Sale, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Sale>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Sale>();
		}

		private async Task<Sale> GetById(int id)
		{
			List<Sale> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>f8c2a197a1e82aebdf03623127265fca</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/