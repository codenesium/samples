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
        public abstract class AbstractPhoneNumberTypeRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractPhoneNumberTypeRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<PhoneNumberType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<PhoneNumberType> Get(int phoneNumberTypeID)
                {
                        return await this.GetById(phoneNumberTypeID);
                }

                public async virtual Task<PhoneNumberType> Create(PhoneNumberType item)
                {
                        this.Context.Set<PhoneNumberType>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(PhoneNumberType item)
                {
                        var entity = this.Context.Set<PhoneNumberType>().Local.FirstOrDefault(x => x.PhoneNumberTypeID == item.PhoneNumberTypeID);
                        if (entity == null)
                        {
                                this.Context.Set<PhoneNumberType>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int phoneNumberTypeID)
                {
                        PhoneNumberType record = await this.GetById(phoneNumberTypeID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<PhoneNumberType>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<PhoneNumberType>> Where(Expression<Func<PhoneNumberType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<PhoneNumberType> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<PhoneNumberType>> SearchLinqEF(Expression<Func<PhoneNumberType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(PhoneNumberType.PhoneNumberTypeID)} ASC";
                        }

                        return await this.Context.Set<PhoneNumberType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PhoneNumberType>();
                }

                private async Task<List<PhoneNumberType>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(PhoneNumberType.PhoneNumberTypeID)} ASC";
                        }

                        return await this.Context.Set<PhoneNumberType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PhoneNumberType>();
                }

                private async Task<PhoneNumberType> GetById(int phoneNumberTypeID)
                {
                        List<PhoneNumberType> records = await this.SearchLinqEF(x => x.PhoneNumberTypeID == phoneNumberTypeID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>fd344880f386f5eac3b887381c969f5c</Hash>
</Codenesium>*/