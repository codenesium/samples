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
        public abstract class AbstractContactTypeRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractContactTypeRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<ContactType>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<ContactType> Get(int contactTypeID)
                {
                        return await this.GetById(contactTypeID);
                }

                public async virtual Task<ContactType> Create(ContactType item)
                {
                        this.Context.Set<ContactType>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(ContactType item)
                {
                        var entity = this.Context.Set<ContactType>().Local.FirstOrDefault(x => x.ContactTypeID == item.ContactTypeID);
                        if (entity == null)
                        {
                                this.Context.Set<ContactType>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int contactTypeID)
                {
                        ContactType record = await this.GetById(contactTypeID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<ContactType>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<ContactType> GetName(string name)
                {
                        var records = await this.SearchLinqEF(x => x.Name == name);

                        return records.FirstOrDefault();
                }

                protected async Task<List<ContactType>> Where(Expression<Func<ContactType, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<ContactType> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<ContactType>> SearchLinqEF(Expression<Func<ContactType, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ContactType.ContactTypeID)} ASC";
                        }

                        return await this.Context.Set<ContactType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ContactType>();
                }

                private async Task<List<ContactType>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ContactType.ContactTypeID)} ASC";
                        }

                        return await this.Context.Set<ContactType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ContactType>();
                }

                private async Task<ContactType> GetById(int contactTypeID)
                {
                        List<ContactType> records = await this.SearchLinqEF(x => x.ContactTypeID == contactTypeID);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<BusinessEntityContact>> BusinessEntityContacts(int contactTypeID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<BusinessEntityContact>().Where(x => x.ContactTypeID == contactTypeID).AsQueryable().Skip(offset).Take(limit).ToListAsync<BusinessEntityContact>();
                }
        }
}

/*<Codenesium>
    <Hash>866a8e6c340649cda2ca6ec31de22295</Hash>
</Codenesium>*/