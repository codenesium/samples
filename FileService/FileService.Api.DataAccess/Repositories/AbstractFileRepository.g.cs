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

		public virtual Task<List<File>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
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

		public async virtual Task<Bucket> BucketByBucketId(int? bucketId)
		{
			return await this.Context.Set<Bucket>().SingleOrDefaultAsync(x => x.Id == bucketId);
		}

		public async virtual Task<FileType> FileTypeByFileTypeId(int fileTypeId)
		{
			return await this.Context.Set<FileType>().SingleOrDefaultAsync(x => x.Id == fileTypeId);
		}

		protected async Task<List<File>> Where(
			Expression<Func<File, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<File, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<File>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<File>();
			}
			else
			{
				return await this.Context.Set<File>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<File>();
			}
		}

		private async Task<File> GetById(int id)
		{
			List<File> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>8f6084f359aa7bc59fe1a0f44c36e577</Hash>
</Codenesium>*/