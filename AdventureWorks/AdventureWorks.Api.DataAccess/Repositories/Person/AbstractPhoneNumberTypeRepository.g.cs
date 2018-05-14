using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractPhoneNumberTypeRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPhoneNumberTypeRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOPhoneNumberType> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOPhoneNumberType Get(int phoneNumberTypeID)
		{
			return this.SearchLinqPOCO(x => x.PhoneNumberTypeID == phoneNumberTypeID).FirstOrDefault();
		}

		public virtual POCOPhoneNumberType Create(
			ApiPhoneNumberTypeModel model)
		{
			PhoneNumberType record = new PhoneNumberType();

			this.Mapper.PhoneNumberTypeMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<PhoneNumberType>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.PhoneNumberTypeMapEFToPOCO(record);
		}

		public virtual void Update(
			int phoneNumberTypeID,
			ApiPhoneNumberTypeModel model)
		{
			PhoneNumberType record = this.SearchLinqEF(x => x.PhoneNumberTypeID == phoneNumberTypeID).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int phoneNumberTypeID)
		{
			PhoneNumberType record = this.SearchLinqEF(x => x.PhoneNumberTypeID == phoneNumberTypeID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PhoneNumberType>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOPhoneNumberType> Where(Expression<Func<PhoneNumberType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOPhoneNumberType> SearchLinqPOCO(Expression<Func<PhoneNumberType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPhoneNumberType> response = new List<POCOPhoneNumberType>();
			List<PhoneNumberType> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.PhoneNumberTypeMapEFToPOCO(x)));
			return response;
		}

		private List<PhoneNumberType> SearchLinqEF(Expression<Func<PhoneNumberType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PhoneNumberType.PhoneNumberTypeID)} ASC";
			}
			return this.Context.Set<PhoneNumberType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<PhoneNumberType>();
		}

		private List<PhoneNumberType> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PhoneNumberType.PhoneNumberTypeID)} ASC";
			}

			return this.Context.Set<PhoneNumberType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<PhoneNumberType>();
		}
	}
}

/*<Codenesium>
    <Hash>c395e500e1c8fb4a2d537162c4fba12d</Hash>
</Codenesium>*/