using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public abstract class AbstractPipelineStepRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractPipelineStepRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<PipelineStep>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
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

                protected async Task<List<PipelineStep>> Where(Expression<Func<PipelineStep, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<PipelineStep> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<PipelineStep>> SearchLinqEF(Expression<Func<PipelineStep, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(PipelineStep.Id)} ASC";
                        }

                        return await this.Context.Set<PipelineStep>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<PipelineStep>();
                }

                private async Task<List<PipelineStep>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(PipelineStep.Id)} ASC";
                        }

                        return await this.Context.Set<PipelineStep>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<PipelineStep>();
                }

                private async Task<PipelineStep> GetById(int id)
                {
                        List<PipelineStep> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
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
        }
}

/*<Codenesium>
    <Hash>2687d6c429f2bac3ee1fbb0dd50bd7c4</Hash>
</Codenesium>*/