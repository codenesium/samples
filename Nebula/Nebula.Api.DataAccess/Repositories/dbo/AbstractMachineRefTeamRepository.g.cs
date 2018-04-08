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
	public abstract class AbstractMachineRefTeamRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractMachineRefTeamRepository(ILogger logger,
		                                        ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(int machineId,
		                          int teamId)
		{
			var record = new EFMachineRefTeam ();

			MapPOCOToEF(0, machineId,
			            teamId, record);

			this.context.Set<EFMachineRefTeam>().Add(record);
			this.context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(int id, int machineId,
		                           int teamId)
		{
			var record =  this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(id,  machineId,
				            teamId, record);
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
				this.context.Set<EFMachineRefTeam>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.Id == id,response);
		}

		protected virtual List<EFMachineRefTeam> SearchLinqEF(Expression<Func<EFMachineRefTeam, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFMachineRefTeam> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFMachineRefTeam, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		public virtual List<POCOMachineRefTeam > GetWhereDirect(Expression<Func<EFMachineRefTeam, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.MachineRefTeams;
		}
		public virtual POCOMachineRefTeam GetByIdDirect(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response.MachineRefTeams.FirstOrDefault();
		}

		private void SearchLinqPOCO(Expression<Func<EFMachineRefTeam, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFMachineRefTeam> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFMachineRefTeam> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int id, int machineId,
		                               int teamId, EFMachineRefTeam   efMachineRefTeam)
		{
			efMachineRefTeam.Id = id;
			efMachineRefTeam.MachineId = machineId;
			efMachineRefTeam.TeamId = teamId;
		}

		public static void MapEFToPOCO(EFMachineRefTeam efMachineRefTeam,Response response)
		{
			if(efMachineRefTeam == null)
			{
				return;
			}
			response.AddMachineRefTeam(new POCOMachineRefTeam()
			{
				Id = efMachineRefTeam.Id.ToInt(),

				MachineId = new ReferenceEntity<int>(efMachineRefTeam.MachineId,
				                                     "Machines"),
				TeamId = new ReferenceEntity<int>(efMachineRefTeam.TeamId,
				                                  "Teams"),
			});

			MachineRepository.MapEFToPOCO(efMachineRefTeam.Machine, response);

			TeamRepository.MapEFToPOCO(efMachineRefTeam.Team, response);
		}
	}
}

/*<Codenesium>
    <Hash>9a86089f8e6c13d331dbcae37068f42a</Hash>
</Codenesium>*/