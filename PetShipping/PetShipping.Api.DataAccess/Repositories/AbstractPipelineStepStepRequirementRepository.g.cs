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
        public abstract class AbstractPipelineStepStepRequirementRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractPipelineStepStepRequirementRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<PipelineStepStepRequirement>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<PipelineStepStepRequirement> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<PipelineStepStepRequirement> Create(PipelineStepStepRequirement item)
                {
                        this.Context.Set<PipelineStepStepRequirement>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(PipelineStepStepRequirement item)
                {
                        var entity = this.Context.Set<PipelineStepStepRequirement>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<PipelineStepStepRequirement>().Attach(item);
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
                        PipelineStepStepRequirement record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<PipelineStepStepRequirement>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<PipelineStepStepRequirement>> Where(Expression<Func<PipelineStepStepRequirement, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<PipelineStepStepRequirement> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<PipelineStepStepRequirement>> SearchLinqEF(Expression<Func<PipelineStepStepRequirement, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(PipelineStepStepRequirement.Id)} ASC";
                        }

                        return await this.Context.Set<PipelineStepStepRequirement>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<PipelineStepStepRequirement>();
                }

                private async Task<List<PipelineStepStepRequirement>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(PipelineStepStepRequirement.Id)} ASC";
                        }

                        return await this.Context.Set<PipelineStepStepRequirement>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<PipelineStepStepRequirement>();
                }

                private async Task<PipelineStepStepRequirement> GetById(int id)
                {
                        List<PipelineStepStepRequirement> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>a65a203f1a82cc971413e271714f256d</Hash>
</Codenesium>*/