using Autofac.Extras.NLog;
using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using sample1NS.Api.Contracts;

namespace sample1NS.Api.DataAccess
{
	public abstract class AbstractLinkLogRepository
	{
		DbContext _context;
		ILogger _logger;

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

		private List<LinkLog> SearchLinqEF(Expression<Func<LinkLog, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<LinkLog>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<LinkLog>();
			}
			else
			{
				return this._context.Set<LinkLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<LinkLog>();
			}
		}

		private List<LinkLog> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<LinkLog>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<LinkLog>();
			}
			else
			{
				return this._context.Set<LinkLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<LinkLog>();
			}
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
			}
			                    );

			LinkRepository.MapEFToPOCO(efLinkLog.Link, response);
		}
	}
}

/*<Codenesium>
    <Hash>0fc15170b9949d309c01a2752d3ebde2</Hash>
</Codenesium>*/