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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractChainRepository(ILogger logger,
		                               ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
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

			this.context.Set<EFChain>().Add(record);
			this.context.SaveChanges();
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
				this.logger.LogError("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(id,  name,
				            teamId,
				            chainStatusId,
				            externalId, record);
				this.context.SaveChanges();
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
				this.context.Set<EFChain>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id,response);
			return response;
		}

		public virtual POCOChain GetByIdDirect(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id,response);
			return response.Chains.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFChain, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOChain> GetWhereDirect(Expression<Func<EFChain, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Chains;
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

		protected virtual List<EFChain> SearchLinqEF(Expression<Func<EFChain, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFChain> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
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

			TeamRepository.MapEFToPOCO(efChain.Team, response);

			ChainStatusRepository.MapEFToPOCO(efChain.ChainStatus, response);
		}
	}
}

/*<Codenesium>
    <Hash>c6eecb2368f9df0d3cc2b5f38713228f</Hash>
</Codenesium>*/