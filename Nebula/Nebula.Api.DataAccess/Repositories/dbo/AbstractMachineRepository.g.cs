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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractMachineRepository(ILogger logger,
		                                 ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
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

			this.context.Set<EFMachine>().Add(record);
			this.context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(int id, string name,
		                           Guid machineGuid,
		                           string jwtKey,
		                           string lastIpAddress,
		                           string description)
		{
			var record =  this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(id,  name,
				            machineGuid,
				            jwtKey,
				            lastIpAddress,
				            description, record);
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
				this.context.Set<EFMachine>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id,response);
			return response;
		}

		public virtual POCOMachine GetByIdDirect(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id,response);
			return response.Machines.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFMachine, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
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

		public virtual List<POCOMachine> GetWhereDirect(Expression<Func<EFMachine, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Machines;
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

		protected virtual List<EFMachine> SearchLinqEF(Expression<Func<EFMachine, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFMachine> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(int id, string name,
		                               Guid machineGuid,
		                               string jwtKey,
		                               string lastIpAddress,
		                               string description, EFMachine   efMachine)
		{
			efMachine.Id = id;
			efMachine.Name = name;
			efMachine.MachineGuid = machineGuid;
			efMachine.JwtKey = jwtKey;
			efMachine.LastIpAddress = lastIpAddress;
			efMachine.Description = description;
		}

		public static void MapEFToPOCO(EFMachine efMachine,Response response)
		{
			if(efMachine == null)
			{
				return;
			}
			response.AddMachine(new POCOMachine()
			{
				Id = efMachine.Id.ToInt(),
				Name = efMachine.Name,
				MachineGuid = efMachine.MachineGuid,
				JwtKey = efMachine.JwtKey,
				LastIpAddress = efMachine.LastIpAddress,
				Description = efMachine.Description,
			});
		}
	}
}

/*<Codenesium>
    <Hash>ae930b39aea0d85bf5ddc5f23ec609b5</Hash>
</Codenesium>*/