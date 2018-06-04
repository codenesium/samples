using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractMachineRefTeamRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }

		public AbstractMachineRefTeamRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<MachineRefTeam>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
		}

		public async virtual Task<MachineRefTeam> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<MachineRefTeam> Create(MachineRefTeam item)
		{
			this.Context.Set<MachineRefTeam>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(MachineRefTeam item)
		{
			var entity = this.Context.Set<MachineRefTeam>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<MachineRefTeam>().Attach(item);
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
			MachineRefTeam record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<MachineRefTeam>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<MachineRefTeam>> Where(Expression<Func<MachineRefTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<MachineRefTeam> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<MachineRefTeam>> SearchLinqEF(Expression<Func<MachineRefTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(MachineRefTeam.Id)} ASC";
			}
			return await this.Context.Set<MachineRefTeam>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<MachineRefTeam>();
		}

		private async Task<List<MachineRefTeam>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(MachineRefTeam.Id)} ASC";
			}

			return await this.Context.Set<MachineRefTeam>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<MachineRefTeam>();
		}

		private async Task<MachineRefTeam> GetById(int id)
		{
			List<MachineRefTeam> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>3473814804f3307af1ed5cdad3f8f1ad</Hash>
</Codenesium>*/