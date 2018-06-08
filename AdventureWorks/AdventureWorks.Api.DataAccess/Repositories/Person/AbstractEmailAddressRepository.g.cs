using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public abstract class AbstractEmailAddressRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractEmailAddressRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<EmailAddress>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<EmailAddress> Get(int businessEntityID)
                {
                        return await this.GetById(businessEntityID);
                }

                public async virtual Task<EmailAddress> Create(EmailAddress item)
                {
                        this.Context.Set<EmailAddress>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(EmailAddress item)
                {
                        var entity = this.Context.Set<EmailAddress>().Local.FirstOrDefault(x => x.BusinessEntityID == item.BusinessEntityID);
                        if (entity == null)
                        {
                                this.Context.Set<EmailAddress>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int businessEntityID)
                {
                        EmailAddress record = await this.GetById(businessEntityID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<EmailAddress>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<EmailAddress>> GetEmailAddress(string emailAddress1)
                {
                        var records = await this.SearchLinqEF(x => x.EmailAddress1 == emailAddress1);

                        return records;
                }

                protected async Task<List<EmailAddress>> Where(Expression<Func<EmailAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<EmailAddress> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<EmailAddress>> SearchLinqEF(Expression<Func<EmailAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(EmailAddress.BusinessEntityID)} ASC";
                        }

                        return await this.Context.Set<EmailAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<EmailAddress>();
                }

                private async Task<List<EmailAddress>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(EmailAddress.BusinessEntityID)} ASC";
                        }

                        return await this.Context.Set<EmailAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<EmailAddress>();
                }

                private async Task<EmailAddress> GetById(int businessEntityID)
                {
                        List<EmailAddress> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>5fba04ed917954d3bad3705dcb758302</Hash>
</Codenesium>*/