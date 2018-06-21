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

namespace AdventureWorksNS.Api.DataAccess
{
        public abstract class AbstractEmailAddressRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractEmailAddressRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<EmailAddress>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
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

                public async Task<List<EmailAddress>> ByEmailAddress(string emailAddress1)
                {
                        var records = await this.Where(x => x.EmailAddress1 == emailAddress1);

                        return records;
                }

                protected async Task<List<EmailAddress>> Where(
                        Expression<Func<EmailAddress, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<EmailAddress, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.BusinessEntityID;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<EmailAddress>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<EmailAddress>();
                        }
                        else
                        {
                                return await this.Context.Set<EmailAddress>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<EmailAddress>();
                        }
                }

                private async Task<EmailAddress> GetById(int businessEntityID)
                {
                        List<EmailAddress> records = await this.Where(x => x.BusinessEntityID == businessEntityID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>babc3f57d52d6244a6237a97a3ba9c45</Hash>
</Codenesium>*/