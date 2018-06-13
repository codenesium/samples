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
        public abstract class AbstractOtherTransportRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractOtherTransportRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<OtherTransport>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<OtherTransport> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<OtherTransport> Create(OtherTransport item)
                {
                        this.Context.Set<OtherTransport>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(OtherTransport item)
                {
                        var entity = this.Context.Set<OtherTransport>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<OtherTransport>().Attach(item);
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
                        OtherTransport record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<OtherTransport>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<OtherTransport>> Where(Expression<Func<OtherTransport, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<OtherTransport> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<OtherTransport>> SearchLinqEF(Expression<Func<OtherTransport, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(OtherTransport.Id)} ASC";
                        }

                        return await this.Context.Set<OtherTransport>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<OtherTransport>();
                }

                private async Task<List<OtherTransport>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(OtherTransport.Id)} ASC";
                        }

                        return await this.Context.Set<OtherTransport>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<OtherTransport>();
                }

                private async Task<OtherTransport> GetById(int id)
                {
                        List<OtherTransport> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>05af582cd79e16daa1ae0ec2206a33e1</Hash>
</Codenesium>*/