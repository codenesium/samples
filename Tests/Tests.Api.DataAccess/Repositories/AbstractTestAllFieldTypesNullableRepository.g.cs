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

namespace TestsNS.Api.DataAccess
{
	public abstract class AbstractTestAllFieldTypesNullableRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractTestAllFieldTypesNullableRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<TestAllFieldTypesNullable>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.FieldBigInt == query.ToNullableLong() ||
				                  x.FieldBit == query.ToNullableBoolean() ||
				                  x.FieldChar.StartsWith(query) ||
				                  x.FieldDate == query.ToNullableDateTime() ||
				                  x.FieldDateTime == query.ToNullableDateTime() ||
				                  x.FieldDateTime2 == query.ToNullableDateTime() ||
				                  x.FieldDateTimeOffset == query.ToNullableDateTimeOffset() ||
				                  x.FieldDecimal.ToNullableDecimal() == query.ToNullableDecimal() ||
				                  x.FieldFloat == query.ToNullableDouble() ||
				                  x.FieldMoney.ToNullableDecimal() == query.ToNullableDecimal() ||
				                  x.FieldNChar.StartsWith(query) ||
				                  x.FieldNText.StartsWith(query) ||
				                  x.FieldNumeric.ToNullableDecimal() == query.ToNullableDecimal() ||
				                  x.FieldNVarchar.StartsWith(query) ||
				                  x.FieldReal.ToNullableDecimal() == query.ToNullableDecimal() ||
				                  x.FieldSmallDateTime == query.ToNullableDateTime() ||
				                  x.FieldSmallInt == query.ToNullableShort() ||
				                  x.FieldSmallMoney.ToNullableDecimal() == query.ToNullableDecimal() ||
				                  x.FieldText.StartsWith(query) ||
				                  x.FieldTime == query.ToNullableTimespan() ||
				                  x.FieldTinyInt == query.ToNullableInt() ||
				                  x.FieldUniqueIdentifier == query.ToNullableGuid() ||
				                  x.FieldVarchar.StartsWith(query) ||
				                  x.FieldXML.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<TestAllFieldTypesNullable> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<TestAllFieldTypesNullable> Create(TestAllFieldTypesNullable item)
		{
			this.Context.Set<TestAllFieldTypesNullable>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(TestAllFieldTypesNullable item)
		{
			var entity = this.Context.Set<TestAllFieldTypesNullable>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<TestAllFieldTypesNullable>().Attach(item);
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
			TestAllFieldTypesNullable record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<TestAllFieldTypesNullable>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<TestAllFieldTypesNullable>> Where(
			Expression<Func<TestAllFieldTypesNullable, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<TestAllFieldTypesNullable, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<TestAllFieldTypesNullable>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<TestAllFieldTypesNullable>();
		}

		private async Task<TestAllFieldTypesNullable> GetById(int id)
		{
			List<TestAllFieldTypesNullable> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>1ce15359b4aff371da9db517046e8dde</Hash>
</Codenesium>*/