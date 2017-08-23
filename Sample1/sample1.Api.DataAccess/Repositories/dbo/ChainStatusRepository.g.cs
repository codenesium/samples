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
	public abstract class AbstractChainStatusRepository
	{
		DbContext _context;
		ILogger _logger;

		public AbstractChainStatusRepository(ILogger logger,
		                                     DbContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int id,
		                          string name)
		{
			var record = new ChainStatus ();

			MapPOCOToEF(id,
			            name, record);

			this._context.Set<ChainStatus>().Add(record);
			this._context.SaveChanges();
			return record.id;
		}

		public virtual void Update(int id,
		                           string name)
		{
			var record =  this.SearchLinqEF(x => x.id == id).FirstOrDefault();
			if (record == null)
			{
				this._logger.Error("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(id,
				            name, record);
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
				this._context.Set<ChainStatus>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.id == id,response);
		}

		private List<ChainStatus> SearchLinqEF(Expression<Func<ChainStatus, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<ChainStatus>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<ChainStatus>();
			}
			else
			{
				return this._context.Set<ChainStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ChainStatus>();
			}
		}

		private List<ChainStatus> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<ChainStatus>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<ChainStatus>();
			}
			else
			{
				return this._context.Set<ChainStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ChainStatus>();
			}
		}

		public virtual void GetWhere(Expression<Func<ChainStatus, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<ChainStatus, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<ChainStatus> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<ChainStatus> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int id,
		                               string name, ChainStatus   efChainStatus)
		{
			efChainStatus.id = id;
			efChainStatus.name = name;
		}

		public static void MapEFToPOCO(ChainStatus efChainStatus,Response response)
		{
			if(efChainStatus == null)
			{
				return;
			}
			response.AddChainStatus(new POCOChainStatus()
			{
				Id = efChainStatus.id.ToInt(),
				Name = efChainStatus.name,
			}
			                        );
		}
	}
}

/*<Codenesium>
    <Hash>b91db5c901d4d63fdf2821467fe651c3</Hash>
</Codenesium>*/