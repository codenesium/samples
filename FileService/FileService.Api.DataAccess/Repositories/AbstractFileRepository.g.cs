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
	public abstract class AbstractFileRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractFileRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<File>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.BucketId == query.ToNullableInt() ||
				                  x.DateCreated == query.ToDateTime() ||
				                  x.Description.StartsWith(query) ||
				                  x.Expiration == query.ToDateTime() ||
				                  x.Extension.StartsWith(query) ||
				                  x.ExternalId == query.ToGuid() ||
				                  x.FileSizeInByte.ToDecimal() == query.ToDecimal() ||
				                  x.FileTypeId == query.ToInt() ||
				                  x.Id == query.ToInt() ||
				                  x.Location.StartsWith(query) ||
				                  x.PrivateKey.StartsWith(query) ||
				                  x.PublicKey.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<File> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<File> Create(File item)
		{
			this.Context.Set<File>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(File item)
		{
			var entity = this.Context.Set<File>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<File>().Attach(item);
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
			File record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<File>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to table Bucket via bucketId.
		public async virtual Task<Bucket> BucketByBucketId(int? bucketId)
		{
			return await this.Context.Set<Bucket>()
			       .SingleOrDefaultAsync(x => x.Id == bucketId);
		}

		// Foreign key reference to table FileType via fileTypeId.
		public async virtual Task<FileType> FileTypeByFileTypeId(int fileTypeId)
		{
			return await this.Context.Set<FileType>()
			       .SingleOrDefaultAsync(x => x.Id == fileTypeId);
		}

		protected async Task<List<File>> Where(
			Expression<Func<File, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<File, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<File>()
			       .Include(x => x.BucketIdNavigation)
			       .Include(x => x.FileTypeIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<File>();
		}

		private async Task<File> GetById(int id)
		{
			List<File> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>f950437cb6d19829a390353f0c183984</Hash>
</Codenesium>*/