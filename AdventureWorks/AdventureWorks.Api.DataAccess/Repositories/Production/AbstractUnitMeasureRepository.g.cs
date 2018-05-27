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
		protected IDALUnitMeasureMapper Mapper { get; }

		public AbstractUnitMeasureRepository(
			IDALUnitMeasureMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOUnitMeasure>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOUnitMeasure> Get(string unitMeasureCode)
		{
			UnitMeasure record = await this.GetById(unitMeasureCode);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOUnitMeasure> Create(
			DTOUnitMeasure dto)
		{
			UnitMeasure record = new UnitMeasure();

			this.Mapper.MapDTOToEF(
				default (string),
				dto,
				record);

			this.Context.Set<UnitMeasure>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			string unitMeasureCode,
			DTOUnitMeasure dto)
		{
			UnitMeasure record = await this.GetById(unitMeasureCode);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{unitMeasureCode}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					unitMeasureCode,
					dto,
					record);

				await this.Context.SaveChangesAsync();
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

		public async Task<DTOUnitMeasure> GetName(string name)
		{
			var records = await this.SearchLinqDTO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<DTOUnitMeasure>> Where(Expression<Func<UnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOUnitMeasure> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOUnitMeasure>> SearchLinqDTO(Expression<Func<UnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOUnitMeasure> response = new List<DTOUnitMeasure>();
			List<UnitMeasure> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>d79d12fa5d9ed94bf4095c2d0eacdff2</Hash>
</Codenesium>*/