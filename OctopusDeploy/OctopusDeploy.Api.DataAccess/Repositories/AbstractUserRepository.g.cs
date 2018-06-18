using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public abstract class AbstractUserRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractUserRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<User>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<User> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<User> Create(User item)
                {
                        this.Context.Set<User>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(User item)
                {
                        var entity = this.Context.Set<User>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<User>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        string id)
                {
                        User record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<User>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<User> GetUsername(string username)
                {
                        var records = await this.Where(x => x.Username == username);

                        return records.FirstOrDefault();
                }
                public async Task<List<User>> GetDisplayName(string displayName)
                {
                        var records = await this.Where(x => x.DisplayName == displayName);

                        return records;
                }
                public async Task<List<User>> GetEmailAddress(string emailAddress)
                {
                        var records = await this.Where(x => x.EmailAddress == emailAddress);

                        return records;
                }
                public async Task<List<User>> GetExternalId(string externalId)
                {
                        var records = await this.Where(x => x.ExternalId == externalId);

                        return records;
                }

                protected async Task<List<User>> Where(
                        Expression<Func<User, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<User, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<User>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<User>();
                        }
                        else
                        {
                                return await this.Context.Set<User>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<User>();
                        }
                }

                private async Task<User> GetById(string id)
                {
                        List<User> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>264a036902a65940ab675b79d0037831</Hash>
</Codenesium>*/