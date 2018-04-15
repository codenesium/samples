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
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractPhoneNumberTypeRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			PhoneNumberTypeModel model)
		{
			var record = new EFPhoneNumberType();

			this.mapper.PhoneNumberTypeMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFPhoneNumberType>().Add(record);
			this.context.SaveChanges();
			return record.PhoneNumberTypeID;
		}

		public virtual void Update(
			int phoneNumberTypeID,
			PhoneNumberTypeModel model)
		{
			var record = this.SearchLinqEF(x => x.PhoneNumberTypeID == phoneNumberTypeID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{phoneNumberTypeID}");
			}
			else
			{
				this.mapper.PhoneNumberTypeMapModelToEF(
					phoneNumberTypeID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int phoneNumberTypeID)
		{
			var record = this.SearchLinqEF(x => x.PhoneNumberTypeID == phoneNumberTypeID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFPhoneNumberType>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int phoneNumberTypeID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.PhoneNumberTypeID == phoneNumberTypeID, response);
			return response;
		}

		public virtual POCOPhoneNumberType GetByIdDirect(int phoneNumberTypeID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.PhoneNumberTypeID == phoneNumberTypeID, response);
			return response.PhoneNumberTypes.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFPhoneNumberType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOPhoneNumberType> GetWhereDirect(Expression<Func<EFPhoneNumberType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.PhoneNumberTypes;
		}

		private void SearchLinqPOCO(Expression<Func<EFPhoneNumberType, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFPhoneNumberType> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.PhoneNumberTypeMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFPhoneNumberType> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.PhoneNumberTypeMapEFToPOCO(x, response));
		}

		protected virtual List<EFPhoneNumberType> SearchLinqEF(Expression<Func<EFPhoneNumberType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFPhoneNumberType> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>1c524d3bcfac135d9b396319ee10ae5c</Hash>
</Codenesium>*/