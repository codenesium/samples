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
        public abstract class AbstractPipelineStatusRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractPipelineStatusRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<PipelineStatus>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<PipelineStatus> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<PipelineStatus> Create(PipelineStatus item)
                {
                        this.Context.Set<PipelineStatus>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(PipelineStatus item)
                {
                        var entity = this.Context.Set<PipelineStatus>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<PipelineStatus>().Attach(item);
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
                        PipelineStatus record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<PipelineStatus>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<PipelineStatus>> Where(Expression<Func<PipelineStatus, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<PipelineStatus> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<PipelineStatus>> SearchLinqEF(Expression<Func<PipelineStatus, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(PipelineStatus.Id)} ASC";
                        }

                        return await this.Context.Set<PipelineStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<PipelineStatus>();
                }

                private async Task<List<PipelineStatus>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(PipelineStatus.Id)} ASC";
                        }

                        return await this.Context.Set<PipelineStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<PipelineStatus>();
                }

                private async Task<PipelineStatus> GetById(int id)
                {
                        List<PipelineStatus> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<Pipeline>> Pipelines(int pipelineStatusId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Pipeline>().Where(x => x.PipelineStatusId == pipelineStatusId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Pipeline>();
                }
        }
}

/*<Codenesium>
    <Hash>7ddd278352c10f210227ef3f74e19979</Hash>
</Codenesium>*/