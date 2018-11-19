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

namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractCustomerRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractCustomerRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Customer>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
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

		// Foreign key reference to this table CustomerCommunication via customerId.
		public async virtual Task<List<CustomerCommunication>> CustomerCommunicationsByCustomerId(int customerId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<CustomerCommunication>().Where(x => x.CustomerId == customerId).AsQueryable().Skip(offset).Take(limit).ToListAsync<CustomerCommunication>();
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

			return await this.Context.Set<Customer>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Customer>();
		}

		private async Task<Customer> GetById(int id)
		{
			List<Customer> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>d06fc2cecc9a85dcfdebad7247c060f3</Hash>
</Codenesium>*/