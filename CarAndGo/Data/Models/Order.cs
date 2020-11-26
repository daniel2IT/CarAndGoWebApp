using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarAndGo.Data.Models
{
    public class Order
    {
        [BindNever]/*nereikia , kad niekada nebutu atvaizduotas */
        public int id { get; set; }
        [Display(Name = "Uzrasykite savo varda")] 
        [StringLength(10)] /* Validacija */
        [Required(ErrorMessage = "Vardo ilgis privalo buti ne didesnis negu 10 simboliu...")]
        public string name { get; set; }
        [StringLength(10)] /* Validacija */
        [Required(ErrorMessage = "Pavardes ilgis privalo buti ne didesnis negu 10 simboliu...")]
        public string surname { get; set; }
        [StringLength(10)] /* Validacija */
        [Required(ErrorMessage = "Adreso ilgis privalo buti ne didesnis negu 10 simboliu...")]
        public string adress { get; set; }
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)] /* Validacija */
        [Required(ErrorMessage = "Tel. Numerio ilgis privalo buti ne didesnis negu 20 simboliu...")]
        public string phone { get; set; }
        [DataType(DataType.EmailAddress)]
        [StringLength(15)] /* Validacija */
        [Required(ErrorMessage = "Email ilgis privalo buti ne didesnis negu 15 simboliu...")]
        public string email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)] /* Duotas laukas, nebutu ne tik tai kad paslepta, bet ir nebutu atvaizduota kodo dalyje,
                                 * tai yra grinas sisteminis laukas*/
        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; } /* Aprasymas prekiu kurias isigijam */
    }
}
