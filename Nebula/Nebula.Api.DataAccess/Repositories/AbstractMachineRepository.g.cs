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
        public abstract class AbstractMachineRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractMachineRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Machine>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
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

                protected async Task<List<Machine>> Where(Expression<Func<Machine, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<Machine> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<Machine>> SearchLinqEF(Expression<Func<Machine, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Machine.Id)} ASC";
                        }

                        return await this.Context.Set<Machine>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Machine>();
                }

                private async Task<List<Machine>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Machine.Id)} ASC";
                        }

                        return await this.Context.Set<Machine>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Machine>();
                }

                private async Task<Machine> GetById(int id)
                {
                        List<Machine> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<Link>> Links(int assignedMachineId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Link>().Where(x => x.AssignedMachineId == assignedMachineId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Link>();
                }
                public async virtual Task<List<MachineRefTeam>> MachineRefTeams(int machineId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<MachineRefTeam>().Where(x => x.MachineId == machineId).AsQueryable().Skip(offset).Take(limit).ToListAsync<MachineRefTeam>();
                }
        }
}

/*<Codenesium>
    <Hash>491a0a641601ea820c40461434d1126f</Hash>
</Codenesium>*/