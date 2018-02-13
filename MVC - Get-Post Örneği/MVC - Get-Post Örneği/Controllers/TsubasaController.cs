using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC___Get_Post_Örneği.Controllers
{
    public class TsubasaController : Controller
    {
        // GET: Tsubasa

        /*
        GET : QueryString olarak datayı gönderir. Bir nedenle tarayıcıya kaydedilebilir ve geçmişte görülebilir.Cache'lenebilir. Güvenli değildir. Url'de gönderildiği için karakter sınırlaması vardır. Yalnızca ASCII karakterler gönderilebilir.


        POST : QueryString olarak gönderilmez. Haliyle Url'de görünmez. Bu nedenle tarayıcıya kaydedilemez, geçmişte görülemez, Cach'lenemez, ama Güvenli. Her türlü data post ile gönderilebilir.

        */
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AraGet(string ifade, string birDigerifade)
        {
            //Arama İşlemleri.....

            //string sonuc=ifade+" kelime GET yöntemi ile arandı. Diğer aranan kelime de : "+birDigerİfade;

            //return View(sonuc);
            object result = ifade + " kelime GET yöntemi ile arandı. Diğer aranan kelime de : " + birDigerifade;

            return View("Sonuc", result);
        }
        public ActionResult AraPost(string aranacakKelime)
        {
            //Arama İşlemleri.....
            object result = aranacakKelime + " kelimesi POST yöntemi ile arandı";
            return View("Sonuc", result);
        }
    }
}