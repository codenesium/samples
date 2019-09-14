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

namespace TicketingCRMNS.Api.DataAccess
{
	public class CustomerRepository : AbstractRepository, ICustomerRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public CustomerRepository(
			ILogger<ICustomerRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Customer>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.Email == null?false : x.Email.StartsWith(query)) ||
				                  (x.FirstName == null?false : x.FirstName.StartsWith(query)) ||
				                  (x.LastName == null?false : x.LastName.StartsWith(query)) ||
				                  (x.Phone == null?false : x.Phone.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Customer> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Customer> Create(Customer item)
		{
			this.Context.Set<Customer>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Customer item)
		{
			var entity = this.Context.Set<Customer>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Customer>().Attach(item);
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
			Customer record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Customer>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<Customer>> Where(
			Expression<Func<Customer, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Customer, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Customer>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Customer>();
		}

		private async Task<Customer> GetById(int id)
		{
			List<Customer> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>2c6ce6c25837f668cdf2058f5bd7dfc1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/