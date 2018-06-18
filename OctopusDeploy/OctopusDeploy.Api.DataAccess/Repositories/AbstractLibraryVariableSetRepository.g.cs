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
        public abstract class AbstractLibraryVariableSetRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractLibraryVariableSetRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<LibraryVariableSet>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<LibraryVariableSet> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<LibraryVariableSet> Create(LibraryVariableSet item)
                {
                        this.Context.Set<LibraryVariableSet>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(LibraryVariableSet item)
                {
                        var entity = this.Context.Set<LibraryVariableSet>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<LibraryVariableSet>().Attach(item);
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
                        LibraryVariableSet record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<LibraryVariableSet>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<LibraryVariableSet> GetName(string name)
                {
                        var records = await this.Where(x => x.Name == name);

                        return records.FirstOrDefault();
                }

                protected async Task<List<LibraryVariableSet>> Where(
                        Expression<Func<LibraryVariableSet, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<LibraryVariableSet, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<LibraryVariableSet>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<LibraryVariableSet>();
                        }
                        else
                        {
                                return await this.Context.Set<LibraryVariableSet>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<LibraryVariableSet>();
                        }
                }

                private async Task<LibraryVariableSet> GetById(string id)
                {
                        List<LibraryVariableSet> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>cdcb951a4f2ef15c6e84c4a31461432d</Hash>
</Codenesium>*/