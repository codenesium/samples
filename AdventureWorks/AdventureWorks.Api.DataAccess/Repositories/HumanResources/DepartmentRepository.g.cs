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
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractDepartmentRepository(ILogger logger,
		                                    ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual short Create(string name,
		                            string groupName,
		                            DateTime modifiedDate)
		{
			var record = new EFDepartment ();

			MapPOCOToEF(0, name,
			            groupName,
			            modifiedDate, record);

			this._context.Set<EFDepartment>().Add(record);
			this._context.SaveChanges();
			return record.departmentID;
		}

		public virtual void Update(short departmentID, string name,
		                           string groupName,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.departmentID == departmentID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",departmentID);
			}
			else
			{
				MapPOCOToEF(departmentID,  name,
				            groupName,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(short departmentID)
		{
			var record = this.SearchLinqEF(x => x.departmentID == departmentID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFDepartment>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(short departmentID, Response response)
		{
			this.SearchLinqPOCO(x => x.departmentID == departmentID,response);
		}

		protected virtual List<EFDepartment> SearchLinqEF(Expression<Func<EFDepartment, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFDepartment> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFDepartment, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
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

		public static void MapPOCOToEF(short departmentID, string name,
		                               string groupName,
		                               DateTime modifiedDate, EFDepartment   efDepartment)
		{
			efDepartment.departmentID = departmentID;
			efDepartment.name = name;
			efDepartment.groupName = groupName;
			efDepartment.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFDepartment efDepartment,Response response)
		{
			if(efDepartment == null)
			{
				return;
			}
			response.AddDepartment(new POCODepartment()
			{
				DepartmentID = efDepartment.departmentID,
				Name = efDepartment.name,
				GroupName = efDepartment.groupName,
				ModifiedDate = efDepartment.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>1baac6fd28498feff2875098e9b7d36c</Hash>
</Codenesium>*/