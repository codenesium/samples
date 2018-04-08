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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractContactTypeRepository(ILogger logger,
		                                     ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(string name,
		                          DateTime modifiedDate)
		{
			var record = new EFContactType ();

			MapPOCOToEF(0, name,
			            modifiedDate, record);

			this.context.Set<EFContactType>().Add(record);
			this.context.SaveChanges();
			return record.ContactTypeID;
		}

		public virtual void Update(int contactTypeID, string name,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.ContactTypeID == contactTypeID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",contactTypeID);
			}
			else
			{
				MapPOCOToEF(contactTypeID,  name,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int contactTypeID)
		{
			var record = this.SearchLinqEF(x => x.ContactTypeID == contactTypeID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFContactType>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int contactTypeID, Response response)
		{
			this.SearchLinqPOCO(x => x.ContactTypeID == contactTypeID,response);
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

		public virtual List<POCOContactType > GetWhereDirect(Expression<Func<EFContactType, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ContactTypes;
		}
		public virtual POCOContactType GetByIdDirect(int contactTypeID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ContactTypeID == contactTypeID,response);
			return response.ContactTypes.FirstOrDefault();
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
			efContactType.ContactTypeID = contactTypeID;
			efContactType.Name = name;
			efContactType.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFContactType efContactType,Response response)
		{
			if(efContactType == null)
			{
				return;
			}
			response.AddContactType(new POCOContactType()
			{
				ContactTypeID = efContactType.ContactTypeID.ToInt(),
				Name = efContactType.Name,
				ModifiedDate = efContactType.ModifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>503047a516b840b078f023ae27a7121b</Hash>
</Codenesium>*/