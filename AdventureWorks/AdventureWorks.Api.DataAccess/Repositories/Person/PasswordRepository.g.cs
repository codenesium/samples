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
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractPasswordRepository(ILogger logger,
		                                  ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
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

			this._context.Set<EFPassword>().Add(record);
			this._context.SaveChanges();
			return record.businessEntityID;
		}

		public virtual void Update(int businessEntityID, string passwordHash,
		                           string passwordSalt,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.businessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",businessEntityID);
			}
			else
			{
				MapPOCOToEF(businessEntityID,  passwordHash,
				            passwordSalt,
				            rowguid,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int businessEntityID)
		{
			var record = this.SearchLinqEF(x => x.businessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFPassword>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int businessEntityID, Response response)
		{
			this.SearchLinqPOCO(x => x.businessEntityID == businessEntityID,response);
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
			efPassword.businessEntityID = businessEntityID;
			efPassword.passwordHash = passwordHash;
			efPassword.passwordSalt = passwordSalt;
			efPassword.rowguid = rowguid;
			efPassword.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFPassword efPassword,Response response)
		{
			if(efPassword == null)
			{
				return;
			}
			response.AddPassword(new POCOPassword()
			{
				BusinessEntityID = efPassword.businessEntityID.ToInt(),
				PasswordHash = efPassword.passwordHash,
				PasswordSalt = efPassword.passwordSalt,
				Rowguid = efPassword.rowguid,
				ModifiedDate = efPassword.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>4ab73c75090c5d15f6619439f027036e</Hash>
</Codenesium>*/