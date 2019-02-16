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

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractAWBuildVersionRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractAWBuildVersionRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<AWBuildVersion>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Database_Version.StartsWith(query) ||
				                  x.ModifiedDate == query.ToDateTime() ||
				                  x.SystemInformationID == query.ToInt() ||
				                  x.VersionDate == query.ToDateTime(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<AWBuildVersion> Get(int systemInformationID)
		{
			return await this.GetById(systemInformationID);
		}

		public async virtual Task<AWBuildVersion> Create(AWBuildVersion item)
		{
			this.Context.Set<AWBuildVersion>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(AWBuildVersion item)
		{
			var entity = this.Context.Set<AWBuildVersion>().Local.FirstOrDefault(x => x.SystemInformationID == item.SystemInformationID);
			if (entity == null)
			{
				this.Context.Set<AWBuildVersion>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int systemInformationID)
		{
			AWBuildVersion record = await this.GetById(systemInformationID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<AWBuildVersion>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<AWBuildVersion>> Where(
			Expression<Func<AWBuildVersion, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<AWBuildVersion, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.SystemInformationID;
			}

			return await this.Context.Set<AWBuildVersion>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<AWBuildVersion>();
		}

		private async Task<AWBuildVersion> GetById(int systemInformationID)
		{
			List<AWBuildVersion> records = await this.Where(x => x.SystemInformationID == systemInformationID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>4891e6c1ae73bc00d6b4b2cf50bc1b27</Hash>
</Codenesium>*/