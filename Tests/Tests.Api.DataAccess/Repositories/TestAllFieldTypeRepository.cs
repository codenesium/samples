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
	public class TestAllFieldTypeRepository : AbstractRepository, ITestAllFieldTypeRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public TestAllFieldTypeRepository(
			ILogger<ITestAllFieldTypeRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<TestAllFieldType>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.FieldBigInt == query.ToLong() ||
				                  x.FieldBit == query.ToBoolean() ||
				                  (x.FieldChar == null?false : x.FieldChar.StartsWith(query)) ||
				                  x.FieldDate == query.ToDateTime() ||
				                  x.FieldDateTime == query.ToDateTime() ||
				                  x.FieldDateTime2 == query.ToDateTime() ||
				                  x.FieldDateTimeOffset == query.ToDateTimeOffset() ||
				                  x.FieldDecimal.ToDecimal() == query.ToDecimal() ||
				                  x.FieldFloat == query.ToDouble() ||
				                  x.FieldMoney.ToDecimal() == query.ToDecimal() ||
				                  (x.FieldNChar == null?false : x.FieldNChar.StartsWith(query)) ||
				                  (x.FieldNText == null?false : x.FieldNText.StartsWith(query)) ||
				                  x.FieldNumeric.ToDecimal() == query.ToDecimal() ||
				                  (x.FieldNVarchar == null?false : x.FieldNVarchar.StartsWith(query)) ||
				                  x.FieldReal.ToDecimal() == query.ToDecimal() ||
				                  x.FieldSmallDateTime == query.ToDateTime() ||
				                  x.FieldSmallInt == query.ToShort() ||
				                  x.FieldSmallMoney.ToDecimal() == query.ToDecimal() ||
				                  (x.FieldText == null?false : x.FieldText.StartsWith(query)) ||
				                  x.FieldTime == query.ToTimespan() ||
				                  x.FieldTinyInt == query.ToInt() ||
				                  x.FieldUniqueIdentifier == query.ToGuid() ||
				                  (x.FieldVarchar == null?false : x.FieldVarchar.StartsWith(query)) ||
				                  (x.FieldXML == null?false : x.FieldXML.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<TestAllFieldType> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<TestAllFieldType> Create(TestAllFieldType item)
		{
			this.Context.Set<TestAllFieldType>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(TestAllFieldType item)
		{
			var entity = this.Context.Set<TestAllFieldType>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<TestAllFieldType>().Attach(item);
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
			TestAllFieldType record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<TestAllFieldType>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<TestAllFieldType>> Where(
			Expression<Func<TestAllFieldType, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<TestAllFieldType, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<TestAllFieldType>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<TestAllFieldType>();
		}

		private async Task<TestAllFieldType> GetById(int id)
		{
			List<TestAllFieldType> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>6aef839749eec5cad0bef952d87a7231</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/