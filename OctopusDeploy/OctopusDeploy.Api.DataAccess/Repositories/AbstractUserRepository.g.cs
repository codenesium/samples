using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
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

                public virtual Task<List<User>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
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
                        var records = await this.SearchLinqEF(x => x.Username == username);

                        return records.FirstOrDefault();
                }
                public async Task<List<User>> GetDisplayName(string displayName)
                {
                        var records = await this.SearchLinqEF(x => x.DisplayName == displayName);

                        return records;
                }
                public async Task<List<User>> GetEmailAddress(string emailAddress)
                {
                        var records = await this.SearchLinqEF(x => x.EmailAddress == emailAddress);

                        return records;
                }
                public async Task<List<User>> GetExternalId(string externalId)
                {
                        var records = await this.SearchLinqEF(x => x.ExternalId == externalId);

                        return records;
                }

                protected async Task<List<User>> Where(Expression<Func<User, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<User> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<User>> SearchLinqEF(Expression<Func<User, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(User.Id)} ASC";
                        }

                        return await this.Context.Set<User>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<User>();
                }

                private async Task<List<User>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(User.Id)} ASC";
                        }

                        return await this.Context.Set<User>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<User>();
                }

                private async Task<User> GetById(string id)
                {
                        List<User> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>ddfcfe280aeff786227e9ef9ea41b3de</Hash>
</Codenesium>*/