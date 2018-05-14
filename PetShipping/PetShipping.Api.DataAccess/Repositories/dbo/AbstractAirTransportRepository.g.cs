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

		public virtual List<POCOAirTransport> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOAirTransport Get(int airlineId)
		{
			return this.SearchLinqPOCO(x => x.AirlineId == airlineId).FirstOrDefault();
		}

		public virtual POCOAirTransport Create(
			AirTransportModel model)
		{
			AirTransport record = new AirTransport();

			this.Mapper.AirTransportMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<AirTransport>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.AirTransportMapEFToPOCO(record);
		}

		public virtual void Update(
			int airlineId,
			AirTransportModel model)
		{
			AirTransport record = this.SearchLinqEF(x => x.AirlineId == airlineId).FirstOrDefault();
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
			AirTransport record = this.SearchLinqEF(x => x.AirlineId == airlineId).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<AirTransport>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOAirTransport> Where(Expression<Func<AirTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOAirTransport> SearchLinqPOCO(Expression<Func<AirTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOAirTransport> response = new List<POCOAirTransport>();
			List<AirTransport> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.AirTransportMapEFToPOCO(x)));
			return response;
		}

		private List<AirTransport> SearchLinqEF(Expression<Func<AirTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(AirTransport.AirlineId)} ASC";
			}
			return this.Context.Set<AirTransport>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<AirTransport>();
		}

		private List<AirTransport> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(AirTransport.AirlineId)} ASC";
			}

			return this.Context.Set<AirTransport>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<AirTransport>();
		}
	}
}

/*<Codenesium>
    <Hash>330e653bb64052bc1a3f46360c1ec90f</Hash>
</Codenesium>*/