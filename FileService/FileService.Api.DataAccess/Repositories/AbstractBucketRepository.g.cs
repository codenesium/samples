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

namespace FileServiceNS.Api.DataAccess
{
	public abstract class AbstractBucketRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractBucketRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Bucket>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Bucket> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Bucket> Create(Bucket item)
		{
			this.Context.Set<Bucket>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Bucket item)
		{
			var entity = this.Context.Set<Bucket>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Bucket>().Attach(item);
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
			Bucket record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Bucket>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// unique constraint IX_Bucket_externalId.
		public async virtual Task<Bucket> ByExternalId(Guid externalId)
		{
			return await this.Context.Set<Bucket>().FirstOrDefaultAsync(x => x.ExternalId == externalId);
		}

		// unique constraint IX_Bucket_name.
		public async virtual Task<Bucket> ByName(string name)
		{
			return await this.Context.Set<Bucket>().FirstOrDefaultAsync(x => x.Name == name);
		}

		// Foreign key reference to this table File via bucketId.
		public async virtual Task<List<File>> FilesByBucketId(int bucketId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<File>().Where(x => x.BucketId == bucketId).AsQueryable().Skip(offset).Take(limit).ToListAsync<File>();
		}

		protected async Task<List<Bucket>> Where(
			Expression<Func<Bucket, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Bucket, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Bucket>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Bucket>();
		}

		private async Task<Bucket> GetById(int id)
		{
			List<Bucket> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>36ac0b26fbbfb04e2c3fe61209a32d25</Hash>
</Codenesium>*/