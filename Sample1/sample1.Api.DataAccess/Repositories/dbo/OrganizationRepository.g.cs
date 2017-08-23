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
	public abstract class AbstractOrganizationRepository
	{
		DbContext _context;
		ILogger _logger;

		public AbstractOrganizationRepository(ILogger logger,
		                                      DbContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int id,
		                          string name)
		{
			var record = new Organization ();

			MapPOCOToEF(id,
			            name, record);

			this._context.Set<Organization>().Add(record);
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
				this._context.Set<Organization>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.id == id,response);
		}

		private List<Organization> SearchLinqEF(Expression<Func<Organization, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Organization>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Organization>();
			}
			else
			{
				return this._context.Set<Organization>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Organization>();
			}
		}

		private List<Organization> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Organization>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Organization>();
			}
			else
			{
				return this._context.Set<Organization>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Organization>();
			}
		}

		public virtual void GetWhere(Expression<Func<Organization, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<Organization, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<Organization> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<Organization> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int id,
		                               string name, Organization   efOrganization)
		{
			efOrganization.id = id;
			efOrganization.name = name;
		}

		public static void MapEFToPOCO(Organization efOrganization,Response response)
		{
			if(efOrganization == null)
			{
				return;
			}
			response.AddOrganization(new POCOOrganization()
			{
				Id = efOrganization.id.ToInt(),
				Name = efOrganization.name,
			}
			                         );
		}
	}
}

/*<Codenesium>
    <Hash>f70c8808f3276307a7f85ebfa5fde7d0</Hash>
</Codenesium>*/