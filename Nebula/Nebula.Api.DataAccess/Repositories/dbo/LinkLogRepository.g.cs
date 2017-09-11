using Autofac.Extras.NLog;
using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractLinkLogRepository
	{
		protected DbContext _context;
		protected ILogger _logger;

		public AbstractLinkLogRepository(ILogger logger,
		                                 DbContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(DateTime dateEntered,
		                          int id,
		                          int linkId,
		                          string log)
		{
			var record = new LinkLog ();

			MapPOCOToEF(dateEntered,
			            id,
			            linkId,
			            log, record);

			this._context.Set<LinkLog>().Add(record);
			this._context.SaveChanges();
			return record.id;
		}

		public virtual void Update(DateTime dateEntered,
		                           int id,
		                           int linkId,
		                           string log)
		{
			var record =  this.SearchLinqEF(x => x.id == id).FirstOrDefault();
			if (record == null)
			{
				this._logger.Error("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(dateEntered,
				            id,
				            linkId,
				            log, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int id)
		{
			var record = this.SearchLinqEF(x => x.id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<LinkLog>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.id == id,response);
		}

		protected virtual List<LinkLog> SearchLinqEF(Expression<Func<LinkLog, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<LinkLog> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<LinkLog, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<LinkLog, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<LinkLog> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<LinkLog> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(DateTime dateEntered,
		                               int id,
		                               int linkId,
		                               string log, LinkLog   efLinkLog)
		{
			efLinkLog.dateEntered = dateEntered;
			efLinkLog.id = id;
			efLinkLog.linkId = linkId;
			efLinkLog.log = log;
		}

		public static void MapEFToPOCO(LinkLog efLinkLog,Response response)
		{
			if(efLinkLog == null)
			{
				return;
			}
			response.AddLinkLog(new POCOLinkLog()
			{
				DateEntered = efLinkLog.dateEntered.ToDateTime(),
				Id = efLinkLog.id.ToInt(),
				Log = efLinkLog.log,

				LinkId = new ReferenceEntity<int>(efLinkLog.linkId,
				                                  "Link"),
			});

			LinkRepository.MapEFToPOCO(efLinkLog.LinkRef, response);
		}
	}
}

/*<Codenesium>
    <Hash>a3cd9657a17873035522de6aa997b6d6</Hash>
</Codenesium>*/