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
        public abstract class AbstractPipelineStepNoteRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractPipelineStepNoteRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<PipelineStepNote>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<PipelineStepNote> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<PipelineStepNote> Create(PipelineStepNote item)
                {
                        this.Context.Set<PipelineStepNote>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(PipelineStepNote item)
                {
                        var entity = this.Context.Set<PipelineStepNote>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<PipelineStepNote>().Attach(item);
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
                        PipelineStepNote record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<PipelineStepNote>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<PipelineStepNote>> Where(Expression<Func<PipelineStepNote, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<PipelineStepNote> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<PipelineStepNote>> SearchLinqEF(Expression<Func<PipelineStepNote, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(PipelineStepNote.Id)} ASC";
                        }

                        return await this.Context.Set<PipelineStepNote>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<PipelineStepNote>();
                }

                private async Task<List<PipelineStepNote>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(PipelineStepNote.Id)} ASC";
                        }

                        return await this.Context.Set<PipelineStepNote>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<PipelineStepNote>();
                }

                private async Task<PipelineStepNote> GetById(int id)
                {
                        List<PipelineStepNote> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>8e8fe5a4fbc61dcf5ff5d9661530cfc9</Hash>
</Codenesium>*/