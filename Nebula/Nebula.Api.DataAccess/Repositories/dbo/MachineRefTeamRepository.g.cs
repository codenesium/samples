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
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractMachineRefTeamRepository(ILogger logger,
		                                        ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int machineId,
		                          int teamId)
		{
			var record = new EFMachineRefTeam ();

			MapPOCOToEF(0, machineId,
			            teamId, record);

			this._context.Set<EFMachineRefTeam>().Add(record);
			this._context.SaveChanges();
			return record.id;
		}

		public virtual void Update(int id, int machineId,
		                           int teamId)
		{
			var record =  this.SearchLinqEF(x => x.id == id).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(id,  machineId,
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
				this._context.Set<EFMachineRefTeam>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.id == id,response);
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
			efMachineRefTeam.id = id;
			efMachineRefTeam.machineId = machineId;
			efMachineRefTeam.teamId = teamId;
		}

		public static void MapEFToPOCO(EFMachineRefTeam efMachineRefTeam,Response response)
		{
			if(efMachineRefTeam == null)
			{
				return;
			}
			response.AddMachineRefTeam(new POCOMachineRefTeam()
			{
				Id = efMachineRefTeam.id.ToInt(),

				MachineId = new ReferenceEntity<int>(efMachineRefTeam.machineId,
				                                     "Machines"),
				TeamId = new ReferenceEntity<int>(efMachineRefTeam.teamId,
				                                  "Teams"),
			});

			MachineRepository.MapEFToPOCO(efMachineRefTeam.MachineRef, response);

			TeamRepository.MapEFToPOCO(efMachineRefTeam.TeamRef, response);
		}
	}
}

/*<Codenesium>
    <Hash>51ed3036de278db5703ab4b8c4eb41a4</Hash>
</Codenesium>*/