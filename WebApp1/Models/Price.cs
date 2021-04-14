namespace WebApp1.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Script.Serialization;
    using WebApp1.Models.Enums;

    /// <summary>
    /// This is a special class.
    /// Because name of field is not follows EF convention for PK then we need some configuration
    /// </summary>
    public partial class Price
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Column(Order = 0)]
        public long ProductId { get; set; }             // This field is first part of PK, and also a FK
        public decimal Value { get; set; }
        [Key, Column(Order = 1)]
        public DateTime ApplyDate { get; set; }  // Second part of the PK

        public PriceType Type { get; set; }

        [ScriptIgnore]
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
