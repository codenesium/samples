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
	public class UnitRepository : AbstractRepository, IUnitRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public UnitRepository(
			ILogger<IUnitRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Unit>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.CallSign == null?false : x.CallSign.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Unit> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Unit> Create(Unit item)
		{
			this.Context.Set<Unit>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Unit item)
		{
			var entity = this.Context.Set<Unit>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Unit>().Attach(item);
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
			Unit record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Unit>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table CallAssignment via unitId.
		public async virtual Task<List<CallAssignment>> CallAssignmentsByUnitId(int unitId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<CallAssignment>()
			       .Include(x => x.CallIdNavigation)
			       .Include(x => x.UnitIdNavigation)

			       .Where(x => x.UnitId == unitId).AsQueryable().Skip(offset).Take(limit).ToListAsync<CallAssignment>();
		}

		// Foreign key reference to this table UnitOfficer via unitId.
		public async virtual Task<List<UnitOfficer>> UnitOfficersByUnitId(int unitId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<UnitOfficer>()
			       .Include(x => x.OfficerIdNavigation)
			       .Include(x => x.UnitIdNavigation)

			       .Where(x => x.UnitId == unitId).AsQueryable().Skip(offset).Take(limit).ToListAsync<UnitOfficer>();
		}

		protected async Task<List<Unit>> Where(
			Expression<Func<Unit, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Unit, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Unit>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Unit>();
		}

		private async Task<Unit> GetById(int id)
		{
			List<Unit> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>24d32b015f8f37e92c7d2428c957a744</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/