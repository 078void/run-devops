using System.ComponentModel.DataAnnotations;

namespace Shopping.Client.Models
{
    public class Product
    {
        public string? Id { get; set; }
        
        [Required(ErrorMessage = "商品名稱為必填")]
        [Display(Name = "商品名稱")]
        public string Name { get; set; } = string.Empty; 
        
        [Display(Name = "商品分類")]
        public string? Category { get; set; }
        
        [Display(Name = "商品描述")]
        public string? Description { get; set; }
        
        [Display(Name = "商品圖片")]
        public string? ImageFile { get; set; } 
        
        [Required(ErrorMessage = "商品價格為必填")]
        [Range(0.01, double.MaxValue, ErrorMessage = "價格必須大於 0")]
        [Display(Name = "商品價格")]
        public decimal Price { get; set; }
    }
}
