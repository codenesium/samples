using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractCultureRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }

		public AbstractCultureRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Culture>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
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

		public async Task<Culture> GetName(string name)
		{
			var records = await this.SearchLinqEF(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<Culture>> Where(Expression<Func<Culture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<Culture> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<Culture>> SearchLinqEF(Expression<Func<Culture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Culture.CultureID)} ASC";
			}
			return await this.Context.Set<Culture>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Culture>();
		}

		private async Task<List<Culture>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Culture.CultureID)} ASC";
			}

			return await this.Context.Set<Culture>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Culture>();
		}

		private async Task<Culture> GetById(string cultureID)
		{
			List<Culture> records = await this.SearchLinqEF(x => x.CultureID == cultureID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>39850d50bd623fd9db88cee8dd52fab9</Hash>
</Codenesium>*/