using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public class AirlineRepository : AbstractRepository, IAirlineRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AirlineRepository(
			ILogger<IAirlineRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Airline>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.Name == null?false : x.Name.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Airline> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Airline> Create(Airline item)
		{
			this.Context.Set<Airline>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Airline item)
		{
			var entity = this.Context.Set<Airline>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Airline>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int id)
		{
			Airline record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Airline>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<Airline>> Where(
			Expression<Func<Airline, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Airline, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Airline>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Airline>();
		}

		private async Task<Airline> GetById(int id)
		{
			List<Airline> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>5d94e5f79f0aa4cebeff6f6dacdd4c27</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/