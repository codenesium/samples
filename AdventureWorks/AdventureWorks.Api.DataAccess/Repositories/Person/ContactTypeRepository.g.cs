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
	public abstract class AbstractContactTypeRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractContactTypeRepository(ILogger logger,
		                                     ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string name,
		                          DateTime modifiedDate)
		{
			var record = new EFContactType ();

			MapPOCOToEF(0, name,
			            modifiedDate, record);

			this._context.Set<EFContactType>().Add(record);
			this._context.SaveChanges();
			return record.contactTypeID;
		}

		public virtual void Update(int contactTypeID, string name,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.contactTypeID == contactTypeID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",contactTypeID);
			}
			else
			{
				MapPOCOToEF(contactTypeID,  name,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int contactTypeID)
		{
			var record = this.SearchLinqEF(x => x.contactTypeID == contactTypeID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFContactType>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int contactTypeID, Response response)
		{
			this.SearchLinqPOCO(x => x.contactTypeID == contactTypeID,response);
		}

		protected virtual List<EFContactType> SearchLinqEF(Expression<Func<EFContactType, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFContactType> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFContactType, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFContactType, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFContactType> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFContactType> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int contactTypeID, string name,
		                               DateTime modifiedDate, EFContactType   efContactType)
		{
			efContactType.contactTypeID = contactTypeID;
			efContactType.name = name;
			efContactType.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFContactType efContactType,Response response)
		{
			if(efContactType == null)
			{
				return;
			}
			response.AddContactType(new POCOContactType()
			{
				ContactTypeID = efContactType.contactTypeID.ToInt(),
				Name = efContactType.name,
				ModifiedDate = efContactType.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>0383bb14a4ffc10c6699263d1a4e40d8</Hash>
</Codenesium>*/