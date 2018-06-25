using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShippingNS.Api.DataAccess
{
        [Table("Employee", Schema="dbo")]
        public partial class Employee : AbstractEntity
        {
                public Employee()
                {
                }

                public virtual void SetProperties(
                        string firstName,
                        int id,
                        bool isSalesPerson,
                        bool isShipper,
                        string lastName)
                {
                        this.FirstName = firstName;
                        this.Id = id;
                        this.IsSalesPerson = isSalesPerson;
                        this.IsShipper = isShipper;
                        this.LastName = lastName;
                }

                [Column("firstName")]
                public string FirstName { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("isSalesPerson")]
                public bool IsSalesPerson { get; private set; }

                [Column("isShipper")]
                public bool IsShipper { get; private set; }

                [Column("lastName")]
                public string LastName { get; private set; }
        }
}

/*<Codenesium>
    <Hash>28cf5f8fc635a71bf40f96f67e542e05</Hash>
</Codenesium>*/