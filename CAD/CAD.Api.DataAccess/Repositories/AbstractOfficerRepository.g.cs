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
				                  x.Id == query.ToInt() ||
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

		// Foreign key reference to this table OfficerCapability via officerId.
		public async virtual Task<List<OfficerCapability>> OfficerCapabilitiesByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<OfficerCapability>()
			       .Include(x => x.CapabilityIdNavigation)
			       .Include(x => x.OfficerIdNavigation)

			       .Where(x => x.OfficerId == officerId).AsQueryable().Skip(offset).Take(limit).ToListAsync<OfficerCapability>();
		}

		// Foreign key reference pass-though. Pass-thru table OfficerCapability. Foreign Table Officer.
		public async virtual Task<List<Officer>> ByCapabilityId(int capabilityId, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.OfficerCapabilities
			              join officers in this.Context.Officers on
			              refTable.OfficerId equals officers.Id
			              where refTable.CapabilityId == capabilityId
			              select officers).Skip(offset).Take(limit).ToListAsync();
		}

		// Foreign key reference pass-though. Pass-thru table OfficerCapability. Foreign Table Officer.
		public async virtual Task<OfficerCapability> CreateOfficerCapability(OfficerCapability item)
		{
			this.Context.Set<OfficerCapability>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		// Foreign key reference pass-though. Pass-thru table OfficerCapability. Foreign Table Officer.
		public async virtual Task DeleteOfficerCapability(OfficerCapability item)
		{
			this.Context.Set<OfficerCapability>().Remove(item);
			await this.Context.SaveChangesAsync();
		}

		// Foreign key reference pass-though. Pass-thru table VehicleOfficer. Foreign Table Officer.
		public async virtual Task<List<Officer>> ByVehicleId(int vehicleId, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.VehicleOfficers
			              join officers in this.Context.Officers on
			              refTable.OfficerId equals officers.Id
			              where refTable.VehicleId == vehicleId
			              select officers).Skip(offset).Take(limit).ToListAsync();
		}

		// Foreign key reference pass-though. Pass-thru table VehicleOfficer. Foreign Table Officer.
		public async virtual Task<VehicleOfficer> CreateVehicleOfficer(VehicleOfficer item)
		{
			this.Context.Set<VehicleOfficer>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		// Foreign key reference pass-though. Pass-thru table VehicleOfficer. Foreign Table Officer.
		public async virtual Task DeleteVehicleOfficer(VehicleOfficer item)
		{
			this.Context.Set<VehicleOfficer>().Remove(item);
			await this.Context.SaveChangesAsync();
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
    <Hash>eb10c7c4a83680d7261d07f345203d07</Hash>
</Codenesium>*/