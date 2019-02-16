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

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractBillOfMaterialRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractBillOfMaterialRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<BillOfMaterial>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.BillOfMaterialsID == query.ToInt() ||
				                  x.BOMLevel == query.ToShort() ||
				                  x.ComponentID == query.ToInt() ||
				                  x.EndDate == query.ToNullableDateTime() ||
				                  x.ModifiedDate == query.ToDateTime() ||
				                  x.PerAssemblyQty == query.ToDouble() ||
				                  x.ProductAssemblyID == query.ToNullableInt() ||
				                  x.StartDate == query.ToDateTime() ||
				                  x.UnitMeasureCode.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<BillOfMaterial> Get(int billOfMaterialsID)
		{
			return await this.GetById(billOfMaterialsID);
		}

		public async virtual Task<BillOfMaterial> Create(BillOfMaterial item)
		{
			this.Context.Set<BillOfMaterial>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(BillOfMaterial item)
		{
			var entity = this.Context.Set<BillOfMaterial>().Local.FirstOrDefault(x => x.BillOfMaterialsID == item.BillOfMaterialsID);
			if (entity == null)
			{
				this.Context.Set<BillOfMaterial>().Attach(item);
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
			BillOfMaterial record = await this.GetById(billOfMaterialsID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<BillOfMaterial>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_BillOfMaterials_UnitMeasureCode.
		public async virtual Task<List<BillOfMaterial>> ByUnitMeasureCode(string unitMeasureCode, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.UnitMeasureCode == unitMeasureCode, limit, offset);
		}

		protected async Task<List<BillOfMaterial>> Where(
			Expression<Func<BillOfMaterial, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<BillOfMaterial, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.BillOfMaterialsID;
			}

			return await this.Context.Set<BillOfMaterial>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<BillOfMaterial>();
		}

		private async Task<BillOfMaterial> GetById(int billOfMaterialsID)
		{
			List<BillOfMaterial> records = await this.Where(x => x.BillOfMaterialsID == billOfMaterialsID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>a1175305c96fa0ed3ff2ef54a05562d7</Hash>
</Codenesium>*/