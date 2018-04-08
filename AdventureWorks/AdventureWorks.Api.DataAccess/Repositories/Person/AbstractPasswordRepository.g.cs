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
	public abstract class AbstractPasswordRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractPasswordRepository(ILogger logger,
		                                  ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(string passwordHash,
		                          string passwordSalt,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFPassword ();

			MapPOCOToEF(0, passwordHash,
			            passwordSalt,
			            rowguid,
			            modifiedDate, record);

			this.context.Set<EFPassword>().Add(record);
			this.context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(int businessEntityID, string passwordHash,
		                           string passwordSalt,
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
				MapPOCOToEF(businessEntityID,  passwordHash,
				            passwordSalt,
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
				this.context.Set<EFPassword>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int businessEntityID, Response response)
		{
			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
		}

		protected virtual List<EFPassword> SearchLinqEF(Expression<Func<EFPassword, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFPassword> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFPassword, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		public virtual List<POCOPassword> GetWhereDirect(Expression<Func<EFPassword, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Passwords;
		}
		public virtual POCOPassword GetByIdDirect(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
			return response.Passwords.FirstOrDefault();
		}

		private void SearchLinqPOCO(Expression<Func<EFPassword, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFPassword> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFPassword> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int businessEntityID, string passwordHash,
		                               string passwordSalt,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFPassword   efPassword)
		{
			efPassword.BusinessEntityID = businessEntityID;
			efPassword.PasswordHash = passwordHash;
			efPassword.PasswordSalt = passwordSalt;
			efPassword.Rowguid = rowguid;
			efPassword.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFPassword efPassword,Response response)
		{
			if(efPassword == null)
			{
				return;
			}
			response.AddPassword(new POCOPassword()
			{
				PasswordHash = efPassword.PasswordHash,
				PasswordSalt = efPassword.PasswordSalt,
				Rowguid = efPassword.Rowguid,
				ModifiedDate = efPassword.ModifiedDate.ToDateTime(),

				BusinessEntityID = new ReferenceEntity<int>(efPassword.BusinessEntityID,
				                                            "People"),
			});

			PersonRepository.MapEFToPOCO(efPassword.Person, response);
		}
	}
}

/*<Codenesium>
    <Hash>7beb6269aeea7e7429609378fa3fab13</Hash>
</Codenesium>*/