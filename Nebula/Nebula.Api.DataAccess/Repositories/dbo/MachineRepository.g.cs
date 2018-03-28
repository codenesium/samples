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
	public abstract class AbstractMachineRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractMachineRepository(ILogger logger,
		                                 ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string name,
		                          Guid machineGuid,
		                          string jwtKey,
		                          string lastIpAddress,
		                          string description)
		{
			var record = new EFMachine ();

			MapPOCOToEF(0, name,
			            machineGuid,
			            jwtKey,
			            lastIpAddress,
			            description, record);

			this._context.Set<EFMachine>().Add(record);
			this._context.SaveChanges();
			return record.id;
		}

		public virtual void Update(int id, string name,
		                           Guid machineGuid,
		                           string jwtKey,
		                           string lastIpAddress,
		                           string description)
		{
			var record =  this.SearchLinqEF(x => x.id == id).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(id,  name,
				            machineGuid,
				            jwtKey,
				            lastIpAddress,
				            description, record);
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
				this._context.Set<EFMachine>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.id == id,response);
		}

		protected virtual List<EFMachine> SearchLinqEF(Expression<Func<EFMachine, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFMachine> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFMachine, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFMachine, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFMachine> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFMachine> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int id, string name,
		                               Guid machineGuid,
		                               string jwtKey,
		                               string lastIpAddress,
		                               string description, EFMachine   efMachine)
		{
			efMachine.id = id;
			efMachine.name = name;
			efMachine.machineGuid = machineGuid;
			efMachine.jwtKey = jwtKey;
			efMachine.lastIpAddress = lastIpAddress;
			efMachine.description = description;
		}

		public static void MapEFToPOCO(EFMachine efMachine,Response response)
		{
			if(efMachine == null)
			{
				return;
			}
			response.AddMachine(new POCOMachine()
			{
				Id = efMachine.id.ToInt(),
				Name = efMachine.name,
				MachineGuid = efMachine.machineGuid,
				JwtKey = efMachine.jwtKey,
				LastIpAddress = efMachine.lastIpAddress,
				Description = efMachine.description,
			});
		}
	}
}

/*<Codenesium>
    <Hash>4d230e2c3dcf2ce04e34cdd2a26d1b1f</Hash>
</Codenesium>*/