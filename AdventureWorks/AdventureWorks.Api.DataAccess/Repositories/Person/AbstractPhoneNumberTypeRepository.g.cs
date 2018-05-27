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
		protected IDALPhoneNumberTypeMapper Mapper { get; }

		public AbstractPhoneNumberTypeRepository(
			IDALPhoneNumberTypeMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOPhoneNumberType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOPhoneNumberType> Get(int phoneNumberTypeID)
		{
			PhoneNumberType record = await this.GetById(phoneNumberTypeID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOPhoneNumberType> Create(
			DTOPhoneNumberType dto)
		{
			PhoneNumberType record = new PhoneNumberType();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<PhoneNumberType>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int phoneNumberTypeID,
			DTOPhoneNumberType dto)
		{
			PhoneNumberType record = await this.GetById(phoneNumberTypeID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{phoneNumberTypeID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					phoneNumberTypeID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
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

		protected async Task<List<DTOPhoneNumberType>> Where(Expression<Func<PhoneNumberType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOPhoneNumberType> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOPhoneNumberType>> SearchLinqDTO(Expression<Func<PhoneNumberType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOPhoneNumberType> response = new List<DTOPhoneNumberType>();
			List<PhoneNumberType> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>f698db5946d844fbc2179037a1bc7f3c</Hash>
</Codenesium>*/