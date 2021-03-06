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

namespace NebulaNS.Api.DataAccess
{
	public class MachineRepository : AbstractRepository, IMachineRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public MachineRepository(
			ILogger<IMachineRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Machine>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.Description == null?false : x.Description.StartsWith(query)) ||
				                  (x.JwtKey == null?false : x.JwtKey.StartsWith(query)) ||
				                  (x.LastIpAddress == null?false : x.LastIpAddress.StartsWith(query)) ||
				                  x.MachineGuid == query.ToGuid() ||
				                  (x.Name == null?false : x.Name.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Machine> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Machine> Create(Machine item)
		{
			this.Context.Set<Machine>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Machine item)
		{
			var entity = this.Context.Set<Machine>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Machine>().Attach(item);
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
			Machine record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Machine>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// unique constraint AX_Machine_MachineGuid.
		public async virtual Task<Machine> ByMachineGuid(Guid machineGuid)
		{
			return await this.Context.Set<Machine>()

			       .FirstOrDefaultAsync(x => x.MachineGuid == machineGuid);
		}

		// Foreign key reference to this table Link via assignedMachineId.
		public async virtual Task<List<Link>> LinksByAssignedMachineId(int assignedMachineId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Link>()
			       .Include(x => x.AssignedMachineIdNavigation)
			       .Include(x => x.ChainIdNavigation)
			       .Include(x => x.LinkStatusIdNavigation)

			       .Where(x => x.AssignedMachineId == assignedMachineId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Link>();
		}

		protected async Task<List<Machine>> Where(
			Expression<Func<Machine, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Machine, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Machine>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Machine>();
		}

		private async Task<Machine> GetById(int id)
		{
			List<Machine> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>5d6e1767fe4d79e04f260cd1ef3081af</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/