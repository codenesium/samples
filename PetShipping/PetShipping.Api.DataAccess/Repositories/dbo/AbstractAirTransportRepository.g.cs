using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractAirTransportRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractAirTransportRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			AirTransportModel model)
		{
			EFAirTransport record = new EFAirTransport();

			this.Mapper.AirTransportMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFAirTransport>().Add(record);
			this.Context.SaveChanges();
			return record.AirlineId;
		}

		public virtual void Update(
			int airlineId,
			AirTransportModel model)
		{
			EFAirTransport record = this.SearchLinqEF(x => x.AirlineId == airlineId).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{airlineId}");
			}
			else
			{
				this.Mapper.AirTransportMapModelToEF(
					airlineId,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int airlineId)
		{
			EFAirTransport record = this.SearchLinqEF(x => x.AirlineId == airlineId).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFAirTransport>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int airlineId)
		{
			return this.SearchLinqPOCO(x => x.AirlineId == airlineId);
		}

		public virtual POCOAirTransport GetByIdDirect(int airlineId)
		{
			return this.SearchLinqPOCO(x => x.AirlineId == airlineId).AirTransports.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFAirTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOAirTransport> GetWhereDirect(Expression<Func<EFAirTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).AirTransports;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFAirTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFAirTransport> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.AirTransportMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFAirTransport> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.AirTransportMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFAirTransport> SearchLinqEF(Expression<Func<EFAirTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFAirTransport> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>b4ee975b27547f081b87c58a009833e9</Hash>
</Codenesium>*/