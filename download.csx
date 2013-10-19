using Newtonsoft.Json;
using System.Net;
using HtmlAgilityPack;

const int MaxPage = 40;
var counter = 1;

var tasks = new List<Task>();

while (counter < MaxPage)
{
    var url = "http://devopsreactions.tumblr.com/page/" + counter;

    var task = Task<IEnumerable<Item>>.Factory.StartNew(() =>
        {
            Console.WriteLine("Downloading " + url);
            var webClient = new WebClient();
            var result = webClient.DownloadString(url);
            var items = new List<Item>();

            try
            {
                Console.WriteLine("Parsing " + url);
                var doc = new HtmlDocument();
                doc.LoadHtml(result);

                var titleNodes = doc.DocumentNode.SelectNodes("//*[@class=\"post_title\"]");
                var imageNodes = doc.DocumentNode.SelectNodes("//*[@class=\"post_title\"]/following::img[1]");
                var titles = titleNodes.Select(t => t.InnerText);
                var images =
                    imageNodes.Select(x => x.Attributes["src"].Value);

                items.AddRange((titles.Zip(images, (s1, s2) => new Item() {Title = s1, Url = s2})));
            }
            catch
            {
            }


            return items;
        });

    tasks.Add(task);
    counter++;
}
Task.WaitAll(tasks.ToArray());

var list = new List<Item>();
foreach (var t in tasks)
{
    list.AddRange(((Task<IEnumerable<Item>>) t).Result);
}
var str = JsonConvert.SerializeObject(list, Formatting.Indented,  new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() });

str = "var devops = " + str + ";";

File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "Content/js", "devops.js"), str);
Console.WriteLine("Done!");

public class Item
{
    public string Title { get; set; }
    public string Url { get; set; }
}