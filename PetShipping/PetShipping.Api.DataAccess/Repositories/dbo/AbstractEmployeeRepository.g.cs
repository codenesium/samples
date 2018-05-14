using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractEmployeeRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractEmployeeRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOEmployee> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOEmployee Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOEmployee Create(
			ApiEmployeeModel model)
		{
			Employee record = new Employee();

			this.Mapper.EmployeeMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Employee>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.EmployeeMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ApiEmployeeModel model)
		{
			Employee record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.EmployeeMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Employee record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Employee>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOEmployee> Where(Expression<Func<Employee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOEmployee> SearchLinqPOCO(Expression<Func<Employee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOEmployee> response = new List<POCOEmployee>();
			List<Employee> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.EmployeeMapEFToPOCO(x)));
			return response;
		}

		private List<Employee> SearchLinqEF(Expression<Func<Employee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Employee.Id)} ASC";
			}
			return this.Context.Set<Employee>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Employee>();
		}

		private List<Employee> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Employee.Id)} ASC";
			}

			return this.Context.Set<Employee>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Employee>();
		}
	}
}

/*<Codenesium>
    <Hash>d0e80f9a24909b18c90e0babb6927903</Hash>
</Codenesium>*/