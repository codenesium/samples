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
        public abstract class AbstractDeploymentRelatedMachineRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractDeploymentRelatedMachineRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<DeploymentRelatedMachine>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<DeploymentRelatedMachine> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<DeploymentRelatedMachine> Create(DeploymentRelatedMachine item)
                {
                        this.Context.Set<DeploymentRelatedMachine>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(DeploymentRelatedMachine item)
                {
                        var entity = this.Context.Set<DeploymentRelatedMachine>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<DeploymentRelatedMachine>().Attach(item);
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
                        DeploymentRelatedMachine record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<DeploymentRelatedMachine>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<DeploymentRelatedMachine>> GetDeploymentId(string deploymentId)
                {
                        var records = await this.SearchLinqEF(x => x.DeploymentId == deploymentId);

                        return records;
                }
                public async Task<List<DeploymentRelatedMachine>> GetMachineId(string machineId)
                {
                        var records = await this.SearchLinqEF(x => x.MachineId == machineId);

                        return records;
                }

                protected async Task<List<DeploymentRelatedMachine>> Where(Expression<Func<DeploymentRelatedMachine, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<DeploymentRelatedMachine> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<DeploymentRelatedMachine>> SearchLinqEF(Expression<Func<DeploymentRelatedMachine, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(DeploymentRelatedMachine.Id)} ASC";
                        }

                        return await this.Context.Set<DeploymentRelatedMachine>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<DeploymentRelatedMachine>();
                }

                private async Task<List<DeploymentRelatedMachine>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(DeploymentRelatedMachine.Id)} ASC";
                        }

                        return await this.Context.Set<DeploymentRelatedMachine>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<DeploymentRelatedMachine>();
                }

                private async Task<DeploymentRelatedMachine> GetById(int id)
                {
                        List<DeploymentRelatedMachine> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>c6743bfdbfc6a53a41830cc8bf5a19f1</Hash>
</Codenesium>*/