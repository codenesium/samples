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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractTeamRepository(ILogger logger,
		                              ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(string name,
		                          int organizationId)
		{
			var record = new EFTeam ();

			MapPOCOToEF(0, name,
			            organizationId, record);

			this.context.Set<EFTeam>().Add(record);
			this.context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(int id, string name,
		                           int organizationId)
		{
			var record =  this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(id,  name,
				            organizationId, record);
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
				this.context.Set<EFTeam>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id,response);
			return response;
		}

		public virtual POCOTeam GetByIdDirect(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id,response);
			return response.Teams.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFTeam, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
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

		public virtual List<POCOTeam> GetWhereDirect(Expression<Func<EFTeam, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Teams;
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

		protected virtual List<EFTeam> SearchLinqEF(Expression<Func<EFTeam, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFTeam> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
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

			OrganizationRepository.MapEFToPOCO(efTeam.Organization, response);
		}
	}
}

/*<Codenesium>
    <Hash>4a1b85b614f148f2e1692b65bb28a38d</Hash>
</Codenesium>*/