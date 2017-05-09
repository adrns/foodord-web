using System.ComponentModel.DataAnnotations;

namespace foodord_web.Models.Forms
{
    public class OrderForm
    {
        [Required(ErrorMessage = "hiányzó név")]
        public string Name { get; set; }
        [Required(ErrorMessage = "hiányzó telefonszám")]
        [RegularExpression(@"(06|\+36)?( |-)?(1|[0-9]{2})( |-)?[0-9]{3}( |-)?[0-9]{4}", ErrorMessage = "helytelen formátumú telefonszám")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "hiányzó irányítószám")]
        [RegularExpression("[1-9][0-9]{3}", ErrorMessage = "helytelen formátumú irányítószám")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "hiányzó megye")]
        public string County { get; set; }
        [Required(ErrorMessage = "hiányzó lakcím")]
        public string Address { get; set; }
    }
}