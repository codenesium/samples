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
	public abstract class AbstractBusinessEntityRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractBusinessEntityRepository(ILogger logger,
		                                        ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFBusinessEntity ();

			MapPOCOToEF(0, rowguid,
			            modifiedDate, record);

			this._context.Set<EFBusinessEntity>().Add(record);
			this._context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(int businessEntityID, Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",businessEntityID);
			}
			else
			{
				MapPOCOToEF(businessEntityID,  rowguid,
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
				this._context.Set<EFBusinessEntity>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int businessEntityID, Response response)
		{
			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
		}

		protected virtual List<EFBusinessEntity> SearchLinqEF(Expression<Func<EFBusinessEntity, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFBusinessEntity> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFBusinessEntity, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFBusinessEntity, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFBusinessEntity> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFBusinessEntity> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int businessEntityID, Guid rowguid,
		                               DateTime modifiedDate, EFBusinessEntity   efBusinessEntity)
		{
			efBusinessEntity.BusinessEntityID = businessEntityID;
			efBusinessEntity.rowguid = rowguid;
			efBusinessEntity.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFBusinessEntity efBusinessEntity,Response response)
		{
			if(efBusinessEntity == null)
			{
				return;
			}
			response.AddBusinessEntity(new POCOBusinessEntity()
			{
				BusinessEntityID = efBusinessEntity.BusinessEntityID.ToInt(),
				Rowguid = efBusinessEntity.rowguid,
				ModifiedDate = efBusinessEntity.ModifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>f7177bc87580f35caf3487d6fa16d29a</Hash>
</Codenesium>*/