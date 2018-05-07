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

		public virtual int Create(
			PhoneNumberTypeModel model)
		{
			EFPhoneNumberType record = new EFPhoneNumberType();

			this.Mapper.PhoneNumberTypeMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFPhoneNumberType>().Add(record);
			this.Context.SaveChanges();
			return record.PhoneNumberTypeID;
		}

		public virtual void Update(
			int phoneNumberTypeID,
			PhoneNumberTypeModel model)
		{
			EFPhoneNumberType record = this.SearchLinqEF(x => x.PhoneNumberTypeID == phoneNumberTypeID).FirstOrDefault();
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
			EFPhoneNumberType record = this.SearchLinqEF(x => x.PhoneNumberTypeID == phoneNumberTypeID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFPhoneNumberType>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual POCOPhoneNumberType Get(int phoneNumberTypeID)
		{
			return this.SearchLinqPOCO(x => x.PhoneNumberTypeID == phoneNumberTypeID).FirstOrDefault();
		}

		public virtual List<POCOPhoneNumberType> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		private List<POCOPhoneNumberType> Where(Expression<Func<EFPhoneNumberType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOPhoneNumberType> SearchLinqPOCO(Expression<Func<EFPhoneNumberType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPhoneNumberType> response = new List<POCOPhoneNumberType>();
			List<EFPhoneNumberType> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.PhoneNumberTypeMapEFToPOCO(x)));
			return response;
		}

		private List<EFPhoneNumberType> SearchLinqEF(Expression<Func<EFPhoneNumberType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFPhoneNumberType>().Where(predicate).AsQueryable().OrderBy("PhoneNumberTypeID ASC").Skip(skip).Take(take).ToList<EFPhoneNumberType>();
			}
			else
			{
				return this.Context.Set<EFPhoneNumberType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPhoneNumberType>();
			}
		}

		private List<EFPhoneNumberType> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFPhoneNumberType>().Where(predicate).AsQueryable().OrderBy("PhoneNumberTypeID ASC").Skip(skip).Take(take).ToList<EFPhoneNumberType>();
			}
			else
			{
				return this.Context.Set<EFPhoneNumberType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPhoneNumberType>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>0b08613bbcaeb66c148f5ebffe92d587</Hash>
</Codenesium>*/