#load "module.csx"
#load "bootstrapper.csx"
#load "pathprovider.csx"
#load "customroutedescriptionprovider.csx"

using System.IO;
using Autofac;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;
using Nancy.Hosting.Self;
using Nancy.Routing;

NancyBootstrapperLocator.Bootstrapper = new Bootstrapper();

var adress = "http://localhost:1337/";

var host = new NancyHost(new Uri(adress));
host.Start();

Console.WriteLine("Nancy is running at " + adress);
Console.WriteLine("Press any key to end");
Console.ReadKey();

host.Stop();