using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAndGo.Data.Models
{
    public class ShopCart
    {
        
        private readonly AppDBContent appDBContent;

        /* atgavimas/interactive duomenu is/su DB*/
        public ShopCart(AppDBContent appDBContent)
        {
            /* Ta vieta reikalinga tam, kad mes galetumeme dirbti su DB */
            this.appDBContent = appDBContent;
        } 

        public string ShopCartIddddd { get; set; } /* Benzininis/Elektromobilis Krepselio paskirstimui*/

        public List<ShopCartItem> listShopItems { get; set; }/* List of all elements kurie bus 
                                                              * atvaizduojami krepselije */

        /* FUNKCIJA -                   musu puslapije kai naudotoja renka preke, kai naudotojas
                                       * paims 1, o po to nores dar viena, mums reikia is anksto
                                       * zinoti ar ankciau jisai pridedavo kazkokia preke, ar ne
                                       * jeigu taip, tai mes i ta pati Krepseli dedam nauja preke
                                       * jeigu ne, tai mes kuriame nauja Krepseli */

        public static ShopCart GetCart(IServiceProvider services) {
            /* Cia tokiu budu sukurem objekta su - nauja sesija */
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDBContent>();/* atgauname table ir dirbame su DB */
            /* ?? tikriname jeigu ne egzistuoja sesijoje tas Id tai mes kuriame nauja */
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            /* Guid inicializuoja nauja instance CartId */
            /* Id musu krepselio, pradzioje gali ir nebuti */
            /* Priskirimas */
            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartIddddd = shopCartId };
        /* context pajungia servisa AppDbContent */
        /* na ir prie visko priskiriame reiksmes */
        /* ShopCartId  pacio krepselio ID */ 

        }

        /* FUNKCIJA - Leidzianti addinti prekes i musu krepseli */
        public void AddToCart(Car carrrrr)
        {
            /* Sukurimas ir priskirimas naujo objekto -> duom bazei */
                appDBContent.ShopCartItems.Add(new ShopCartItem {

                ShopCartId = ShopCartIddddd, /*public string ShopCartId { get; set; }*/
                car = carrrrr,
                price = carrrrr.Price /* decimal */
            });
            appDBContent.SaveChanges();
        }

        /* FUNKCIJA - Leidzia mums atvaizduoti visus prekes kurie yra krepselije */
        public List<ShopCartItem> getShopItems()
        { /* mes isrenkame tik tuos elementus, kurie turi IDKrepselio = IddddKrepselio nustatyta 
           * musu sesijoje */
            /* include(s => s.car) atgauname visus caro objektus */
            /* ToList() kadangi graziname sarasa */
            return appDBContent.ShopCartItems.Where(c => c.ShopCartId == ShopCartIddddd).Include(s => s.car).ToList();
        }

}
}
