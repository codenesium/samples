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
	public abstract class AbstractSpecialOfferRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractSpecialOfferRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<SpecialOffer>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<SpecialOffer> Get(int specialOfferID)
		{
			return await this.GetById(specialOfferID);
		}

		public async virtual Task<SpecialOffer> Create(SpecialOffer item)
		{
			this.Context.Set<SpecialOffer>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(SpecialOffer item)
		{
			var entity = this.Context.Set<SpecialOffer>().Local.FirstOrDefault(x => x.SpecialOfferID == item.SpecialOfferID);
			if (entity == null)
			{
				this.Context.Set<SpecialOffer>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int specialOfferID)
		{
			SpecialOffer record = await this.GetById(specialOfferID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SpecialOffer>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// unique constraint AK_SpecialOffer_rowguid.
		public async virtual Task<SpecialOffer> ByRowguid(Guid rowguid)
		{
			return await this.Context.Set<SpecialOffer>().FirstOrDefaultAsync(x => x.Rowguid == rowguid);
		}

		protected async Task<List<SpecialOffer>> Where(
			Expression<Func<SpecialOffer, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<SpecialOffer, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.SpecialOfferID;
			}

			return await this.Context.Set<SpecialOffer>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SpecialOffer>();
		}

		private async Task<SpecialOffer> GetById(int specialOfferID)
		{
			List<SpecialOffer> records = await this.Where(x => x.SpecialOfferID == specialOfferID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>8c8f304ad10249ef684488e91acffa0b</Hash>
</Codenesium>*/