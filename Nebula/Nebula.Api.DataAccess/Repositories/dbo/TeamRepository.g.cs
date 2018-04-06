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
	public abstract class AbstractTeamRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractTeamRepository(ILogger logger,
		                              ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string name,
		                          int organizationId)
		{
			var record = new EFTeam ();

			MapPOCOToEF(0, name,
			            organizationId, record);

			this._context.Set<EFTeam>().Add(record);
			this._context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(int id, string name,
		                           int organizationId)
		{
			var record =  this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(id,  name,
				            organizationId, record);
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
				this._context.Set<EFTeam>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.Id == id,response);
		}

		protected virtual List<EFTeam> SearchLinqEF(Expression<Func<EFTeam, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFTeam> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFTeam, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFTeam, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFTeam> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFTeam> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int id, string name,
		                               int organizationId, EFTeam   efTeam)
		{
			efTeam.Id = id;
			efTeam.Name = name;
			efTeam.OrganizationId = organizationId;
		}

		public static void MapEFToPOCO(EFTeam efTeam,Response response)
		{
			if(efTeam == null)
			{
				return;
			}
			response.AddTeam(new POCOTeam()
			{
				Id = efTeam.Id.ToInt(),
				Name = efTeam.Name,

				OrganizationId = new ReferenceEntity<int>(efTeam.OrganizationId,
				                                          "Organizations"),
			});

			OrganizationRepository.MapEFToPOCO(efTeam.OrganizationRef, response);
		}
	}
}

/*<Codenesium>
    <Hash>2941b74cde08e329bbd8db0e2d49f1f0</Hash>
</Codenesium>*/