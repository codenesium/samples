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

		public virtual Task<List<UnitMeasure>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
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

		public async Task<UnitMeasure> ByName(string name)
		{
			var records = await this.Where(x => x.Name == name);

			return records.FirstOrDefault();
		}

		public async virtual Task<List<BillOfMaterial>> BillOfMaterials(string unitMeasureCode, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<BillOfMaterial>().Where(x => x.UnitMeasureCode == unitMeasureCode).AsQueryable().Skip(offset).Take(limit).ToListAsync<BillOfMaterial>();
		}

		public async virtual Task<List<Product>> Products(string sizeUnitMeasureCode, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Product>().Where(x => x.SizeUnitMeasureCode == sizeUnitMeasureCode).AsQueryable().Skip(offset).Take(limit).ToListAsync<Product>();
		}

		protected async Task<List<UnitMeasure>> Where(
			Expression<Func<UnitMeasure, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<UnitMeasure, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.UnitMeasureCode;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<UnitMeasure>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<UnitMeasure>();
			}
			else
			{
				return await this.Context.Set<UnitMeasure>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<UnitMeasure>();
			}
		}

		private async Task<UnitMeasure> GetById(string unitMeasureCode)
		{
			List<UnitMeasure> records = await this.Where(x => x.UnitMeasureCode == unitMeasureCode);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>deb642f4a7cb8427ee2949e148eeac42</Hash>
</Codenesium>*/