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
	public abstract class AbstractClaspRepository
	{
		protected DbContext _context;
		protected ILogger _logger;

		public AbstractClaspRepository(ILogger logger,
		                               DbContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int id,
		                          int nextChainId,
		                          int previousChainId)
		{
			var record = new Clasp ();

			MapPOCOToEF(id,
			            nextChainId,
			            previousChainId, record);

			this._context.Set<Clasp>().Add(record);
			this._context.SaveChanges();
			return record.id;
		}

		public virtual void Update(int id,
		                           int nextChainId,
		                           int previousChainId)
		{
			var record =  this.SearchLinqEF(x => x.id == id).FirstOrDefault();
			if (record == null)
			{
				this._logger.Error("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(id,
				            nextChainId,
				            previousChainId, record);
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
				this._context.Set<Clasp>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.id == id,response);
		}

		protected virtual List<Clasp> SearchLinqEF(Expression<Func<Clasp, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<Clasp> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<Clasp, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<Clasp, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<Clasp> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<Clasp> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int id,
		                               int nextChainId,
		                               int previousChainId, Clasp   efClasp)
		{
			efClasp.id = id;
			efClasp.nextChainId = nextChainId;
			efClasp.previousChainId = previousChainId;
		}

		public static void MapEFToPOCO(Clasp efClasp,Response response)
		{
			if(efClasp == null)
			{
				return;
			}
			response.AddClasp(new POCOClasp()
			{
				Id = efClasp.id.ToInt(),

				NextChainId = new ReferenceEntity<int>(efClasp.nextChainId,
				                                       "Chain"),
				PreviousChainId = new ReferenceEntity<int>(efClasp.previousChainId,
				                                           "Chain"),
			});

			ChainRepository.MapEFToPOCO(efClasp.Chain, response);
			ChainRepository.MapEFToPOCO(efClasp.Chain, response);
		}
	}
}

/*<Codenesium>
    <Hash>51839e845ad221d43514ea61f2c5e994</Hash>
</Codenesium>*/