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

namespace TestsNS.Api.DataAccess
{
        public abstract class AbstractTestAllFieldTypeRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractTestAllFieldTypeRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<TestAllFieldType>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<TestAllFieldType> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<TestAllFieldType> Create(TestAllFieldType item)
                {
                        this.Context.Set<TestAllFieldType>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(TestAllFieldType item)
                {
                        var entity = this.Context.Set<TestAllFieldType>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<TestAllFieldType>().Attach(item);
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
                        TestAllFieldType record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<TestAllFieldType>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<TestAllFieldType>> Where(
                        Expression<Func<TestAllFieldType, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<TestAllFieldType, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<TestAllFieldType>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<TestAllFieldType>();
                        }
                        else
                        {
                                return await this.Context.Set<TestAllFieldType>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<TestAllFieldType>();
                        }
                }

                private async Task<TestAllFieldType> GetById(int id)
                {
                        List<TestAllFieldType> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>f9bc1dc0972a7b09574a4abf09fe1f18</Hash>
</Codenesium>*/