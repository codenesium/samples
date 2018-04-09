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
				this.logger.LogError($"Unable to find id:{businessEntityID}");
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

		public virtual Response GetById(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
			return response;
		}

		public virtual POCOPassword GetByIdDirect(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
			return response.Passwords.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFPassword, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOPassword> GetWhereDirect(Expression<Func<EFPassword, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Passwords;
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

		protected virtual List<EFPassword> SearchLinqEF(Expression<Func<EFPassword, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFPassword> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(int businessEntityID, string passwordHash,
		                               string passwordSalt,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFPassword   efPassword)
		{
			efPassword.SetProperties(businessEntityID.ToInt(),passwordHash,passwordSalt,rowguid,modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(EFPassword efPassword,Response response)
		{
			if(efPassword == null)
			{
				return;
			}
			response.AddPassword(new POCOPassword(efPassword.BusinessEntityID.ToInt(),efPassword.PasswordHash,efPassword.PasswordSalt,efPassword.Rowguid,efPassword.ModifiedDate.ToDateTime()));

			PersonRepository.MapEFToPOCO(efPassword.Person, response);
		}
	}
}

/*<Codenesium>
    <Hash>5f31c2a981202b562bda8092fb46330f</Hash>
</Codenesium>*/