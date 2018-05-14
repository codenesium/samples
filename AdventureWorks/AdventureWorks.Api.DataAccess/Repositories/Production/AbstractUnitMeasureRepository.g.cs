using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractUnitMeasureRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractUnitMeasureRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOUnitMeasure> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOUnitMeasure Get(string unitMeasureCode)
		{
			return this.SearchLinqPOCO(x => x.UnitMeasureCode == unitMeasureCode).FirstOrDefault();
		}

		public virtual POCOUnitMeasure Create(
			ApiUnitMeasureModel model)
		{
			UnitMeasure record = new UnitMeasure();

			this.Mapper.UnitMeasureMapModelToEF(
				default (string),
				model,
				record);

			this.Context.Set<UnitMeasure>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.UnitMeasureMapEFToPOCO(record);
		}

		public virtual void Update(
			string unitMeasureCode,
			ApiUnitMeasureModel model)
		{
			UnitMeasure record = this.SearchLinqEF(x => x.UnitMeasureCode == unitMeasureCode).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			string unitMeasureCode)
		{
			UnitMeasure record = this.SearchLinqEF(x => x.UnitMeasureCode == unitMeasureCode).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<UnitMeasure>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOUnitMeasure GetName(string name)
		{
			return this.SearchLinqPOCO(x => x.Name == name).FirstOrDefault();
		}

		protected List<POCOUnitMeasure> Where(Expression<Func<UnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOUnitMeasure> SearchLinqPOCO(Expression<Func<UnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOUnitMeasure> response = new List<POCOUnitMeasure>();
			List<UnitMeasure> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.UnitMeasureMapEFToPOCO(x)));
			return response;
		}

		private List<UnitMeasure> SearchLinqEF(Expression<Func<UnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(UnitMeasure.UnitMeasureCode)} ASC";
			}
			return this.Context.Set<UnitMeasure>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<UnitMeasure>();
		}

		private List<UnitMeasure> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(UnitMeasure.UnitMeasureCode)} ASC";
			}

			return this.Context.Set<UnitMeasure>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<UnitMeasure>();
		}
	}
}

/*<Codenesium>
    <Hash>932f07f43c677ad3a9a2d73d0967c645</Hash>
</Codenesium>*/