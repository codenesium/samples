using Codenesium.DataConversionExtensions.AspNetCore;
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
        public abstract class AbstractHandlerPipelineStepRepository : AbstractRepository
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

                public virtual Task<List<HandlerPipelineStep>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
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

                public async virtual Task<Handler> GetHandler(int handlerId)
                {
                        return await this.Context.Set<Handler>().SingleOrDefaultAsync(x => x.Id == handlerId);
                }

                public async virtual Task<PipelineStep> GetPipelineStep(int pipelineStepId)
                {
                        return await this.Context.Set<PipelineStep>().SingleOrDefaultAsync(x => x.Id == pipelineStepId);
                }

                protected async Task<List<HandlerPipelineStep>> Where(
                        Expression<Func<HandlerPipelineStep, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<HandlerPipelineStep, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<HandlerPipelineStep>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<HandlerPipelineStep>();
                        }
                        else
                        {
                                return await this.Context.Set<HandlerPipelineStep>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<HandlerPipelineStep>();
                        }
                }

                private async Task<HandlerPipelineStep> GetById(int id)
                {
                        List<HandlerPipelineStep> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>ba2402847377181e17c1fe07c5d64739</Hash>
</Codenesium>*/