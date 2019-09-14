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

namespace CADNS.Api.DataAccess
{
	public class UnitOfficerRepository : AbstractRepository, IUnitOfficerRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public UnitOfficerRepository(
			ILogger<IUnitOfficerRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<UnitOfficer>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.OfficerIdNavigation == null || x.OfficerIdNavigation.LastName == null?false : x.OfficerIdNavigation.LastName.StartsWith(query)) ||
				                  (x.UnitIdNavigation == null || x.UnitIdNavigation.CallSign == null?false : x.UnitIdNavigation.CallSign.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<UnitOfficer> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<UnitOfficer> Create(UnitOfficer item)
		{
			this.Context.Set<UnitOfficer>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(UnitOfficer item)
		{
			var entity = this.Context.Set<UnitOfficer>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<UnitOfficer>().Attach(item);
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
			UnitOfficer record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<UnitOfficer>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to table Officer via officerId.
		public async virtual Task<Officer> OfficerByOfficerId(int officerId)
		{
			return await this.Context.Set<Officer>()
			       .SingleOrDefaultAsync(x => x.Id == officerId);
		}

		// Foreign key reference to table Unit via unitId.
		public async virtual Task<Unit> UnitByUnitId(int unitId)
		{
			return await this.Context.Set<Unit>()
			       .SingleOrDefaultAsync(x => x.Id == unitId);
		}

		protected async Task<List<UnitOfficer>> Where(
			Expression<Func<UnitOfficer, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<UnitOfficer, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<UnitOfficer>()
			       .Include(x => x.OfficerIdNavigation)
			       .Include(x => x.UnitIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<UnitOfficer>();
		}

		private async Task<UnitOfficer> GetById(int id)
		{
			List<UnitOfficer> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>2ac93ff6ccc80bf327d6dc85f51e4e9a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/