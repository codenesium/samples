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
        public abstract class AbstractHandlerPipelineStepRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractHandlerPipelineStepRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<HandlerPipelineStep>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<HandlerPipelineStep> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<HandlerPipelineStep> Create(HandlerPipelineStep item)
                {
                        this.Context.Set<HandlerPipelineStep>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(HandlerPipelineStep item)
                {
                        var entity = this.Context.Set<HandlerPipelineStep>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<HandlerPipelineStep>().Attach(item);
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
                        HandlerPipelineStep record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<HandlerPipelineStep>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<HandlerPipelineStep>> Where(Expression<Func<HandlerPipelineStep, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<HandlerPipelineStep> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<HandlerPipelineStep>> SearchLinqEF(Expression<Func<HandlerPipelineStep, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(HandlerPipelineStep.Id)} ASC";
                        }

                        return await this.Context.Set<HandlerPipelineStep>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<HandlerPipelineStep>();
                }

                private async Task<List<HandlerPipelineStep>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(HandlerPipelineStep.Id)} ASC";
                        }

                        return await this.Context.Set<HandlerPipelineStep>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<HandlerPipelineStep>();
                }

                private async Task<HandlerPipelineStep> GetById(int id)
                {
                        List<HandlerPipelineStep> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>95bdbbdba1f5d737547a77ba3c40f1a4</Hash>
</Codenesium>*/