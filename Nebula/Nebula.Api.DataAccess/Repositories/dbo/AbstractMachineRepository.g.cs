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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractMachineRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOMachine> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOMachine Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOMachine Create(
			MachineModel model)
		{
			Machine record = new Machine();

			this.Mapper.MachineMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Machine>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.MachineMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			MachineModel model)
		{
			Machine record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.MachineMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Machine record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Machine>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOMachine MachineGuid(Guid machineGuid)
		{
			return this.SearchLinqPOCO(x => x.MachineGuid == machineGuid).FirstOrDefault();
		}

		protected List<POCOMachine> Where(Expression<Func<Machine, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOMachine> SearchLinqPOCO(Expression<Func<Machine, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOMachine> response = new List<POCOMachine>();
			List<Machine> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.MachineMapEFToPOCO(x)));
			return response;
		}

		private List<Machine> SearchLinqEF(Expression<Func<Machine, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Machine.Id)} ASC";
			}
			return this.Context.Set<Machine>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Machine>();
		}

		private List<Machine> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Machine.Id)} ASC";
			}

			return this.Context.Set<Machine>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Machine>();
		}
	}
}

/*<Codenesium>
    <Hash>a7cbbbc13ccf27fec79db7fcaffd6c5d</Hash>
</Codenesium>*/