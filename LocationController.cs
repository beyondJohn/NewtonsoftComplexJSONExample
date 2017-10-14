using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;

namespace MyWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Location")]
    public class LocationController : Controller
    {
        [EnableCors("SiteCorsPolicy")]//Remove this if CORS is not configured, not needed unless using CrossOriginResourceSharing
        [HttpPost]
        public string Post(string lat, string lng)
        {

            var file = System.IO.Path.GetFullPath("../Data/Location/Location.txt");
            string allText = System.IO.File.ReadAllText(file);
            //allText = allText.Replace("\\", "");

            JObject jsonObj = JObject.Parse(allText);

            string myJsonObj = jsonObj["location"].ToString();

            JObject locations = JObject.Parse(myJsonObj);

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            int adder = 1;
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.None;

                writer.WriteStartObject();
                writer.WritePropertyName("location");
                writer.WriteStartObject();
                foreach (var location in locations)
                {
                    var jsonObj1 = JObject.Parse(location.Value.ToString());

                    var checkLat = jsonObj1["lat"].ToString();
                    var checkLng = jsonObj1["lng"].ToString();

                    writer.WritePropertyName(adder.ToString());
                    writer.WriteStartObject();
                    writer.WritePropertyName("lat");
                    writer.WriteValue(checkLat);

                    writer.WritePropertyName("lng");
                    writer.WriteValue(checkLng);
                    writer.WriteEndObject();

                    adder++;

                }
                writer.WritePropertyName(adder.ToString());
                writer.WriteStartObject();
                writer.WritePropertyName("lat");
                writer.WriteValue(lat);

                writer.WritePropertyName("lng");
                writer.WriteValue(lng);
                writer.WriteEnd();
                writer.WriteEndObject();

            }
             System.IO.File.WriteAllText(ile, sw.ToString());

            return allText;
        }
    }
}
