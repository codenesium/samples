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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractDatabaseLogRepository(ILogger logger,
		                                     ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
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

			this.context.Set<EFDatabaseLog>().Add(record);
			this.context.SaveChanges();
			return record.DatabaseLogID;
		}

		public virtual void Update(int databaseLogID, DateTime postTime,
		                           string databaseUser,
		                           string @event,
		                           string schema,
		                           string @object,
		                           string tSQL,
		                           string xmlEvent)
		{
			var record =  this.SearchLinqEF(x => x.DatabaseLogID == databaseLogID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",databaseLogID);
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
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int databaseLogID)
		{
			var record = this.SearchLinqEF(x => x.DatabaseLogID == databaseLogID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFDatabaseLog>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int databaseLogID, Response response)
		{
			this.SearchLinqPOCO(x => x.DatabaseLogID == databaseLogID,response);
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

		public virtual List<POCODatabaseLog > GetWhereDirect(Expression<Func<EFDatabaseLog, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.DatabaseLogs;
		}
		public virtual POCODatabaseLog GetByIdDirect(int databaseLogID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.DatabaseLogID == databaseLogID,response);
			return response.DatabaseLogs.FirstOrDefault();
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
			efDatabaseLog.DatabaseLogID = databaseLogID;
			efDatabaseLog.PostTime = postTime;
			efDatabaseLog.DatabaseUser = databaseUser;
			efDatabaseLog.@Event = @event;
			efDatabaseLog.Schema = schema;
			efDatabaseLog.@Object = @object;
			efDatabaseLog.TSQL = tSQL;
			efDatabaseLog.XmlEvent = xmlEvent;
		}

		public static void MapEFToPOCO(EFDatabaseLog efDatabaseLog,Response response)
		{
			if(efDatabaseLog == null)
			{
				return;
			}
			response.AddDatabaseLog(new POCODatabaseLog()
			{
				DatabaseLogID = efDatabaseLog.DatabaseLogID.ToInt(),
				PostTime = efDatabaseLog.PostTime.ToDateTime(),
				DatabaseUser = efDatabaseLog.DatabaseUser,
				@Event = efDatabaseLog.@Event,
				Schema = efDatabaseLog.Schema,
				@Object = efDatabaseLog.@Object,
				TSQL = efDatabaseLog.TSQL,
				XmlEvent = efDatabaseLog.XmlEvent,
			});
		}
	}
}

/*<Codenesium>
    <Hash>d06868c8b72d3bbb6612f0302081c7c6</Hash>
</Codenesium>*/