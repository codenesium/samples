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
		public virtual int BusinessEntityID { get; private set; }

		[MaxLength(50)]
		[Column("City")]
		public virtual string City { get; private set; }

		[MaxLength(50)]
		[Column("CountryRegion")]
		public virtual string CountryRegion { get; private set; }

		[MaxLength(128)]
		[Column("EMailAddress")]
		public virtual string EMailAddress { get; private set; }

		[Column("EMailSpecialInstructions")]
		public virtual string EMailSpecialInstruction { get; private set; }

		[MaxLength(50)]
		[Column("EMailTelephoneNumber")]
		public virtual string EMailTelephoneNumber { get; private set; }

		[MaxLength(50)]
		[Column("FirstName")]
		public virtual string FirstName { get; private set; }

		[Column("HomeAddressSpecialInstructions")]
		public virtual string HomeAddressSpecialInstruction { get; private set; }

		[MaxLength(50)]
		[Column("LastName")]
		public virtual string LastName { get; private set; }

		[MaxLength(50)]
		[Column("MiddleName")]
		public virtual string MiddleName { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("PostalCode")]
		public virtual string PostalCode { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }

		[MaxLength(50)]
		[Column("StateProvince")]
		public virtual string StateProvince { get; private set; }

		[MaxLength(50)]
		[Column("Street")]
		public virtual string Street { get; private set; }

		[MaxLength(50)]
		[Column("TelephoneNumber")]
		public virtual string TelephoneNumber { get; private set; }

		[Column("TelephoneSpecialInstructions")]
		public virtual string TelephoneSpecialInstruction { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c6ab2f48b5b493cd3f85048e7b8206db</Hash>
</Codenesium>*/