using Autofac.Extras.NLog;
using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractMachineRepository
	{
		protected DbContext _context;
		protected ILogger _logger;

		public AbstractMachineRepository(ILogger logger,
		                                 DbContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string description,
		                          int id,
		                          string jwtKey,
		                          string lastIpAddress,
		                          Guid machineGuid,
		                          string name)
		{
			var record = new Machine ();

			MapPOCOToEF(description,
			            id,
			            jwtKey,
			            lastIpAddress,
			            machineGuid,
			            name, record);

			this._context.Set<Machine>().Add(record);
			this._context.SaveChanges();
			return record.id;
		}

		public virtual void Update(string description,
		                           int id,
		                           string jwtKey,
		                           string lastIpAddress,
		                           Guid machineGuid,
		                           string name)
		{
			var record =  this.SearchLinqEF(x => x.id == id).FirstOrDefault();
			if (record == null)
			{
				this._logger.Error("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(description,
				            id,
				            jwtKey,
				            lastIpAddress,
				            machineGuid,
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
				this._context.Set<Machine>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.id == id,response);
		}

		protected virtual List<Machine> SearchLinqEF(Expression<Func<Machine, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<Machine> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<Machine, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<Machine, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<Machine> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<Machine> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(string description,
		                               int id,
		                               string jwtKey,
		                               string lastIpAddress,
		                               Guid machineGuid,
		                               string name, Machine   efMachine)
		{
			efMachine.description = description;
			efMachine.id = id;
			efMachine.jwtKey = jwtKey;
			efMachine.lastIpAddress = lastIpAddress;
			efMachine.machineGuid = machineGuid;
			efMachine.name = name;
		}

		public static void MapEFToPOCO(Machine efMachine,Response response)
		{
			if(efMachine == null)
			{
				return;
			}
			response.AddMachine(new POCOMachine()
			{
				Description = efMachine.description,
				Id = efMachine.id.ToInt(),
				JwtKey = efMachine.jwtKey,
				LastIpAddress = efMachine.lastIpAddress,
				MachineGuid = efMachine.machineGuid,
				Name = efMachine.name,
			});
		}
	}
}

/*<Codenesium>
    <Hash>724c425c5409af0f862fc3dea33433dc</Hash>
</Codenesium>*/