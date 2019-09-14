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

namespace TestsNS.Api.DataAccess
{
	public class SelfReferenceRepository : AbstractRepository, ISelfReferenceRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public SelfReferenceRepository(
			ILogger<ISelfReferenceRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<SelfReference>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.SelfReferenceIdNavigation == null || x.SelfReferenceIdNavigation.Id == null?false : x.SelfReferenceIdNavigation.Id == query.ToInt()) ||
				                  (x.SelfReferenceId2Navigation == null || x.SelfReferenceId2Navigation.Id == null?false : x.SelfReferenceId2Navigation.Id == query.ToInt()),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<SelfReference> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<SelfReference> Create(SelfReference item)
		{
			this.Context.Set<SelfReference>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(SelfReference item)
		{
			var entity = this.Context.Set<SelfReference>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<SelfReference>().Attach(item);
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
			SelfReference record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SelfReference>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table SelfReference via selfReferenceId.
		public async virtual Task<List<SelfReference>> SelfReferencesBySelfReferenceId(int selfReferenceId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<SelfReference>()
			       .Include(x => x.SelfReferenceIdNavigation)
			       .Include(x => x.SelfReferenceId2Navigation)

			       .Where(x => x.SelfReferenceId == selfReferenceId).AsQueryable().Skip(offset).Take(limit).ToListAsync<SelfReference>();
		}

		// Foreign key reference to this table SelfReference via selfReferenceId2.
		public async virtual Task<List<SelfReference>> SelfReferencesBySelfReferenceId2(int selfReferenceId2, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<SelfReference>()
			       .Include(x => x.SelfReferenceIdNavigation)
			       .Include(x => x.SelfReferenceId2Navigation)

			       .Where(x => x.SelfReferenceId2 == selfReferenceId2).AsQueryable().Skip(offset).Take(limit).ToListAsync<SelfReference>();
		}

		// Foreign key reference to table SelfReference via selfReferenceId.
		public async virtual Task<SelfReference> SelfReferenceBySelfReferenceId(int? selfReferenceId)
		{
			return await this.Context.Set<SelfReference>()
			       .SingleOrDefaultAsync(x => x.Id == selfReferenceId);
		}

		// Foreign key reference to table SelfReference via selfReferenceId2.
		public async virtual Task<SelfReference> SelfReferenceBySelfReferenceId2(int? selfReferenceId2)
		{
			return await this.Context.Set<SelfReference>()
			       .SingleOrDefaultAsync(x => x.Id == selfReferenceId2);
		}

		protected async Task<List<SelfReference>> Where(
			Expression<Func<SelfReference, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<SelfReference, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<SelfReference>()
			       .Include(x => x.SelfReferenceIdNavigation)
			       .Include(x => x.SelfReferenceId2Navigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SelfReference>();
		}

		private async Task<SelfReference> GetById(int id)
		{
			List<SelfReference> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>38c8eab056a390bf03aace6e1ee6bf56</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/