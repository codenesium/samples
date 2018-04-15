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
	public abstract class AbstractLocationRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractLocationRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual short Create(
			LocationModel model)
		{
			var record = new EFLocation();

			this.mapper.LocationMapModelToEF(
				default (short),
				model,
				record);

			this.context.Set<EFLocation>().Add(record);
			this.context.SaveChanges();
			return record.LocationID;
		}

		public virtual void Update(
			short locationID,
			LocationModel model)
		{
			var record = this.SearchLinqEF(x => x.LocationID == locationID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{locationID}");
			}
			else
			{
				this.mapper.LocationMapModelToEF(
					locationID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			short locationID)
		{
			var record = this.SearchLinqEF(x => x.LocationID == locationID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFLocation>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(short locationID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.LocationID == locationID, response);
			return response;
		}

		public virtual POCOLocation GetByIdDirect(short locationID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.LocationID == locationID, response);
			return response.Locations.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFLocation, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOLocation> GetWhereDirect(Expression<Func<EFLocation, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Locations;
		}

		private void SearchLinqPOCO(Expression<Func<EFLocation, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFLocation> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.LocationMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFLocation> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.LocationMapEFToPOCO(x, response));
		}

		protected virtual List<EFLocation> SearchLinqEF(Expression<Func<EFLocation, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFLocation> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>d7da1ff71d82a15e77d02210f2676c72</Hash>
</Codenesium>*/