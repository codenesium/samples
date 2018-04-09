using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDepartmentRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractDepartmentRepository(ILogger logger,
		                                    ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual short Create(string name,
		                            string groupName,
		                            DateTime modifiedDate)
		{
			var record = new EFDepartment ();

			MapPOCOToEF(0, name,
			            groupName,
			            modifiedDate, record);

			this.context.Set<EFDepartment>().Add(record);
			this.context.SaveChanges();
			return record.DepartmentID;
		}

		public virtual void Update(short departmentID, string name,
		                           string groupName,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.DepartmentID == departmentID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",departmentID);
			}
			else
			{
				MapPOCOToEF(departmentID,  name,
				            groupName,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(short departmentID)
		{
			var record = this.SearchLinqEF(x => x.DepartmentID == departmentID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFDepartment>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(short departmentID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.DepartmentID == departmentID,response);
			return response;
		}

		public virtual POCODepartment GetByIdDirect(short departmentID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.DepartmentID == departmentID,response);
			return response.Departments.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFDepartment, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
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

		public virtual List<POCODepartment> GetWhereDirect(Expression<Func<EFDepartment, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Departments;
		}

		private void SearchLinqPOCO(Expression<Func<EFDepartment, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFDepartment> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFDepartment> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		protected virtual List<EFDepartment> SearchLinqEF(Expression<Func<EFDepartment, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFDepartment> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(short departmentID, string name,
		                               string groupName,
		                               DateTime modifiedDate, EFDepartment   efDepartment)
		{
			efDepartment.DepartmentID = departmentID;
			efDepartment.Name = name;
			efDepartment.GroupName = groupName;
			efDepartment.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFDepartment efDepartment,Response response)
		{
			if(efDepartment == null)
			{
				return;
			}
			response.AddDepartment(new POCODepartment()
			{
				DepartmentID = efDepartment.DepartmentID,
				Name = efDepartment.Name,
				GroupName = efDepartment.GroupName,
				ModifiedDate = efDepartment.ModifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>22fe7b8c5125cc3f6f14177bf0921fd4</Hash>
</Codenesium>*/