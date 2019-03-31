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
	public abstract class AbstractOfficerRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractOfficerRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Officer>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Badge.StartsWith(query) ||
				                  x.Email.StartsWith(query) ||
				                  x.FirstName.StartsWith(query) ||
				                  x.LastName.StartsWith(query) ||
				                  x.Password.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Officer> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Officer> Create(Officer item)
		{
			this.Context.Set<Officer>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Officer item)
		{
			var entity = this.Context.Set<Officer>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Officer>().Attach(item);
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
			Officer record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Officer>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table Note via officerId.
		public async virtual Task<List<Note>> NotesByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Note>()
			       .Include(x => x.CallIdNavigation)
			       .Include(x => x.OfficerIdNavigation)

			       .Where(x => x.OfficerId == officerId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Note>();
		}

		// Foreign key reference to this table OfficerCapabilities via officerId.
		public async virtual Task<List<OfficerCapabilities>> OfficerCapabilitiesByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<OfficerCapabilities>()
			       .Include(x => x.CapabilityIdNavigation)
			       .Include(x => x.OfficerIdNavigation)

			       .Where(x => x.OfficerId == officerId).AsQueryable().Skip(offset).Take(limit).ToListAsync<OfficerCapabilities>();
		}

		// Foreign key reference to this table UnitOfficer via officerId.
		public async virtual Task<List<UnitOfficer>> UnitOfficersByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<UnitOfficer>()
			       .Include(x => x.OfficerIdNavigation)
			       .Include(x => x.UnitIdNavigation)

			       .Where(x => x.OfficerId == officerId).AsQueryable().Skip(offset).Take(limit).ToListAsync<UnitOfficer>();
		}

		// Foreign key reference to this table VehicleOfficer via officerId.
		public async virtual Task<List<VehicleOfficer>> VehicleOfficersByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<VehicleOfficer>()
			       .Include(x => x.OfficerIdNavigation)
			       .Include(x => x.VehicleIdNavigation)

			       .Where(x => x.OfficerId == officerId).AsQueryable().Skip(offset).Take(limit).ToListAsync<VehicleOfficer>();
		}

		protected async Task<List<Officer>> Where(
			Expression<Func<Officer, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Officer, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Officer>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Officer>();
		}

		private async Task<Officer> GetById(int id)
		{
			List<Officer> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>298dbf71f967628f003aec26e1cfa6c8</Hash>
</Codenesium>*/