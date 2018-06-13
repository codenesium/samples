using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public abstract class AbstractAdminRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractAdminRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Admin>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<Admin> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Admin> Create(Admin item)
                {
                        this.Context.Set<Admin>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Admin item)
                {
                        var entity = this.Context.Set<Admin>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Admin>().Attach(item);
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
                        Admin record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Admin>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<Admin>> Where(Expression<Func<Admin, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<Admin> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<Admin>> SearchLinqEF(Expression<Func<Admin, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Admin.Id)} ASC";
                        }

                        return await this.Context.Set<Admin>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Admin>();
                }

                private async Task<List<Admin>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Admin.Id)} ASC";
                        }

                        return await this.Context.Set<Admin>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Admin>();
                }

                private async Task<Admin> GetById(int id)
                {
                        List<Admin> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<Venue>> Venues(int adminId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Venue>().Where(x => x.AdminId == adminId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Venue>();
                }
        }
}

/*<Codenesium>
    <Hash>f85e7646c901585fb8b6dc09fbdc052d</Hash>
</Codenesium>*/