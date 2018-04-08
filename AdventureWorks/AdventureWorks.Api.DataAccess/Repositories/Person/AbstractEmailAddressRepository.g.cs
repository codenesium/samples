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
	public abstract class AbstractEmailAddressRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractEmailAddressRepository(ILogger logger,
		                                      ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(int emailAddressID,
		                          string emailAddress1,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFEmailAddress ();

			MapPOCOToEF(0, emailAddressID,
			            emailAddress1,
			            rowguid,
			            modifiedDate, record);

			this.context.Set<EFEmailAddress>().Add(record);
			this.context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(int businessEntityID, int emailAddressID,
		                           string emailAddress1,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",businessEntityID);
			}
			else
			{
				MapPOCOToEF(businessEntityID,  emailAddressID,
				            emailAddress1,
				            rowguid,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int businessEntityID)
		{
			var record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFEmailAddress>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int businessEntityID, Response response)
		{
			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
		}

		protected virtual List<EFEmailAddress> SearchLinqEF(Expression<Func<EFEmailAddress, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFEmailAddress> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFEmailAddress, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		public virtual List<POCOEmailAddress > GetWhereDirect(Expression<Func<EFEmailAddress, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.EmailAddresses;
		}
		public virtual POCOEmailAddress GetByIdDirect(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
			return response.EmailAddresses.FirstOrDefault();
		}

		private void SearchLinqPOCO(Expression<Func<EFEmailAddress, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFEmailAddress> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFEmailAddress> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int businessEntityID, int emailAddressID,
		                               string emailAddress1,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFEmailAddress   efEmailAddress)
		{
			efEmailAddress.BusinessEntityID = businessEntityID;
			efEmailAddress.EmailAddressID = emailAddressID;
			efEmailAddress.EmailAddress1 = emailAddress1;
			efEmailAddress.Rowguid = rowguid;
			efEmailAddress.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFEmailAddress efEmailAddress,Response response)
		{
			if(efEmailAddress == null)
			{
				return;
			}
			response.AddEmailAddress(new POCOEmailAddress()
			{
				EmailAddressID = efEmailAddress.EmailAddressID.ToInt(),
				EmailAddress1 = efEmailAddress.EmailAddress1,
				Rowguid = efEmailAddress.Rowguid,
				ModifiedDate = efEmailAddress.ModifiedDate.ToDateTime(),

				BusinessEntityID = new ReferenceEntity<int>(efEmailAddress.BusinessEntityID,
				                                            "People"),
			});

			PersonRepository.MapEFToPOCO(efEmailAddress.Person, response);
		}
	}
}

/*<Codenesium>
    <Hash>14668c2d4695a01fcb4f913b5ac88c35</Hash>
</Codenesium>*/