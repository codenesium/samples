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
	public abstract class AbstractClientCommunicationRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractClientCommunicationRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ClientCommunication>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<ClientCommunication> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<ClientCommunication> Create(ClientCommunication item)
		{
			this.Context.Set<ClientCommunication>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(ClientCommunication item)
		{
			var entity = this.Context.Set<ClientCommunication>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<ClientCommunication>().Attach(item);
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
			ClientCommunication record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ClientCommunication>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<Client> ClientByClientId(int clientId)
		{
			return await this.Context.Set<Client>().SingleOrDefaultAsync(x => x.Id == clientId);
		}

		public async virtual Task<Employee> EmployeeByEmployeeId(int employeeId)
		{
			return await this.Context.Set<Employee>().SingleOrDefaultAsync(x => x.Id == employeeId);
		}

		protected async Task<List<ClientCommunication>> Where(
			Expression<Func<ClientCommunication, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<ClientCommunication, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<ClientCommunication>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ClientCommunication>();
			}
			else
			{
				return await this.Context.Set<ClientCommunication>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<ClientCommunication>();
			}
		}

		private async Task<ClientCommunication> GetById(int id)
		{
			List<ClientCommunication> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>9ab6ef04c9c71edc8f9da5af0f8d4499</Hash>
</Codenesium>*/