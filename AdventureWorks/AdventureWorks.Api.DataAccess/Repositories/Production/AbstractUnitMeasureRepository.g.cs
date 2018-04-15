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
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractUnitMeasureRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual string Create(
			UnitMeasureModel model)
		{
			var record = new EFUnitMeasure();

			this.mapper.UnitMeasureMapModelToEF(
				default (string),
				model,
				record);

			this.context.Set<EFUnitMeasure>().Add(record);
			this.context.SaveChanges();
			return record.UnitMeasureCode;
		}

		public virtual void Update(
			string unitMeasureCode,
			UnitMeasureModel model)
		{
			var record = this.SearchLinqEF(x => x.UnitMeasureCode == unitMeasureCode).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{unitMeasureCode}");
			}
			else
			{
				this.mapper.UnitMeasureMapModelToEF(
					unitMeasureCode,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			string unitMeasureCode)
		{
			var record = this.SearchLinqEF(x => x.UnitMeasureCode == unitMeasureCode).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFUnitMeasure>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(string unitMeasureCode)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.UnitMeasureCode == unitMeasureCode, response);
			return response;
		}

		public virtual POCOUnitMeasure GetByIdDirect(string unitMeasureCode)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.UnitMeasureCode == unitMeasureCode, response);
			return response.UnitMeasures.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFUnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOUnitMeasure> GetWhereDirect(Expression<Func<EFUnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.UnitMeasures;
		}

		private void SearchLinqPOCO(Expression<Func<EFUnitMeasure, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFUnitMeasure> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.UnitMeasureMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFUnitMeasure> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.UnitMeasureMapEFToPOCO(x, response));
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
    <Hash>c470500c915c139422b3a2eceed86347</Hash>
</Codenesium>*/