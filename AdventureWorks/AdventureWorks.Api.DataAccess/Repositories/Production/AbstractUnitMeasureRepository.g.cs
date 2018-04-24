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

		public virtual ApiResponse GetById(string unitMeasureCode)
		{
			return this.SearchLinqPOCO(x => x.UnitMeasureCode == unitMeasureCode);
		}

		public virtual POCOUnitMeasure GetByIdDirect(string unitMeasureCode)
		{
			return this.SearchLinqPOCO(x => x.UnitMeasureCode == unitMeasureCode).UnitMeasures.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFUnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOUnitMeasure> GetWhereDirect(Expression<Func<EFUnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).UnitMeasures;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFUnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFUnitMeasure> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.UnitMeasureMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFUnitMeasure> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.UnitMeasureMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFUnitMeasure> SearchLinqEF(Expression<Func<EFUnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFUnitMeasure> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>3107b7bb37a8e222dd93e5a558e29dc3</Hash>
</Codenesium>*/