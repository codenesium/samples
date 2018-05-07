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

		public virtual POCOAirTransport Get(int airlineId)
		{
			return this.SearchLinqPOCO(x => x.AirlineId == airlineId).FirstOrDefault();
		}

		public virtual List<POCOAirTransport> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		private List<POCOAirTransport> Where(Expression<Func<EFAirTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOAirTransport> SearchLinqPOCO(Expression<Func<EFAirTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOAirTransport> response = new List<POCOAirTransport>();
			List<EFAirTransport> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.AirTransportMapEFToPOCO(x)));
			return response;
		}

		private List<EFAirTransport> SearchLinqEF(Expression<Func<EFAirTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFAirTransport>().Where(predicate).AsQueryable().OrderBy("AirlineId ASC").Skip(skip).Take(take).ToList<EFAirTransport>();
			}
			else
			{
				return this.Context.Set<EFAirTransport>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAirTransport>();
			}
		}

		private List<EFAirTransport> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFAirTransport>().Where(predicate).AsQueryable().OrderBy("AirlineId ASC").Skip(skip).Take(take).ToList<EFAirTransport>();
			}
			else
			{
				return this.Context.Set<EFAirTransport>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAirTransport>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>d39a1d15a840e4b8a083ba1cbecee39f</Hash>
</Codenesium>*/