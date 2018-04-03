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
	public abstract class AbstractDatabaseLogRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractDatabaseLogRepository(ILogger logger,
		                                     ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(DateTime postTime,
		                          string databaseUser,
		                          string @event,
		                          string schema,
		                          string @object,
		                          string tSQL,
		                          string xmlEvent)
		{
			var record = new EFDatabaseLog ();

			MapPOCOToEF(0, postTime,
			            databaseUser,
			            @event,
			            schema,
			            @object,
			            tSQL,
			            xmlEvent, record);

			this._context.Set<EFDatabaseLog>().Add(record);
			this._context.SaveChanges();
			return record.databaseLogID;
		}

		public virtual void Update(int databaseLogID, DateTime postTime,
		                           string databaseUser,
		                           string @event,
		                           string schema,
		                           string @object,
		                           string tSQL,
		                           string xmlEvent)
		{
			var record =  this.SearchLinqEF(x => x.databaseLogID == databaseLogID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",databaseLogID);
			}
			else
			{
				MapPOCOToEF(databaseLogID,  postTime,
				            databaseUser,
				            @event,
				            schema,
				            @object,
				            tSQL,
				            xmlEvent, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int databaseLogID)
		{
			var record = this.SearchLinqEF(x => x.databaseLogID == databaseLogID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFDatabaseLog>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int databaseLogID, Response response)
		{
			this.SearchLinqPOCO(x => x.databaseLogID == databaseLogID,response);
		}

		protected virtual List<EFDatabaseLog> SearchLinqEF(Expression<Func<EFDatabaseLog, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFDatabaseLog> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFDatabaseLog, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFDatabaseLog, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFDatabaseLog> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFDatabaseLog> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int databaseLogID, DateTime postTime,
		                               string databaseUser,
		                               string @event,
		                               string schema,
		                               string @object,
		                               string tSQL,
		                               string xmlEvent, EFDatabaseLog   efDatabaseLog)
		{
			efDatabaseLog.databaseLogID = databaseLogID;
			efDatabaseLog.postTime = postTime;
			efDatabaseLog.databaseUser = databaseUser;
			efDatabaseLog.@event = @event;
			efDatabaseLog.schema = schema;
			efDatabaseLog.@object = @object;
			efDatabaseLog.tSQL = tSQL;
			efDatabaseLog.xmlEvent = xmlEvent;
		}

		public static void MapEFToPOCO(EFDatabaseLog efDatabaseLog,Response response)
		{
			if(efDatabaseLog == null)
			{
				return;
			}
			response.AddDatabaseLog(new POCODatabaseLog()
			{
				DatabaseLogID = efDatabaseLog.databaseLogID.ToInt(),
				PostTime = efDatabaseLog.postTime.ToDateTime(),
				DatabaseUser = efDatabaseLog.databaseUser,
				@Event = efDatabaseLog.@event,
				Schema = efDatabaseLog.schema,
				@Object = efDatabaseLog.@object,
				TSQL = efDatabaseLog.tSQL,
				XmlEvent = efDatabaseLog.xmlEvent,
			});
		}
	}
}

/*<Codenesium>
    <Hash>862d90d97977b60c834e85276f0142ef</Hash>
</Codenesium>*/