namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }

        [Display(Name = "Loại sản phẩm")]
        public int? Category_ID { get; set; }

        [Display(Name = "Đơn giá")]
        [Column(TypeName = "money")]
        public decimal? UnitCost { get; set; }

        [Display(Name = "Số lượng")]
        public int? Quantity { get; set; }

        [Display(Name = "Ảnh sản phẩm")]
        [StringLength(255)]
        public string Image { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(255)]
        public string Description { get; set; }

        [Display(Name = "Trạng thái")]
        [StringLength(50)]
        public string Status { get; set; }

        public virtual Category Category { get; set; }
    }
}
