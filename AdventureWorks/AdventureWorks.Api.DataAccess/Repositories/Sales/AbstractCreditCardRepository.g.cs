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
	public abstract class AbstractCreditCardRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractCreditCardRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<CreditCard>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.CardNumber.StartsWith(query) ||
				                  x.CardType.StartsWith(query) ||
				                  x.CreditCardID == query.ToInt() ||
				                  x.ExpMonth == query.ToInt() ||
				                  x.ExpYear == query.ToShort() ||
				                  x.ModifiedDate == query.ToDateTime(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<CreditCard> Get(int creditCardID)
		{
			return await this.GetById(creditCardID);
		}

		public async virtual Task<CreditCard> Create(CreditCard item)
		{
			this.Context.Set<CreditCard>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(CreditCard item)
		{
			var entity = this.Context.Set<CreditCard>().Local.FirstOrDefault(x => x.CreditCardID == item.CreditCardID);
			if (entity == null)
			{
				this.Context.Set<CreditCard>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int creditCardID)
		{
			CreditCard record = await this.GetById(creditCardID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<CreditCard>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// unique constraint AK_CreditCard_CardNumber.
		public async virtual Task<CreditCard> ByCardNumber(string cardNumber)
		{
			return await this.Context.Set<CreditCard>()

			       .FirstOrDefaultAsync(x => x.CardNumber == cardNumber);
		}

		// Foreign key reference to this table SalesOrderHeader via creditCardID.
		public async virtual Task<List<SalesOrderHeader>> SalesOrderHeadersByCreditCardID(int creditCardID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<SalesOrderHeader>()
			       .Include(x => x.CreditCardIDNavigation)
			       .Where(x => x.CreditCardID == creditCardID).AsQueryable().Skip(offset).Take(limit).ToListAsync<SalesOrderHeader>();
		}

		protected async Task<List<CreditCard>> Where(
			Expression<Func<CreditCard, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<CreditCard, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.CreditCardID;
			}

			return await this.Context.Set<CreditCard>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<CreditCard>();
		}

		private async Task<CreditCard> GetById(int creditCardID)
		{
			List<CreditCard> records = await this.Where(x => x.CreditCardID == creditCardID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>b66d490cc8425f415f5a40d3f5b6ffa2</Hash>
</Codenesium>*/