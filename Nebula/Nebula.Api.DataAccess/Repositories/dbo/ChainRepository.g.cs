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
	public abstract class AbstractChainRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractChainRepository(ILogger logger,
		                               ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int chainStatusId,
		                          Guid externalId,
		                          int id,
		                          string name,
		                          int teamId)
		{
			var record = new Chain ();

			MapPOCOToEF(chainStatusId,
			            externalId,
			            id,
			            name,
			            teamId, record);

			this._context.Set<Chain>().Add(record);
			this._context.SaveChanges();
			return record.id;
		}

		public virtual void Update(int chainStatusId,
		                           Guid externalId,
		                           int id,
		                           string name,
		                           int teamId)
		{
			var record =  this.SearchLinqEF(x => x.id == id).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(chainStatusId,
				            externalId,
				            id,
				            name,
				            teamId, record);
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
				this._context.Set<Chain>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.id == id,response);
		}

		protected virtual List<Chain> SearchLinqEF(Expression<Func<Chain, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<Chain> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<Chain, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<Chain, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<Chain> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<Chain> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int chainStatusId,
		                               Guid externalId,
		                               int id,
		                               string name,
		                               int teamId, Chain   efChain)
		{
			efChain.chainStatusId = chainStatusId;
			efChain.externalId = externalId;
			efChain.id = id;
			efChain.name = name;
			efChain.teamId = teamId;
		}

		public static void MapEFToPOCO(Chain efChain,Response response)
		{
			if(efChain == null)
			{
				return;
			}
			response.AddChain(new POCOChain()
			{
				ExternalId = efChain.externalId,
				Id = efChain.id.ToInt(),
				Name = efChain.name,

				ChainStatusId = new ReferenceEntity<int>(efChain.chainStatusId,
				                                         "ChainStatus"),
				TeamId = new ReferenceEntity<int>(efChain.teamId,
				                                  "Teams"),
			});

			ChainStatusRepository.MapEFToPOCO(efChain.ChainStatusRef, response);

			TeamRepository.MapEFToPOCO(efChain.TeamRef, response);
		}
	}
}

/*<Codenesium>
    <Hash>026166284bc133396884c63973d5c846</Hash>
</Codenesium>*/