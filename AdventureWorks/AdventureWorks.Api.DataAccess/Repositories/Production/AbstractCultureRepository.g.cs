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
	public abstract class AbstractCultureRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractCultureRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Culture>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Culture> Get(string cultureID)
		{
			return await this.GetById(cultureID);
		}

		public async virtual Task<Culture> Create(Culture item)
		{
			this.Context.Set<Culture>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Culture item)
		{
			var entity = this.Context.Set<Culture>().Local.FirstOrDefault(x => x.CultureID == item.CultureID);
			if (entity == null)
			{
				this.Context.Set<Culture>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			string cultureID)
		{
			Culture record = await this.GetById(cultureID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Culture>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// unique constraint AK_Culture_Name.
		public async virtual Task<Culture> ByName(string name)
		{
			return await this.Context.Set<Culture>().FirstOrDefaultAsync(x => x.Name == name);
		}

		protected async Task<List<Culture>> Where(
			Expression<Func<Culture, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Culture, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.CultureID;
			}

			return await this.Context.Set<Culture>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Culture>();
		}

		private async Task<Culture> GetById(string cultureID)
		{
			List<Culture> records = await this.Where(x => x.CultureID == cultureID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>1472702b4181f823b4742b6232983ac4</Hash>
</Codenesium>*/