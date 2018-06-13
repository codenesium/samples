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
        public abstract class AbstractUserRoleRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractUserRoleRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<UserRole>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<UserRole> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<UserRole> Create(UserRole item)
                {
                        this.Context.Set<UserRole>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(UserRole item)
                {
                        var entity = this.Context.Set<UserRole>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<UserRole>().Attach(item);
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
                        UserRole record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<UserRole>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<UserRole> GetName(string name)
                {
                        var records = await this.SearchLinqEF(x => x.Name == name);

                        return records.FirstOrDefault();
                }

                protected async Task<List<UserRole>> Where(Expression<Func<UserRole, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<UserRole> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<UserRole>> SearchLinqEF(Expression<Func<UserRole, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(UserRole.Id)} ASC";
                        }

                        return await this.Context.Set<UserRole>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<UserRole>();
                }

                private async Task<List<UserRole>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(UserRole.Id)} ASC";
                        }

                        return await this.Context.Set<UserRole>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<UserRole>();
                }

                private async Task<UserRole> GetById(string id)
                {
                        List<UserRole> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>6f1e3d5678b3fa859ede6c9f6f66fe46</Hash>
</Codenesium>*/