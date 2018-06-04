using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractAirTransportRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }

		public AbstractAirTransportRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<AirTransport>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
		}

		public async virtual Task<AirTransport> Get(int airlineId)
		{
			return await this.GetById(airlineId);
		}

		public async virtual Task<AirTransport> Create(AirTransport item)
		{
			this.Context.Set<AirTransport>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(AirTransport item)
		{
			var entity = this.Context.Set<AirTransport>().Local.FirstOrDefault(x => x.AirlineId == item.AirlineId);
			if (entity == null)
			{
				this.Context.Set<AirTransport>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int airlineId)
		{
			AirTransport record = await this.GetById(airlineId);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<AirTransport>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<AirTransport>> Where(Expression<Func<AirTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<AirTransport> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<AirTransport>> SearchLinqEF(Expression<Func<AirTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(AirTransport.AirlineId)} ASC";
			}
			return await this.Context.Set<AirTransport>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<AirTransport>();
		}

		private async Task<List<AirTransport>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(AirTransport.AirlineId)} ASC";
			}

			return await this.Context.Set<AirTransport>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<AirTransport>();
		}

		private async Task<AirTransport> GetById(int airlineId)
		{
			List<AirTransport> records = await this.SearchLinqEF(x => x.AirlineId == airlineId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>48001994b528b8bfb0c94ae3bdd1eb78</Hash>
</Codenesium>*/