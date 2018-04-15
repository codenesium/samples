using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractRateRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractRateRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			RateModel model)
		{
			var record = new EFRate();

			this.mapper.RateMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFRate>().Add(record);
			this.context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(
			int id,
			RateModel model)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{id}");
			}
			else
			{
				this.mapper.RateMapModelToEF(
					id,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFRate>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int id)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response;
		}

		public virtual POCORate GetByIdDirect(int id)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response.Rates.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCORate> GetWhereDirect(Expression<Func<EFRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Rates;
		}

		private void SearchLinqPOCO(Expression<Func<EFRate, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFRate> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.RateMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFRate> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.RateMapEFToPOCO(x, response));
		}

		protected virtual List<EFRate> SearchLinqEF(Expression<Func<EFRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFRate> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>d2c73963c96b3fea060543188b378b00</Hash>
</Codenesium>*/