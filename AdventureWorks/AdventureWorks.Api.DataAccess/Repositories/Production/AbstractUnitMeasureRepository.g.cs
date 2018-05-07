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

		public virtual string Create(
			UnitMeasureModel model)
		{
			EFUnitMeasure record = new EFUnitMeasure();

			this.Mapper.UnitMeasureMapModelToEF(
				default (string),
				model,
				record);

			this.Context.Set<EFUnitMeasure>().Add(record);
			this.Context.SaveChanges();
			return record.UnitMeasureCode;
		}

		public virtual void Update(
			string unitMeasureCode,
			UnitMeasureModel model)
		{
			EFUnitMeasure record = this.SearchLinqEF(x => x.UnitMeasureCode == unitMeasureCode).FirstOrDefault();
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
			EFUnitMeasure record = this.SearchLinqEF(x => x.UnitMeasureCode == unitMeasureCode).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFUnitMeasure>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual POCOUnitMeasure Get(string unitMeasureCode)
		{
			return this.SearchLinqPOCO(x => x.UnitMeasureCode == unitMeasureCode).FirstOrDefault();
		}

		public virtual List<POCOUnitMeasure> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		private List<POCOUnitMeasure> Where(Expression<Func<EFUnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOUnitMeasure> SearchLinqPOCO(Expression<Func<EFUnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOUnitMeasure> response = new List<POCOUnitMeasure>();
			List<EFUnitMeasure> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.UnitMeasureMapEFToPOCO(x)));
			return response;
		}

		private List<EFUnitMeasure> SearchLinqEF(Expression<Func<EFUnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFUnitMeasure>().Where(predicate).AsQueryable().OrderBy("UnitMeasureCode ASC").Skip(skip).Take(take).ToList<EFUnitMeasure>();
			}
			else
			{
				return this.Context.Set<EFUnitMeasure>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFUnitMeasure>();
			}
		}

		private List<EFUnitMeasure> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFUnitMeasure>().Where(predicate).AsQueryable().OrderBy("UnitMeasureCode ASC").Skip(skip).Take(take).ToList<EFUnitMeasure>();
			}
			else
			{
				return this.Context.Set<EFUnitMeasure>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFUnitMeasure>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>f22910da556355aa743e452479a6c71e</Hash>
</Codenesium>*/