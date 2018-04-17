using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MobiusX
{
    public class MobiusClient : WebClient
    {
        private readonly CookieContainer m_container = new CookieContainer();
        private string _uri;

        public MobiusClient(string mobiusIpAddress)
        {
            this._uri = string.Format("http://{0}", mobiusIpAddress);
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest webRequest = base.GetWebRequest(address);
            HttpWebRequest httpWebRequest = webRequest as HttpWebRequest;
            if (httpWebRequest != null)
                httpWebRequest.CookieContainer = this.m_container;
            return webRequest;
        }

        /// <summary>
        /// Logs into the Mobius web server with the specified user credentials
        /// </summary>
        /// <param name="username">the registered username in Mobius server</param>
        /// <param name="password">the registered password in Mobius server</param>
        public void LogIn(string username, string password)
        {
            this.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 6.2; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/32.0.1667.0 Safari/537.36");
            this.UploadValues(this._uri + "/auth/login", new NameValueCollection()
              {
                {
                  "username",
                  HttpUtility.UrlEncode(username)
                },
                {
                  "password",
                  HttpUtility.UrlEncode(password)
                },
                {
                  "came_from",
                  HttpUtility.UrlDecode(this._uri)
                }
              });
        }
    
        public string URI { get { return _uri; } }
    }
}
