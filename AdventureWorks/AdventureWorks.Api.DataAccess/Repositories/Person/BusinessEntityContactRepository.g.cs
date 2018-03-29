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
	public abstract class AbstractBusinessEntityContactRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractBusinessEntityContactRepository(ILogger logger,
		                                               ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int personID,
		                          int contactTypeID,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFBusinessEntityContact ();

			MapPOCOToEF(0, personID,
			            contactTypeID,
			            rowguid,
			            modifiedDate, record);

			this._context.Set<EFBusinessEntityContact>().Add(record);
			this._context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(int businessEntityID, int personID,
		                           int contactTypeID,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",businessEntityID);
			}
			else
			{
				MapPOCOToEF(businessEntityID,  personID,
				            contactTypeID,
				            rowguid,
				            modifiedDate, record);
				this._context.SaveChanges();
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
				this._context.Set<EFBusinessEntityContact>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int businessEntityID, Response response)
		{
			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
		}

		protected virtual List<EFBusinessEntityContact> SearchLinqEF(Expression<Func<EFBusinessEntityContact, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFBusinessEntityContact> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFBusinessEntityContact, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFBusinessEntityContact, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFBusinessEntityContact> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFBusinessEntityContact> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int businessEntityID, int personID,
		                               int contactTypeID,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFBusinessEntityContact   efBusinessEntityContact)
		{
			efBusinessEntityContact.BusinessEntityID = businessEntityID;
			efBusinessEntityContact.PersonID = personID;
			efBusinessEntityContact.ContactTypeID = contactTypeID;
			efBusinessEntityContact.rowguid = rowguid;
			efBusinessEntityContact.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFBusinessEntityContact efBusinessEntityContact,Response response)
		{
			if(efBusinessEntityContact == null)
			{
				return;
			}
			response.AddBusinessEntityContact(new POCOBusinessEntityContact()
			{
				Rowguid = efBusinessEntityContact.rowguid,
				ModifiedDate = efBusinessEntityContact.ModifiedDate.ToDateTime(),

				BusinessEntityID = new ReferenceEntity<int>(efBusinessEntityContact.BusinessEntityID,
				                                            "BusinessEntities"),
				PersonID = new ReferenceEntity<int>(efBusinessEntityContact.PersonID,
				                                    "People"),
				ContactTypeID = new ReferenceEntity<int>(efBusinessEntityContact.ContactTypeID,
				                                         "ContactTypes"),
			});

			BusinessEntityRepository.MapEFToPOCO(efBusinessEntityContact.BusinessEntityRef, response);

			PersonRepository.MapEFToPOCO(efBusinessEntityContact.PersonRef, response);

			ContactTypeRepository.MapEFToPOCO(efBusinessEntityContact.ContactTypeRef, response);
		}
	}
}

/*<Codenesium>
    <Hash>6ae036e6652af6355918efe3de44d0e5</Hash>
</Codenesium>*/