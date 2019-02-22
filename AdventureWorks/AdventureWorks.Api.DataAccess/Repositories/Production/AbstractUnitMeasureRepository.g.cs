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
	public abstract class AbstractUnitMeasureRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractUnitMeasureRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<UnitMeasure>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.ModifiedDate == query.ToDateTime() ||
				                  x.Name.StartsWith(query) ||
				                  x.UnitMeasureCode.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<UnitMeasure> Get(string unitMeasureCode)
		{
			return await this.GetById(unitMeasureCode);
		}

		public async virtual Task<UnitMeasure> Create(UnitMeasure item)
		{
			this.Context.Set<UnitMeasure>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(UnitMeasure item)
		{
			var entity = this.Context.Set<UnitMeasure>().Local.FirstOrDefault(x => x.UnitMeasureCode == item.UnitMeasureCode);
			if (entity == null)
			{
				this.Context.Set<UnitMeasure>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			string unitMeasureCode)
		{
			UnitMeasure record = await this.GetById(unitMeasureCode);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<UnitMeasure>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// unique constraint AK_UnitMeasure_Name.
		public async virtual Task<UnitMeasure> ByName(string name)
		{
			return await this.Context.Set<UnitMeasure>()

			       .FirstOrDefaultAsync(x => x.Name == name);
		}

		// Foreign key reference to this table BillOfMaterial via unitMeasureCode.
		public async virtual Task<List<BillOfMaterial>> BillOfMaterialsByUnitMeasureCode(string unitMeasureCode, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<BillOfMaterial>()
			       .Include(x => x.UnitMeasureCodeNavigation)
			       .Where(x => x.UnitMeasureCode == unitMeasureCode).AsQueryable().Skip(offset).Take(limit).ToListAsync<BillOfMaterial>();
		}

		// Foreign key reference to this table Product via sizeUnitMeasureCode.
		public async virtual Task<List<Product>> ProductsBySizeUnitMeasureCode(string sizeUnitMeasureCode, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Product>()
			       .Include(x => x.SizeUnitMeasureCodeNavigation)
			       .Where(x => x.SizeUnitMeasureCode == sizeUnitMeasureCode).AsQueryable().Skip(offset).Take(limit).ToListAsync<Product>();
		}

		// Foreign key reference to this table Product via weightUnitMeasureCode.
		public async virtual Task<List<Product>> ProductsByWeightUnitMeasureCode(string weightUnitMeasureCode, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Product>()
			       .Include(x => x.WeightUnitMeasureCodeNavigation)
			       .Where(x => x.WeightUnitMeasureCode == weightUnitMeasureCode).AsQueryable().Skip(offset).Take(limit).ToListAsync<Product>();
		}

		protected async Task<List<UnitMeasure>> Where(
			Expression<Func<UnitMeasure, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<UnitMeasure, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.UnitMeasureCode;
			}

			return await this.Context.Set<UnitMeasure>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<UnitMeasure>();
		}

		private async Task<UnitMeasure> GetById(string unitMeasureCode)
		{
			List<UnitMeasure> records = await this.Where(x => x.UnitMeasureCode == unitMeasureCode);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>c52a5b25f4d68d149f666dae6fe3d0b3</Hash>
</Codenesium>*/