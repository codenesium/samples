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

namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractVersionInfoRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractVersionInfoRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<VersionInfo>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.AppliedOn == query.ToNullableDateTime() ||
				                  x.Description.StartsWith(query) ||
				                  x.Version == query.ToLong(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<VersionInfo> Get(long version)
		{
			return await this.GetById(version);
		}

		public async virtual Task<VersionInfo> Create(VersionInfo item)
		{
			this.Context.Set<VersionInfo>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(VersionInfo item)
		{
			var entity = this.Context.Set<VersionInfo>().Local.FirstOrDefault(x => x.Version == item.Version);
			if (entity == null)
			{
				this.Context.Set<VersionInfo>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			long version)
		{
			VersionInfo record = await this.GetById(version);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<VersionInfo>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<VersionInfo>> Where(
			Expression<Func<VersionInfo, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<VersionInfo, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Version;
			}

			return await this.Context.Set<VersionInfo>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<VersionInfo>();
		}

		private async Task<VersionInfo> GetById(long version)
		{
			List<VersionInfo> records = await this.Where(x => x.Version == version);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>ab8bba0ead7071ccfef8f1a07e7386ee</Hash>
</Codenesium>*/