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
	public abstract class AbstractStateProvinceRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractStateProvinceRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			StateProvinceModel model)
		{
			var record = new EFStateProvince();

			this.mapper.StateProvinceMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFStateProvince>().Add(record);
			this.context.SaveChanges();
			return record.StateProvinceID;
		}

		public virtual void Update(
			int stateProvinceID,
			StateProvinceModel model)
		{
			var record = this.SearchLinqEF(x => x.StateProvinceID == stateProvinceID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{stateProvinceID}");
			}
			else
			{
				this.mapper.StateProvinceMapModelToEF(
					stateProvinceID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int stateProvinceID)
		{
			var record = this.SearchLinqEF(x => x.StateProvinceID == stateProvinceID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFStateProvince>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int stateProvinceID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.StateProvinceID == stateProvinceID, response);
			return response;
		}

		public virtual POCOStateProvince GetByIdDirect(int stateProvinceID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.StateProvinceID == stateProvinceID, response);
			return response.StateProvinces.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFStateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOStateProvince> GetWhereDirect(Expression<Func<EFStateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.StateProvinces;
		}

		private void SearchLinqPOCO(Expression<Func<EFStateProvince, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFStateProvince> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.StateProvinceMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFStateProvince> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.StateProvinceMapEFToPOCO(x, response));
		}

		protected virtual List<EFStateProvince> SearchLinqEF(Expression<Func<EFStateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFStateProvince> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>e1c863c60c19074fece3e19047e2b4ef</Hash>
</Codenesium>*/