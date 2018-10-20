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
	public abstract class AbstractFileTypeRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractFileTypeRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<FileType>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<FileType> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<FileType> Create(FileType item)
		{
			this.Context.Set<FileType>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(FileType item)
		{
			var entity = this.Context.Set<FileType>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<FileType>().Attach(item);
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
			FileType record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<FileType>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<List<File>> FilesByFileTypeId(int fileTypeId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<File>().Where(x => x.FileTypeId == fileTypeId).AsQueryable().Skip(offset).Take(limit).ToListAsync<File>();
		}

		protected async Task<List<FileType>> Where(
			Expression<Func<FileType, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<FileType, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<FileType>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<FileType>();
			}
			else
			{
				return await this.Context.Set<FileType>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<FileType>();
			}
		}

		private async Task<FileType> GetById(int id)
		{
			List<FileType> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>ad706347ad3e706564f8faae20c8c108</Hash>
</Codenesium>*/