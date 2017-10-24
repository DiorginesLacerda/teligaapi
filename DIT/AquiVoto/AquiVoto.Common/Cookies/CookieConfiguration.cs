using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace AquiVoto.Common
{
    public class CookieConfiguration
    {
        #region .: SINGLETON :.
        private static readonly CookieConfiguration _instance = new CookieConfiguration();
        public static CookieConfiguration Instance
        {
            get
            {
                return _instance;
            }
        }

        public CookieConfiguration()
        {
        }
        #endregion

        public void ClearCookie(string cookieName)
        {
            // Clear authentication cookie
            HttpCookie rFormsCookie = new HttpCookie(cookieName, "");
            rFormsCookie.Expires = DateTime.Now.AddYears(-1);
            HttpContext.Current.Response.Cookies.Add(rFormsCookie);

            // Clear session cookie 
            HttpCookie rSessionCookie = new HttpCookie(cookieName, "");
            rSessionCookie.Expires = DateTime.Now.AddYears(-1);
            HttpContext.Current.Response.Cookies.Add(rSessionCookie);
        }

        public void LogOff()
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                //delete tickets
                FormsAuthentication.SignOut();

                HttpContext.Current.Session.Clear();
                HttpContext.Current.Session.Abandon();

                //clear all cookies.
                CookieConfiguration.Instance.ClearCookie(CookieNavigation.COOKIE_USUARIO);

                // Invalidate the Cache on the Client Side
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                HttpContext.Current.Response.Cache.SetNoStore();
            }
        }

        public void SaveCookie(long id)
        {
            LogOff();

            if (HttpContext.Current.Request.Browser.Cookies)
            {
                bool persistedCookie = true;
                DateTime creationDate = DateTime.Now;
                DateTime expirationDate = DateTime.Now.AddDays(1);

                
                //AUTH COOKIE
                Save_Cookie_With_Ticket(CookieNavigation.TICKET_USUARIO, creationDate, expirationDate
                    , persistedCookie, id.ToString(), CookieNavigation.COOKIE_USUARIO);
               
                //FORMS AUTHENTICATION
                FormsAuthentication.SetAuthCookie(id.ToString(), persistedCookie);
            }
        }

        private void Save_Cookie_With_Ticket(string ticketName, DateTime creationDate, DateTime dateExpiration, bool persistedCookie
                                            , string content, string cookieName)
        {
            //ticket
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, ticketName
                , creationDate, dateExpiration, persistedCookie, content);

            //encrypt cookie
            string cookieEncrypt = FormsAuthentication.Encrypt(ticket);

            HttpCookie cookieDataId = new HttpCookie(cookieName, cookieEncrypt);

            //cookie is accessible by http only.
            cookieDataId.HttpOnly = true;

            //cookie is using SSL (in production only).
            cookieDataId.Secure = true;

#if DEBUG
            cookieDataId.Secure = false;
#endif

            if (persistedCookie)
                cookieDataId.Expires = ticket.Expiration;

            cookieDataId.Path = FormsAuthentication.FormsCookiePath;
            HttpContext.Current.Response.Cookies.Add(cookieDataId);
        }
    }
}
