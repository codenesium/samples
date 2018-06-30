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

namespace OctopusDeployNS.Api.DataAccess
{
        public abstract class AbstractMachinePolicyRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractMachinePolicyRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<MachinePolicy>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<MachinePolicy> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<MachinePolicy> Create(MachinePolicy item)
                {
                        this.Context.Set<MachinePolicy>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(MachinePolicy item)
                {
                        var entity = this.Context.Set<MachinePolicy>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<MachinePolicy>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        string id)
                {
                        MachinePolicy record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<MachinePolicy>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<MachinePolicy> ByName(string name)
                {
                        var records = await this.Where(x => x.Name == name);

                        return records.FirstOrDefault();
                }

                protected async Task<List<MachinePolicy>> Where(
                        Expression<Func<MachinePolicy, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<MachinePolicy, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<MachinePolicy>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<MachinePolicy>();
                        }
                        else
                        {
                                return await this.Context.Set<MachinePolicy>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<MachinePolicy>();
                        }
                }

                private async Task<MachinePolicy> GetById(string id)
                {
                        List<MachinePolicy> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>edfe40718e42224ee4e672132a4167a3</Hash>
</Codenesium>*/