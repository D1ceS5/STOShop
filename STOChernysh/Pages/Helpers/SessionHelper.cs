using STOChernysh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace STOChernysh
{
    
    public enum SessionKey
    {
        CART,
        RETURN_URL
    }
    public static class SessionHelper
    {
        public static void Set(HttpSessionState session, SessionKey key, object value)
        {
            session[Enum.GetName(typeof(SessionKey), key)] = value;
        }
        public static Crt GetCart(HttpSessionState session)
        {
            Crt cart = Get<Crt>(session, SessionKey.CART);
            if (cart == null)
            {
                cart = new Crt();
                Set(session, SessionKey.CART, cart);
            }
            return cart;
        }

        public static T Get<T>(HttpSessionState session, SessionKey key)
        {
            object dataValue = session[Enum.GetName(typeof(SessionKey), key)];
            if (dataValue != null && dataValue is T)
            {
                return (T)dataValue;
            }
            else
            {
                return default(T);
            }
        }
    }
}