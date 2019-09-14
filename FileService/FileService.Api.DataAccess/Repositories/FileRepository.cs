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
	public class FileRepository : AbstractRepository, IFileRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public FileRepository(
			ILogger<IFileRepository> logger,
			ApplicationDbContext context)
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
				                  (x.BucketIdNavigation == null || x.BucketIdNavigation.Name == null?false : x.BucketIdNavigation.Name.StartsWith(query)) ||
				                  x.DateCreated == query.ToDateTime() ||
				                  (x.Description == null?false : x.Description.StartsWith(query)) ||
				                  x.Expiration == query.ToDateTime() ||
				                  (x.Extension == null?false : x.Extension.StartsWith(query)) ||
				                  x.ExternalId == query.ToGuid() ||
				                  x.FileSizeInByte.ToDecimal() == query.ToDecimal() ||
				                  (x.FileTypeIdNavigation == null || x.FileTypeIdNavigation.Name == null?false : x.FileTypeIdNavigation.Name.StartsWith(query)) ||
				                  (x.Location == null?false : x.Location.StartsWith(query)) ||
				                  (x.PrivateKey == null?false : x.PrivateKey.StartsWith(query)) ||
				                  (x.PublicKey == null?false : x.PublicKey.StartsWith(query)),
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
    <Hash>38c3f4733914eef34a22fdd41525c824</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/