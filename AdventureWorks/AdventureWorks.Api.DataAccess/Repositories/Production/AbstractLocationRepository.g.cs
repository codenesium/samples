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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractLocationRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual short Create(
			LocationModel model)
		{
			EFLocation record = new EFLocation();

			this.Mapper.LocationMapModelToEF(
				default (short),
				model,
				record);

			this.Context.Set<EFLocation>().Add(record);
			this.Context.SaveChanges();
			return record.LocationID;
		}

		public virtual void Update(
			short locationID,
			LocationModel model)
		{
			EFLocation record = this.SearchLinqEF(x => x.LocationID == locationID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{locationID}");
			}
			else
			{
				this.Mapper.LocationMapModelToEF(
					locationID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			short locationID)
		{
			EFLocation record = this.SearchLinqEF(x => x.LocationID == locationID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFLocation>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(short locationID)
		{
			return this.SearchLinqPOCO(x => x.LocationID == locationID);
		}

		public virtual POCOLocation GetByIdDirect(short locationID)
		{
			return this.SearchLinqPOCO(x => x.LocationID == locationID).Locations.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFLocation, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOLocation> GetWhereDirect(Expression<Func<EFLocation, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).Locations;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFLocation, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFLocation> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.LocationMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFLocation> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.LocationMapEFToPOCO(x, response));
			return response;
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
    <Hash>151bae112b88a2896f5a04bac0ce688a</Hash>
</Codenesium>*/