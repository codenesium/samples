using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALEmployeeMapper
	{
		public virtual Employee MapBOToEF(
			BOEmployee bo)
		{
			Employee efEmployee = new Employee ();

			efEmployee.SetProperties(
				bo.FirstName,
				bo.Id,
				bo.IsSalesPerson,
				bo.IsShipper,
				bo.LastName);
			return efEmployee;
		}

		public virtual BOEmployee MapEFToBO(
			Employee ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOEmployee();

			bo.SetProperties(
				ef.Id,
				ef.FirstName,
				ef.IsSalesPerson,
				ef.IsShipper,
				ef.LastName);
			return bo;
		}

		public virtual List<BOEmployee> MapEFToBO(
			List<Employee> records)
		{
			List<BOEmployee> response = new List<BOEmployee>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b5374d0b0780a2c67652faee8e3b90e4</Hash>
</Codenesium>*/