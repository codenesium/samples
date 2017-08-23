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
	public abstract class AbstractTeamRepository
	{
		DbContext _context;
		ILogger _logger;

		public AbstractTeamRepository(ILogger logger,
		                              DbContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int id,
		                          string name,
		                          int organizationId)
		{
			var record = new Team ();

			MapPOCOToEF(id,
			            name,
			            organizationId, record);

			this._context.Set<Team>().Add(record);
			this._context.SaveChanges();
			return record.id;
		}

		public virtual void Update(int id,
		                           string name,
		                           int organizationId)
		{
			var record =  this.SearchLinqEF(x => x.id == id).FirstOrDefault();
			if (record == null)
			{
				this._logger.Error("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(id,
				            name,
				            organizationId, record);
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
				this._context.Set<Team>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.id == id,response);
		}

		private List<Team> SearchLinqEF(Expression<Func<Team, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Team>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Team>();
			}
			else
			{
				return this._context.Set<Team>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Team>();
			}
		}

		private List<Team> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Team>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Team>();
			}
			else
			{
				return this._context.Set<Team>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Team>();
			}
		}

		public virtual void GetWhere(Expression<Func<Team, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<Team, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<Team> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<Team> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int id,
		                               string name,
		                               int organizationId, Team   efTeam)
		{
			efTeam.id = id;
			efTeam.name = name;
			efTeam.organizationId = organizationId;
		}

		public static void MapEFToPOCO(Team efTeam,Response response)
		{
			if(efTeam == null)
			{
				return;
			}
			response.AddTeam(new POCOTeam()
			{
				Id = efTeam.id.ToInt(),
				Name = efTeam.name,

				OrganizationId = new ReferenceEntity<int>(efTeam.organizationId,
				                                          "Organization"),
			}
			                 );

			OrganizationRepository.MapEFToPOCO(efTeam.Organization, response);
		}
	}
}

/*<Codenesium>
    <Hash>be2c1c182c20f33db07a308ebedd8f86</Hash>
</Codenesium>*/