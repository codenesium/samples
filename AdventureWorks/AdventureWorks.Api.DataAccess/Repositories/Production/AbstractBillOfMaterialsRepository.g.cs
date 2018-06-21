using Codenesium.DataConversionExtensions.AspNetCore;
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
        public abstract class AbstractBillOfMaterialsRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractBillOfMaterialsRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<BillOfMaterials>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<BillOfMaterials> Get(int billOfMaterialsID)
                {
                        return await this.GetById(billOfMaterialsID);
                }

                public async virtual Task<BillOfMaterials> Create(BillOfMaterials item)
                {
                        this.Context.Set<BillOfMaterials>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(BillOfMaterials item)
                {
                        var entity = this.Context.Set<BillOfMaterials>().Local.FirstOrDefault(x => x.BillOfMaterialsID == item.BillOfMaterialsID);
                        if (entity == null)
                        {
                                this.Context.Set<BillOfMaterials>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int billOfMaterialsID)
                {
                        BillOfMaterials record = await this.GetById(billOfMaterialsID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<BillOfMaterials>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<BillOfMaterials> ByProductAssemblyIDComponentIDStartDate(Nullable<int> productAssemblyID, int componentID, DateTime startDate)
                {
                        var records = await this.Where(x => x.ProductAssemblyID == productAssemblyID && x.ComponentID == componentID && x.StartDate == startDate);

                        return records.FirstOrDefault();
                }

                public async Task<List<BillOfMaterials>> ByUnitMeasureCode(string unitMeasureCode)
                {
                        var records = await this.Where(x => x.UnitMeasureCode == unitMeasureCode);

                        return records;
                }

                protected async Task<List<BillOfMaterials>> Where(
                        Expression<Func<BillOfMaterials, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<BillOfMaterials, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.BillOfMaterialsID;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<BillOfMaterials>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<BillOfMaterials>();
                        }
                        else
                        {
                                return await this.Context.Set<BillOfMaterials>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<BillOfMaterials>();
                        }
                }

                private async Task<BillOfMaterials> GetById(int billOfMaterialsID)
                {
                        List<BillOfMaterials> records = await this.Where(x => x.BillOfMaterialsID == billOfMaterialsID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>90274850e7234588db58ea6398f11458</Hash>
</Codenesium>*/