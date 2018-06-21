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
        public abstract class AbstractPipelineStepRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractPipelineStepRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<PipelineStep>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<PipelineStep> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<PipelineStep> Create(PipelineStep item)
                {
                        this.Context.Set<PipelineStep>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(PipelineStep item)
                {
                        var entity = this.Context.Set<PipelineStep>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<PipelineStep>().Attach(item);
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
                        PipelineStep record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<PipelineStep>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async virtual Task<List<HandlerPipelineStep>> HandlerPipelineSteps(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<HandlerPipelineStep>().Where(x => x.PipelineStepId == pipelineStepId).AsQueryable().Skip(offset).Take(limit).ToListAsync<HandlerPipelineStep>();
                }

                public async virtual Task<List<OtherTransport>> OtherTransports(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<OtherTransport>().Where(x => x.PipelineStepId == pipelineStepId).AsQueryable().Skip(offset).Take(limit).ToListAsync<OtherTransport>();
                }

                public async virtual Task<List<PipelineStepDestination>> PipelineStepDestinations(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<PipelineStepDestination>().Where(x => x.PipelineStepId == pipelineStepId).AsQueryable().Skip(offset).Take(limit).ToListAsync<PipelineStepDestination>();
                }

                public async virtual Task<List<PipelineStepNote>> PipelineStepNotes(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<PipelineStepNote>().Where(x => x.PipelineStepId == pipelineStepId).AsQueryable().Skip(offset).Take(limit).ToListAsync<PipelineStepNote>();
                }

                public async virtual Task<List<PipelineStepStepRequirement>> PipelineStepStepRequirements(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<PipelineStepStepRequirement>().Where(x => x.PipelineStepId == pipelineStepId).AsQueryable().Skip(offset).Take(limit).ToListAsync<PipelineStepStepRequirement>();
                }

                public async virtual Task<PipelineStepStatus> GetPipelineStepStatus(int pipelineStepStatusId)
                {
                        return await this.Context.Set<PipelineStepStatus>().SingleOrDefaultAsync(x => x.Id == pipelineStepStatusId);
                }

                public async virtual Task<Employee> GetEmployee(int shipperId)
                {
                        return await this.Context.Set<Employee>().SingleOrDefaultAsync(x => x.Id == shipperId);
                }

                protected async Task<List<PipelineStep>> Where(
                        Expression<Func<PipelineStep, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<PipelineStep, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<PipelineStep>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<PipelineStep>();
                        }
                        else
                        {
                                return await this.Context.Set<PipelineStep>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<PipelineStep>();
                        }
                }

                private async Task<PipelineStep> GetById(int id)
                {
                        List<PipelineStep> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>491635c92ff21486442e2813c3f2e167</Hash>
</Codenesium>*/