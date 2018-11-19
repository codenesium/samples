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
	public abstract class AbstractCustomerCommunicationRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractCustomerCommunicationRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<CustomerCommunication>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<CustomerCommunication> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<CustomerCommunication> Create(CustomerCommunication item)
		{
			this.Context.Set<CustomerCommunication>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(CustomerCommunication item)
		{
			var entity = this.Context.Set<CustomerCommunication>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<CustomerCommunication>().Attach(item);
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
			CustomerCommunication record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<CustomerCommunication>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_CustomerCommunication_customerId.
		public async virtual Task<List<CustomerCommunication>> ByCustomerId(int customerId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.CustomerId == customerId, limit, offset);
		}

		// Non-unique constraint IX_CustomerCommunication_employeeId.
		public async virtual Task<List<CustomerCommunication>> ByEmployeeId(int employeeId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.EmployeeId == employeeId, limit, offset);
		}

		// Foreign key reference to table Customer via customerId.
		public async virtual Task<Customer> CustomerByCustomerId(int customerId)
		{
			return await this.Context.Set<Customer>().SingleOrDefaultAsync(x => x.Id == customerId);
		}

		// Foreign key reference to table Employee via employeeId.
		public async virtual Task<Employee> EmployeeByEmployeeId(int employeeId)
		{
			return await this.Context.Set<Employee>().SingleOrDefaultAsync(x => x.Id == employeeId);
		}

		protected async Task<List<CustomerCommunication>> Where(
			Expression<Func<CustomerCommunication, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<CustomerCommunication, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<CustomerCommunication>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<CustomerCommunication>();
		}

		private async Task<CustomerCommunication> GetById(int id)
		{
			List<CustomerCommunication> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>d8d3be8ce4f5e5766e5ecdbaa8eff88d</Hash>
</Codenesium>*/