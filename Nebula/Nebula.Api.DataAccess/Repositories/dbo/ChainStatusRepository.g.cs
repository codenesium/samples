using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractChainStatusRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractChainStatusRepository(ILogger logger,
		                                     ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string name)
		{
			var record = new ChainStatus ();

			MapPOCOToEF(0, name, record);

			this._context.Set<ChainStatus>().Add(record);
			this._context.SaveChanges();
			return record.id;
		}

		public virtual void Update(int id, string name)
		{
			var record =  this.SearchLinqEF(x => x.id == id).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(id,  name, record);
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

		protected virtual List<ChainStatus> SearchLinqEF(Expression<Func<ChainStatus, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<ChainStatus> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
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

		public static void MapPOCOToEF(int id, string name, ChainStatus   efChainStatus)
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
			});
		}
	}
}

/*<Codenesium>
    <Hash>49b918e34d30e172c0626029b413dbab</Hash>
</Codenesium>*/