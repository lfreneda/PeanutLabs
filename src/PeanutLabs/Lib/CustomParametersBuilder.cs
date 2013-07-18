using System.Collections.Specialized;
using System.Text;

namespace PeanutLabs.Lib
{
    public class CustomParametersBuilder
    {
        public string Transform(string key, string value)
        {
            return Transform(new NameValueCollection() { { key, value } });
        }

        public string Transform(NameValueCollection nameValueCollection)
        {
            var queryStringBuilder = new StringBuilder();
            var index = 1;
            foreach (string key in nameValueCollection)
            {
                var value = nameValueCollection[key];
                var keyParameter = string.Format("var_key_{0}={1}", index, key);
                var valueParameter = string.Format("var_val_{0}={1}", index, value);
                queryStringBuilder.Append(string.Concat(keyParameter, "&", valueParameter));
                queryStringBuilder.Append("&");
                index++;
            }

            var queryString = queryStringBuilder.ToString();
            return queryString.Remove(queryString.Length - 1, 1);
        }
    }
}