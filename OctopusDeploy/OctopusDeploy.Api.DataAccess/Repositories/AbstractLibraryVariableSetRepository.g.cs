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

                public virtual Task<List<LibraryVariableSet>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
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
                        var records = await this.SearchLinqEF(x => x.Name == name);

                        return records.FirstOrDefault();
                }

                protected async Task<List<LibraryVariableSet>> Where(Expression<Func<LibraryVariableSet, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<LibraryVariableSet> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<LibraryVariableSet>> SearchLinqEF(Expression<Func<LibraryVariableSet, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(LibraryVariableSet.Id)} ASC";
                        }

                        return await this.Context.Set<LibraryVariableSet>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<LibraryVariableSet>();
                }

                private async Task<List<LibraryVariableSet>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(LibraryVariableSet.Id)} ASC";
                        }

                        return await this.Context.Set<LibraryVariableSet>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<LibraryVariableSet>();
                }

                private async Task<LibraryVariableSet> GetById(string id)
                {
                        List<LibraryVariableSet> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>1ce43d054133bc4129914c42519578fd</Hash>
</Codenesium>*/