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
	public abstract class AbstractClaspRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractClaspRepository(ILogger logger,
		                               ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int previousChainId,
		                          int nextChainId)
		{
			var record = new EFClasp ();

			MapPOCOToEF(0, previousChainId,
			            nextChainId, record);

			this._context.Set<EFClasp>().Add(record);
			this._context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(int id, int previousChainId,
		                           int nextChainId)
		{
			var record =  this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(id,  previousChainId,
				            nextChainId, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int id)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFClasp>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.Id == id,response);
		}

		protected virtual List<EFClasp> SearchLinqEF(Expression<Func<EFClasp, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFClasp> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFClasp, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFClasp, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFClasp> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFClasp> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int id, int previousChainId,
		                               int nextChainId, EFClasp   efClasp)
		{
			efClasp.Id = id;
			efClasp.PreviousChainId = previousChainId;
			efClasp.NextChainId = nextChainId;
		}

		public static void MapEFToPOCO(EFClasp efClasp,Response response)
		{
			if(efClasp == null)
			{
				return;
			}
			response.AddClasp(new POCOClasp()
			{
				Id = efClasp.Id.ToInt(),

				PreviousChainId = new ReferenceEntity<int>(efClasp.PreviousChainId,
				                                           "Chains"),
				NextChainId = new ReferenceEntity<int>(efClasp.NextChainId,
				                                       "Chains"),
			});

			ChainRepository.MapEFToPOCO(efClasp.ChainRef, response);

			ChainRepository.MapEFToPOCO(efClasp.ChainRef1, response);
		}
	}
}

/*<Codenesium>
    <Hash>3875072248e40fcee097c66c5e1700fc</Hash>
</Codenesium>*/