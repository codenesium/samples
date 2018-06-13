using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public abstract class AbstractMachinePolicyRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractMachinePolicyRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<MachinePolicy>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
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

                public async Task<MachinePolicy> GetName(string name)
                {
                        var records = await this.SearchLinqEF(x => x.Name == name);

                        return records.FirstOrDefault();
                }

                protected async Task<List<MachinePolicy>> Where(Expression<Func<MachinePolicy, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<MachinePolicy> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<MachinePolicy>> SearchLinqEF(Expression<Func<MachinePolicy, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(MachinePolicy.Id)} ASC";
                        }

                        return await this.Context.Set<MachinePolicy>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<MachinePolicy>();
                }

                private async Task<List<MachinePolicy>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(MachinePolicy.Id)} ASC";
                        }

                        return await this.Context.Set<MachinePolicy>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<MachinePolicy>();
                }

                private async Task<MachinePolicy> GetById(string id)
                {
                        List<MachinePolicy> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>827244d0f30893f0d33a397ef39297ea</Hash>
</Codenesium>*/