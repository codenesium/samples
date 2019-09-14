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

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public class FamilyRepository : AbstractRepository, IFamilyRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public FamilyRepository(
			ILogger<IFamilyRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Family>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.Notes == null?false : x.Notes.StartsWith(query)) ||
				                  (x.PrimaryContactEmail == null?false : x.PrimaryContactEmail.StartsWith(query)) ||
				                  (x.PrimaryContactFirstName == null?false : x.PrimaryContactFirstName.StartsWith(query)) ||
				                  (x.PrimaryContactLastName == null?false : x.PrimaryContactLastName.StartsWith(query)) ||
				                  (x.PrimaryContactPhone == null?false : x.PrimaryContactPhone.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Family> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Family> Create(Family item)
		{
			this.Context.Set<Family>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Family item)
		{
			var entity = this.Context.Set<Family>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Family>().Attach(item);
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
			Family record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Family>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table Student via familyId.
		public async virtual Task<List<Student>> StudentsByFamilyId(int familyId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Student>()
			       .Include(x => x.FamilyIdNavigation)
			       .Include(x => x.UserIdNavigation)

			       .Where(x => x.FamilyId == familyId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Student>();
		}

		protected async Task<List<Family>> Where(
			Expression<Func<Family, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Family, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Family>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Family>();
		}

		private async Task<Family> GetById(int id)
		{
			List<Family> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>8cebf81b2162067583d315388192392d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/