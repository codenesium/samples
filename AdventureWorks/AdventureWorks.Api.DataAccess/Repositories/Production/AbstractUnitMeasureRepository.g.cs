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
	public abstract class AbstractUnitMeasureRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }

		public AbstractUnitMeasureRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<UnitMeasure>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
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

		public async Task<UnitMeasure> GetName(string name)
		{
			var records = await this.SearchLinqEF(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<UnitMeasure>> Where(Expression<Func<UnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<UnitMeasure> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<UnitMeasure>> SearchLinqEF(Expression<Func<UnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(UnitMeasure.UnitMeasureCode)} ASC";
			}
			return await this.Context.Set<UnitMeasure>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<UnitMeasure>();
		}

		private async Task<List<UnitMeasure>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(UnitMeasure.UnitMeasureCode)} ASC";
			}

			return await this.Context.Set<UnitMeasure>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<UnitMeasure>();
		}

		private async Task<UnitMeasure> GetById(string unitMeasureCode)
		{
			List<UnitMeasure> records = await this.SearchLinqEF(x => x.UnitMeasureCode == unitMeasureCode);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>039ac606eaaa526d99aa5b904d91577f</Hash>
</Codenesium>*/