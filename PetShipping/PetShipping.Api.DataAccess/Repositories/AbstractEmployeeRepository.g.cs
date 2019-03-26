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
	public abstract class AbstractEmployeeRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractEmployeeRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Employee>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.FirstName.StartsWith(query) ||
				                  x.Id == query.ToInt() ||
				                  x.IsSalesPerson == query.ToBoolean() ||
				                  x.IsShipper == query.ToBoolean() ||
				                  x.LastName.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Employee> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Employee> Create(Employee item)
		{
			this.Context.Set<Employee>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Employee item)
		{
			var entity = this.Context.Set<Employee>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Employee>().Attach(item);
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
			Employee record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Employee>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table CustomerCommunication via employeeId.
		public async virtual Task<List<CustomerCommunication>> CustomerCommunicationsByEmployeeId(int employeeId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<CustomerCommunication>()
			       .Include(x => x.CustomerIdNavigation)
			       .Include(x => x.EmployeeIdNavigation)

			       .Where(x => x.EmployeeId == employeeId).AsQueryable().Skip(offset).Take(limit).ToListAsync<CustomerCommunication>();
		}

		// Foreign key reference to this table PipelineStep via shipperId.
		public async virtual Task<List<PipelineStep>> PipelineStepsByShipperId(int shipperId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<PipelineStep>()
			       .Include(x => x.PipelineStepStatusIdNavigation)
			       .Include(x => x.ShipperIdNavigation)

			       .Where(x => x.ShipperId == shipperId).AsQueryable().Skip(offset).Take(limit).ToListAsync<PipelineStep>();
		}

		// Foreign key reference to this table PipelineStepNote via employeeId.
		public async virtual Task<List<PipelineStepNote>> PipelineStepNotesByEmployeeId(int employeeId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<PipelineStepNote>()
			       .Include(x => x.EmployeeIdNavigation)
			       .Include(x => x.PipelineStepIdNavigation)

			       .Where(x => x.EmployeeId == employeeId).AsQueryable().Skip(offset).Take(limit).ToListAsync<PipelineStepNote>();
		}

		protected async Task<List<Employee>> Where(
			Expression<Func<Employee, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Employee, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Employee>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Employee>();
		}

		private async Task<Employee> GetById(int id)
		{
			List<Employee> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>18d39afabaaa993e513c0e888d88a894</Hash>
</Codenesium>*/