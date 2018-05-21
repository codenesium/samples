using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractUnitMeasureRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractUnitMeasureRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOUnitMeasure>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOUnitMeasure> Get(string unitMeasureCode)
		{
			UnitMeasure record = await this.GetById(unitMeasureCode);

			return this.Mapper.UnitMeasureMapEFToPOCO(record);
		}

		public async virtual Task<POCOUnitMeasure> Create(
			ApiUnitMeasureModel model)
		{
			UnitMeasure record = new UnitMeasure();

			this.Mapper.UnitMeasureMapModelToEF(
				default (string),
				model,
				record);

			this.Context.Set<UnitMeasure>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.UnitMeasureMapEFToPOCO(record);
		}

		public async virtual Task Update(
			string unitMeasureCode,
			ApiUnitMeasureModel model)
		{
			UnitMeasure record = await this.GetById(unitMeasureCode);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{unitMeasureCode}");
			}
			else
			{
				this.Mapper.UnitMeasureMapModelToEF(
					unitMeasureCode,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
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

		public async Task<POCOUnitMeasure> GetName(string name)
		{
			var records = await this.SearchLinqPOCO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOUnitMeasure>> Where(Expression<Func<UnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOUnitMeasure> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOUnitMeasure>> SearchLinqPOCO(Expression<Func<UnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOUnitMeasure> response = new List<POCOUnitMeasure>();
			List<UnitMeasure> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.UnitMeasureMapEFToPOCO(x)));
			return response;
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
    <Hash>d6c13fa277a59eca1f2fd4f928e13eab</Hash>
</Codenesium>*/