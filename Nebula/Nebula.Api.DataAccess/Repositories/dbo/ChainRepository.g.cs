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

		public virtual int Create(string name,
		                          int teamId,
		                          int chainStatusId,
		                          Guid externalId)
		{
			var record = new EFChain ();

			MapPOCOToEF(0, name,
			            teamId,
			            chainStatusId,
			            externalId, record);

			this._context.Set<EFChain>().Add(record);
			this._context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(int id, string name,
		                           int teamId,
		                           int chainStatusId,
		                           Guid externalId)
		{
			var record =  this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(id,  name,
				            teamId,
				            chainStatusId,
				            externalId, record);
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
				this._context.Set<EFChain>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.Id == id,response);
		}

		protected virtual List<EFChain> SearchLinqEF(Expression<Func<EFChain, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFChain> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFChain, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFChain, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFChain> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFChain> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int id, string name,
		                               int teamId,
		                               int chainStatusId,
		                               Guid externalId, EFChain   efChain)
		{
			efChain.Id = id;
			efChain.Name = name;
			efChain.TeamId = teamId;
			efChain.ChainStatusId = chainStatusId;
			efChain.ExternalId = externalId;
		}

		public static void MapEFToPOCO(EFChain efChain,Response response)
		{
			if(efChain == null)
			{
				return;
			}
			response.AddChain(new POCOChain()
			{
				Id = efChain.Id.ToInt(),
				Name = efChain.Name,
				ExternalId = efChain.ExternalId,

				TeamId = new ReferenceEntity<int>(efChain.TeamId,
				                                  "Teams"),
				ChainStatusId = new ReferenceEntity<int>(efChain.ChainStatusId,
				                                         "ChainStatus"),
			});

			TeamRepository.MapEFToPOCO(efChain.TeamRef, response);

			ChainStatusRepository.MapEFToPOCO(efChain.ChainStatusRef, response);
		}
	}
}

/*<Codenesium>
    <Hash>f7313b29b3e70be20e007e4e8a4325cf</Hash>
</Codenesium>*/