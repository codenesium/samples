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
	public abstract class AbstractPersonPhoneRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractPersonPhoneRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			string phoneNumber,
			int phoneNumberTypeID,
			DateTime modifiedDate)
		{
			var record = new EFPersonPhone();

			MapPOCOToEF(
				0,
				phoneNumber,
				phoneNumberTypeID,
				modifiedDate,
				record);

			this.context.Set<EFPersonPhone>().Add(record);
			this.context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(
			int businessEntityID,
			string phoneNumber,
			int phoneNumberTypeID,
			DateTime modifiedDate)
		{
			var record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{businessEntityID}");
			}
			else
			{
				MapPOCOToEF(
					businessEntityID,
					phoneNumber,
					phoneNumberTypeID,
					modifiedDate,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int businessEntityID)
		{
			var record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFPersonPhone>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID, response);
			return response;
		}

		public virtual POCOPersonPhone GetByIdDirect(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID, response);
			return response.PersonPhones.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFPersonPhone, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOPersonPhone> GetWhereDirect(Expression<Func<EFPersonPhone, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.PersonPhones;
		}

		private void SearchLinqPOCO(Expression<Func<EFPersonPhone, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFPersonPhone> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFPersonPhone> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFPersonPhone> SearchLinqEF(Expression<Func<EFPersonPhone, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFPersonPhone> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int businessEntityID,
			string phoneNumber,
			int phoneNumberTypeID,
			DateTime modifiedDate,
			EFPersonPhone efPersonPhone)
		{
			efPersonPhone.SetProperties(businessEntityID.ToInt(), phoneNumber, phoneNumberTypeID.ToInt(), modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(
			EFPersonPhone efPersonPhone,
			Response response)
		{
			if (efPersonPhone == null)
			{
				return;
			}

			response.AddPersonPhone(new POCOPersonPhone(efPersonPhone.BusinessEntityID.ToInt(), efPersonPhone.PhoneNumber, efPersonPhone.PhoneNumberTypeID.ToInt(), efPersonPhone.ModifiedDate.ToDateTime()));

			PersonRepository.MapEFToPOCO(efPersonPhone.Person, response);

			PhoneNumberTypeRepository.MapEFToPOCO(efPersonPhone.PhoneNumberType, response);
		}
	}
}

/*<Codenesium>
    <Hash>23bc8d4ba21c9b02937a8243cd2095cc</Hash>
</Codenesium>*/