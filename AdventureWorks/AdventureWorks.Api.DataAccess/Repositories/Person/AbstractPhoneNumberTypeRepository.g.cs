using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractPhoneNumberTypeRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPhoneNumberTypeRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOPhoneNumberType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOPhoneNumberType> Get(int phoneNumberTypeID)
		{
			PhoneNumberType record = await this.GetById(phoneNumberTypeID);

			return this.Mapper.PhoneNumberTypeMapEFToPOCO(record);
		}

		public async virtual Task<POCOPhoneNumberType> Create(
			ApiPhoneNumberTypeModel model)
		{
			PhoneNumberType record = new PhoneNumberType();

			this.Mapper.PhoneNumberTypeMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<PhoneNumberType>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.PhoneNumberTypeMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int phoneNumberTypeID,
			ApiPhoneNumberTypeModel model)
		{
			PhoneNumberType record = await this.GetById(phoneNumberTypeID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{phoneNumberTypeID}");
			}
			else
			{
				this.Mapper.PhoneNumberTypeMapModelToEF(
					phoneNumberTypeID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int phoneNumberTypeID)
		{
			PhoneNumberType record = await this.GetById(phoneNumberTypeID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PhoneNumberType>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOPhoneNumberType>> Where(Expression<Func<PhoneNumberType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPhoneNumberType> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOPhoneNumberType>> SearchLinqPOCO(Expression<Func<PhoneNumberType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPhoneNumberType> response = new List<POCOPhoneNumberType>();
			List<PhoneNumberType> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.PhoneNumberTypeMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<PhoneNumberType>> SearchLinqEF(Expression<Func<PhoneNumberType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PhoneNumberType.PhoneNumberTypeID)} ASC";
			}
			return await this.Context.Set<PhoneNumberType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PhoneNumberType>();
		}

		private async Task<List<PhoneNumberType>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PhoneNumberType.PhoneNumberTypeID)} ASC";
			}

			return await this.Context.Set<PhoneNumberType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PhoneNumberType>();
		}

		private async Task<PhoneNumberType> GetById(int phoneNumberTypeID)
		{
			List<PhoneNumberType> records = await this.SearchLinqEF(x => x.PhoneNumberTypeID == phoneNumberTypeID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>8c78b6a73837e9648823ab365abcc381</Hash>
</Codenesium>*/