using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("vAdditionalContactInfo", Schema="Person")]
	public partial class VAdditionalContactInfo : AbstractEntity
	{
		public VAdditionalContactInfo()
		{
		}

		public virtual void SetProperties(
			int businessEntityID,
			string city,
			string countryRegion,
			string eMailAddress,
			string eMailSpecialInstruction,
			string eMailTelephoneNumber,
			string firstName,
			string homeAddressSpecialInstruction,
			string lastName,
			string middleName,
			DateTime modifiedDate,
			string postalCode,
			Guid rowguid,
			string stateProvince,
			string street,
			string telephoneNumber,
			string telephoneSpecialInstruction)
		{
			this.BusinessEntityID = businessEntityID;
			this.City = city;
			this.CountryRegion = countryRegion;
			this.EMailAddress = eMailAddress;
			this.EMailSpecialInstruction = eMailSpecialInstruction;
			this.EMailTelephoneNumber = eMailTelephoneNumber;
			this.FirstName = firstName;
			this.HomeAddressSpecialInstruction = homeAddressSpecialInstruction;
			this.LastName = lastName;
			this.MiddleName = middleName;
			this.ModifiedDate = modifiedDate;
			this.PostalCode = postalCode;
			this.Rowguid = rowguid;
			this.StateProvince = stateProvince;
			this.Street = street;
			this.TelephoneNumber = telephoneNumber;
			this.TelephoneSpecialInstruction = telephoneSpecialInstruction;
		}

		[Column("BusinessEntityID")]
		public int BusinessEntityID { get; private set; }

		[MaxLength(50)]
		[Column("City")]
		public string City { get; private set; }

		[MaxLength(50)]
		[Column("CountryRegion")]
		public string CountryRegion { get; private set; }

		[MaxLength(128)]
		[Column("EMailAddress")]
		public string EMailAddress { get; private set; }

		[Column("EMailSpecialInstructions")]
		public string EMailSpecialInstruction { get; private set; }

		[MaxLength(50)]
		[Column("EMailTelephoneNumber")]
		public string EMailTelephoneNumber { get; private set; }

		[MaxLength(50)]
		[Column("FirstName")]
		public string FirstName { get; private set; }

		[Column("HomeAddressSpecialInstructions")]
		public string HomeAddressSpecialInstruction { get; private set; }

		[MaxLength(50)]
		[Column("LastName")]
		public string LastName { get; private set; }

		[MaxLength(50)]
		[Column("MiddleName")]
		public string MiddleName { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("PostalCode")]
		public string PostalCode { get; private set; }

		[Column("rowguid")]
		public Guid Rowguid { get; private set; }

		[MaxLength(50)]
		[Column("StateProvince")]
		public string StateProvince { get; private set; }

		[MaxLength(50)]
		[Column("Street")]
		public string Street { get; private set; }

		[MaxLength(50)]
		[Column("TelephoneNumber")]
		public string TelephoneNumber { get; private set; }

		[Column("TelephoneSpecialInstructions")]
		public string TelephoneSpecialInstruction { get; private set; }
	}
}

/*<Codenesium>
    <Hash>27d47f52608cac6003814b0112a4ddf0</Hash>
</Codenesium>*/