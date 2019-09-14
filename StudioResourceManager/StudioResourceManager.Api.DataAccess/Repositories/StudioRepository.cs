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

namespace StudioResourceManagerNS.Api.DataAccess
{
	public class StudioRepository : AbstractRepository, IStudioRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public StudioRepository(
			ILogger<IStudioRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Studio>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.Address1 == null?false : x.Address1.StartsWith(query)) ||
				                  (x.Address2 == null?false : x.Address2.StartsWith(query)) ||
				                  (x.City == null?false : x.City.StartsWith(query)) ||
				                  (x.Name == null?false : x.Name.StartsWith(query)) ||
				                  (x.Province == null?false : x.Province.StartsWith(query)) ||
				                  (x.Website == null?false : x.Website.StartsWith(query)) ||
				                  (x.Zip == null?false : x.Zip.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Studio> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Studio> Create(Studio item)
		{
			this.Context.Set<Studio>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Studio item)
		{
			var entity = this.Context.Set<Studio>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Studio>().Attach(item);
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
			Studio record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Studio>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<Studio>> Where(
			Expression<Func<Studio, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Studio, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Studio>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Studio>();
		}

		private async Task<Studio> GetById(int id)
		{
			List<Studio> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>97cd7e55181803710fd7388aaa2d7b47</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/