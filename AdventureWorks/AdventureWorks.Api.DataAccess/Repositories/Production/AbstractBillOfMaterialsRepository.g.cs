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
	public abstract class AbstractBillOfMaterialsRepository: AbstractRepository
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

		public virtual Task<List<BillOfMaterials>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
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

		public async Task<BillOfMaterials> GetProductAssemblyIDComponentIDStartDate(Nullable<int> productAssemblyID,int componentID,DateTime startDate)
		{
			var records = await this.SearchLinqEF(x => x.ProductAssemblyID == productAssemblyID && x.ComponentID == componentID && x.StartDate == startDate);

			return records.FirstOrDefault();
		}
		public async Task<List<BillOfMaterials>> GetUnitMeasureCode(string unitMeasureCode)
		{
			var records = await this.SearchLinqEF(x => x.UnitMeasureCode == unitMeasureCode);

			return records;
		}

		protected async Task<List<BillOfMaterials>> Where(Expression<Func<BillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<BillOfMaterials> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<BillOfMaterials>> SearchLinqEF(Expression<Func<BillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(BillOfMaterials.BillOfMaterialsID)} ASC";
			}
			return await this.Context.Set<BillOfMaterials>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<BillOfMaterials>();
		}

		private async Task<List<BillOfMaterials>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(BillOfMaterials.BillOfMaterialsID)} ASC";
			}

			return await this.Context.Set<BillOfMaterials>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<BillOfMaterials>();
		}

		private async Task<BillOfMaterials> GetById(int billOfMaterialsID)
		{
			List<BillOfMaterials> records = await this.SearchLinqEF(x => x.BillOfMaterialsID == billOfMaterialsID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>71ab02eee7e611b41874dad09db547cf</Hash>
</Codenesium>*/